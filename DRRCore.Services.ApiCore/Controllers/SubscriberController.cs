using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : Controller
    {
        public readonly ISubscriberApplication _subscriberApplication;
        public readonly ISubscriberPriceApplication _subscriberPriceApplication;
        public readonly ICouponBillingSubscriberApplication _couponBillingSubscriberApplication;
        public SubscriberController(ISubscriberApplication subscriberApplication, ISubscriberPriceApplication subscriberPriceApplication,
            ICouponBillingSubscriberApplication couponBillingSubscriberApplication)
        {
            _subscriberApplication = subscriberApplication;
            _subscriberPriceApplication = subscriberPriceApplication;
            _couponBillingSubscriberApplication = couponBillingSubscriberApplication;
        }

        [HttpPost()]
        [Route("add")]
        public async Task<ActionResult> AddSubscriber(AddOrUpdateSubscriberRequestDto request)
        {
            return Ok(await _subscriberApplication.AddOrUpdateAsync(request));
        }
        [HttpGet()]
        [Route("get")]
        public async Task<ActionResult> GetSubscribers(string? code, string? name, string? enable)
        {
            code ??= string.Empty;
            name ??= string.Empty;
            enable ??= string.Empty;
            return Ok(await _subscriberApplication.GetSubscriber(code, name, enable));
        }
        [HttpGet()]
        [Route("getById")]
        public async Task<ActionResult> GetSubscriberById(int id)
        {
            return Ok(await _subscriberApplication.GetSubscriberById(id));
        }
        [HttpGet()]
        [Route("getByCode")]
        public async Task<ActionResult> GetSubscriberPriceByCode(string code)
        {
            return Ok(await _subscriberApplication.GetSubscriberByCode(code));
        }
        [HttpPost()]
        [Route("delete")]
        public async Task<ActionResult> DeleteSubscriber(int id)
        {
            return Ok(await _subscriberApplication.DeleteSubscriber(id));
        }
        [HttpPost()]
        [Route("active")]
        public async Task<ActionResult> ActiveSubscriber(int id)
        {
            return Ok(await _subscriberApplication.ActiveSubscriber(id));
        }

        [HttpPost()]
        [Route("addPrice")]
        public async Task<ActionResult> AddSubscriberPrice(AddOrUpdateSubscriberPriceRequestDto request)
        {
            return Ok(await _subscriberPriceApplication.AddOrUpdateAsync(request));
        }

        [HttpPost()]
        [Route("loginSubscriber")]
        public async Task<ActionResult> loginSubscriber(string? usr, string? psw)
        {
            return Ok(await _subscriberApplication.LoginSubscriber(usr,psw));
        }
        [HttpGet()]
        [Route("getPrices")]
        public async Task<ActionResult> GetSubscriberPrice(int idSubscriber)
        {
            return Ok(await _subscriberPriceApplication.GetSubscriberPricesById(idSubscriber));
        }
        [HttpGet()]
        [Route("getPrice")]
        public async Task<ActionResult> GetSubscriberPriceById(int id)
        {
            return Ok(await _subscriberPriceApplication.GetSubscriberPriceById(id));
        }
        [HttpPost()]
        [Route("deletePrice")]
        public async Task<ActionResult> DeleteSubscriberPrice(int id)
        {
            return Ok(await _subscriberPriceApplication.DeleteAsync(id));
        }

        [HttpGet()]
        [Route("getContinents")]
        public async Task<ActionResult> getContinentesById(int id)
        {
            return Ok(await _subscriberPriceApplication.GetContinentsById(id));
        }
        [HttpGet()]
        [Route("getCountries")]
        public async Task<ActionResult> getCountriesById(int idSubscriber, int idContinent)
        {
            return Ok(await _subscriberPriceApplication.GetCountriesById(idSubscriber,idContinent));
        }
        [HttpGet()]
        [Route("getPriceByIds")]
        public async Task<ActionResult> getPriceByIds(int idSubscriber, int idContinent, int idCountry)
        {
            return Ok(await _subscriberPriceApplication.GetSelectSubscriberPrice(idSubscriber, idContinent, idCountry));
        }
        [HttpPost()]
        [Route("addCouponBilling")]
        public async Task<ActionResult> AddOrUpdateCouponBilling(AddOrUpdateCouponBillingSubscriberRequestDto obj)
        {
            return Ok(await _couponBillingSubscriberApplication.AddOrUpdateCouponBillingSubscriber(obj));
        }
        [HttpGet()]
        [Route("getCouponBilling")]
        public async Task<ActionResult> getCouponBilling(int idSubscriber)
        {
            return Ok(await _couponBillingSubscriberApplication.GetCouponBillingByIdSubscriber(idSubscriber));
        }
        [HttpGet()]
        [Route("getCouponBillingHistory")]
        public async Task<ActionResult> getCouponBillingHistory(int idSubscriber)
        {
            return Ok(await _couponBillingSubscriberApplication.GetHistoryByIdSubscriber(idSubscriber));
        }
        [HttpPost()]
        [Route("addCouponBillingHistory")]
        public async Task<ActionResult> AddCouponBillingHistory(AddOrUpdateCouponBillingSubscriberHistoryRequestDto obj)
        {
            return Ok(await _couponBillingSubscriberApplication.AddCouponBillingHistory(obj));
        }
    }
}
