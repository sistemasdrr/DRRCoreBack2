namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyCreditOpinionRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public bool? CreditRequest { get; set; }

        public string? ConsultedCredit { get; set; }

        public string? SuggestedCredit { get; set; }

        public string? CurrentCommentary { get; set; }

        public string? PreviousCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
