namespace DRRCore.Application.DTO.Core.Response
{
    public class GetStatusPersonResponseDto
    {
        public bool Person { get; set; } = false;
        public bool Home { get; set; } = false;
        public bool Job { get; set; } = false;
        public bool Activities { get; set; } = false;
        public bool Properties { get; set; } = false;
        public bool Sbs { get; set; } = false;
        public bool History { get; set; } = false;
        public bool InfoGeneral { get; set; } = false;
        public bool Images { get; set; } = false;
    }
}
