using ImageAltTextService.Poco;
using ImageAltTextService.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ImageAltTextService.Controllers;

[ApiController]
[Route("api/v1/image-alt-text")]
public class ImageAltTextController(
    ILogger<ImageAltTextController> logger,
    IMultiModalChatCompletionService multiModalChatCompletionService)
    : Controller
{    
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateAsync([FromForm] ImageAltTextGenerateFormRequest form)
    {
        try
        {
            var tasks = form.Images.Select(async image =>
                {
                    using var memoryStream = new MemoryStream();
                    await image.CopyToAsync(memoryStream);
                    return new ImageData(image.FileName, memoryStream.ToArray());
                });

            var imagesData = await Task.WhenAll(tasks);

            var altTextForImagesCollection = new Dictionary<string, string>();

            foreach (var imageData in imagesData)
            {
                logger.LogInformation($"Generating alt text for image {imageData.Filename}");

                var altText = await multiModalChatCompletionService.GenerateAltTextForImageAsync(imageData.Data);

                altTextForImagesCollection.Add(imageData.Filename, altText);
            }

            return new OkObjectResult(new ImageAltTextGenerateResponse(altTextForImagesCollection));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return new StatusCodeResult(500);
        }
    }
}
