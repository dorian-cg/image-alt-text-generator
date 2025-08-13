using ImageAltTextService.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging(options => options.AddConsole());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(o => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddControllers();

var modelDeployment = builder.Configuration["AzureOpenAIChatCompletion:DeploymentName"]!;
var modelApiKey = builder.Configuration["AzureOpenAIChatCompletion:ApiKey"]!;
var modelEndpoint = builder.Configuration["AzureOpenAIChatCompletion:Endpoint"]!;

builder.Services.AddAzureOpenAIChatCompletion(
    deploymentName: modelDeployment,    
    apiKey: modelApiKey,
    endpoint: modelEndpoint
);
builder.Services.AddScoped((serviceProvider) => new Kernel(serviceProvider));
builder.Services.AddScoped<IMultiModalChatCompletionService, MultiModalChatCompletionService>();
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
