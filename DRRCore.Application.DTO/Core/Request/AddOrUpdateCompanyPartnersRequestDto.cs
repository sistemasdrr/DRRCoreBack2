namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyPartnersRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public bool? MainExecutive { get; set; }

        public string? Profession { get; set; }

        public decimal? Participation { get; set; }

        public string? StartDate { get; set; }
        public int? Numeration { get; set; }
        public bool? Print { get; set; }

    }
}
