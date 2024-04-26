namespace DRRCore.Application.DTO.Core.Response
{
    public class GetComercialLatePaymentResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? CreditorOrSupplier { get; set; }

        public string? DocumentType { get; set; }

        public string? DocumentTypeEng { get; set; }

        public string? Date { get; set; }

        public decimal? AmountNc { get; set; }

        public decimal? AmountFc { get; set; }

        public string? PendingPaymentDate { get; set; }

        public int? DaysLate { get; set; }
    }
}
