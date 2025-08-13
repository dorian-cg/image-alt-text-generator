namespace ImageAltTextService.Poco;

public class ImageAltTextGenerateResponse
{
    public Dictionary<string, string> ImagesAltTextGenerated { get; set; } = [];
    public string GeneratedDateTime { get; set; } = DateTime.Now.ToString("O");

    public ImageAltTextGenerateResponse()
    {        
    }

    public ImageAltTextGenerateResponse(Dictionary<string, string> imagesAltTextGenerated)
    {
        ImagesAltTextGenerated = imagesAltTextGenerated;
    }
}
