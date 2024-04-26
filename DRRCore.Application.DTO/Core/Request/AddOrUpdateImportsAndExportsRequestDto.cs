namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateImportsAndExportsRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? Type { get; set; }

        public int? Year { get; set; }

        public string? Amount { get; set; }

        public string? Observation { get; set; }

        public string? ObservationEng { get; set; }
    }
}
