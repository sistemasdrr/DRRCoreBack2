using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComboController : Controller
    {
        private readonly IComboboxApplication _comboboxApplication;
        public ComboController(IComboboxApplication comboboxApplication)
        {
            _comboboxApplication = comboboxApplication;
        }

        [HttpGet()]
        [Route("doctype")]
        public async Task<ActionResult> GetDocumentTypeCombo()
        {
            return Ok(await _comboboxApplication.GetDocumentTypeNatural());
        }
        [HttpGet()]
        [Route("documentType")]
        public async Task<ActionResult> GetDocumentType()
        {
            return Ok(await _comboboxApplication.GetDocumentType());
        }
        [HttpGet()]
        [Route("reason")]
        public async Task<ActionResult> GetReason()
        {
            return Ok(await _comboboxApplication.GetReasonTicket());
        }
        [HttpGet()]
        [Route("userEmails")]
        public async Task<ActionResult> userEmails()
        {
            return Ok(await _comboboxApplication.GetUserEmails());
        }
        [HttpGet()]
        [Route("civilstatus")]
        public async Task<ActionResult> GetCivilStatusCombo()
        {
            return Ok(await _comboboxApplication.GetCivilStatus());
        }
        [HttpGet()]
        [Route("continent")]
        public async Task<ActionResult> GetContinentsCombo()
        {
            return Ok(await _comboboxApplication.GetContinents());
        }
        [HttpGet()]
        [Route("country")]
        public async Task<ActionResult> GetCountriesCombo()
        {
            return Ok(await _comboboxApplication.GetCountries());
        }
        [HttpGet()]
        [Route("countryById")]
        public async Task<ActionResult> GetCountryByIdCombo(int idCountry)
        {
            return Ok(await _comboboxApplication.GetCountryById(idCountry));
        }
        [HttpGet()]
        [Route("countrybycontinent")]
        public async Task<ActionResult> GetCountriesByContinentCombo(int continent)
        {
            return Ok(await _comboboxApplication.GetCountriesByContinent(continent));
        }
        [HttpGet()]
        [Route("jobdep")]
        public async Task<ActionResult> GetJobDepartmentCombo()
        {
            return Ok(await _comboboxApplication.GetDepartment());
        }
        [HttpGet()]
        [Route("jobbydep")]
        public async Task<ActionResult> GetJobByDepartmentCombo(int department)
        {
            return Ok(await _comboboxApplication.GetJobByDepartment(department));
        }
        [HttpGet()]
        [Route("currency")]
        public async Task<ActionResult> GetCurrencyCombo()
        {
            return Ok(await _comboboxApplication.GetCurrency());
        }
        [HttpGet()]
        [Route("bankaccounttype")]
        public async Task<ActionResult> GetBankAccountTypeCombo()
        {
            return Ok(await _comboboxApplication.GetBankAccountType());
        }
        [HttpGet()]
        [Route("fambondytype")]
        public async Task<ActionResult> GetFamilyBondyTypeCombo()
        {
            return Ok(await _comboboxApplication.GetFamilyBondyType());
        }
        [HttpGet()]
        [Route("legalpersontype")]
        public async Task<ActionResult> GetLegalPersonTypeCombo()
        {
            return Ok(await _comboboxApplication.GetLegalPersonType());
        }
        [HttpGet()]
        [Route("creditrisk")]
        public async Task<ActionResult> GetCreditRiskCombo()
        {
            return Ok(await _comboboxApplication.GetCreditRisk());
        }
        [HttpGet()]
        [Route("companyreputation")]
        public async Task<ActionResult> GetCompanyReputationCombo()
        {
            return Ok(await _comboboxApplication.GetCompanyReputation());
        }
        [HttpGet()]
        [Route("paymentpolicy")]
        public async Task<ActionResult> GetPaymentPolicyCombo()
        {
            return Ok(await _comboboxApplication.GetPaymentPolicy());
        }
        [HttpGet()]
        [Route("legalregister")]
        public async Task<ActionResult> GetLegalRegisterSituationCombo()
        {
            return Ok(await _comboboxApplication.GetLegalRegisterSituation());
        }
        [HttpGet()]
        [Route("subscriberCategories")]
        public async Task<ActionResult> GetSubscriberCategory()
        {
            return Ok(await _comboboxApplication.GetSubscriberCategories());
        }
        [HttpGet()]
        [Route("financialSituation")]
        public async Task<ActionResult> GetFinancialSituacion()
        {
            return Ok(await _comboboxApplication.GetFinancialSituacion());
        }
        [HttpGet()]
        [Route("collaborationDegree")]
        public async Task<ActionResult> GetCollaborationDegree()
        {
            return Ok(await _comboboxApplication.GetCollaborationDegree());
        }
        [HttpGet()]
        [Route("opcionalCommentarySbs")]
        public async Task<ActionResult> GetOpcionalCommentarySbs()
        {
            return Ok(await _comboboxApplication.GetOpcionalCommentarySbs());
        }
        [HttpGet()]
        [Route("branchSector")]
        public async Task<ActionResult> GetBranchSector()
        {
            return Ok(await _comboboxApplication.GetBranchSector());
        }
        [HttpGet()]
        [Route("businessBranch")]
        public async Task<ActionResult> GetBusinessBranch()
        {
            return Ok(await _comboboxApplication.GetBusinessBranch());
        }
        [HttpGet()]
        [Route("businessActivity")]
        public async Task<ActionResult> GetBusinessActivity(int idBusinessBranch)
        {
            return Ok(await _comboboxApplication.GetBusinessActivity(idBusinessBranch));
        }
        [HttpGet()]
        [Route("landOwnership")]
        public async Task<ActionResult> GetLandOwnership()
        {
            return Ok(await _comboboxApplication.GetLandOwnership());
        }
        [HttpGet()]
        [Route("personSituation")]
        public async Task<ActionResult> GetPersonSituation()
        {
            return Ok(await _comboboxApplication.GetPersonSituation());
        }
        [HttpGet()]
        [Route("profession")]
        public async Task<ActionResult> GetProfession()
        {
            return Ok(await _comboboxApplication.GetProfession());
        }
    }
}
