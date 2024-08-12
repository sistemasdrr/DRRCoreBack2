using AutoMapper;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using log4net.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DRRCore.Application.Main.CoreApplication
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly int idUser;
        private readonly ClaimsIdentity claims;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITCuponDomain _tCuponDomain;
        private readonly ICompanyDomain _companyDomain;
        private readonly ICompanyBackgroundDomain _companyBackgroundDomain;
        private readonly ICompanyBranchDomain _companyBranchDomain;
        private readonly ICompanyFinancialInformationDomain _companyFinancialInformationDomain;
        private readonly IFinancialSalesHistoryDomain _financialSalesHistoryDomain;
        private readonly IFinancialBalanceDomain _financialBalanceDomain;
        private readonly IProviderDomain _providerDomain;
        private readonly IComercialLatePaymentDomain _comercialLatePaymentDomain;
        private readonly IBankDebtDomain _bankDebtDomain;
        private readonly ICompanySBSDomain _companySBSDomain;
        private readonly IEndorsementsDomain _endorsementsDomain;
        private readonly ICompanyCreditOpinionDomain _companyCreditOpinionDomain;
        private readonly ICompanyGeneralInformationDomain _companyGeneralInformationDomain;
        private readonly IImportsAndExportsDomain _importsAndExportsDomain;
        private readonly ICompanyPartnersDomain _companyPartnersDomain;
        private readonly ICompanyShareHolderDomain _companyShareHolderDomain;
        private readonly IWorkerHistoryDomain _workerHistoryDomain;
        private readonly ICompanyRelationDomain _companyRelationDomain;
        private readonly IReportingDownload _reportingDownload;
        private readonly ICompanyImageDomain _companyImagesDomain;
        private readonly ITicketDomain _ticketDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CompanyApplication(ICompanyDomain companyDomain,ICompanyBackgroundDomain companyBackgroundDomain, ICompanyBranchDomain companyBranchDomain,
            ICompanyFinancialInformationDomain companyFinancialInformationDomain, IMapper mapper, ILogger logger, ICompanyShareHolderDomain companyShareHolderDomain,
            IFinancialSalesHistoryDomain financialSalesHistoryDomain, IFinancialBalanceDomain financialBalanceDomain, IWorkerHistoryDomain workerHistoryDomain,
            IProviderDomain providerDomain, IComercialLatePaymentDomain comercialLatePaymentDomain, IBankDebtDomain bankDebtDomain, ICompanyRelationDomain companyRelationDomain,
            ICompanySBSDomain companySBSDomain, IEndorsementsDomain endorsementsDomain, ICompanyCreditOpinionDomain companyCreditOpinionDomain, ICompanyImageDomain companyImagesDomain,
            ICompanyGeneralInformationDomain companyGeneralInformationDomain,
            IReportingDownload reportingDownload,
            ITicketDomain ticketDomain,
            ITCuponDomain tCuponDomain,
            IImportsAndExportsDomain importsAndExportsDomain, ICompanyPartnersDomain companyPartnersDomain, IHttpContextAccessor httpContextAccessor)
        {
            _companyDomain = companyDomain;
            _companyBackgroundDomain = companyBackgroundDomain;
            _companyBranchDomain = companyBranchDomain;
            _companyFinancialInformationDomain = companyFinancialInformationDomain;
            _financialSalesHistoryDomain = financialSalesHistoryDomain;
            _financialBalanceDomain = financialBalanceDomain;
            _providerDomain = providerDomain;
            _comercialLatePaymentDomain = comercialLatePaymentDomain;
            _bankDebtDomain = bankDebtDomain;
            _companySBSDomain = companySBSDomain;
            _endorsementsDomain = endorsementsDomain;
            _companyCreditOpinionDomain = companyCreditOpinionDomain;
            _companyGeneralInformationDomain = companyGeneralInformationDomain;
            _importsAndExportsDomain = importsAndExportsDomain;
            _companyPartnersDomain = companyPartnersDomain;
            _companyShareHolderDomain = companyShareHolderDomain;
            _workerHistoryDomain = workerHistoryDomain;
            _companyRelationDomain = companyRelationDomain;
            _ticketDomain= ticketDomain;           
            _companyImagesDomain = companyImagesDomain;
            _mapper = mapper;
            _logger = logger;
            _reportingDownload=reportingDownload;
            _httpContextAccessor = httpContextAccessor;
            claims = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
        }
        public async Task<Response<int>> AddOrUpdateAsync(AddOrUpdateCompanyRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage=1,
                            LastUpdaterUser=1
                        });
                    }
                    var newCompany = _mapper.Map<Domain.Entities.SqlCoreContext.Company>(obj);
                    newCompany.Traductions = traductions;
                     response.Data = await _companyDomain.AddCompanyAsync(newCompany);
                }
                else
                {
                    using var context = new SqlCoreContext();
                    var existingCompany = await context.Companies
                    .Where(x => x.Id == obj.Id)
                    .Include(x => x.CompanyFinancialInformations)
                    .Include(x => x.TraductionCompanies)
                   .FirstOrDefaultAsync();


                    if (existingCompany == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFoundEmployee;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCompany = _mapper.Map(obj, existingCompany);
                    existingCompany.Since = obj.Since;
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCompany.Traductions= traductions;
                    existingCompany.UpdateDate = DateTime.Now;
                    await _companyDomain.UpdateAsync(existingCompany);
                    response.Data = existingCompany.Id;
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

        public async Task<Response<int?>> AddOrUpdateCompanyBackGroundAsync(AddOrUpdateCompanyBackgroundRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int?>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newCompany = _mapper.Map<CompanyBackground>(obj);                   
                    response.Data = await _companyBackgroundDomain.AddAsync(newCompany,traductions);
                }
                else
                {
                    using var context = new SqlCoreContext();
                    var existingCompany = await context.CompanyBackgrounds
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if (existingCompany == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCompany = _mapper.Map(obj, existingCompany);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCompany.UpdateDate = DateTime.Now;
                    response.Data = await _companyBackgroundDomain.UpdateAsync(existingCompany,traductions);
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

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                }
                response.Data = await _companyDomain.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListCompanyResponseDto>>> GetAllCompanys(string name, string form, int idCountry, bool haveReport, string filterBy)
        {
            var response = new Response<List<GetListCompanyResponseDto>>();
            try
            {
                if (filterBy != "S")
                {
                    var company = await _companyDomain.GetByNameAsync(name, form, idCountry, haveReport, filterBy);
                    if (company == null)
                    {
                        response.IsSuccess = true;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                    }
                    response.Data = _mapper.Map<List<GetListCompanyResponseDto>>(company);
                }
                else
                {
                    var ticket = await _ticketDomain.GetByNameAsync(name,"E");
                    var mapper= _mapper.Map<List<GetListCompanyResponseDto>>(ticket);

                    var oldTicket = await _ticketDomain.GetSimilarByNameAsync(name,"E");
                    if (oldTicket.Any())
                    {
                        foreach (var item in oldTicket)
                        {
                            var company = await _companyDomain.GetByOldCode(item.Empresa);
                            if (company != null)
                            {
                                mapper.Add(new GetListCompanyResponseDto
                                {
                                    Name = item.NombreSolicitado,
                                    DispatchedName = item.NombreDespachado,
                                    Language = item.Idioma,
                                    Id = company.Id,
                                    Country =company.IdCountryNavigation.Name,
                                    IsoCountry= company.IdCountryNavigation.Iso,
                                    FlagCountry=company.IdCountryNavigation.FlagIso,
                                    Code=company.OldCode
                                });
                            }
                        }
                    }    
                    mapper = mapper.DistinctBy(x=>x.Name).DistinctBy(x => x.Code).ToList();
                    response.Data = mapper;
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

        public async Task<Response<GetCompanyResponseDto>> GetCompanyById(int id)
        {
            var response = new Response<GetCompanyResponseDto>();
            try
            {
                var company = await _companyDomain.GetByIdAsync(id);
                if (company == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyResponseDto>(company);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetCompanyBackgroundResponseDto>> GetCompanyBackgroundById(int id)
        {
            var response = new Response<GetCompanyBackgroundResponseDto>();
            try
            {
                var company = await _companyBackgroundDomain.GetByIdAsync(id);
                if (company == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyBackgroundResponseDto>(company);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> ActiveWebVisionAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                }
                response.Data = await _companyDomain.ActiveWebVision(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DesactiveWebVisionAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                }
                response.Data = await _companyDomain.DesactiveWebVision(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<int>> AddOrUpdateCompanyFinancialInformationAsync(AddOrUpdateCompanyFinancialInformationRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newCompany = _mapper.Map<CompanyFinancialInformation>(obj);
                    response.Data = await _companyFinancialInformationDomain.AddCompanyFinancialInformation(newCompany, traductions);
                }
                else
                {
                    using var context = new SqlCoreContext();
                    var existingCompany = await context.CompanyFinancialInformations
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if (existingCompany == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCompany = _mapper.Map(obj, existingCompany);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCompany.UpdateDate = DateTime.Now;
                    response.Data = await _companyFinancialInformationDomain.UpdateCompanyFinancialInformation(existingCompany, traductions);
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

        public async Task<Response<GetCompanyFinancialInformationResponseDto>> GetCompanyFinancialInformationById(int id)
        {
            var response = new Response<GetCompanyFinancialInformationResponseDto>();
            try
            {
                var company = await _companyFinancialInformationDomain.GetByIdAsync(id);
                if (company == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyFinancialInformationResponseDto>(company);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetCompanyFinancialInformationResponseDto>> GetCompanyFinancialInformationByIdCompany(int idCompany)
        {
            var response = new Response<GetCompanyFinancialInformationResponseDto>();
            try
            {
                var company = await _companyFinancialInformationDomain.GetByIdCompany(idCompany);
                if (company == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyFinancialInformationResponseDto>(company);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateSaleHistoryAsync(AddOrUpdateSaleHistoryRequestDto obj)
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
                }else if(obj.Id == 0)
                {
                    var newSaleHistory = _mapper.Map<SalesHistory>(obj);
                    response.Data = await _financialSalesHistoryDomain.AddAsync(newSaleHistory);
                }
                else if(obj.Id > 0)
                {
                    var existingSaleHistory = await _financialSalesHistoryDomain.GetByIdAsync(obj.Id);
                    existingSaleHistory = _mapper.Map(obj, existingSaleHistory);
                    response.Data = await _financialSalesHistoryDomain.UpdateAsync(existingSaleHistory);
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListSalesHistoryResponseDto>>> GetListSalesHistoriesByIdCompany(int idCompany)
        {
            var response = new Response<List<GetListSalesHistoryResponseDto>>();
            try
            {
                var list = await _financialSalesHistoryDomain.GetByIdCompany(idCompany);
                if(list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }               
                response.Data = _mapper.Map<List<GetListSalesHistoryResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetSaleHistoryResponseDto>> GetSaleHistoryById(int id)
        {
            var response = new Response<GetSaleHistoryResponseDto>();
            try
            {
                var saleHistory = await _financialSalesHistoryDomain.GetByIdAsync(id);
                if(saleHistory == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetSaleHistoryResponseDto>(saleHistory);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteSaleHistory(int id)
        {
            var response = new Response<bool>();
            try
            {
                if(id == 0 || id == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = await _financialSalesHistoryDomain.DeleteAsync(id);
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateFinancialBalanceAsync(AddOrUpdateFinancialBalanceRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                if(obj.Id == 0)
                {
                    var newBalance = _mapper.Map<FinancialBalance>(obj);
                    response.Data = await _financialBalanceDomain.AddAsync(newBalance);
                }
                else
                {
                    var existingBalance = await _financialBalanceDomain.GetByIdAsync(obj.Id);
                    existingBalance = _mapper.Map(obj, existingBalance);
                    response.Data = await _financialBalanceDomain.UpdateAsync(existingBalance);
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

        public async Task<Response<List<GetComboValueResponseDto>>> GetListFinancialBalanceAsync(int idCompany, string balanceType)
        {
            var response = new Response<List<GetComboValueResponseDto>>();
            try
            {
                var list = await _financialBalanceDomain.GetFinancialBalanceByIdCompany(idCompany, balanceType);
                if(list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
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

        public async Task<Response<GetFinancialBalanceResponseDto>> GetFinancialBalanceById(int id)
        {
            var response = new Response<GetFinancialBalanceResponseDto>();
            try
            {
                var balance = await _financialBalanceDomain.GetByIdAsync(id);
                if (balance == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetFinancialBalanceResponseDto>(balance);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteFinancialBalance(int id)
        {
            var response = new Response<bool>();
            try
            {
                var balance = await _financialBalanceDomain.GetByIdAsync(id);
                if (balance == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _financialBalanceDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> AddOrUpdateProviderAsync(AddOrUpdateProviderRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newProvider = _mapper.Map<Provider>(obj);
                    response.Data = await _providerDomain.AddAsync(newProvider);
                }
                else
                {
                    var existingProvider = await _providerDomain.GetByIdAsync(obj.Id);
                    existingProvider = _mapper.Map(obj, existingProvider);
                    response.Data = await _providerDomain.UpdateAsync(existingProvider);
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

        public async Task<Response<List<GetListProviderResponseDto>>> GetListProvidersAsync(int idCompany)
        {
            var response = new Response<List<GetListProviderResponseDto>>();
            response.Data = new List<GetListProviderResponseDto>();
            try
            {
                var list = await _providerDomain.GetProvidersByIdCompany(idCompany);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                using var context = new SqlCoreContext();
                foreach (var item in list)
                {
                    var ticket = new Ticket();
                    if (item.IdTicket != null)
                    {
                        ticket = await context.Tickets.Where(x => x.Id == item.IdTicket).FirstOrDefaultAsync();
                    }
                    response.Data.Add(new GetListProviderResponseDto
                    {
                        Id = item.Id,
                        IdCompany = item.IdCompany,
                        IdPerson = item.IdPerson,
                        Name = item.Name,
                        IdCountry = item.IdCountry,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Date = StaticFunctions.DateTimeToString(item.Date),
                        DateReferent = StaticFunctions.DateTimeToString(item.DateReferent),
                        Qualification = item.Qualification,
                        QualificationEng = item.QualificationEng,
                        AdditionalCommentary = item.AdditionalCommentary,
                        AdditionalCommentaryEng = item.AdditionalCommentaryEng,
                        AttendedBy = item.AttendedBy,
                        MaximumAmount = item.MaximumAmount,
                        MaximumAmountEng = item.MaximumAmountEng,
                        ClientSince = item.ClientSince,
                        ClientSinceEng  = item.ClientSinceEng,
                        Compliance = item.Compliance,
                        ComplianceEng  = item.ComplianceEng,
                        IdCurrency = item.IdCurrency,
                        ReferentCommentary = item.ReferentCommentary,
                        Telephone = item.Telephone,
                        TimeLimitEng = item.TimeLimitEng,
                        TimeLimit = item.TimeLimit,
                        IdTicket = item.IdTicket,
                        Ticket = item.Ticket == null ? ticket?.Number.ToString("D6") : item.Ticket,
                        ProductsTheySell = item.ProductsTheySell,
                        ProductsTheySellEng = item.ProductsTheySellEng,
                        ReferentName = item.ReferentName,

                    });
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
        public async Task<Response<GetProviderResponseDto>> GetProviderById(int id)
        {
            var response = new Response<GetProviderResponseDto>();
            try
            {
                var provider = await _providerDomain.GetByIdAsync(id);
                if (provider == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetProviderResponseDto>(provider);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteProvider(int id)
        {
            var response = new Response<bool>();
            try
            {
                var provider = await _providerDomain.GetByIdAsync(id);
                if (provider == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _providerDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> AddOrUpdateComercialLatePaymentAsync(AddOrUpdateComercialLatePaymentRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    var newComercialLatePayment = _mapper.Map<ComercialLatePayment>(obj);
                    response.Data = await _comercialLatePaymentDomain.AddAsync(newComercialLatePayment);
                }
                else
                {
                    var existingComercialLatePayment = await _comercialLatePaymentDomain.GetByIdAsync(obj.Id);
                    existingComercialLatePayment = _mapper.Map(obj, existingComercialLatePayment);
                    response.Data = await _comercialLatePaymentDomain.UpdateAsync(existingComercialLatePayment);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListComercialLatePaymentResponseDto>>> GetListComercialLatePaymentAsync(int idCompany)
        {
            var response = new Response<List<GetListComercialLatePaymentResponseDto>>();
            try
            {
                var list = await _comercialLatePaymentDomain.GetComercialLatePaymetByIdCompany(idCompany);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<List<GetListComercialLatePaymentResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetComercialLatePaymentResponseDto>> GetComercialLatePaymentById(int id)
        {
            var response = new Response<GetComercialLatePaymentResponseDto>();
            try
            {
                var comercialLatePayment = await _comercialLatePaymentDomain.GetByIdAsync(id);
                if (comercialLatePayment == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetComercialLatePaymentResponseDto>(comercialLatePayment);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteComercialLatePayment(int id)
        {
            var response = new Response<bool>();
            try
            {
                var comercialLatePayment = await _comercialLatePaymentDomain.GetByIdAsync(id);
                if (comercialLatePayment == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _comercialLatePaymentDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> AddOrUpdateBankDebtAsync(AddOrUpdateBankDebtRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    var newBankDebt = _mapper.Map<BankDebt>(obj);
                    response.Data = await _bankDebtDomain.AddAsync(newBankDebt);
                }
                else
                {
                    var existingBankDebt = await _bankDebtDomain.GetByIdAsync(obj.Id);
                    existingBankDebt = _mapper.Map(obj, existingBankDebt);
                    response.Data = await _bankDebtDomain.UpdateAsync(existingBankDebt);
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

        public async Task<Response<List<GetListBankDebtResponseDto>>> GetListBankDebtAsync(int idCompany)
        {
            var response = new Response<List<GetListBankDebtResponseDto>>();
            try
            {
                var list = await _bankDebtDomain.GetBankDebtsByIdCompany(idCompany);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<List<GetListBankDebtResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetBankDebtResponseDto>> GetBankDebtById(int id)
        {
            var response = new Response<GetBankDebtResponseDto>();
            try
            {
                var bankDebt = await _bankDebtDomain.GetByIdAsync(id);
                if (bankDebt == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetBankDebtResponseDto>(bankDebt);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteBankDebt(int id)
        {
            var response = new Response<bool>();
            try
            {
                var bankDebt = await _bankDebtDomain.GetByIdAsync(id);
                if (bankDebt == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _bankDebtDomain.DeleteAsync(id);
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

        public async Task<Response<int>> AddOrUpdateCompanySBSAsync(AddOrUpdateCompanySbsRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newCompanySbs = _mapper.Map<CompanySb>(obj);
                    response.Data = await _companySBSDomain.AddCompanySBS(newCompanySbs, traductions);
                }
                else
                {
                    using var context = new SqlCoreContext();
                    var existingCompanySbs = await context.CompanySbs
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Where(x => x.IdCompany == obj.IdCompany).FirstOrDefaultAsync();
                    if (existingCompanySbs == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCompanySbs = _mapper.Map(obj, existingCompanySbs);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCompanySbs.UpdateDate = DateTime.Now;
                    response.Data = await _companySBSDomain.UpdateCompanySBS(existingCompanySbs, traductions);
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

        public async Task<Response<GetCompanySbsResponseDto>> GetCompanySBSById(int id)
        {
            var response = new Response<GetCompanySbsResponseDto>();
            try
            {
                var companySbs = await _companySBSDomain.GetByIdCompany(id);
                if (companySbs == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanySbsResponseDto>(companySbs);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCompanySBS(int id)
        {
            var response = new Response<bool>();
            try
            {
                var bankDebt = await _companySBSDomain.GetByIdAsync(id);
                if (bankDebt == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _companySBSDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> AddOrUpdateEndorsementsAsync(AddOrUpdateEndorsementsRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    var newEndorsement = _mapper.Map<Endorsement>(obj);
                    response.Data = await _endorsementsDomain.AddAsync(newEndorsement);
                }
                else
                {
                    var existingEndorsement = await _endorsementsDomain.GetByIdAsync(obj.Id);
                    existingEndorsement = _mapper.Map(obj, existingEndorsement);
                    response.Data = await _endorsementsDomain.UpdateAsync(existingEndorsement);
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

        public async Task<Response<List<GetEndorsementsResponseDto>>> GetListEndorsementsAsync(int idCompany)
        {
            var response = new Response<List<GetEndorsementsResponseDto>>();
            try
            {
                var list = await _endorsementsDomain.GetByIdCompany(idCompany);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<List<GetEndorsementsResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetEndorsementsResponseDto>> GetEndorsementsById(int id)
        {
            var response = new Response<GetEndorsementsResponseDto>();
            try
            {
                var endorsement = await _endorsementsDomain.GetByIdAsync(id);
                if (endorsement == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetEndorsementsResponseDto>(endorsement);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteEndorsements(int id)
        {
            var response = new Response<bool>();
            try
            {
                var endorsement = await _endorsementsDomain.GetByIdAsync(id);
                if (endorsement == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _endorsementsDomain.DeleteAsync(id);
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

        public async Task<Response<int>> AddOrUpdateCreditOpinionAsync(AddOrUpdateCompanyCreditOpinionRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newCreditOpinion = _mapper.Map<CompanyCreditOpinion>(obj);
                    response.Data = await _companyCreditOpinionDomain.AddCreditOpinion(newCreditOpinion, traductions);
                }
                else
                {
                    var existingCreditOpinion = await _companyCreditOpinionDomain.GetByIdCompany((int)obj.IdCompany);
                    if (existingCreditOpinion == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCreditOpinion = _mapper.Map(obj, existingCreditOpinion);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCreditOpinion.UpdateDate = DateTime.Now;
                    response.Data = await _companyCreditOpinionDomain.UpdateCreditOpinion(existingCreditOpinion, traductions);
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

        public async Task<Response<GetCompanyCreditOpinionResponseDto>> GetCreditOpinionByIdCompany(int idCompany)
        {
            var response = new Response<GetCompanyCreditOpinionResponseDto>();
            try
            {
                var creditOpinion = await _companyCreditOpinionDomain.GetByIdCompany(idCompany);
                if (creditOpinion == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyCreditOpinionResponseDto>(creditOpinion);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCreditOpinion(int id)
        {
            var response = new Response<bool>();
            try
            {
                var companyCreditOpinion = await _companyCreditOpinionDomain.GetByIdAsync(id);
                if (companyCreditOpinion == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _companyCreditOpinionDomain.DeleteAsync(id);
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

        public async Task<Response<int>> AddOrUpdateGeneralInformation(AddOrUpdateCompanyGeneralInformationRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newGeneralInformation = _mapper.Map<CompanyGeneralInformation>(obj);
                    response.Data = await _companyGeneralInformationDomain.AddGeneralInformation(newGeneralInformation, traductions);
                }
                else
                {
                    var existingGeneralInformation = await _companyGeneralInformationDomain.GetByIdCompany((int)obj.IdCompany);
                    if (existingGeneralInformation == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingGeneralInformation = _mapper.Map(obj, existingGeneralInformation);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingGeneralInformation.UpdateDate = DateTime.Now;
                    response.Data = await _companyGeneralInformationDomain.UpdateGeneralInformation(existingGeneralInformation, traductions);
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

        public async Task<Response<GetCompanyGeneralInformationResponseDto>> GetGeneralInformationByIdCompany(int idCompany)
        {
            var response = new Response<GetCompanyGeneralInformationResponseDto>();
            try
            {
                var generalInformation = await _companyGeneralInformationDomain.GetByIdCompany(idCompany);
                if (generalInformation == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyGeneralInformationResponseDto>(generalInformation);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<int>> AddOrUpdateCompanyBranchAsync(AddOrUpdateCompanyBranchRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            var response = new Response<int>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newCompanyBranch= _mapper.Map<CompanyBranch>(obj);
                    response.Data = await _companyBranchDomain.AddAsync(newCompanyBranch, traductions);
                }
                else
                {
                    using var context = new SqlCoreContext();
                    var existingCompanyBranch = await context.CompanyBranches
                    .Include(x => x.IdCompanyNavigation).ThenInclude(x => x.TraductionCompanies)
                    .Include(x => x.IdLandOwnershipNavigation)
                    .Where(x => x.IdCompany == obj.IdCompany)
                    .FirstOrDefaultAsync();
                    if (existingCompanyBranch == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingCompanyBranch = _mapper.Map(obj, existingCompanyBranch);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingCompanyBranch.UpdateDate = DateTime.Now;
                    response.Data = await _companyBranchDomain.UpdateAsync(existingCompanyBranch, traductions);
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

        public async Task<Response<GetCompanyBranchResponseDto>> GetCompanyBranchByIdCompany(int idCompany)
        {
            var response = new Response<GetCompanyBranchResponseDto>();
            try
            {
                var companyBranch = await _companyBranchDomain.GetCompanyBranchByIdCompany(idCompany);
                if (companyBranch == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyBranchResponseDto>(companyBranch);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteImportAndExport(int id)
        {
            var response = new Response<bool>();
            try
            {
                var importAndExport = await _importsAndExportsDomain.GetByIdAsync(id);
                if (importAndExport == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _importsAndExportsDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> AddOrUpdateImportAndExport(AddOrUpdateImportsAndExportsRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newImportAndExport = _mapper.Map<ImportsAndExport>(obj);
                    response.Data = await _importsAndExportsDomain.AddAsync(newImportAndExport);
                }
                else
                {
                    var existingImportAndExport = await _importsAndExportsDomain.GetByIdAsync((int)obj.Id);
                    if (existingImportAndExport == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingImportAndExport = _mapper.Map(obj, existingImportAndExport);
                    existingImportAndExport.UpdateDate = DateTime.Now;
                    response.Data = await _importsAndExportsDomain.UpdateAsync(existingImportAndExport);
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

        public async Task<Response<GetImportsAndExportResponseDto>> GetImportAndExportById(int id)
        {
            var response = new Response<GetImportsAndExportResponseDto>();
            try
            {
                var importAndExport = await _importsAndExportsDomain.GetByIdAsync(id);
                if (importAndExport == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetImportsAndExportResponseDto>(importAndExport);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetImportsAndExportResponseDto>>> GetListImportAndExportByIdCompany(int idCompany, string type)
        {
            var response = new Response<List<GetImportsAndExportResponseDto>>();
            try
            {
                if(type == "I")
                {
                    var list = await _importsAndExportsDomain.GetImports(idCompany);
                    response.Data = _mapper.Map<List<GetImportsAndExportResponseDto>>(list);

                }
                else if(type == "E") 
                {
                    var list = await _importsAndExportsDomain.GetExports(idCompany);
                    response.Data = _mapper.Map<List<GetImportsAndExportResponseDto>>(list);
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

        public async Task<Response<bool>> AddOrUpdateCompanyPartner(AddOrUpdateCompanyPartnersRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newObj= _mapper.Map<CompanyPartner>(obj);
                    response.Data = await _companyPartnersDomain.AddAsync(newObj);
                }
                else
                {
                    var existingObj= await _companyPartnersDomain.GetByIdAsync((int)obj.Id);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _companyPartnersDomain.UpdateAsync(existingObj);
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

        public async Task<Response<GetCompanyPartnersResponseDto>> GetCompanyPartnerById(int id)
        {
            var response = new Response<GetCompanyPartnersResponseDto>();
            try
            {
                var obj = await _companyPartnersDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyPartnersResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCompanyPartner(int id)
        {
            var response = new Response<bool>();
            try
            {
                var obj = await _companyPartnersDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _companyPartnersDomain.DeleteAsync(id);
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

        public async Task<Response<List<GetListCompanyPartnersResponseDto>>> GetListCompanyPartnerByIdCompany(int idCompany)
        {
            var response = new Response<List<GetListCompanyPartnersResponseDto>>();
            try
            {
                var list = await _companyPartnersDomain.GetPartnersByIdCompany(idCompany);
                if(list != null)
                {
                    response.Data = _mapper.Map<List<GetListCompanyPartnersResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
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

        public async Task<Response<bool>> AddOrUpdateCompanyShareHolder(AddOrUpdateCompanyShareHolderRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newObj = _mapper.Map<CompanyShareHolder>(obj);
                    response.Data = await _companyShareHolderDomain.AddAsync(newObj);
                }
                else
                {
                    var existingObj = await _companyShareHolderDomain.GetByIdAsync((int)obj.Id);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _companyShareHolderDomain.UpdateAsync(existingObj);
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

        public async Task<Response<GetCompanyShareHolderResponseDto>> GetCompanyShareHolderById(int id)
        {
            var response = new Response<GetCompanyShareHolderResponseDto>();
            try
            {
                var obj = await _companyShareHolderDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyShareHolderResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCompanyShareHolder(int id)
        {
            var response = new Response<bool>();
            try
            {
                var obj = await _companyShareHolderDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _companyShareHolderDomain.DeleteAsync(id);
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

        public async Task<Response<List<GetListCompanyShareHolderResponseDto>>> GetListCompanyShareHolderByIdCompany(int idCompany)
        {
            var response = new Response<List<GetListCompanyShareHolderResponseDto>>();
            try
            {
                var list = await _companyShareHolderDomain.GetShareHoldersByIdCompany(idCompany);
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListCompanyShareHolderResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
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

        public async Task<Response<bool>> AddOrUpdateWorkerHistory(AddOrUpdateWorkerHistoryRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newObj = _mapper.Map<WorkersHistory>(obj);
                    response.Data = await _workerHistoryDomain.AddAsync(newObj);
                }
                else
                {
                    var existingObj = await _workerHistoryDomain.GetByIdAsync((int)obj.Id);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _workerHistoryDomain.UpdateAsync(existingObj);
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

        public async Task<Response<GetWorkersHistoryResponseDto>> GetWorkerHistoryById(int id)
        {
            var response = new Response<GetWorkersHistoryResponseDto>();
            try
            {
                var obj = await _workerHistoryDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetWorkersHistoryResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteWorkerHistory(int id)
        {
            var response = new Response<bool>();
            try
            {
                var obj = await _workerHistoryDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _workerHistoryDomain.DeleteAsync(id);
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

        public async Task<Response<List<GetListWorkersHistoryResponseDto>>> GetListWorkerHistoryByIdCompany(int idCompany)
        {
            var response = new Response<List<GetListWorkersHistoryResponseDto>>();
            try
            {
                var list = await _workerHistoryDomain.GetByIdCompanyAsync(idCompany);
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListWorkersHistoryResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
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

        public async Task<Response<bool>> AddOrUpdateCompanyRelation(AddOrUpdateCompanyRelationRequestDto obj)
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
                if (obj.Id == 0)
                {
                    var newObj = _mapper.Map<CompanyRelation>(obj);
                    response.Data = await _companyRelationDomain.AddAsync(newObj);
                }
                else
                {
                    var existingObj = await _companyRelationDomain.GetByIdAsync((int)obj.Id);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _companyRelationDomain.UpdateAsync(existingObj);
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
        public async Task<Response<bool>> AddListCompanyRelation(AddListCompanyRelationRequestDto obj)
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
                using var context = new SqlCoreContext();
                if(obj.IdsCompanyRelation != null)
                {
                    foreach (var item in obj.IdsCompanyRelation)
                    {
                        await context.CompanyRelations.AddAsync(new CompanyRelation
                        {
                            Id = 0,
                            IdCompany = obj.IdCompany,
                            IdCompanyRelation = item,
                        });
                    }
                    await context.SaveChangesAsync();
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
        public async Task<Response<GetCompanyRelationResponseDto>> GetCompanyRelationById(int id)
        {
            var response = new Response<GetCompanyRelationResponseDto>();
            try
            {
                var obj = await _companyRelationDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyRelationResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCompanyRelation(int id)
        {
            var response = new Response<bool>();
            try
            {
                var obj = await _companyRelationDomain.GetByIdAsync(id);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _companyRelationDomain.DeleteAsync(id);
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

        public async Task<Response<List<GetListCompanyRelationResponseDto>>> GetListCompanyRelationByIdCompany(int idCompany)
        {
            var response = new Response<List<GetListCompanyRelationResponseDto>>();
            try
            {
                var list = await _companyRelationDomain.GetCompanyRelationByIdCompany(idCompany);
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetListCompanyRelationResponseDto>>(list);
                }
                else
                {
                    response.Data = null;
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

        public async Task<Response<GetFileResponseDto>> DownloadF1(int idCompany,string language, string format)
        {            
            var response = new Response<GetFileResponseDto>();
            try
            {
                var company = await _companyDomain.GetByIdAsync(idCompany);

                string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                string languageFileName = language == "I" ? "ENG" : "ESP";
                string fileFormat ="{0}_{1}{2}" ;
                //string report = language == "I" ? "EIECORE-F1-EMPRESAS" : "EIECORE-F1-EMPRESAS_ES";
                string report = "EMPRESAS/F1-EMPRESAS-ES";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType= StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", idCompany.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                };
               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public string? GetReportName(string language,string format)
        {
            string result = "";
            if(language == "I")
            {
                switch(format.ToLower())
                {
                    case "pdf": result = "EMPRESAS/F8-EMPRESAS-EN"; break;
                    case "word": result = "EMPRESAS/F8-EMPRESAS-WORD-EN"; break;
                }
            }
            else
            {
                switch (format.ToLower())
                {
                    case "pdf": result =  "EMPRESAS/F8-EMPRESAS-ES"; break;
                    case "word": result = "EMPRESAS/F8-EMPRESAS-WORD-ES"; break;
                }
            }
            return result;
        }
        public async Task<Response<GetFileResponseDto>> DownloadF8(int idCompany, string language, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                var company = await _companyDomain.GetByIdAsync(idCompany);

                string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                string languageFileName = language == "I" ? "ENG" : "ESP";
                string fileFormat = "{0}_{1}{2}";
                //string report = language == "I" ? "EMPRESAS/F8-EMPRESAS-EN" : "EMPRESAS/F8-EMPRESAS-ES";
                string report = GetReportName(language,format);
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", idCompany.ToString() },
                    { "idTicket", "" },
                    { "language", language }
                 };

                var file = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary);
                response.Data = new GetFileResponseDto
                {
                    File = file,
                    ContentType = contentType,
                    Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                };

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetStatusCompanyResponseDto>> GetStatusCompany(int idCompany)
        {
            var response = new Response<GetStatusCompanyResponseDto>();
            var status = new GetStatusCompanyResponseDto();
            try
            {
                using var context = new SqlCoreContext();
                var company = await _companyDomain.GetByIdAsync(idCompany);
                if(company != null)
                {
                    status.Company = true;
                    var background = await _companyBackgroundDomain.GetByIdAsync(idCompany);
                    status.Background = background != null ? true : false;
                    var branch = await _companyBranchDomain.GetCompanyBranchByIdCompany(idCompany);
                    status.Branch = branch != null ? true : false;
                    var financial = await _companyFinancialInformationDomain.GetByIdCompany(idCompany);
                    status.Financial = financial != null ? true : false;
                    var balance = await _financialBalanceDomain.GetFinancialBalanceByIdCompany(idCompany, "GENERAL");
                    status.Balance = balance.Count > 0 ? true : false;
                    var sbs = await _companySBSDomain.GetByIdCompany(idCompany);
                    var provider = await _providerDomain.GetProvidersByIdCompany(idCompany);
                    var bankDebt = await _bankDebtDomain.GetBankDebtsByIdCompany(idCompany);
                    var comercial = await _comercialLatePaymentDomain.GetComercialLatePaymetByIdCompany(idCompany);
                    status.Sbs = sbs != null || provider.Count > 0 || bankDebt.Count > 0 || comercial.Count > 0 ? true : false;
                    var opinion = await _companyCreditOpinionDomain.GetByIdCompany(idCompany);
                    status.Opinion = opinion != null ? !opinion.ConsultedCredit.IsNullOrEmpty() || !opinion.SuggestedCredit.IsNullOrEmpty() || !opinion.CurrentCommentary.IsNullOrEmpty() : false;
                    var infoGeneral = await _companyGeneralInformationDomain.GetByIdCompany(idCompany);
                    status.InfoGeneral = infoGeneral != null ? !infoGeneral.GeneralInfo.IsNullOrEmpty() : false;
                    var images = await _companyImagesDomain.GetImagesByIdCompany(idCompany);
                    status.Images = images != null ? !images.Img1.IsNullOrEmpty() || !images.Img2.IsNullOrEmpty() || !images.Img3.IsNullOrEmpty() || !images.Img4.IsNullOrEmpty() : false;
                }
                else
                {
                    status.Company = false;
                }
                response.Data = status;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> NewComercialReferences(int idCompany, int? idTicket)
        {
            var response = new Response<bool>(); 
            try
            {

            }catch(Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<List<GetProviderHistoryResponseDto>>> GetProviderHistory(string type, int id)
        {
            var response = new Response<List<GetProviderHistoryResponseDto>>();
            response.Data = new List<GetProviderHistoryResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                if(type == "E")
                {
                    var list = await context.Providers.Where(x => x.IdCompany == id).ToListAsync();
                    var distIdTicket = list.DistinctBy(x => x.IdTicket).Where(x => x.Qualification == "Dió referencia");
                    foreach (var item in distIdTicket)
                    {
                        var distProvider = list.DistinctBy(x => x.Name).Where(x => x.IdTicket == item.IdTicket && x.Qualification == "Dió referencia");
                        response.Data.Add(new GetProviderHistoryResponseDto
                        {
                            IdTicket = item.IdTicket,
                            Ticket = item.Ticket,
                            Date = StaticFunctions.DateTimeToString(item.Date),
                            NumReferences = distProvider.Count(),
                            ReferentName = item.ReferentName,
                        });
                    }
                }else if(type == "P")
                {
                    response.Data = await _providerDomain.GetProvidersHistoryByIdPerson(id);
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateProviderListAsync(List<GetListProviderResponseDto> obj, int idCompany,string user, int idTicket)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets.Where(x => x.Id == idTicket).FirstOrDefaultAsync();
                var currentUser =await context.UserLogins.Include(x=>x.IdEmployeeNavigation).Where(x => x.Id == int.Parse(user)).FirstOrDefaultAsync();

                if(ticket == null || currentUser == null)
                {
                    throw new Exception("ticket o usuario no encontrado.");
                }

                var list = await context.Providers.Where(x => x.Enable == true && x.IdCompany == idCompany && x.Flag == true).ToListAsync();
                foreach (var item in list)
                {
                    item.Flag = false;
                    context.Providers.Update(item);
                }
                
                foreach (var item1 in obj)
                {
                    await context.Providers.AddAsync(new Provider
                    {
                        Id = 0,
                        IdCompany = item1.IdCompany == 0 || item1.IdCompany == null ? null : item1.IdCompany,
                        Name = item1.Name,
                        IdCountry = item1.IdCountry,
                        Qualification = item1.Qualification,
                        QualificationEng = item1.QualificationEng,
                        Date = StaticFunctions.VerifyDate(item1.Date),
                        Telephone = item1.Telephone,
                        AttendedBy = item1.AttendedBy,
                        IdCurrency = item1.IdCurrency==0?null : item1.IdCurrency,
                        MaximumAmount = item1.MaximumAmount,
                        MaximumAmountEng = item1.MaximumAmountEng,
                        TimeLimit = item1.TimeLimit,
                        TimeLimitEng = item1.TimeLimitEng,
                        Compliance = item1.Compliance,
                        ComplianceEng = item1.ComplianceEng,
                        ClientSince = item1.ClientSince,
                        ClientSinceEng = item1.ClientSinceEng,
                        ProductsTheySell = item1.ProductsTheySell,
                        ProductsTheySellEng = item1.ProductsTheySellEng,
                        AdditionalCommentary = item1.AdditionalCommentary,
                        AdditionalCommentaryEng = item1.AdditionalCommentaryEng,
                        ReferentCommentary = item1.ReferentCommentary,
                        IdPerson = item1.IdPerson == 0 || item1.IdPerson == null ? null : item1.IdPerson,
                        IdTicket = ticket.Id,
                        ReferentName = currentUser.IdEmployeeNavigation.FirstName+" "+ currentUser.IdEmployeeNavigation.LastName,
                        Flag = true,
                        Ticket = ticket.Number.ToString("D6"),
                        DateReferent =DateTime.Now
                    });

                }
                var history = await context.TicketHistories.Where(X => X.IdTicket == idTicket && X.AsignedTo.Contains("RC") && X.Flag == false).FirstOrDefaultAsync();
                if (history != null)
                {
                    history.UpdateDate = DateTime.Now;
                    history.Flag = true;
                    context.TicketHistories.Update(history);
                }
                await context.SaveChangesAsync();
                response.Data = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetCompanySearchResponseDto>>> GetCompanySearch(string name, string taxCode, int idCountry)
        {
            var response = new Response<List<GetCompanySearchResponseDto>>();
            try
            {
                var companies = await _companyDomain.GetCompanySearch(name, taxCode, idCountry);
                response.Data = _mapper.Map<List<GetCompanySearchResponseDto>>(companies);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadSubReportCompany(int? idCompany, string section, string language)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                var company = await _companyDomain.GetByIdAsync((int)idCompany);

                string companyCode = company.OldCode ?? "N" + company.Id.ToString("D6");
                string languageFileName = language == "I" ? "ENG" : "ESP";
                string fileFormat = "{0}_{1}{2}";
                string format = "pdf";
                List<string> subReport = new List<string>(); ;

                if(section == "IDENTIFICACION")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/IDENTIFICACION" : "EMPRESAS/PDF/ESP/IDENTIFICACION");
                }else if(section == "ANTECEDENTES")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/RESU-EJEC" : "EMPRESAS/PDF/ESP/RESU-EJEC");
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/EST-LEGAL" : "EMPRESAS/PDF/ESP/EST-LEGAL");
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/HISTORIA" : "EMPRESAS/PDF/ESP/HISTORIA");
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/EMP-REL" : "EMPRESAS/PDF/ESP/EMP-REL");
                }
                else if (section == "RAMO")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/RAMO" : "EMPRESAS/PDF/ESP/RAMO");
                }
                else if (section == "FINANZAS")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/INFO-FINAN" : "EMPRESAS/PDF/ESP/INFO-FINAN");
                }
                else if (section == "BALANCES")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/INFO-FINAN" : "EMPRESAS/PDF/ESP/INFO-FINAN");
                }
                else if (section == "SBS")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/MOROSIDAD" : "EMPRESAS/PDF/ESP/MOROSIDAD");
                }
                else if (section == "OPINION-CREDITO")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/OPI-CRED" : "EMPRESAS/PDF/ESP/OPI-CRED");
                }
                else if (section == "IMAGENES")
                {
                    subReport.Add(language == "I" ? "EMPRESAS/PDF/ENG/IMAGENES" : "EMPRESAS/PDF/ESP/IMAGENES");
                }

                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", idCompany.ToString() },
                    { "idTicket", ""},
                    { "language", language }
                 };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateCombinedReportAsync(subReport, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, companyCode, languageFileName, extension)
                };

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetListProviderResponseDto>>> GetListProviderHistoryByIdTicket(int idTicket)
        {
            var response = new Response<List<GetListProviderResponseDto>>();
            response.Data = new List<GetListProviderResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Providers
                    .Where(x => x.IdTicket == idTicket && x.Qualification == "Dió referencia")
                    .Include(x => x.IdCountryNavigation)
                    .DistinctBy(x => x.Name)
                    .ToListAsync();
                foreach (var item in list)
                {
                    response.Data.Add(new GetListProviderResponseDto
                    {
                        Name = item.Name,
                        Country = item.IdCountryNavigation.Iso ?? "",
                        FlagCountry = item.IdCountryNavigation.FlagIso ?? "",
                        Telephone = item.Telephone
                    });
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
