namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyRelationRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdCompanyRelation { get; set; }
    }
}
