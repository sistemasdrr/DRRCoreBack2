using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IComboboxApplication
    {
        Task<Response<List<GetComboValueResponseDto>>> GetDocumentTypeNatural();
        Task<Response<List<GetComboValueResponseDto>>> GetDocumentType();
        Task<Response<List<GetComboValueResponseDto>>> GetReasonTicket();
        Task<Response<List<GetComboValueResponseDto>>> GetCivilStatus();
        Task<Response<List<GetComboValueResponseDto>>> GetContinents();
        Task<Response<List<GetComboValueFlagResponseDto>>> GetCountries();
        Task<Response<GetComboValueFlagResponseDto>> GetCountryById(int idCountry);
        Task<Response<List<GetComboValueFlagResponseDto>>> GetCountriesByContinent(int idContinent);
        Task<Response<List<GetComboValueResponseDto>>> GetDepartment();
        Task<Response<List<GetComboValueResponseDto>>> GetJobByDepartment(int idDepartment);
        Task<Response<List<GetComboValueResponseDto>>> GetCurrency();
        Task<Response<List<GetComboValueResponseDto>>> GetFamilyBondyType();
        Task<Response<List<GetComboValueResponseDto>>> GetBankAccountType();
        Task<Response<List<GetComboValueResponseDto>>> GetLegalPersonType();
        Task<Response<List<GetComboCreditRiskResponseDto>>> GetCreditRisk();
        Task<Response<List<GetComboColorResponseDto>>> GetPaymentPolicy();
        Task<Response<List<GetComboColorResponseDto>>> GetCompanyReputation();
        Task<Response<List<GetComboValueResponseDto>>> GetLegalRegisterSituation();
        Task<Response<List<GetComboValueResponseDto>>> GetSubscriberCategories();
        Task<Response<List<GetFinancialSituationResponseDto>>> GetFinancialSituacion();
        Task<Response<List<GetComboValueResponseDto>>> GetCollaborationDegree();
        Task<Response<List<GetComboValueResponseDto>>> GetOpcionalCommentarySbs();
        Task<Response<List<GetComboValueResponseDto>>> GetBranchSector();
        Task<Response<List<GetComboValueResponseDto>>> GetBusinessBranch();
        Task<Response<List<GetComboValueEngResponseDto>>> GetBusinessActivity(int idBusinessBranch);
        Task<Response<List<GetComboValueResponseDto>>> GetLandOwnership(); 
        Task<Response<List<GetComboValueResponseDto>>> GetPersonSituation();
        Task<Response<List<GetComboValueResponseDto>>> GetProfession();
        Task<Response<List<GetComboNameValueResponseDto>>> GetUserEmails();
    }
}
