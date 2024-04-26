namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListPersonResponseDto
    {
        public int Id { get; set; }

        public string? OldCode { get; set; }

        public string Fullname { get; set; } = null!;
        public string DispatchName { get; set; } = null!;

        public string? LastSearched { get; set; }

        public string? Language { get; set; }

        public string? BirthDate { get; set; }

        public string? DocumentType { get; set; }

        public string? CodeDocumentType { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }
        public string? IsoCountry { get; set; }
        public string? Code { get; set; }

        public string? FlagCountry { get; set; }

        public string? Email { get; set; }

        public string? Cellphone { get; set; }

        public string? Profession { get; set; }

        public int TraductionPercentage { get; set; }

        public string? CreditRisk { get; set; }

        public bool? OnWeb { get; set; }

        public bool? Enable { get; set; }

        public string? Quality { get; set; }
    }
}
