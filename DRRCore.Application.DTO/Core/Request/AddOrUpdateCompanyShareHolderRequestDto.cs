namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyShareHolderRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdCompanyShareHolder { get; set; }

        public string? Relation { get; set; }

        public string? RelationEng { get; set; }

        public int? Participation { get; set; }

        public string? StartDate { get; set; }
    }
}
