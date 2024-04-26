using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyResponseDto
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

        public string? Quality { get; set; }

        public int? IdLegalPersonType { get; set; }

        public string? TaxTypeName { get; set; }

        public string? TaxTypeCode { get; set; }

        public int? IdLegalRegisterSituation { get; set; }

        public string? Address { get; set; }

        public string? Duration { get; set; }

        public string? Place { get; set; }

        public int? IdCountry { get; set; }
        public int? IdContinent { get; set; }
        public string? TaxTypeByCountry { get; set; }

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
        public bool Enable { get; set; }
        public bool? Print { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
