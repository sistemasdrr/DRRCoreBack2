namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonJobRequestDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public int? IdCompany { get; set; }

        public string? CurrentJob { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string? MonthlyIncome { get; set; }

        public string? AnnualIncome { get; set; }

        public string? JobDetails { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
