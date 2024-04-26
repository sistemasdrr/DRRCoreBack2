namespace DRRCore.Application.DTO.Core.Response
{
    public class GetComboValueEngResponseDto
    {
        public int Id { get; set; }
        public string Valor { get; set; } = string.Empty;
        public string ValorEng { get; set; } = string.Empty;

    }
    public class GetComboNameValueResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;

    }
}
