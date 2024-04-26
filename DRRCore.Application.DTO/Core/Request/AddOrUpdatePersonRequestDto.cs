namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonRequestDto
    {
        public int Id { get; set; }

        public string? OldCode { get; set; }

        public string Fullname { get; set; } = null!;

        public string? LastSearched { get; set; }

        public string? Language { get; set; }

        public string? Nationality { get; set; }

        public string? BirthDate { get; set; }

        public string? BirthPlace { get; set; }

        public int? IdDocumentType { get; set; }

        public string? CodeDocumentType { get; set; }

        public string? TaxTypeName { get; set; }

        public string? TaxTypeCode { get; set; }

        public int? IdLegalRegisterSituation { get; set; }

        public string? Address { get; set; }

        public string? Cp { get; set; }

        public string? City { get; set; }

        public string? OtherDirecctions { get; set; }

        public string? TradeName { get; set; }

        public int? IdCountry { get; set; }

        public string? CodePhone { get; set; }

        public string? NumberPhone { get; set; }

        public int? IdCivilStatus { get; set; }

        public string? RelationshipWith { get; set; }

        public int? RelationshipDocumentType { get; set; }

        public string? RelationshipCodeDocument { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public string? Email { get; set; }

        public string? Cellphone { get; set; }

        public string? Profession { get; set; }

        public string? ClubMember { get; set; }

        public string? Insurance { get; set; }

        public string? NewsCommentary { get; set; }

        public bool? PrintNewsCommentary { get; set; }

        public string? PrivateCommentary { get; set; }

        public string? ReputationCommentary { get; set; }

        public int? IdCreditRisk { get; set; }

        public int? IdPaymentPolicy { get; set; }

        public int? IdReputation { get; set; }

        public int? IdPersonSituation { get; set; }
        public string? Quality { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
