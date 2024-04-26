using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Application.Main.CoreApplication
{
    public class CouponBillingSubscriberApplication : ICouponBillingSubscriberApplication
    {
        private readonly ICouponBillingSubscriberDomain _couponBillingSubscriberDomain;
        private readonly ICouponBillingSubscriberHistoryDomain _couponBillingSubscriberHistoryDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CouponBillingSubscriberApplication(ICouponBillingSubscriberDomain couponBillingSubscriberDomain, ICouponBillingSubscriberHistoryDomain couponBillingSubscriberHistoryDomain, IMapper mapper, ILogger logger)
        {
            _couponBillingSubscriberDomain = couponBillingSubscriberDomain;
            _couponBillingSubscriberHistoryDomain = couponBillingSubscriberHistoryDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> AddCouponBillingHistory(AddOrUpdateCouponBillingSubscriberHistoryRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if(obj.Id == 0)
                {
                    var newHistory = _mapper.Map<CouponBillingSubscriberHistory>(obj);
                    newHistory.LastUpdateUser = 1;
                    response.Data = await _couponBillingSubscriberHistoryDomain.AddAsync(newHistory);
                    if(response.Data == true)
                    {
                        var couponBilling = await _couponBillingSubscriberDomain.GetByIdAsync((int)obj.IdCouponBilling);
                        couponBilling.NumCoupon += obj.CouponAmount;
                        await _couponBillingSubscriberDomain.UpdateAsync(couponBilling);
                    }
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.MessageNoDataFound;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateCouponBillingSubscriber(AddOrUpdateCouponBillingSubscriberRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if(obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                if(obj.Id == 0) 
                {
                    var newCouponBilling = _mapper.Map<CouponBillingSubscriber>(obj);
                    response.Data = await _couponBillingSubscriberDomain.AddAsync(newCouponBilling);
                }
                else
                {
                    var existingCoupongBilling = await _couponBillingSubscriberDomain.GetByIdAsync(obj.Id);
                    if(existingCoupongBilling == null) 
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    else
                    {
                        obj.NumCoupon = existingCoupongBilling.NumCoupon;
                        existingCoupongBilling = _mapper.Map(obj, existingCoupongBilling);
                        existingCoupongBilling.UpdateDate = DateTime.Now;
                        response.Data = await _couponBillingSubscriberDomain.UpdateAsync(existingCoupongBilling);
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.MessageNoDataFound;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetCouponBillingSubscriberHistoryResponseDto>>> GetHistoryByIdSubscriber(int idSubscriber)
        {
            var response = new Response<List<GetCouponBillingSubscriberHistoryResponseDto>>();
            try
            {
                var list = await _couponBillingSubscriberHistoryDomain.GetCouponBillingHistoriesByIdSubscriber(idSubscriber);
                if(list != null)
                {
                    response.Data = _mapper.Map<List<GetCouponBillingSubscriberHistoryResponseDto>>(list);
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.MessageNoDataFound;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        async Task<Response<GetCouponBillingSubscriberResponseDto>> ICouponBillingSubscriberApplication.GetCouponBillingByIdSubscriber(int idSubscriber)
        {
            var response = new Response<GetCouponBillingSubscriberResponseDto>();
            try
            {
                var couponBilling = await _couponBillingSubscriberDomain.GetCouponBillingByIdSubscriber(idSubscriber);
                if(couponBilling != null)
                {
                    response.Data = _mapper.Map<GetCouponBillingSubscriberResponseDto>(couponBilling);
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.MessageNoDataFound;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
