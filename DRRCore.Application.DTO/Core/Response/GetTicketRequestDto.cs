namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketRequestDto
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
    }
    public class GetTicketPendingObservationsResponseDto
    {
        public int Id { get; set; }
        public string? About { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public int? IdSubscriber{ get; set; }
        public int? IdReason { get; set; }
        public string? Message { get; set; }
        public string? Conclusion { get; set; }
        public int? IdStatusTicketObservation{ get; set; }
        public string? Cc { get; set; }
        public DateTime? ObservationDate { get; set; }
        public DateTime? AsignedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SolutionDate { get; set; }
        public List<GetEmployeeObservated>? EmployeesObservated { get; set; }
    }
    public class AddOrUpdateTicketPendingObservationsResponseDto
    {
        public int Id { get; set; }
        public int? IdTicket { get; set; }
        public string? About { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public int? IdSubscriber { get; set; }
        public int? IdReason { get; set; }
        public string? Message { get; set; }
        public string? Conclusion { get; set; }
        public int? IdStatusTicketObservation { get; set; }
        public string? Cc { get; set; }
        public DateTime? ObservationDate { get; set; }
        public DateTime? AsignedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SolutionDate { get; set; }
        public List<GetEmployeeObservated>? EmployeesObservated { get; set; }
    }
    public class GetEmployeeAssignated
    {
        public int Id { get; set; }
        public string? UserTo { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
    public class GetEmployeeObservated
    {
        public int Id { get; set; }
        public string? UserTo { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
    
}
