using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonApplication _personApplication;
        private readonly IPersonImagesApplication _personImagesApplication;
        public PersonController(IPersonApplication personApplication, IPersonImagesApplication personImagesApplication)
        {
            _personApplication = personApplication;
            _personImagesApplication = personImagesApplication;
        }

        [HttpPost()]
        [Route("addPerson")]
        public async Task<ActionResult> addPerson(AddOrUpdatePersonRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePerson(request));
        }
        [HttpPost()]
        [Route("deletePerson")]
        public async Task<ActionResult> deletePerson(int id)
        {
            return Ok(await _personApplication.DeletePerson(id));
        }
        [HttpPost()]
        [Route("activateWeb")]
        public async Task<ActionResult> activateWeb(int id)
        {
            return Ok(await _personApplication.ActivateWebPerson(id));
        }
        [HttpPost()]
        [Route("desactivateWeb")]
        public async Task<ActionResult> desactivateWeb(int id)
        {
            return Ok(await _personApplication.DesactivateWebPerson(id));
        }
        [HttpGet()]
        [Route("getListPerson")]
        public async Task<ActionResult> getListPerson(string? fullname, string? form, int idCountry, bool haveReport, string filterBy)
        {
            fullname ??= string.Empty;
            form ??= string.Empty;
            return Ok(await _personApplication.GetListPerson(fullname, form, idCountry, haveReport, filterBy));
        }
        [HttpGet()]
        [Route("getPerson")]
        public async Task<ActionResult> getPerson(int id)
        {
            return Ok(await _personApplication.GetPersonById(id));
        }
       
        [HttpPost()]
        [Route("addPersonHome")]
        public async Task<ActionResult> addPersonHome(AddOrUpdatePersonHomeRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonHomeAsync(request));
        }
        [HttpGet()]
        [Route("getPersonHome")]
        public async Task<ActionResult> getPersonHome(int idPerson)
        {
            return Ok(await _personApplication.GetPersonHomeByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonJob")]
        public async Task<ActionResult> addPersonJob(AddOrUpdatePersonJobRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonJobAsync(request));
        }
        [HttpGet()]
        [Route("getPersonJob")]
        public async Task<ActionResult> getPersonJob(int idPerson)
        {
            return Ok(await _personApplication.GetPersonJobByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonActivity")]
        public async Task<ActionResult> addPersonActivity(AddOrUpdatePersonActivitiesRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonActivitiesAsync(request));
        }
        [HttpGet()]
        [Route("getPersonActivity")]
        public async Task<ActionResult> getPersonActivity(int idPerson)
        {
            return Ok(await _personApplication.GetPersonActivitiesByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonProperty")]
        public async Task<ActionResult> addPersonProperty(AddOrUpdatePersonPropertyRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonPropertyAsync(request));
        }
        [HttpGet()]
        [Route("getPersonProperty")]
        public async Task<ActionResult> getPersonProperty(int idPerson)
        {
            return Ok(await _personApplication.GetPersonPropertyByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonHistory")]
        public async Task<ActionResult> addPersonHistory(AddOrUpdatePersonHistoryRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonHistoryAsync(request));
        }
        [HttpGet()]
        [Route("getPersonHistory")]
        public async Task<ActionResult> getPersonHistory(int idPerson)
        {
            return Ok(await _personApplication.GetPersonHistoryByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonGeneralInfo")]
        public async Task<ActionResult> addPersonGeneralInfo(AddOrUpdatePersonGeneralInfoRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonGeneralInfoAsync(request));
        }
        [HttpGet()]
        [Route("getPersonGeneralInfo")]
        public async Task<ActionResult> getPersonGeneralInfo(int idPerson)
        {
            return Ok(await _personApplication.GetPersonGeneralInfoByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPersonSbs")]
        public async Task<ActionResult> addPersonSbs(AddOrUpdatePersonSbsRequestDto request)
        {
            return Ok(await _personApplication.AddOrUpdatePersonSBSAsync(request));
        }
        [HttpGet()]
        [Route("getPersonSbs")]
        public async Task<ActionResult> getPersonSbs(int idPerson)
        {
            return Ok(await _personApplication.GetPersonSBSById(idPerson));
        }
        [HttpPost()]
        [Route("addOrUpdateProvider")]
        public async Task<ActionResult> addOrUpdateProvider(AddOrUpdateProviderRequestDto obj)
        {
            return Ok(await _personApplication.AddOrUpdateProviderAsync(obj));
        }
        [HttpGet()]
        [Route("getListProvider")]
        public async Task<ActionResult> getListProvider(int idPerson)
        {
            return Ok(await _personApplication.GetListProvidersAsync(idPerson));
        }
        [HttpGet()]
        [Route("getProviderById")]
        public async Task<ActionResult> getProviderById(int id)
        {
            return Ok(await _personApplication.GetProviderById(id));
        }
        [HttpPost()]
        [Route("deleteProvider")]
        public async Task<ActionResult> deleteProvider(int id)
        {
            return Ok(await _personApplication.DeleteProvider(id));
        }
        [HttpPost()]
        [Route("addOrUpdateLatePayment")]
        public async Task<ActionResult> addOrUpdateLatePayment(AddOrUpdateComercialLatePaymentRequestDto obj)
        {
            return Ok(await _personApplication.AddOrUpdateComercialLatePaymentAsync(obj));
        }
        [HttpGet()]
        [Route("getListLatePayment")]
        public async Task<ActionResult> getListLatePayment(int idPerson)
        {
            return Ok(await _personApplication.GetListComercialLatePaymentAsync(idPerson));
        }
        [HttpGet()]
        [Route("getLatePaymentById")]
        public async Task<ActionResult> getLatePaymentById(int id)
        {
            return Ok(await _personApplication.GetComercialLatePaymentById(id));
        }
        [HttpPost()]
        [Route("deleteLatePayment")]
        public async Task<ActionResult> deleteLatePayment(int id)
        {
            return Ok(await _personApplication.DeleteComercialLatePayment(id));
        }
        [HttpPost()]
        [Route("addOrUpdateBankDebt")]
        public async Task<ActionResult> addOrUpdateBankDebt(AddOrUpdateBankDebtRequestDto obj)
        {
            return Ok(await _personApplication.AddOrUpdateBankDebtAsync(obj));
        }
        [HttpGet()]
        [Route("getListBankDebt")]
        public async Task<ActionResult> getListBankDebt(int idPerson)
        {
            return Ok(await _personApplication.GetListBankDebtAsync(idPerson));
        }
        [HttpGet()]
        [Route("getBankDebtById")]
        public async Task<ActionResult> getBankDebtById(int id)
        {
            return Ok(await _personApplication.GetBankDebtById(id));
        }
        [HttpPost()]
        [Route("deleteBankDebt")]
        public async Task<ActionResult> deleteBankDebt(int id)
        {
            return Ok(await _personApplication.DeleteBankDebt(id));
        }



        [HttpPost()]
        [Route("addPersonImg")]
        public async Task<ActionResult> addOrUpdatePersonImg(AddOrUpdatePersonImagesRequestDto obj)
        {
            return Ok(await _personImagesApplication.AddOrUpdateImages(obj));
        }
        [HttpGet()]
        [Route("getPersonImgById")]
        public async Task<ActionResult> getPersonImgById(int idPerson)
        {
            return Ok(await _personImagesApplication.GetPersonImagesByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("uploadImage")]
        public async Task<ActionResult> uploadImage(IFormFile request)
        {
            return Ok(await _personImagesApplication.UploadImage(request));
        }
        [HttpGet()]
        [Route("getImageByPath")]
        public async Task<ActionResult> getImageByPath(string path)
        {
            var result = await _personImagesApplication.GetImageByPath(path);

            if (result != null && result.Data != null)
            {
                return File(result.Data.File?.ToArray(), result.Data.ContentType, result.Data.FileName);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost()]
        [Route("addPersonPartner")]
        public async Task<ActionResult> addPersonPartner(AddOrUpdateCompanyPartnersRequestDto obj)
        {
            return Ok(await _personApplication.AddOrUpdatePersonPartner(obj));
        }
        [HttpGet()]
        [Route("getPersonPartner")]
        public async Task<ActionResult> getPersonPartner(int id)
        {
            return Ok(await _personApplication.GetPersonPartnerById(id));
        }
        [HttpPost()]
        [Route("deletePersonPartner")]
        public async Task<ActionResult> deletePersonPartner(int id)
        {
            return Ok(await _personApplication.DeletePersonPartner(id));
        }
        [HttpGet()]
        [Route("getListPersonPartner")]
        public async Task<ActionResult> getListPersonPartner(int idPerson)
        {
            return Ok(await _personApplication.GetListPersonPartnerByIdPerson(idPerson));
        }
        [HttpPost()]
        [Route("addPhoto")]
        public async Task<ActionResult> addPhoto(AddOrUpdatePersonPhotoRequestDto obj)
        {
            return Ok(await _personApplication.AddOrUpdatePhotoAsync(obj));
        }
        [HttpGet()]
        [Route("getPhoto")]
        public async Task<ActionResult> getPhoto(int id)
        {
            return Ok(await _personApplication.GetPhotoById(id));
        }
        [HttpPost()]
        [Route("deletePhoto")]
        public async Task<ActionResult> deletePhoto(int id)
        {
            return Ok(await _personApplication.DeletePhoto(id));
        }
        [HttpGet()]
        [Route("getListPhoto")]
        public async Task<ActionResult> getListPhoto(int idPerson)
        {
            return Ok(await _personApplication.GetListPhotoAsync(idPerson));
        }
        [HttpGet()]
        [Route("getStatus")]
        public async Task<ActionResult> getStatus(int idPerson)
        {
            return Ok(await _personApplication.GetStatusPerson(idPerson));
        }
    }
}
