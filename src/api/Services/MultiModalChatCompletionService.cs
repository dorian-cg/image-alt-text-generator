using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ImageAltTextService.Services;

public interface IMultiModalChatCompletionService
{
    Task<string> GenerateAltTextForImageAsync(byte[] imageData);
}

public class MultiModalChatCompletionService(ILogger<MultiModalChatCompletionService> logger, Kernel kernel) : IMultiModalChatCompletionService
{
    private IChatCompletionService chatCompletionService => kernel.GetRequiredService<IChatCompletionService>();

    public async Task<string> GenerateAltTextForImageAsync(byte[] imageData)
    {
        try
        {
            logger.LogInformation("Called GenerateAltTextForImage");
            var chatHistory = new ChatHistory("Your job is describing images.");
            chatHistory.AddUserMessage([
                new TextContent("What’s in this image?"),
                new ImageContent(imageData, "image/jpeg"),
            ]);
            var response = await chatCompletionService.GetChatMessageContentAsync(chatHistory);
            return response.Content!;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return string.Empty;
        }
    }
}
