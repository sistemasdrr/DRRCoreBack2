using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Application.Main.CoreApplication
{
    public class ComboboxApplication : IComboboxApplication
    {
        private readonly IDocumentTypeDomain _documentTypeDomain;
        private readonly ICivilStatusDomain _civilStatusDomain;
        private readonly ICountryDomain _countryDomain;
        private readonly IJobDepartmentDomain _jobDepartmentDomain;
        private readonly IJobDomain _jobDomain;
        private readonly ICurrencyDomain _currencyDomain;
        private readonly IFamilyBondyTypeDomain _familyBondyTypeDomain;
        private readonly IBankAccountTypeDomain _bankAccountTypeDomain;
        private readonly ILegalPersonTypeDomain _legalPersonTypeDomain;
        private readonly ICreditRiskDomain _creditRiskDomain;
        private readonly IPaymentPolicyDomain _paymentPolicyDomain;
        private readonly IReputationDomain _reputationDomain;
        private readonly ILegalRegisterSituationDomain _legalRegisterSituationDomain;
        private readonly ISubscriberCategoryDomain _subscriberCategoryDomain;
        private readonly IFinancialSituacionDomain _financialSituacionDomain;
        private readonly ICollaborationDegreeDomain _collaborationDegreeDomain;
        private readonly IOpcionalCommentarySbsDomain _opcionalCommentarySbsDomain;
        private readonly IBranchSectorDomain _branchSectorDomain;
        private readonly IBusinessBranchDomain _businessBranchDomain;
        private readonly IBusinessActivityDomain _businessActivityDomain;
        private readonly ILandOwnershipDomain _landOwnershipDomain;
        private readonly IPersonSituationDomain _personSituationDomain;
        private readonly IProfessionDomain _professionDomain;
        private readonly IUserLoginDomain _userLoginDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ComboboxApplication(IDocumentTypeDomain documentTypeDomain,
                                   ICivilStatusDomain civilStatusDomain,
                                   ICountryDomain countryDomain,
                                   IJobDepartmentDomain jobDepartmentDomain,
                                   IFamilyBondyTypeDomain familyBondyTypeDomain,
                                   IBankAccountTypeDomain bankAccountTypeDomain,
                                   ICurrencyDomain currencyDomain,
                                   ILegalPersonTypeDomain legalPersonTypeDomain,
                                   ICreditRiskDomain creditRiskDomain,
                                   IPaymentPolicyDomain paymentPolicyDomain,
                                   IReputationDomain reputationDomain,
                                   ILegalRegisterSituationDomain legalRegisterSituationDomain,
                                   ISubscriberCategoryDomain subscriberCategoryDomain,
                                   IFinancialSituacionDomain financialSituacionDomain,
                                   ICollaborationDegreeDomain collaborationDegreeDomain,
                                   IOpcionalCommentarySbsDomain opcionalCommentarySbsDomain,
                                   IBranchSectorDomain branchSectorDomain,
                                   IBusinessBranchDomain businessBranchDomain,
                                   IBusinessActivityDomain businessActivityDomain,
                                   ILandOwnershipDomain landOwnershipDomain,
                                   IPersonSituationDomain personSituationDomain,
                                   IProfessionDomain professionDomain,
                                   IJobDomain jobDomain,
                                   IUserLoginDomain userLoginDomain,
                                    IMapper mapper,ILogger logger) { 
        
            _documentTypeDomain = documentTypeDomain;
            _mapper = mapper;
            _logger = logger;
            _civilStatusDomain = civilStatusDomain;
            _countryDomain = countryDomain;
            _jobDepartmentDomain = jobDepartmentDomain;
            _currencyDomain = currencyDomain;
            _bankAccountTypeDomain = bankAccountTypeDomain;
            _familyBondyTypeDomain = familyBondyTypeDomain;
            _legalPersonTypeDomain = legalPersonTypeDomain;
            _creditRiskDomain = creditRiskDomain;
            _paymentPolicyDomain = paymentPolicyDomain;
            _legalRegisterSituationDomain = legalRegisterSituationDomain;
            _reputationDomain= reputationDomain;
            _jobDomain = jobDomain;
            _subscriberCategoryDomain = subscriberCategoryDomain;
            _collaborationDegreeDomain = collaborationDegreeDomain;
            _financialSituacionDomain = financialSituacionDomain;
            _opcionalCommentarySbsDomain = opcionalCommentarySbsDomain;
            _branchSectorDomain = branchSectorDomain;
            _businessBranchDomain = businessBranchDomain;
            _businessActivityDomain = businessActivityDomain;
            _personSituationDomain= personSituationDomain;
            _landOwnershipDomain = landOwnershipDomain;
            _professionDomain = professionDomain;
            _userLoginDomain = userLoginDomain;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetBankAccountType()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _bankAccountTypeDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetBranchSector()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _branchSectorDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueEngResponseDto>>> GetBusinessActivity(int idBusinessBranch)
        {
            var response = new Response<List<GetComboValueEngResponseDto>>();
            try
            {
                var list = await _businessActivityDomain.GetAllByIdBranch(idBusinessBranch);
                response.Data = _mapper.Map<List<GetComboValueEngResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetBusinessBranch()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _businessBranchDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetCivilStatus()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _civilStatusDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetCollaborationDegree()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _collaborationDegreeDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboColorResponseDto>>> GetCompanyReputation()
        {
            var response = new Response<List<GetComboColorResponseDto>>();
            try
            {
                var list = await _reputationDomain.GetAllCompanyReputationAsync();
                response.Data = _mapper.Map<List<GetComboColorResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetContinents()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _countryDomain.GetContinents();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueFlagResponseDto>>> GetCountries()
        {
            var response = new Response<List<GetComboValueFlagResponseDto>>();
            try
            {
                var list = await _countryDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueFlagResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueFlagResponseDto>>> GetCountriesByContinent(int idContinent)
        {
            var response = new Response<List<GetComboValueFlagResponseDto>>();
            try
            {
                var list = await _countryDomain.GetCountriesByContinent(idContinent);
                response.Data = _mapper.Map<List<GetComboValueFlagResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetComboValueFlagResponseDto>> GetCountryById(int idCountry)
        {
            var response = new Response<GetComboValueFlagResponseDto>();
            try
            {
                var country = await _countryDomain.GetByIdAsync(idCountry);
                response.Data = _mapper.Map<GetComboValueFlagResponseDto>(country);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboCreditRiskResponseDto>>> GetCreditRisk()
        {
            var response = new Response<List<GetComboCreditRiskResponseDto>>();
            try
            {
                var list = await _creditRiskDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboCreditRiskResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetCurrency()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _currencyDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetDepartment()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _jobDepartmentDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetDocumentType()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            response.Data = new List<GetComboValueResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var docs = await context.DocumentTypes.ToListAsync();
                foreach (var item in docs)
                {
                    response.Data.Add(new GetComboValueResponseDto
                    {
                        Id = item.Id,
                        Valor = item.Abreviation + " - " + item.Name
                    });

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetDocumentTypeNatural()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _documentTypeDomain.GetAllNaturalDocumentAsync();               
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetFamilyBondyType()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _familyBondyTypeDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetFinancialSituationResponseDto>>> GetFinancialSituacion()
        {
            var response = new Response<List<GetFinancialSituationResponseDto>>();
            try
            {
                var list = await _financialSituacionDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetFinancialSituationResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetJobByDepartment(int idDepartment)
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _jobDomain.GetJobByDepartment(idDepartment);
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetLandOwnership()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _landOwnershipDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetLegalPersonType()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _legalPersonTypeDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetLegalRegisterSituation()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _legalRegisterSituationDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetOpcionalCommentarySbs()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _opcionalCommentarySbsDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboColorResponseDto>>> GetPaymentPolicy()
        {
            var response = new Response<List<GetComboColorResponseDto>>();
            try
            {
                var list = await _paymentPolicyDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboColorResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetPersonSituation()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _personSituationDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetProfession()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _professionDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetReasonTicket()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Reasons.Where(x => x.Enable == true).ToListAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetComboValueResponseDto>>> GetSubscriberCategories()
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _subscriberCategoryDomain.GetAllAsync();
                response.Data = _mapper.Map<List<GetComboValueResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetComboNameValueResponseDto>>> GetUserEmails()
        {
            var response = new Response<List<GetComboNameValueResponseDto>>();
            try
            {
                var list = await _userLoginDomain.GetUserLoginEmails();
                response.Data = _mapper.Map<List<GetComboNameValueResponseDto>>(list);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Message = Messages.BadQuery;
                response.IsSuccess = false;
                
            }
            return response;
        }
    }
}
