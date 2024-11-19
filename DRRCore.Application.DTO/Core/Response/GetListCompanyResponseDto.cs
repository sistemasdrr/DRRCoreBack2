namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListCompanyResponseDto
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public string DispatchedName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
            public string Cellphone { get; set; } = string.Empty;
        public string CreditRisk { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
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
        public int Status { get; set; } = 0;
        public int TaxStatus { get; set; } = 0;
        public int IdLegalRegisterSituation { get; set; } = 0;
        public string TypeRegister { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
    public class GetListCompanyQuery
    {
        public int Id { get; set; }
        public string? Language { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? TaxTypeCode { get; set; } = string.Empty;
        public DateTime? LastSearched { get; set; }
        public string? FlagIso { get; set; } = string.Empty;
        public string? Iso { get; set; } = string.Empty;
        public string? TypeRegister { get; set; } = string.Empty;
        public string? MainExecutive { get; set; } = string.Empty;
        public int? Conteo { get; set; }
        public bool? HaveReport { get; set; }
        public int? IdCountry { get; set; }
        public string? SocialName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Telephone { get; set; } = string.Empty;
        public string? CellPhone { get; set; } = string.Empty;
        public string? Place { get; set; }
        public int? Status { get; set; }
        public int? TaxStatus { get; set; }
        public string? Quality { get; set; } = string.Empty;

    }


}
