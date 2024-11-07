namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListCompanyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public string DispatchedName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string CreditRisk { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int TraductionPercentage { get; set; }
        public string LastReportDate { get; set;} = string.Empty;
        public string Country { get;set; } = string.Empty;
        public string FlagCountry { get; set; } = string.Empty;
        public string IsoCountry { get; set; } = string.Empty;
        public string TaxNumber { get; set;} = string.Empty;
        public string Quality { get; set;} = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public bool? OnWeb { get; set; }
        public bool HaveReport { get; set; } = false;
        public int Indicators { get; set; } = 0;
        public bool DuplicateTax { get; set; } = false;
        public int IdLegalRegisterSituation { get; set; } = 0;
        public string TypeRegister { get; set; } = string.Empty;
        
    }
}
