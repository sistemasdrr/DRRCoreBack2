
using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DRRCore.Application.Main.CoreApplication
{
    public class SubscriberPriceApplication : ISubscriberPriceApplication
    {
        private readonly ISubscriberPriceDomain _subscriberPriceDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SubscriberPriceApplication(ISubscriberPriceDomain subscriberPriceDomain, IMapper mapper, ILogger logger)
        {
            _subscriberPriceDomain = subscriberPriceDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> AddOrUpdateAsync(AddOrUpdateSubscriberPriceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    if (obj.Id > 0)
                    {
                        var existingSubscriberPrice = await _subscriberPriceDomain.GetByIdAsync(obj.Id);
                        if(existingSubscriberPrice != null)
                        {
                            existingSubscriberPrice = _mapper.Map(obj, existingSubscriberPrice);
                            existingSubscriberPrice.UpdateDate = DateTime.Now;
                            response.Data = await _subscriberPriceDomain.UpdateAsync(existingSubscriberPrice);
                        }
                        else
                        {
                            response.Data = false;
                            response.IsSuccess = false;
                        }
                    }
                    else
                    {
                        var newSubscriberPrice = _mapper.Map<SubscriberPrice>(obj);
                        response.Data = await _subscriberPriceDomain.AddAsync(newSubscriberPrice);
                    }
                }
                
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                var existingSubscriberPrice = await _subscriberPriceDomain.GetByIdAsync(id);
                if(existingSubscriberPrice != null)
                {
                    response.Data = await _subscriberPriceDomain.DeleteAsync(id);
                }
                else
                {
                    response.Data = false;
                    response.IsSuccess = false;
                    response.IsWarning = true;
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetContinentsById(int idSubscriber)
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            var list = new List<GetComboValueResponseDto>();
            try
            {
                if (idSubscriber > 0)
                {
                    var ListSubscriberPrice = await _subscriberPriceDomain.GetPricesBySubscriberId(idSubscriber);
                    foreach (var item in ListSubscriberPrice)
                    {
                        if(item.IdContinent > 0 && item.IdContinent != null)
                        {
                            var subscriberPrice = _mapper.Map<GetComboValueResponseDto>(item);
                            if (!list.Any(x => x.Id == subscriberPrice.Id))
                            {
                                list.Add(subscriberPrice);
                            }
                        }
                    }
                    response.Data = list;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueFlagResponseDto>>> GetCountriesById(int idSubscriber, int idContitent)
        {
            var response = new Response<List<GetComboValueFlagResponseDto>>();
            var list = new List<GetComboValueFlagResponseDto>();
            try
            {
                if (idSubscriber > 0)
                {
                    var ListSubscriberPrice = await _subscriberPriceDomain.GetPricesBySubscriberId(idSubscriber);
                    foreach (var item in ListSubscriberPrice)
                    {
                        if (item.IdCountry > 0 && item.IdCountry!= null && item.IdContinent == idContitent)
                        {
                            var subscriberPrice = _mapper.Map<GetComboValueFlagResponseDto>(item);
                            if (!list.Any(x => x.Id == subscriberPrice.Id))
                            {
                                list.Add(subscriberPrice);
                            }
                        }
                    }
                    response.Data = list;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetPricesResponseDto>>> GetSelectSubscriberPrice(int idSubscriber, int idContinent, int idCountry)
        {
            var response = new Response<List<GetPricesResponseDto>>();
            var list = new List<GetPricesResponseDto>();
            try
            {
                if (idSubscriber > 0)
                {
                    var subscriberPrice = await _subscriberPriceDomain.GetPriceBySubscriberIds(idSubscriber, idContinent, idCountry);
                    
                        var T1 = new GetPricesResponseDto();
                        T1.Name = "T1";
                        T1.Price = (int)subscriberPrice.PriceT1;
                        T1.Days = (int)subscriberPrice.DayT1;
                        list.Add((GetPricesResponseDto)T1);
                    
                        var T2 = new GetPricesResponseDto();
                        T2.Name = "T2";
                        T2.Price = (int)subscriberPrice.PriceT2;
                        T2.Days = (int)subscriberPrice.DayT2;
                        list.Add((GetPricesResponseDto)T2);
                  
                        var T3 = new GetPricesResponseDto();
                        T3.Name = "T3";
                        T3.Price = (int)subscriberPrice.PriceT3;
                        T3.Days = (int)subscriberPrice.DayT3;
                        list.Add((GetPricesResponseDto)T3);
                    
                        var TB = new GetPricesResponseDto();
                        TB.Name = "BC";
                        TB.Price = (int)subscriberPrice.PriceB;
                        TB.Days = (int)subscriberPrice.PriceB;
                        list.Add((GetPricesResponseDto)TB);

                    response.Data = list;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        //GetPriceContinentsResponseDto
        public async Task<Response<GetSuscriberPriceByIdResponseDto>> GetSubscriberPriceById(int id)
        {
            var response = new Response<GetSuscriberPriceByIdResponseDto>();
            try
            {
               if(id > 0)
                {
                    var subscriberPrice = await _subscriberPriceDomain.GetByIdAsync(id);
                    response.Data = _mapper.Map<GetSuscriberPriceByIdResponseDto>(subscriberPrice);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetSuscriberPriceResponseDto>>> GetSubscriberPricesById(int idSubscriber)
        {
            var response = new Response<List<GetSuscriberPriceResponseDto>>();
            try
            {
                if (idSubscriber > 0)
                {
                    var ListSubscriberPrice = await _subscriberPriceDomain.GetPricesBySubscriberId(idSubscriber);
                    response.Data = _mapper.Map<List<GetSuscriberPriceResponseDto>>(ListSubscriberPrice);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

    }
}
