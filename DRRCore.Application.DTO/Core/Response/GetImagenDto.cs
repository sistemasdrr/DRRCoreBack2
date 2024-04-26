namespace DRRCore.Application.DTO.Core.Response
{
    public class GetImagentDto
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public MemoryStream File { get; set; } = new MemoryStream();
    }
    public class GetImagentXmlDto
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileAsBase64 { get; set; }
    }
    public class GetFileDto
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public MemoryStream File { get; set; } = new MemoryStream();
    }
}
