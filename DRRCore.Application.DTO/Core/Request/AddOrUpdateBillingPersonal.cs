namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateBillingPersonal
    {
        public int Id { get; set; }

        public int? IdEmployee { get; set; }

        public string? Code { get; set; }

        public bool? Commission { get; set; }

        public string? ReportType { get; set; }

        public string? Quality { get; set; }

        public bool? IsComplement { get; set; }

        public decimal? Amount { get; set; }
    }
}
