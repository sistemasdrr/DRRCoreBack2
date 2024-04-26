using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IPersonApplication
    {
        Task<Response<GetPersonResponseDto>> GetPersonById(int id);
        Task<Response<List<GetListPersonResponseDto>>> GetListPerson(string fullname, string form, int idCountry, bool haveReport, string filterBy);
        Task<Response<int>> AddOrUpdatePerson(AddOrUpdatePersonRequestDto obj);
        Task<Response<bool>> DeletePerson(int id);
        Task<Response<bool>> ActivateWebPerson(int id);
        Task<Response<bool>> DesactivateWebPerson(int id);

        Task<Response<int?>> AddOrUpdatePersonHomeAsync(AddOrUpdatePersonHomeRequestDto obj);
        Task<Response<GetPersonHomeResponseDto>> GetPersonHomeByIdPerson(int idPerson);
        Task<Response<int?>> AddOrUpdatePersonJobAsync(AddOrUpdatePersonJobRequestDto obj);
        Task<Response<GetPersonJobResponseDto>> GetPersonJobByIdPerson(int idPerson);
        Task<Response<int?>> AddOrUpdatePersonActivitiesAsync(AddOrUpdatePersonActivitiesRequestDto obj);
        Task<Response<GetPersonActivitiesResponseDto>> GetPersonActivitiesByIdPerson(int idPerson);
        Task<Response<int?>> AddOrUpdatePersonPropertyAsync(AddOrUpdatePersonPropertyRequestDto obj);
        Task<Response<GetPersonPropertyResponseDto>> GetPersonPropertyByIdPerson(int idPerson);


        Task<Response<bool>> AddOrUpdateProviderAsync(AddOrUpdateProviderRequestDto obj);
        Task<Response<List<GetListProviderResponseDto>>> GetListProvidersAsync(int idPerson);
        Task<Response<GetProviderResponseDto>> GetProviderById(int id);
        Task<Response<bool>> DeleteProvider(int id);
        Task<Response<bool>> AddOrUpdateComercialLatePaymentAsync(AddOrUpdateComercialLatePaymentRequestDto obj);
        Task<Response<List<GetListComercialLatePaymentResponseDto>>> GetListComercialLatePaymentAsync(int idPerson);
        Task<Response<GetComercialLatePaymentResponseDto>> GetComercialLatePaymentById(int id);
        Task<Response<bool>> DeleteComercialLatePayment(int id);
        Task<Response<bool>> AddOrUpdateBankDebtAsync(AddOrUpdateBankDebtRequestDto obj);
        Task<Response<List<GetListBankDebtResponseDto>>> GetListBankDebtAsync(int idPerson);
        Task<Response<GetBankDebtResponseDto>> GetBankDebtById(int id);
        Task<Response<bool>> DeleteBankDebt(int id);

        Task<Response<int?>> AddOrUpdatePersonSBSAsync(AddOrUpdatePersonSbsRequestDto obj);
        Task<Response<GetPersonSbsResponseDto>> GetPersonSBSById(int idPerson);
        Task<Response<int?>> AddOrUpdatePersonHistoryAsync(AddOrUpdatePersonHistoryRequestDto obj);
        Task<Response<GetPersonHistoryResponseDto>> GetPersonHistoryByIdPerson(int idPerson);
        Task<Response<int?>> AddOrUpdatePersonGeneralInfoAsync(AddOrUpdatePersonGeneralInfoRequestDto obj);
        Task<Response<GetPersonGeneralInfoResponseDto>> GetPersonGeneralInfoByIdPerson(int idPerson);
        Task<Response<bool>> AddOrUpdatePersonPartner(AddOrUpdateCompanyPartnersRequestDto obj);
        Task<Response<GetCompanyPartnersResponseDto>> GetPersonPartnerById(int id);
        Task<Response<bool>> DeletePersonPartner(int id);
        Task<Response<List<GetListPersonPartnerResponseDto>>> GetListPersonPartnerByIdPerson(int idPerson);
        Task<Response<GetStatusPersonResponseDto>> GetStatusPerson(int idPerson);


        Task<Response<bool>> AddOrUpdatePhotoAsync(AddOrUpdatePersonPhotoRequestDto obj);
        Task<Response<List<GetPersonPhotoResponseDto>>> GetListPhotoAsync(int idPerson);
        Task<Response<GetPersonPhotoResponseDto>> GetPhotoById(int id);
        Task<Response<bool>> DeletePhoto(int id);
      
    }
}
