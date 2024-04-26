using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Employee
{
    public int Id { get; set; }

    public int? IdDocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Telephone { get; set; }

    public string? Cellphone { get; set; }

    public string? EmergencyPhone { get; set; }

    public int? IdCivilStatus { get; set; }

    public int? ChildrenNumber { get; set; }

    public string? BloodType { get; set; }

    public string? Address { get; set; }

    public int? IdCountry { get; set; }

    public string? Province { get; set; }

    public string? Distrit { get; set; }

    public string? Birthday { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? IdJobDepartment { get; set; }

    public int? IdJob { get; set; }

    public string? WorkModality { get; set; }

    public string? SalaryBank { get; set; }

    public int? IdBankAccountTypeSalary { get; set; }

    public string? NumberAccountSalary { get; set; }

    public int? IdCurrencySalary { get; set; }

    public string? CtsBank { get; set; }

    public int? IdBankAccountTypeCts { get; set; }

    public string? NumberAccountCts { get; set; }

    public int? IdCurrencyCts { get; set; }

    public string? PhotoPath { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<HealthInsurance> HealthInsurances { get; set; } = new List<HealthInsurance>();

    public virtual DocumentType? IdDocumentTypeNavigation { get; set; }

    public virtual JobDepartment? IdJobDepartmentNavigation { get; set; }

    public virtual Job? IdJobNavigation { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();

    public virtual ICollection<TicketAssignation> TicketAssignations { get; set; } = new List<TicketAssignation>();

    public virtual ICollection<TicketQuery> TicketQueries { get; set; } = new List<TicketQuery>();

    public virtual ICollection<TicketReceptor> TicketReceptors { get; set; } = new List<TicketReceptor>();

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
