using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetEmployeeResponseDto
    {
        public string ShortName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
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
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? IdJobDepartment { get; set; }
        public string Department {  get; set; } 
        public int? IdJob { get; set; }
        public string Job { get; set; }
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
        public bool Enable { get; set; }
        public List<GetHealthInsuranceResponseDto> HealthInsuranceResponseDto { get; set; } = new List<GetHealthInsuranceResponseDto>();
    }
    public class GetHealthInsuranceResponseDto
    {
        public string Code { get; set; } = string.Empty;
        public string? NameHolder { get; set; }
        public int? IdFamilyBondType { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
