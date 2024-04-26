namespace DRRCore.Application.DTO.Core.Response
{
    public class GetFinancialSituationResponseDto
    {
        public int Id { get; set; }
        public string Valor { get; set; } = string.Empty;
        public string reportCommentWithBalance { get; set; } = string.Empty;
        public string reportCommentWithoutBalance { get; set; } = string.Empty;
    }
}
