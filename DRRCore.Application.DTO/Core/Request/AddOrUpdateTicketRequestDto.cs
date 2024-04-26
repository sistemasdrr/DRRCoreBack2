namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateTicketRequestDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int? IdSubscriber { get; set; }

        public bool? RevealName { get; set; }

        public string? NameRevealed { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Language { get; set; }

        public string? QueryCredit { get; set; }

        public string? TimeLimit { get; set; }

        public string? AditionalData { get; set; }
        public string? SubscriberIndications { get; set; }

        public string About { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime RealExpireDate { get; set; }

        public int? IdContinent { get; set; }

        public int? IdCountry { get; set; }

        public string ReportType { get; set; } = null!;

        public string ProcedureType { get; set; } = null!;

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? BusineesName { get; set; }

        public string? ComercialName { get; set; }

        public string? TaxType { get; set; }

        public string? TaxCode { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Telephone { get; set; }

        public int? Creditrisk { get; set; }
       
        public bool? Enable { get; set; }     

        public string? RequestedName { get; set; }

        public decimal? Price { get; set; }
        public string? UserFrom { get; set; }
    }
    public class SavePreAsignTicketDto
    {
        public int Id { get; set; }
        public int? IdEmisor { get; set; }
        public int? IdReceptor { get; set; }
        public string? Commentary { get; set; }
    }
}
