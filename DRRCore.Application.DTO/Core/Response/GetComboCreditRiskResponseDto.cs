namespace DRRCore.Application.DTO.Core.Response
{
    public class GetComboCreditRiskResponseDto:GetComboValueResponseDto
    {
        public int Rate { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Identifier { get; set; }= string.Empty;
        public string Abreviation { get; set; } = string.Empty;

    }
}
