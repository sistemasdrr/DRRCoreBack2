using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPersonJobResponseDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public int? IdCompany { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TaxTypeName { get; set; }
        public string? TaxTypeCode { get; set; }
        public string? SubTelephone { get; set; }
        public string? Telephone { get; set; }

        public string? CurrentJob { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string? MonthlyIncome { get; set; }

        public string? AnnualIncome { get; set; }

        public string? JobDetails { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
