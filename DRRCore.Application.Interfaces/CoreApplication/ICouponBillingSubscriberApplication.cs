using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface ICouponBillingSubscriberApplication
    {
        Task<Response<GetCouponBillingSubscriberResponseDto>> GetCouponBillingByIdSubscriber(int idSubscriber);
        Task<Response<bool>> AddOrUpdateCouponBillingSubscriber(AddOrUpdateCouponBillingSubscriberRequestDto obj);
        Task<Response<List<GetCouponBillingSubscriberHistoryResponseDto>>> GetHistoryByIdSubscriber(int idSubscriber);
        Task<Response<bool>> AddCouponBillingHistory(AddOrUpdateCouponBillingSubscriberHistoryRequestDto obj);
    }
}
