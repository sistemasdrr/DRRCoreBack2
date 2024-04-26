namespace DRRCore.Application.DTO.Core.Response
{
    public class GetFileResponseDto
    {
        public byte[] File { get; set; }=new byte[0];
        public string Name { get; set; }= string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
