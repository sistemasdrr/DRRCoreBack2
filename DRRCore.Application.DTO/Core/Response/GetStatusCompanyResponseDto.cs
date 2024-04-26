namespace DRRCore.Application.DTO.Core.Response
{
    public class GetStatusCompanyResponseDto
    {
        public bool Company { get; set; } = false;
        public bool Background { get; set; } = false;
        public bool Branch { get; set; } = false;
        public bool Financial{ get; set; } = false;
        public bool Balance { get; set; } = false;
        public bool Sbs { get; set; } = false;
        public bool Opinion{ get; set; } = false;
        public bool InfoGeneral { get; set; } = false;
        public bool Images { get; set; } = false;
    }
}
