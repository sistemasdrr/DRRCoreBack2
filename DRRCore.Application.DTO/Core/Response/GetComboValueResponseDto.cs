namespace DRRCore.Application.DTO.Core.Response
{
    public class GetComboValueResponseDto
    {
        public int Id { get; set; }
        public string Valor { get; set; } = string.Empty;
    }
    public class GetComboValueSitResponseDto
    {
        public int Id { get; set; }
        public string Valor { get; set; } = string.Empty;
        public bool? Flag { get; set; }
    }
}
