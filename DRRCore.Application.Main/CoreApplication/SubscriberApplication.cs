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
    public class SubscriberApplication : ISubscriberApplication
    {
        private readonly ISubscriberDomain _subscriberDomain;
        private readonly ICouponBillingSubscriberDomain _couponBillingSubscriberDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SubscriberApplication(ISubscriberDomain subscriberDomain, IMapper mapper, ILogger logger, ICouponBillingSubscriberDomain couponBillingSubscriberDomain)
        {
            _subscriberDomain = subscriberDomain;
            _mapper = mapper;
            _logger = logger;
            _couponBillingSubscriberDomain = couponBillingSubscriberDomain;
        }

        public async Task<Response<bool>> ActiveSubscriber(int id)
        {
            var response = new Response<bool>();
            try
            {
                var existingSubscriber = await _subscriberDomain.GetSubscriberById(id);
                if (existingSubscriber == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFoundEmployee;
                    _logger.LogError(response.Message);
                    return response;
                }
                
                response.Data = await _subscriberDomain.ActiveSubscriberAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<int>> AddOrUpdateAsync(AddOrUpdateSubscriberRequestDto subscriberDto)
        {
            var response = new Response<int>();
            try
            {
                if (subscriberDto == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (subscriberDto.Id == 0)
                {
                    var newSubscriber = _mapper.Map<Subscriber>(subscriberDto);
                    response.Data = await _subscriberDomain.AddSubscriberAsync(newSubscriber);
                    if(response.Data > 0)
                    {
                        var newCouponBilling = new CouponBillingSubscriber();
                        newCouponBilling.IdSubscriber = response.Data;
                        newCouponBilling.NumCoupon = 0;
                        await _couponBillingSubscriberDomain.AddAsync(newCouponBilling);
                    }
                }
                else
                {
                    var existingSubscriber = await _subscriberDomain.GetSubscriberById(subscriberDto.Id);
                    if (existingSubscriber == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingSubscriber = _mapper.Map(subscriberDto, existingSubscriber);
                    existingSubscriber.UpdateDate = DateTime.Now;
                    await _subscriberDomain.UpdateSubscriberAsync(existingSubscriber);
                    response.Data = existingSubscriber.Id;
                }

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteSubscriber(int id)
        {
            var response = new Response<bool>();
            try
            {
                var existingSubscriber = await _subscriberDomain.GetSubscriberById(id);
                if (existingSubscriber == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFoundEmployee;
                    _logger.LogError(response.Message);
                    return response;
                }

                response.Data = await _subscriberDomain.DeleteSubscriberAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListSubscriberResponseDto>>> GetSubscriber(string code, string name, string enable)
        {
            var response = new Response<List<GetListSubscriberResponseDto>>();
            try
            {
                var subscriber = await _subscriberDomain.GetSubscriber(code, name, enable);
                if (subscriber == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetListSubscriberResponseDto>>(subscriber);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetSubscriberResponseDto>> GetSubscriberByCode(string code)
        {
            var response = new Response<GetSubscriberResponseDto>();
            try
            {
                var subscriber = await _subscriberDomain.GetSubscriberByCode(code);
                if (subscriber == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<GetSubscriberResponseDto>(subscriber);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetSubscriberResponseDto>> GetSubscriberById(int id)
        {
            var response = new Response<GetSubscriberResponseDto>();
            try
            {
                var subscriber = await _subscriberDomain.GetSubscriberById(id);
                if (subscriber == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<GetSubscriberResponseDto>(subscriber);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetSubscriberDataResponseDto>> LoginSubscriber(string? user, string? psw)
        {
            var response = new Response<GetSubscriberDataResponseDto>();
            try
            {
                var subscriber = await _subscriberDomain.LoginSubscriber(user, psw);
                if (subscriber == null)
                {
                    response.Data = null;
                }
                else
                {
                    response.Data = _mapper.Map<GetSubscriberDataResponseDto>(subscriber);
                }
            }catch(Exception ex)
            {
                _logger.LogError(response.Message, ex);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
