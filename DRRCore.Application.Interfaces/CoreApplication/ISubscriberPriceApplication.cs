using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface ISubscriberPriceApplication
    {
        Task<Response<List<GetSuscriberPriceResponseDto>>> GetSubscriberPricesById(int idSubscriber);
        Task<Response<GetSuscriberPriceByIdResponseDto>> GetSubscriberPriceById(int id);
        Task<Response<bool>> AddOrUpdateAsync (AddOrUpdateSubscriberPriceRequestDto obj);
        Task<Response<bool>> DeleteAsync (int id);
        Task<Response<List<GetComboValueResponseDto>>> GetContinentsById(int idSubscriber);
        Task<Response<List<GetComboValueFlagResponseDto>>> GetCountriesById(int idSubscriber, int idContitent);
        Task<Response<List<GetPricesResponseDto>>> GetSelectSubscriberPrice(int idSubscriber, int idContinent, int idCountry);
    }
}
