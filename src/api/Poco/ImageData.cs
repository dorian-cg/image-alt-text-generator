namespace ImageAltTextService.Poco;

public class ImageData
{
    public string Filename { get; set; } = string.Empty;
    public byte[] Data { get; set; } = [];

    public ImageData(string filename, byte[] data)
    {
        Filename = filename;
        Data = data;
    }
}
