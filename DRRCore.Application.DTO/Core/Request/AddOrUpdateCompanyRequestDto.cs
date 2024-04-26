namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyRequestDto
    {
        public int Id { get; set; }
        public string? OldCode { get; set; }
        public string Name { get; set; } = null!;
        public string? SocialName { get; set; }
        //Datetime
        public string? LastSearched { get; set; }
        public string Language { get; set; } = null!;
        public string? TypeRegister { get; set; }
        public string? YearFundation { get; set; }
        //Datetime
        public string? Quality { get; set; }
        public int? IdLegalPersonType { get; set; }
        public string? TaxTypeName { get; set; }
        public string? TaxTypeCode { get; set; }
        public int? IdLegalRegisterSituation { get; set; }
        public string? Address { get; set; }
        public string? Duration { get; set; }
        public string? Place { get; set; }
        public int? IdCountry { get; set; }
        public string? SubTelephone { get; set; }
        public string? Cellphone { get; set; }
        public string? Telephone { get; set; }
        public string? PostalCode { get; set; }
        public string? WhatsappPhone { get; set; }
        public string? Email { get; set; }
        public string? WebPage { get; set; }
        public int? IdCreditRisk { get; set; }
        public int? IdPaymentPolicy { get; set; }
        public int? IdReputation { get; set; }
        public int? LastUpdaterUser { get; set; }
        public string? ReputationComentary { get; set; }      
        public string? NewsComentary { get; set; }       
        public string? IdentificacionCommentary { get; set; }
        public bool IsRelationed { get; set; }  
        public int CodeRelationed { get; set; }

        public bool? Print { get; set; }

        public List<TraductionDto> Traductions { get; set; }=new List<TraductionDto>();
    }
    public class TraductionDto
    {
        public string Key { get; set; } = string.Empty;
        public string? Value { get; set; }= string.Empty;
    }
}
