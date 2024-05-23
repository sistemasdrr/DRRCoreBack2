namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyRelationRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdCompanyRelation { get; set; }
    }
    public class AddListCompanyRelationRequestDto
    {
        public int? IdCompany { get; set; }

        public List<int?> IdsCompanyRelation { get; set; }
    }
}
