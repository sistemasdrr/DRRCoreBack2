﻿using DRRCore.Application.DTO.API;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Provider = DRRCore.Application.DTO.API.Provider;

namespace DRRCore.Application.DTO
{
    public class ApiDummy
    {

        public static ICompanyDomain _companyDomain;
        public static ICompanyBackgroundDomain _companyBackgroundDomain;
        public ApiDummy(ICompanyDomain companyDomain, ICompanyBackgroundDomain companyBackgroundDomain)
        {

            _companyDomain = companyDomain;
            _companyBackgroundDomain = companyBackgroundDomain;
        }
        public static async Task<ReportDto> Report(GetRequestDto request)
        {
            try
            {
                using var context = new SqlCoreContext();
              
               
                var company = await context.Companies
                    .Where(x => x.OldCode == request.Code.Substring(0,11))
                    .Include(c => c.TraductionCompanies)
                    .FirstOrDefaultAsync();

                if (company != null)
                {
                    return new ReportDto
                    {
                        RequestClient = await RequestClient(request),
                        Information = await Information(company.Id),
                        Summary = await Summary(company.Id),
                        LegalBackground = await LegalBackground(company.Id),
                        Executives = await ExecutiveShareholders(company.Id),
                        WhoIsWho = await WhoIsWhos(company.Id),
                        Placeholders = await Placeholders(company.Id),
                        BussinessHistory = company.TraductionCompanies.FirstOrDefault().TBhistory,
                        RelatedCompanies = await RelatedCompanies(company.Id),
                        Business = await Business(company.Id),
                        PaymentRecords = await PaymentRecords(company.Id),
                        BankingInformation = await BankingInformation(company.Id),
                        FinancialInformation = await FinancialInformation(company.Id),
                        News = company.TraductionCompanies.FirstOrDefault().TEnew

                    };
                }
                else
                {
                    throw new Exception("No se encontró la información de la empresa");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
           
        }
        private static async Task<RequestClientDto> RequestClient(GetRequestDto request)
        {
            try
            {
               
                var client = new RequestClientDto
                {
                    RequestDate = request.RequestClient.RequestDate,
                    Priority = "T1",
                    Request = request.RequestClient.Request == null ? "" : request.RequestClient.Request,
                    Environment = "Develop"
                };
                return client;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
           
        }
        private static async Task<InformationDto> Information(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies
                    .Where(x => x.Id == idCompany)
                    .Include(x => x.IdLegalRegisterSituationNavigation)
                    .Include(x => x.IdCountryNavigation)
                    .Include(x => x.IdLegalPersonTypeNavigation)
                    .Include(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.TraductionCompanies)
                    .FirstOrDefaultAsync();
                
                var information = new InformationDto()
                {
                    CorrectCompanyName = company.Name == null ? "" : company.Name,
                    TradeName = company.SocialName == null ? "" : company.SocialName,
                    QualityInformation = company.Quality == null ? "" : company.Quality,
                    TaxpayerRegistration = new DocumentTypeDto
                    {
                        TypeDocument = company.TaxTypeName == null ? "" : company.TaxTypeName,
                        NumberDocument = company.TaxTypeCode.IsNullOrEmpty() == true ? "" : company.TaxTypeCode
                    },
                    TaxpayerSituation = new ValueDetailDto
                    {
                        Code = company.IdLegalRegisterSituationNavigation == null || company.IdLegalRegisterSituationNavigation.ApiCode == null ? "" : company.IdLegalRegisterSituationNavigation.ApiCode, //"TS1",
                        Description = company.IdLegalRegisterSituationNavigation == null || company.IdLegalRegisterSituationNavigation.EnglishName == null ? "" : company.IdLegalRegisterSituationNavigation.EnglishName//"Active"
                    },
                    JuridicForm = new ValueDetailDto
                    {
                        Code = company.IdLegalPersonTypeNavigation == null || company.IdLegalPersonTypeNavigation.ApiCode == null ? "" : company.IdLegalPersonTypeNavigation.ApiCode,//"JF26",
                        Description = company.IdLegalPersonTypeNavigation == null || company.IdLegalPersonTypeNavigation.EnglishName == null ? "" : company.IdLegalPersonTypeNavigation.EnglishName//"Publicly Held Corporation"
                    },
                    Main_Address = company.Address??string.Empty,//"Argentina, 4793, ****",
                    CityProvincie = company.Place ?? string.Empty, //"Callao",
                    PostalCode = company.PostalCode ?? string.Empty,//"Callao, 3",
                    Country = company.IdCountryNavigation == null || company.IdCountryNavigation.Iso == null ? "" : company.IdCountryNavigation.Iso,//"PER",
                    Phone = company.Cellphone ?? string.Empty,// "+511  3150800 - 2154130-11054",
                    Email = company.Email ?? string.Empty,//"******@alicorp.com.pe ; ******@alicorp.com.pe",
                    WebUrl = company.WebPage ?? string.Empty,//"www.alicorp.com.pe",
                    Comment = company.TraductionCompanies.FirstOrDefault().TEcomide ?? ""//"Email: s*****@gromero.com.pe\r\n\r\nIt should be mentioned the currently investigated Company is NOT INCLUDED IN THE OFAC Sanctions List (List of companies and individuals linked with money from terrorism and narcotics trafficking published by the Office of Foreign Assets Control of the United States Department of the Treasury)."
                };
                return information;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }    
        }
        private static async Task<SummaryDto> Summary(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.IdLegalRegisterSituationNavigation)
                    .Include(x => x.IdCountryNavigation)
                    .Include(x => x.IdLegalPersonTypeNavigation)
                    .Include(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.TraductionCompanies)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBranchSectorNavigation)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .Include(x => x.CompanyBackgrounds).ThenInclude(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(c => c.CompanyFinancialInformations).ThenInclude(cb => cb.IdCollaborationDegreeNavigation)
                    .Include(c => c.CompanyFinancialInformations).ThenInclude(cb => cb.IdFinancialSituacionNavigation)
                    .Include(x => x.FinancialBalances).ThenInclude(x => x.IdCurrencyNavigation)
                    .FirstOrDefaultAsync();
                var summary = new SummaryDto()
                {
                    Sector = new ValueDetailDto
                    {
                        Code = company.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation?.ApiCode == null ? "" : company.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation?.ApiCode,//"SC2",
                        Description = company.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation?.EnglishName == null ? "" : company.CompanyBranches.FirstOrDefault()?.IdBranchSectorNavigation?.EnglishName//"Industry, Manufacturing, Clothing, Production, Manufacturing, Construction\r\n"
                    },
                    Branch = new ValueDetailDto
                    {
                        Code = company.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation?.ApiCode == null ? "": company.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation?.ApiCode,//"BR6",
                        Description = company.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation?.EnglishName == null ? "" : company.CompanyBranches.FirstOrDefault()?.IdBusinessBranchNavigation?.EnglishName//"Food in general, solid and liquid food, stores.\r\n"
                    },
                    InscriptionYear = company.CompanyBackgrounds.FirstOrDefault()?.StartFunctionYear== null ? "" : company.CompanyBackgrounds.FirstOrDefault()?.StartFunctionYear,//"1956",
                    CapitalStock = new CurrencyAmountDto
                    {
                        IsoCurrency = company.CompanyBackgrounds.FirstOrDefault()?.CurrentPaidCapitalCurrencyNavigation?.Abreviation == null ? "" : company.CompanyBackgrounds.FirstOrDefault()?.CurrentPaidCapitalCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.CompanyBackgrounds.FirstOrDefault()?.CurrentPaidCapital == null ? 0 : (double)company.CompanyBackgrounds.FirstOrDefault()?.CurrentPaidCapital,//555666664,
                        Comment = company.TraductionCompanies.FirstOrDefault().TBpaidCapital ?? ""//"Soles"
                    },
                    ShareholdersEquity = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.TotalPatrimony == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.TotalPatrimony,//4555555555,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date?.ToString(Constants.DateFormatEnglish)//"12/31/2020"
                    },
                    AnnualRevenues = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Sales == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Sales,//66665989,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date?.ToString(Constants.DateFormatEnglish)//"12/31/2020"

                    },
                    Profits = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Utilities == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Utilities ,//7655654654,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date?.ToString(Constants.DateFormatEnglish)//"12/31/2020"
                    },
                    Employees = company.CompanyBranches.FirstOrDefault()?.WorkerNumber == null ? 0 : (int)company.CompanyBranches.FirstOrDefault()?.WorkerNumber,//5000,
                    ChiefExecutive = "PEREZ GUBBINS, ALFREDO *****",
                    Disposition = new ValueDetailDto
                    {
                        Code = company.CompanyFinancialInformations.FirstOrDefault()?.IdCollaborationDegreeNavigation?.ApiCode == null ? "" : company.CompanyFinancialInformations.FirstOrDefault()?.IdCollaborationDegreeNavigation?.ApiCode,//"DI13",
                        Description = company.CompanyFinancialInformations.FirstOrDefault()?.IdCollaborationDegreeNavigation?.EnglishName == null ? "" : company.CompanyFinancialInformations.FirstOrDefault()?.IdCollaborationDegreeNavigation?.EnglishName//"Report prepared exclusively from outside sources."
                    },
                    FinalSituation = new ValueDetailDto
                    {
                        Code = company.CompanyFinancialInformations.FirstOrDefault()?.IdFinancialSituacionNavigation?.ApiCode == null ? "" : company.CompanyFinancialInformations.FirstOrDefault()?.IdFinancialSituacionNavigation?.ApiCode,//"SF3",
                        Description = company.CompanyFinancialInformations.FirstOrDefault()?.IdFinancialSituacionNavigation?.EnglishName == null ? "" : company.CompanyFinancialInformations.FirstOrDefault()?.IdFinancialSituacionNavigation?.EnglishName,//"ACCEPTABLE Financial Situation"
                    },
                    PaymentsPolicy = new ValueDetailDto
                    {
                        Code = company.IdPaymentPolicyNavigation?.ApiCode == null ? "" : company.IdPaymentPolicyNavigation?.ApiCode,//"PP3",
                        Description = company.IdPaymentPolicyNavigation?.EnglishName == null ? "" : company.IdPaymentPolicyNavigation?.EnglishName,//"IRREGULAR (Prompt and sometimes delayed payments)"
                    },
                    Credit = new ValueDetailDto
                    {
                        Code = company.IdCreditRiskNavigation?.ApiCode == null ? "" : company.IdCreditRiskNavigation?.ApiCode,//"RC3",
                        Description = company.IdCreditRiskNavigation?.EnglishName == null ? "" : company.IdCreditRiskNavigation?.EnglishName,//"MODERATE RISK. (Slightly fair Financial Situation)"
                    }
                };
                return summary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
             
        }
        public static CurrencyAmountDto GetExchangeRate(string? exchangeRate)
        {
            try
            {
                var array = exchangeRate.Split("|");
                if(array.Count() == 3) 
                {
                    return new CurrencyAmountDto
                    {
                        IsoCurrency = array[0].Trim(),
                        Amount = double.Parse(array[1].Trim()),
                        Comment = array[2].Trim()
                    };
                }
                else
                {
                    return new CurrencyAmountDto();
                }
            }catch(Exception ex)
            {
                return new CurrencyAmountDto();
            }
        }
        private static async Task<LegalBackgroundDto> LegalBackground(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.IdLegalPersonTypeNavigation)
                    .Include(x => x.TraductionCompanies)
                    .Include(x => x.CompanyBackgrounds).ThenInclude(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.FinancialBalances).ThenInclude(x => x.IdCurrencyNavigation)
                    .FirstOrDefaultAsync();
                var background = new LegalBackgroundDto
                {
                    LegalStatus = company.IdLegalPersonTypeNavigation.EnglishName == null ? "" : company.IdLegalPersonTypeNavigation.EnglishName,//"Publicly Held Corporation",
                    IncorporationDate = company.CompanyBackgrounds.FirstOrDefault().ConstitutionDate == null ? "" : company.CompanyBackgrounds.FirstOrDefault().ConstitutionDate,
                    OperationStartDate = company.CompanyBackgrounds.FirstOrDefault().StartFunctionYear == null ? "" : company.CompanyBackgrounds.FirstOrDefault().StartFunctionYear,
                    RegisterPlace = company.TraductionCompanies.FirstOrDefault().TBregisterIn ?? "",//"Lima",
                    NotaryOffice = company.CompanyBackgrounds.FirstOrDefault().NotaryRegister == null ? "" : company.CompanyBackgrounds.FirstOrDefault().NotaryRegister,//"Julio César*****",
                    DurationTime = company.TraductionCompanies.FirstOrDefault().TBduration ?? "",//"Indefinite",
                    RegistrationFolio = company.TraductionCompanies.FirstOrDefault().TBpublicRegis ?? "",//"Entry 1, Page 351, *****",
                    PaidInCapital = new CurrencyAmountDto
                    {
                        IsoCurrency = company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation == null || company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation.Abreviation == null ? "" : company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation.Abreviation,//"PEN",
                        Amount = company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapital == null ? 0 : (double)company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapital,//555666664,
                        Comment = company.TraductionCompanies.FirstOrDefault().TBpaidCapital ?? ""//"Soles"
                    },
                    LastCapitalIncreaseDate = company.CompanyBackgrounds.FirstOrDefault().LastQueryRrpp == null ? "" : StaticFunctions.DateTimeToString(company.CompanyBackgrounds.FirstOrDefault().LastQueryRrpp),
                    ShareholdersEquity = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().IdCurrencyNavigation.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().IdCurrencyNavigation.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().TotalPatrimony == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().TotalPatrimony,//4555555555,
                       LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().Date == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().Date?.ToString(Constants.DateFormatEnglish)//"12/31/2020"
                    },
                    ShareClass = "",//"Common",
                    StockExchangeListed = company.CompanyBackgrounds.FirstOrDefault().Traded == "Si" ? true : false,
                    CurrentExchangeRate = GetExchangeRate(company.CompanyBackgrounds.FirstOrDefault().CurrentExchangeRate),
                    Membership = "",//"Lima Chamber of Commerce",
                    Comments = company.TraductionCompanies.FirstOrDefault().TBlegalBack ?? "",//"The Subject is listed in the Stock Exchange of\tima under the  tickers ALICORC1 and ALICORI1....."

                };
                return background;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            } 
        }
        private static async Task<ExecutiveShareholderDto> ExecutiveShareholders(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation)
                    .FirstOrDefaultAsync();
                decimal? partipation = 0;
                var ListExecutives = new List<ListExecutiveShareholderDto>();
                foreach (var item in company.CompanyPartners)
                {

                    ListExecutives.Add(new ListExecutiveShareholderDto
                    {
                        Name = item.IdPersonNavigation.Fullname == null ? "" : item.IdPersonNavigation.Fullname,
                        Title = item.ProfessionEng == null ? "" : item.ProfessionEng,
                        SinceDate = item.StartDate == null ? "" : item.StartDate?.ToString(Constants.DateFormatEnglish)
                    });
                    partipation += item.Participation;
                }
                var exec = new ExecutiveShareholderDto
                {
                    ListExecutives = ListExecutives,
                    OtherParticipationPercentage = 100 - (int)partipation,
                    ParticipationPercentage = (int)partipation
                };
                return exec;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
        }
        private static async Task<List<WhoIsWhoDto>> WhoIsWhos(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.IdDocumentTypeNavigation)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.IdCivilStatusNavigation)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(y => y.CompanyPartners).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .FirstOrDefaultAsync();

                var listWhoIsWho = new List<WhoIsWhoDto>();
                foreach (var item in company.CompanyPartners)
                {
                    var listCompanyAssociated = new List<Associated>();
                    foreach (var item1 in item.IdPersonNavigation.CompanyPartners)
                    {
                        listCompanyAssociated.Add(new Associated
                        {
                            Name = item1.IdCompanyNavigation.Name == null ? "" : item1.IdCompanyNavigation.Name,
                            Title = item1.ProfessionEng == null ? "" : item1.ProfessionEng,
                            IsoCountry = item1.IdCompanyNavigation.IdCountryNavigation == null || item1.IdCompanyNavigation.IdCountryNavigation.Iso == null ? "" : item1.IdCompanyNavigation.IdCountryNavigation.Iso,
                            RegistrationNumber = item1.IdCompanyNavigation.TaxTypeCode == null ? "" : item1.IdCompanyNavigation.TaxTypeCode
                        });
                    }
                    listWhoIsWho.Add(new WhoIsWhoDto
                    {
                        Name = item.IdPersonNavigation.Fullname == null ? "" : item.IdPersonNavigation.Fullname,
                        Title = item.IdPersonNavigation.TraductionPeople.FirstOrDefault().TPprofession ?? "",
                        Nacionality = item.IdPersonNavigation.TraductionPeople.FirstOrDefault().TPnacionality ?? "",
                        Birthday = item.IdPersonNavigation.BirthDate == null ? "" : item.IdPersonNavigation.BirthDate,
                        Document = new DocumentTypeDto
                        {
                            TypeDocument = item.IdPersonNavigation.IdDocumentTypeNavigation == null || item.IdPersonNavigation.IdDocumentTypeNavigation.Abreviation == null ? "" : item.IdPersonNavigation.IdDocumentTypeNavigation.Abreviation,
                            NumberDocument = item.IdPersonNavigation == null || item.IdPersonNavigation.CodeDocumentType == null ? "" : item.IdPersonNavigation.CodeDocumentType
                        },
                        CivilStatus = item.IdPersonNavigation.IdCivilStatusNavigation == null || item.IdPersonNavigation.IdCivilStatusNavigation.EnglishName == null ? "" : item.IdPersonNavigation.IdCivilStatusNavigation.EnglishName,
                        Adreess = item.IdPersonNavigation.Address == null ? "" : item.IdPersonNavigation.Address,
                        Profession = item.IdPersonNavigation.TraductionPeople.FirstOrDefault().TPprofession ?? "",
                        PaymentPolitic = new ValueDetailDto
                        {
                            Code = item.IdPersonNavigation.IdPaymentPolicyNavigation == null || item.IdPersonNavigation.IdPaymentPolicyNavigation.ApiCode == null ? "" : item.IdPersonNavigation.IdPaymentPolicyNavigation.ApiCode,
                            Description = item.IdPersonNavigation.IdPaymentPolicyNavigation == null || item.IdPersonNavigation.IdPaymentPolicyNavigation.EnglishName == null ? "" : item.IdPersonNavigation.IdPaymentPolicyNavigation.EnglishName,
                        },
                        FatherName = item.IdPersonNavigation.FatherName == null ? "" : item.IdPersonNavigation.FatherName,
                        ChiefExecutive = item.MainExecutive == null || item.MainExecutive == false ? false : true,
                        BackgroundInformation = item.IdPersonNavigation.TraductionPeople.FirstOrDefault().THdetails ?? "",
                        AssociatedCompanies = listCompanyAssociated,

                    });
                }
                var whoIsWho = new List<WhoIsWhoDto>
                {
                    new WhoIsWhoDto
                    {
                        ParticipateCompanies=new List<Participate>
                        {
                            new Participate
                            {
                                Name= "CEMENTOS PACASMAYO S.A.A.",
                                SinceDate= "03/22/2005",
                                IsoCountry= "PER"
                            },
                             new Participate
                            {
                                Name= "PALMAS DEL ORIENTE S.A.",
                                SinceDate= "",
                                IsoCountry= "PER"
                            }
                        }
                    },
                };
                return listWhoIsWho;
            }
            catch (Exception ex)
            {
                return new List<WhoIsWhoDto>();
                throw new Exception(ex.Message);
            }
        }
        private static async Task<List<PlaceholderDto>> Placeholders(int? idCompany)
        {
            using var context = new SqlCoreContext();
            var company = await context.Companies.Where(x => x.Id == idCompany)
                .Include(x => x.CompanyShareHolderIdCompanyNavigations).ThenInclude(x => x.IdCompanyShareHolderNavigation).ThenInclude(x => x.IdCountryNavigation)
                .FirstOrDefaultAsync();
            try
            {
                var listPlaceholder = company.CompanyShareHolderIdCompanyNavigations.ToList();
                var list = new List<PlaceholderDto>();
                foreach (var item in listPlaceholder)
                {
                    list.Add(new PlaceholderDto
                    {
                        Name = item.IdCompanyShareHolderNavigation.Name == null ? "" : item.IdCompanyShareHolderNavigation.Name,
                        IsoCountry = item.IdCompanyShareHolderNavigation.IdCountryNavigation == null || item.IdCompanyShareHolderNavigation.IdCountryNavigation.Iso == null ? "" : item.IdCompanyShareHolderNavigation.IdCountryNavigation.Iso,
                        Relation = item.RelationEng == null ? "" : item.RelationEng
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                return new List<PlaceholderDto>();
                throw new Exception(ex.Message);
            }
        }
        private static async Task<List<RelatedCompanyDto>> RelatedCompanies(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.CompanyRelationIdCompanyRelationNavigations).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.CompanyRelationIdCompanyNavigations).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.CompanyRelationIdCompanyNavigations).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.IdLegalRegisterSituationNavigation)
                    .Include(x => x.CompanyRelationIdCompanyNavigations).ThenInclude(x => x.IdCompanyNavigation).ThenInclude(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .FirstOrDefaultAsync();
    
                    var listCompanyRelated = company.CompanyRelationIdCompanyNavigations.ToList();
                var list = new List<RelatedCompanyDto>();
                foreach (var item in listCompanyRelated)
                {
                    list.Add(new RelatedCompanyDto
                    {
                        Name = item.IdCompanyNavigation.Name == null ? "" : item.IdCompanyNavigation.Name,
                        IsoCountry = item.IdCompanyNavigation.IdCountryNavigation == null || item.IdCompanyNavigation.IdCountryNavigation.Iso == null ? "" : item.IdCompanyNavigation.IdCountryNavigation.Iso,
                        SituationCompany = item.IdCompanyNavigation.IdLegalRegisterSituationNavigation == null || item.IdCompanyNavigation.IdLegalRegisterSituationNavigation.EnglishName == null ? "" : item.IdCompanyNavigation.IdLegalRegisterSituationNavigation.EnglishName,
                        RegistrationNumber = item.IdCompanyNavigation.TaxTypeCode == null ? "" : item.IdCompanyNavigation.TaxTypeCode,
                        BussinessActivity = item.IdCompanyNavigation.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation == null || item.IdCompanyNavigation.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.EnglishName == null ? "" : item.IdCompanyNavigation.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.EnglishName,
                        Relation = item.RelationEng == null ? "" : item.RelationEng
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                return new List<RelatedCompanyDto>();
                throw new Exception(ex.Message);
            }
        }
        private static async Task<BusinessDto> Business(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.ImportsAndExports)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBranchSectorNavigation)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .Include(x => x.TraductionCompanies)
                    .FirstOrDefaultAsync();
                var listImportsAndExports = company.ImportsAndExports.Where(x => x.Enable == true).ToList();

                var listI = new List<BussinessAmountDetailDto>();
                var listE = new List<BussinessAmountDetailDto>();
                foreach (var item in listImportsAndExports)
                {
                    if (item.Type == "I")
                    {
                        listI.Add(new BussinessAmountDetailDto
                        {
                            Year = item.Year.ToString(),
                            Amount = double.Parse(item.Amount)
                        });
                    }
                    else
                    {
                        listE.Add(new BussinessAmountDetailDto
                        {
                            Year = item.Year.ToString(),
                            Amount = double.Parse(item.Amount)
                        });
                    }
                }
                var bussiness = new BusinessDto
                {
                    MainActivity = company.TraductionCompanies.FirstOrDefault().TRprincAct ?? "",//"Subject is engaged in manufacturing and sale of fatty-type food....",
                    Sector = new ValueDetailDto
                    {
                        Code = company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation == null || company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation.ApiCode == null ? "" : company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation.ApiCode,//"SC2",
                        Description = company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation == null || company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation.EnglishName == null ? "" : company.CompanyBranches.FirstOrDefault().IdBranchSectorNavigation.EnglishName//"Industry, Manufacturing, Clothing, Production, Manufacturing, Construction\r\n"
                    },
                    Branch = new ValueDetailDto
                    {
                        Code = company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation == null || company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.ApiCode == null ? "" : company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.ApiCode,//"BR6",
                        Description = company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation == null || company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.EnglishName == null ? "" : company.CompanyBranches.FirstOrDefault().IdBusinessBranchNavigation.EnglishName//"Food in general, solid and liquid food, stores.\r\n"
                    },
                    Import = new BussinessImportExportDto
                    {
                        HasImportedOrExported = company.CompanyBranches.FirstOrDefault().Import == false || company.CompanyBranches.FirstOrDefault().Import == null ? false : true,
                        Countries = new List<string>
                        {
                            company.CompanyBranches.FirstOrDefault().CountriesImport
                        },
                        Details = listI
                    },
                    Export = new BussinessImportExportDto
                    {
                        HasImportedOrExported = company.CompanyBranches.FirstOrDefault().Export,
                        Countries = new List<string>
                        {
                            company.CompanyBranches.FirstOrDefault().CountriesExport
                        },
                        Details = listE
                    },
                    CashSalesPercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().CashSalePercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().CashSalePercentage,
                        Description = company.CompanyBranches.FirstOrDefault().CashSaleComentary == null ? "" : company.CompanyBranches.FirstOrDefault().CashSaleComentary
                    },
                    CreditSalesPercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().CreditSalePercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().CreditSalePercentage,
                        Description = company.CompanyBranches.FirstOrDefault().CreditSaleComentary == null ? "" : company.CompanyBranches.FirstOrDefault().CreditSaleComentary
                    },
                    ForeignSalePercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().AbroadSalePercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().AbroadSalePercentage,
                        Description = company.CompanyBranches.FirstOrDefault().AbroadSaleComentary == null ? "" : company.CompanyBranches.FirstOrDefault().AbroadSaleComentary
                    },
                    DomesticPourchasesPercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().NationalPurchasesPercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().NationalPurchasesPercentage,
                        Description = company.CompanyBranches.FirstOrDefault().NationalPurchasesComentary == null ? "" : company.CompanyBranches.FirstOrDefault().NationalPurchasesComentary
                    },
                    ForeignPourchasesPercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().InternationalPurchasesPercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().InternationalPurchasesPercentage,
                        Description = company.CompanyBranches.FirstOrDefault().InternationalPurchasesComentary == null ? "" : company.CompanyBranches.FirstOrDefault().InternationalPurchasesComentary
                    },
                    SellingTerritoryPercentage = new PercentageValue
                    {
                        Value = company.CompanyBranches.FirstOrDefault().TerritorySalePercentage == null ? 0 : company.CompanyBranches.FirstOrDefault().TerritorySalePercentage,
                        Description = company.CompanyBranches.FirstOrDefault().TerritorySaleComentary == null ? "" : company.CompanyBranches.FirstOrDefault().TerritorySaleComentary
                    },
                    Employess = company.CompanyBranches.FirstOrDefault().WorkerNumber == null ? 0 : company.CompanyBranches.FirstOrDefault().WorkerNumber
                };

                return bussiness;
            }
            catch (Exception ex)
            {
                return new BusinessDto();
                throw new Exception(ex.Message);
            }
        }
        private static async Task<FinancialInformationDto> FinancialInformation(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.ImportsAndExports)
                    .Include(x => x.FinancialBalances).ThenInclude(x => x.IdCurrencyNavigation)
                  
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBranchSectorNavigation)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .Include(x => x.TraductionCompanies)
                    .FirstOrDefaultAsync();
                var balancesGen = company.FinancialBalances.Where(x => x.BalanceType == "GENERAL").OrderByDescending(x => x.Date).ToList();
                var balancesSit = company.FinancialBalances.Where(x => x.BalanceType == "SITUACIONAL").OrderByDescending(x => x.Date).ToList();
                var listBalGen = new List<BalanceSheetDto>();
                var listBalSit = new List<BalanceSheetDto>();

               
                    var ratio = new RatioSituationDto
                    {
                        LiquidityRatio = balancesGen.Count > 0?(double)balancesGen.FirstOrDefault().LiquidityRatio:0,
                        DebtToEquityRatio = balancesGen.Count > 0 ? (double)balancesGen.FirstOrDefault().DebtRatio:0,
                        ProfitabilityMargin = balancesGen.Count > 0 ? (double)balancesGen.FirstOrDefault().ProfitabilityRatio:0,
                        WorkingCapital = balancesGen.Count > 0 ? (double)balancesGen.FirstOrDefault().WorkingCapital:0
                    };

                foreach (var balanceSit in balancesSit)
                {
                        listBalSit.Add(new BalanceSheetDto
                        {
                           IsCurrent=balancesSit.OrderByDescending(x => x.Date).FirstOrDefault().Date==balanceSit.Date,
                            Date = balanceSit.Date?.ToString(Constants.DateFormatEnglish),
                            TypeBalanceSheet = "Interim",
                            Period = balanceSit.DurationEng,
                            IsoCurrency = balanceSit.IdCurrencyNavigation.Abreviation,
                            ExchangeRate = balanceSit.ExchangeRate.ToString(),
                            Assets = new AssetsDto
                            {
                                CashBanks = (double)balanceSit.ACashBoxBank,
                                Receivables = (double)balanceSit.AToCollect,
                                Inventory = (double)balanceSit.AInventory,
                                OthersAssets = (double)balanceSit.AOtherCurrentAssets,
                                CurrentAssets = (double)balanceSit.TotalCurrentAssets,
                                Fixed = (double)balanceSit.AFixed,
                                OthersCurrentAssets = (double)balanceSit.AOtherNonCurrentAssets,
                                TotalAssets = (double)balanceSit.TotalAssets
                            },
                            Liabilities = new LiabilitiesDto
                            {
                                BankSuppliers = (double)balanceSit.LCashBoxBank,
                                OthersLiabilities = (double)balanceSit.LOtherCurrentLiabilities,
                                CurrentLiabilities = (double)balanceSit.TotalCurrentLiabilities,
                                OthersCurrentLiabilities = (double)balanceSit.LOtherNonCurrentLiabilities
                            },
                            ShareholdersEquity = new ShareholdersEquityDto
                            {
                                Capital = (double)balanceSit.PCapital,
                                Reserves = (double)balanceSit.PStockPile,
                                ProfitsLoots = (double)balanceSit.PUtilities,
                                TotalLiabilitiesShareholderEquity = (double)balanceSit.TotalLiabilitiesPatrimony,
                                TotalShareholderEquity = (double)balanceSit.TotalPatrimony
                            },
                            Sales = (double)balanceSit.Sales,
                            ProfitLoss = (double)balanceSit.Utilities
                        });
                    

                }
                foreach (var balance in balancesGen)
                {
                    listBalGen.Add(new BalanceSheetDto
                    {
                        IsCurrent = balancesGen.OrderByDescending(x => x.Date).FirstOrDefault().Date == balance.Date,
                        Date = balance.Date?.ToString(Constants.DateFormatEnglish),
                        TypeBalanceSheet = "General",
                        Period = balance.DurationEng == null ? "" : balance.DurationEng,
                        IsoCurrency = balance.IdCurrencyNavigation == null || balance.IdCurrencyNavigation.Abreviation == null ? "" : balance.IdCurrencyNavigation.Abreviation,
                        ExchangeRate = balance.ExchangeRate == null ? "" : balance.ExchangeRate.ToString(),
                        Assets = new AssetsDto
                        {
                            CashBanks = (double)balance.ACashBoxBank == null ? 0 : (double)balance.ACashBoxBank,
                            Receivables = (double)balance.AToCollect == null ? 0 : (double)balance.AToCollect,
                            Inventory = (double)balance.AInventory == null ? 0 : (double)balance.AInventory,
                            OthersAssets = (double)balance.AOtherCurrentAssets == null ? 0 : (double)balance.AOtherCurrentAssets,
                            CurrentAssets = (double)balance.TotalCurrentAssets == null ? 0 : (double)balance.TotalCurrentAssets,
                            Fixed = (double)balance.AFixed == null ? 0 : (double)balance.AFixed,
                            OthersCurrentAssets = (double)balance.AOtherNonCurrentAssets == null ? 0 : (double)balance.AOtherNonCurrentAssets,
                            TotalAssets = (double)balance.TotalAssets
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = (double)balance.LCashBoxBank,
                            OthersLiabilities = (double)balance.LOtherCurrentLiabilities,
                            CurrentLiabilities = (double)balance.TotalCurrentLiabilities,
                            OthersCurrentLiabilities = (double)balance.LOtherNonCurrentLiabilities
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = (double)balance.PCapital,
                            Reserves = (double)balance.PStockPile,
                            ProfitsLoots = (double)balance.PUtilities,
                            TotalLiabilitiesShareholderEquity = (double)balance.TotalLiabilitiesPatrimony,
                            TotalShareholderEquity = (double)balance.TotalPatrimony
                        },
                        Sales = (double)balance.Sales,
                        ProfitLoss = (double)balance.Utilities
                    });
                }
                var financial = new FinancialInformationDto
                {
                    Disposition = new ValueDetailDto
                    {
                        Code = company.CompanyFinancialInformations.Count<=0?string.Empty: company.CompanyFinancialInformations?.FirstOrDefault().IdCollaborationDegreeNavigation.ApiCode,//"DI13",
                        Description = company.CompanyFinancialInformations.Count <= 0 ? string.Empty : company.CompanyFinancialInformations?.FirstOrDefault().IdCollaborationDegreeNavigation.EnglishName//"Report prepared exclusively from outside sources."
                    },
                    InformationProvided = company.TraductionCompanies?.FirstOrDefault().TFcomment ?? "",//"Directly personnel did not allow the coordination of an interview....",
                    InterimBalanceSheets = listBalSit,
                    RatioSituation = ratio,
                    SituationalFinancial = new ValueDetailDto
                    {
                        Code = company.CompanyFinancialInformations.Count <= 0 ? string.Empty : company.CompanyFinancialInformations?.FirstOrDefault().IdFinancialSituacionNavigation.ApiCode,//"SF3",
                        Description = company.CompanyFinancialInformations.Count <= 0 ? string.Empty : company.CompanyFinancialInformations?.FirstOrDefault().IdFinancialSituacionNavigation.EnglishName//"ACCEPTABLE Financial Situation"
                    },
                    Comments = company.TraductionCompanies?.FirstOrDefault().TFprincActiv?? "",//"Land\r\nBuildings, plants and other constructions\r\nMachinery and equipment...",
                    AnalystComments = company.TraductionCompanies?.FirstOrDefault().TFanalistCom ?? "",//"Alicorp S.A.A. was incorporated in Peru on July 16, 1956....",
                    Insurances = new List<InsuranceCompaniesDto>(),
                    BalanceSheets = listBalGen
                };
                return financial;
            }
            catch (Exception ex)
            {
                return new FinancialInformationDto();
                throw new Exception(ex.Message);
            }
        }

        private static async Task<BankingInformationDto> BankingInformation(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.BankDebts)
                    .Include(x => x.CompanySbs)
                    .Include(x => x.TraductionCompanies)
                    .FirstOrDefaultAsync();

                var listBankDebt = company.BankDebts.Where(x => x.Enable == true).ToList();
                var list = new List<BankDto>();
                foreach (var item in listBankDebt)
                {
                    list.Add(new BankDto
                    {
                        Bank = item.BankName == null ? "" : item.BankName,
                        DebtRating = new ValueDetailDto
                        {
                            Code = "",
                            Description = item.Qualification == null ? "" : item.Qualification
                        },
                        Amount = item.DebtFc == null ? 0 : (double)item.DebtFc,
                        IsoCurrency = ""
                    });
                }
                var bankDebt = new BankingInformationDto
                {
                    ExchangeRateSbs = company.CompanySbs.FirstOrDefault().ExchangeRate == null ? 0 : (double)company.CompanySbs.FirstOrDefault().ExchangeRate,//3.99,
                    RiskCenter = "No delinquency was reported to Credit Bureau.",
                    RegisterDate = company.CompanySbs.FirstOrDefault().DebtRecordedDate == null ? "" : company.CompanySbs.FirstOrDefault().DebtRecordedDate?.ToString(Constants.DateFormatEnglish),//"12/31/2021",
                    MNTotal = company.CompanySbs.FirstOrDefault().GuaranteesOfferedNc == null ? 0 : (double)company.CompanySbs.FirstOrDefault().GuaranteesOfferedNc,//852364459,
                    MNGuaranteesOffered = 209663451,

                    SbsComment = company.TraductionCompanies.FirstOrDefault().TScommentary ?? "",// "Maintains unused lines of credit in banks:\r\nSCOTIABANK for S/.43.543.802.44 for loans.\r\nCITIBANK DEL PERU for S/.1,263,675 for c..."
                };
                return bankDebt;
            }
            catch (Exception ex)
            {
                return new BankingInformationDto();
                throw new Exception(ex.Message);
            }
        }

        private static async Task<PaymentRecordsDto> PaymentRecords(int? idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.Id == idCompany)
                    .Include(x => x.Providers).ThenInclude(x => x.IdCurrencyNavigation)
                    .Include(x => x.Providers).ThenInclude(x => x.IdCountryNavigation)
                    .Include(x => x.Traductions)
                    .FirstOrDefaultAsync();

                var providers = company.Providers.Where(x => x.Enable == true).ToList();
                var listPri = new List<Provider>();
                var listSec = new List<Provider>();
                foreach (var item in providers)
                {
                    if (!item.ProductsTheySellEng.IsNullOrEmpty() || !item.ClientSinceEng.IsNullOrEmpty() ||
                        !item.TimeLimitEng.IsNullOrEmpty() || !item.ComplianceEng.IsNullOrEmpty())
                    {
                        listPri.Add(new Provider
                        {
                            Name = item.Name == null ? "" : item.Name,
                            IsoCountry = item.IdCountryNavigation == null || item.IdCountryNavigation.Iso == null ? "" : item.IdCountryNavigation.Iso,
                            Phone = item.Telephone == null ? "" : item.Telephone,
                            ProductsOrServicesRequires = item.ProductsTheySellEng == null ? "" : item.ProductsTheySellEng,
                            ClientSince = item.ClientSinceEng == null ? "" : item.ClientSinceEng,
                            Terms = item.TimeLimitEng == null ? "" : item.TimeLimitEng,
                            Comments = item.AdditionalCommentaryEng == null ? "" : item.AdditionalCommentaryEng,
                            Performance = item.ComplianceEng == null ? "" : item.ComplianceEng
                        });
                    }
                    else
                    {
                        listSec.Add(new Provider
                        {
                            Name = item.Name == null ? "" : item.Name,
                            IsoCountry = item.IdCountryNavigation == null || item.IdCountryNavigation.Iso == null ? "" : item.IdCountryNavigation.Iso,
                            Phone = item.Telephone == null ? "" : item.Telephone,
                            Comments = item.AdditionalCommentaryEng == null ? "" : item.AdditionalCommentaryEng,
                        });
                    }
                }
                var prov = new PaymentRecordsDto
                {
                    PrimaryProviders = listPri,
                    SecondaryProviders = listSec
                };
                return prov;
            }
            catch (Exception ex)
            {
                return new PaymentRecordsDto();
                throw new Exception(ex.Message);
            }
        }
    }
}
