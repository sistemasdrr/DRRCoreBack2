namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListTicketResponseDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? IdSubscriber { get; set; }
        public string? Language { get; set; }
        public string About { get; set; } = null!;
        public int? IdContinent { get; set; }
        public int? IdCountry { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public int? Creditrisk { get; set; }
        public bool? Enable { get; set; }
        public string? Quality { get; set; }
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? StatusFinalOwner { get; set; }

        //ABONADO
        public string? SubscriberCode { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCountry { get; set; }
        public string? SubscriberFlag { get; set; }
        public string? QueryCredit { get; set; }
        public string? TimeLimit { get; set; }
        public bool? RevealName { get; set; }
        public string? NameRevealed { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? AditionalData { get; set; }
        public string? SubscriberIndications { get; set; }

        //EMPRESA
        public string? BusineesName { get; set; }
        public string? ComercialName { get; set; }
        public string? RequestedName { get; set; }
        public string? TaxType { get; set; }
        public string? TaxCode { get; set; }
        public string? InvestigatedContinent { get; set; }
        public string? InvestigatedCountry { get; set; }
        public string? InvestigatedFlag { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }

        //INFORME
        public string ReportType { get; set; } = null!;
        public string ProcedureType { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RealExpireDate { get; set; }
        public string? DispatchDate { get; set; }

        //Consulta
        public string AsignedTo { get; set; }
        public bool HasQuery { get; set; }
        public int StatusQuery { get; set; }
        public int Receptor { get; set; }
        public int Receptor2 { get; set; }
        public string Commentary { get; set; } = string.Empty;
        public bool HasFiles { get; set; }
        public List<TicketFileResponseDto> Files { get; set; } = new List<TicketFileResponseDto>();
        public string Origen { get; set; }
        public int? NumberAssign { get; set; }
        public string? AssinedTo { get; set; }
        public string? Observations { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? References { get; set; }

    }
    public class GetListTicketResponseDto2
    {
        public int Id { get; set; }
        public int? IdTicket { get; set; }
        public string Number { get; set; }
        public int? IdSubscriber { get; set; }
        public string? Language { get; set; }
        public string About { get; set; } = null!;
        public int? IdContinent { get; set; }
        public int? IdCountry { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public int? Creditrisk { get; set; }
        public bool? Enable { get; set; }
        public string? Quality { get; set; }
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? StatusFinalOwner { get; set; }

        //ABONADO
        public string? SubscriberCode { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCountry { get; set; }
        public string? SubscriberFlag { get; set; }
        public string? QueryCredit { get; set; }
        public string? TimeLimit { get; set; }
        public bool? RevealName { get; set; }
        public string? NameRevealed { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? AditionalData { get; set; }
        public string? SubscriberIndications { get; set; }

        //EMPRESA
        public string? BusineesName { get; set; }
        public string? ComercialName { get; set; }
        public string? RequestedName { get; set; }
        public string? TaxType { get; set; }
        public string? TaxCode { get; set; }
        public string? InvestigatedContinent { get; set; }
        public string? InvestigatedCountry { get; set; }
        public string? InvestigatedFlag { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }

        //INFORME
        public string ReportType { get; set; } = null!;
        public string ProcedureType { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RealExpireDate { get; set; }
        public string? DispatchDate { get; set; }

        //Consulta
        public string AsignedTo { get; set; }
        public List<UserCode> OtherUserCode { get; set; }
        public bool HasQuery { get; set; }
        public int StatusQuery { get; set; }
        public int Receptor { get; set; }
        public int Receptor2 { get; set; }
        public string Commentary { get; set; } = string.Empty;
        public bool HasFiles { get; set; }
        public List<TicketFileResponseDto> Files { get; set; } = new List<TicketFileResponseDto>();
        public string Origen { get; set; }
        public int? NumberAssign { get; set; }
        public string? AssinedTo { get; set; }
        public string? Observations { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? References { get; set; }

    }
    public class UserCode
    {
        public string? Code { get; set; }
        public bool Active { get; set; }
    }
}
