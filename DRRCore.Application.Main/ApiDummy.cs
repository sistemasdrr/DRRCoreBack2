using DRRCore.Application.DTO.API;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Provider = DRRCore.Application.DTO.API.Provider;

namespace DRRCore.Application.DTO
{
    public class ApiDummy
    {
        public static async Task<ReportDto> Report(int idTicket)
        {
            try
            {
                using var context = new SqlCoreContext();
                var ticket = await context.Tickets
                    .Where(x => x.Id == idTicket)
                    .Include(x => x.IdCompanyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.Traductions)
                    .FirstOrDefaultAsync();
                /*
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.IdLegalRegisterSituationNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.IdCountryNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.IdLegalPersonTypeNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.IdPaymentPolicyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.IdCreditRiskNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyBackgrounds)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyBackgrounds).ThenInclude(cb => cb.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyBranches)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyBranches).ThenInclude(cb => cb.IdBranchSectorNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyFinancialInformations)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyFinancialInformations).ThenInclude(cb => cb.IdCollaborationDegreeNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyFinancialInformations).ThenInclude(cb => cb.IdFinancialSituacionNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.FinancialBalances)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.FinancialBalances).ThenInclude(cb => cb.IdCurrencyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(x => x.Traductions)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(x => x.IdDocumentTypeNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(x => x.IdCivilStatusNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(x => x.IdPaymentPolicyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(cba => cba.CompanyPartners)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyPartners).ThenInclude(cb => cb.IdPersonNavigation).ThenInclude(cba => cba.CompanyPartners).ThenInclude(x => x.IdCompanyNavigation)
                    .Include(x => x.IdCompanyNavigation).ThenInclude(c => c.CompanyRelationIdCompanyNavigations)
                    */

                return new ReportDto
                {
                    RequestClient = await RequestClient(ticket),
                    Information = await Information(ticket.IdCompany),
                    Summary = await Summary(ticket.IdCompany),
                    LegalBackground = await LegalBackground(ticket.IdCompany),
                    Executives = await ExecutiveShareholders(ticket.IdCompany),
                    WhoIsWho = await WhoIsWhos(ticket.IdCompany),
                    Placeholders = await Placeholders(ticket.IdCompany),
                    BussinessHistory = ticket.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue,//"Alicorp S.A.A. was incorporated in 1956 as Anderson Clayton & Company......",
                    RelatedCompanies = await RelatedCompanies(ticket.IdCompany),
                    Business = await Business(ticket.IdCompany),
                    PaymentRecords = await PaymentRecords(ticket.IdCompany),
                    BankingInformation = await BankingInformation(ticket.IdCompany),
                    FinancialInformation = await FinancialInformation(ticket.IdCompany),
                    News = ticket.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue//"Alicorp: ventas en negocio de consumo masivo crecieron 4,7% en primer trimestre de 2023\r\n\r\nas ventas consolidadas de la empresa alcanzaron los S/3.326 millones, que, comparado al mismo periodo del 2022, decrece ligeramente en un 0,6%.\r\n\r\nAlicorp presentó sus resultados financieros del primer trimestre del año, periodo en el que la inflación se mantuvo a niveles elevados. En este escenario, la compañía informó que mantiene resiliencia gracias al soporte que le brindan ventajas competitivas como el valor marca, innovación y diversificación de sus negocios.\r\n\r\nAl cierre del primer trimestre, se observó un menor volumen de ventas, explicado por una reducción del consumo privado debido a los conflictos internos del país y al desempeño del negocio de Molienda, que vio afectada su abastecimiento de insumos por el bloqueo en la frontera con Bolivia, originado por los conflictos en el sur. Así las ventas consolidadas de Alicorp alcanzaron los S/3.326 millones, que, comparado al mismo periodo del 2022, decrece ligeramente en un 0,6%."

                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
           
        }
        private static async Task<RequestClientDto> RequestClient(Ticket ticket)
        {
            try
            {
               
                var client = new RequestClientDto
                {
                    RequestDate = ticket.OrderDate.ToString("MM/dd/yyyy"),
                    Priority = "T1",
                    Request = ticket.RequestedName == null ? "" : ticket.RequestedName,
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
                    .Include(x => x.Traductions)
                    .FirstOrDefaultAsync();
                var information = new InformationDto()
                {
                    CorrectCompanyName = company.Name == null ? "" : company.Name,
                    TradeName = company.SocialName == null ? "" : company.SocialName,
                    QualityInformation = company.Quality == null ? "" : company.Quality,
                    TaxpayerRegistration = new DocumentTypeDto
                    {
                        TypeDocument = company.TaxTypeName == null ? "" : company.TaxTypeName,
                        NumberDocument = company.TaxTypeCode.IsNullOrEmpty() == true ? "" : company.TaxTypeCode.Substring(0, Math.Min(company.TaxTypeCode.Length, 7))
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
                    Comment = company.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue == null ? "" : company.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue//"Email: s*****@gromero.com.pe\r\n\r\nIt should be mentioned the currently investigated Company is NOT INCLUDED IN THE OFAC Sanctions List (List of companies and individuals linked with money from terrorism and narcotics trafficking published by the Office of Foreign Assets Control of the United States Department of the Treasury)."
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
                    .Include(x => x.Traductions)
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
                        Comment = company.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault()?.LargeValue == null ? "" : company.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault()?.LargeValue//"Soles"
                    },
                    ShareholdersEquity = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.TotalPatrimony == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.TotalPatrimony,//4555555555,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : StaticFunctions.DateTimeToString(company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date)//"12/31/2020"
                    },
                    AnnualRevenues = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Sales == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Sales,//66665989,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : StaticFunctions.DateTimeToString(company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date)//"12/31/2020"

                    },
                    Profits = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.IdCurrencyNavigation?.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Utilities == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Utilities ,//7655654654,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date == null ? "" : StaticFunctions.DateTimeToString(company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault()?.Date)//"12/31/2020"
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
                    .Include(x => x.Traductions)
                    .Include(x => x.CompanyBackgrounds).ThenInclude(x => x.CurrentPaidCapitalCurrencyNavigation)
                    .Include(x => x.FinancialBalances).ThenInclude(x => x.IdCurrencyNavigation)
                    .FirstOrDefaultAsync();
                var background = new LegalBackgroundDto
                {
                    LegalStatus = company.IdLegalPersonTypeNavigation.EnglishName == null ? "" : company.IdLegalPersonTypeNavigation.EnglishName,//"Publicly Held Corporation",
                    IncorporationDate = company.CompanyBackgrounds.FirstOrDefault().ConstitutionDate == null ? "" : StaticFunctions.DateTimeToString(company.CompanyBackgrounds.FirstOrDefault().ConstitutionDate),
                    OperationStartDate = company.CompanyBackgrounds.FirstOrDefault().StartFunctionYear == null ? "" : company.CompanyBackgrounds.FirstOrDefault().StartFunctionYear,
                    RegisterPlace = company.Traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue == null ? "" : company.Traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue,//"Lima",
                    NotaryOffice = company.CompanyBackgrounds.FirstOrDefault().NotaryRegister == null ? "" : company.CompanyBackgrounds.FirstOrDefault().NotaryRegister,//"Julio César*****",
                    DurationTime = company.Traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue == null ? "" : company.Traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue,//"Indefinite",
                    RegistrationFolio = company.Traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue == null ? "" : company.Traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue,//"Entry 1, Page 351, *****",
                    PaidInCapital = new CurrencyAmountDto
                    {
                        IsoCurrency = company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation == null || company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation.Abreviation == null ? "" : company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapitalCurrencyNavigation.Abreviation,//"PEN",
                        Amount = company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapital == null ? 0 : (double)company.CompanyBackgrounds.FirstOrDefault().CurrentPaidCapital,//555666664,
                        Comment = company.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue == null ? "" : company.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue//"Soles"
                    },
                    LastCapitalIncreaseDate = company.CompanyBackgrounds.FirstOrDefault().LastQueryRrpp == null ? "" : StaticFunctions.DateTimeToString(company.CompanyBackgrounds.FirstOrDefault().LastQueryRrpp),
                    ShareholdersEquity = new CurrencyAmountWithDateDto
                    {
                        IsoCurrency = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().IdCurrencyNavigation.Abreviation == null ? "" : company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().IdCurrencyNavigation.Abreviation,//"PEN",
                        Amount = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().TotalPatrimony == null ? 0 : (double)company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().TotalPatrimony,//4555555555,
                        LastInformationDate = company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().Date == null ? "" : StaticFunctions.DateTimeToString(company.FinancialBalances.OrderByDescending(x => x.Date).FirstOrDefault().Date)//"12/31/2020"
                    },
                    ShareClass = "",//"Common",
                    StockExchangeListed = company.CompanyBackgrounds.FirstOrDefault().Traded == "Si" ? true : false,
                    CurrentExchangeRate = GetExchangeRate(company.CompanyBackgrounds.FirstOrDefault().CurrentExchangeRate),
                    Membership = "",//"Lima Chamber of Commerce",
                    Comments = company.Traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue == null ? "" : company.Traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue,//"The Subject is listed in the Stock Exchange of\tima under the  tickers ALICORC1 and ALICORI1....."

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
                        SinceDate = item.StartDate == null ? "" : StaticFunctions.DateTimeToString(item.StartDate)
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
                    .Include(x => x.CompanyPartners).ThenInclude(x => x.IdPersonNavigation).ThenInclude(x => x.Traductions)
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
                        Title = item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue == null ? "" : item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue,
                        Nacionality = item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue == null ? "" : item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue,
                        Birthday = item.IdPersonNavigation.BirthDate == null ? "" : item.IdPersonNavigation.BirthDate,
                        Document = new DocumentTypeDto
                        {
                            TypeDocument = item.IdPersonNavigation.IdDocumentTypeNavigation == null || item.IdPersonNavigation.IdDocumentTypeNavigation.Abreviation == null ? "" : item.IdPersonNavigation.IdDocumentTypeNavigation.Abreviation,
                            NumberDocument = item.IdPersonNavigation == null || item.IdPersonNavigation.CodeDocumentType == null ? "" : item.IdPersonNavigation.CodeDocumentType
                        },
                        CivilStatus = item.IdPersonNavigation.IdCivilStatusNavigation == null || item.IdPersonNavigation.IdCivilStatusNavigation.EnglishName == null ? "" : item.IdPersonNavigation.IdCivilStatusNavigation.EnglishName,
                        Adreess = item.IdPersonNavigation.Address == null ? "" : item.IdPersonNavigation.Address,
                        Profession = item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue == null ? "" : item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue,
                        PaymentPolitic = new ValueDetailDto
                        {
                            Code = item.IdPersonNavigation.IdPaymentPolicyNavigation == null || item.IdPersonNavigation.IdPaymentPolicyNavigation.ApiCode == null ? "" : item.IdPersonNavigation.IdPaymentPolicyNavigation.ApiCode,
                            Description = item.IdPersonNavigation.IdPaymentPolicyNavigation == null || item.IdPersonNavigation.IdPaymentPolicyNavigation.EnglishName == null ? "" : item.IdPersonNavigation.IdPaymentPolicyNavigation.EnglishName,
                        },
                        FatherName = item.IdPersonNavigation.FatherName == null ? "" : item.IdPersonNavigation.FatherName,
                        ChiefExecutive = item.MainExecutive == null || item.MainExecutive == false ? false : true,
                        BackgroundInformation = item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "L_H_DETAILS").FirstOrDefault().LargeValue == null ? "" : item.IdPersonNavigation.Traductions.Where(x => x.Identifier == "L_H_DETAILS").FirstOrDefault().LargeValue,
                        AssociatedCompanies = listCompanyAssociated,

                    });
                }
                var whoIsWho = new List<WhoIsWhoDto>
                {
                    new WhoIsWhoDto
                    {

                        BackgroundInformation= "Son of Dionisio Romero Seminario, one of the main fo....",
                        AssociatedCompanies=new List<Associated>
                        {
                            new Associated
                            {
                                Name= "BANCO DE CREDITO DE BOLIVIA S.A.",
                                Title= "President",
                                IsoCountry= "BOL",
                                RegistrationNumber="1020435022"
                            },
                            new Associated
                            {
                                 Name= "INDUSTRIAS DEL ESPINO S.A.",
                                Title= "President",
                                IsoCountry= "PER",
                                RegistrationNumber="20163901197"
                            }
                        },
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
                     new WhoIsWhoDto
                    {
                        Name = "PEREZ GUBBINS, ALFRED****",
                        Title = "Chairman of BoD",
                        Nacionality="Peruvian",
                        Birthday="19OCT1954",
                        Document=new DocumentTypeDto
                        {
                            TypeDocument="DNI",
                            NumberDocument="12345678"
                        },
                        CivilStatus="Married to Joelyn ****",
                        Adreess="Lima",
                        Profession="MBA - Economist",
                        PaymentPolitic=new ValueDetailDto
                        {
                            Code="PP3",
                            Description="PROMPT (Payments always on time. Several years)"
                        },
                        FatherName="Dionisio Romero ****",
                        ChiefExecutive=true,
                        BackgroundInformation="Son of Dionisio Romero Seminario, one of the main fo....",
                        AssociatedCompanies=new List<Associated>
                        {
                            new Associated
                            {
                                Name= "BANCO DE CREDITO DE BOLIVIA S.A.",
                                Title= "President",
                                IsoCountry= "BOL",
                                RegistrationNumber="1020435022"
                            },
                            new Associated
                            {
                                 Name= "INDUSTRIAS DEL ESPINO S.A.",
                                Title= "President",
                                IsoCountry= "PER",
                                RegistrationNumber="20163901197"
                            }
                        },
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
                    }
                };
                return whoIsWho;
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
                    MainActivity = company.Traductions.Where(x => x.Identifier == "L_R_PRINCACT").FirstOrDefault().LargeValue,//"Subject is engaged in manufacturing and sale of fatty-type food....",
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
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBranchSectorNavigation)
                    .Include(x => x.CompanyBranches).ThenInclude(x => x.IdBusinessBranchNavigation)
                    .FirstOrDefaultAsync();
                var balancesGen = company.FinancialBalances.Where(x => x.BalanceType == "GENERAL").OrderByDescending(x => x.Date).ToList();
                var balancesSit = company.FinancialBalances.Where(x => x.BalanceType == "SITUACIONAL").OrderByDescending(x => x.Date).FirstOrDefault();
                var listBalGen = new List<BalanceSheetDto>();
                var listBalSit = new List<BalanceSheetDto>();
                var ratio = new RatioSituationDto
                {
                    LiquidityRatio = (double)balancesGen.FirstOrDefault().LiquidityRatio,
                    DebtToEquityRatio = (double)balancesGen.FirstOrDefault().DebtRatio,
                    ProfitabilityMargin = (double)balancesGen.FirstOrDefault().ProfitabilityRatio,
                    WorkingCapital = (double)balancesGen.FirstOrDefault().WorkingCapital
                };
                if (balancesSit != null)
                {
                    listBalSit.Add(new BalanceSheetDto
                    {
                        Date = StaticFunctions.DateTimeToString(balancesSit.Date),
                        TypeBalanceSheet = "Interim",
                        Period = balancesSit.DurationEng,
                        IsoCurrency = balancesSit.IdCurrencyNavigation.Abreviation,
                        ExchangeRate = balancesSit.ExchangeRate.ToString(),
                        Assets = new AssetsDto
                        {
                            CashBanks = (double)balancesSit.ACashBoxBank,
                            Receivables = (double)balancesSit.AToCollect,
                            Inventory = (double)balancesSit.AInventory,
                            OthersAssets = (double)balancesSit.AOtherCurrentAssets,
                            CurrentAssets = (double)balancesSit.TotalCurrentAssets,
                            Fixed = (double)balancesSit.AFixed,
                            OthersCurrentAssets = (double)balancesSit.AOtherNonCurrentAssets,
                            TotalAssets = (double)balancesSit.TotalAssets
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = (double)balancesSit.LCashBoxBank,
                            OthersLiabilities = (double)balancesSit.LOtherCurrentLiabilities,
                            CurrentLiabilities = (double)balancesSit.TotalCurrentLiabilities,
                            OthersCurrentLiabilities = (double)balancesSit.LOtherNonCurrentLiabilities
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = (double)balancesSit.PCapital,
                            Reserves = (double)balancesSit.PStockPile,
                            ProfitsLoots = (double)balancesSit.PUtilities,
                            TotalLiabilitiesShareholderEquity = (double)balancesSit.TotalLiabilitiesPatrimony,
                            TotalShareholderEquity = (double)balancesSit.TotalPatrimony
                        },
                        Sales = (double)balancesSit.Sales,
                        ProfitLoss = (double)balancesSit.Utilities
                    });

                }
                foreach (var balance in balancesGen)
                {
                    listBalGen.Add(new BalanceSheetDto
                    {
                        Date = StaticFunctions.DateTimeToString(balance.Date),
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
                        Code = company.CompanyFinancialInformations.FirstOrDefault().IdCollaborationDegreeNavigation.ApiCode,//"DI13",
                        Description = company.CompanyFinancialInformations.FirstOrDefault().IdCollaborationDegreeNavigation.EnglishName//"Report prepared exclusively from outside sources."
                    },
                    InformationProvided = company.Traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue,//"Directly personnel did not allow the coordination of an interview....",
                    InterimBalanceSheets = listBalSit,
                    RatioSituation = ratio,
                    SituationalFinancial = new ValueDetailDto
                    {
                        Code = company.CompanyFinancialInformations.FirstOrDefault().IdFinancialSituacionNavigation.ApiCode,//"SF3",
                        Description = company.CompanyFinancialInformations.FirstOrDefault().IdFinancialSituacionNavigation.EnglishName//"ACCEPTABLE Financial Situation"
                    },
                    Comments = company.Traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue,//"Land\r\nBuildings, plants and other constructions\r\nMachinery and equipment...",
                    AnalystComments = company.Traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue,//"Alicorp S.A.A. was incorporated in Peru on July 16, 1956....",
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
                    .Include(x => x.Traductions)
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
                    RegisterDate = company.CompanySbs.FirstOrDefault().DebtRecordedDate == null ? "" : StaticFunctions.DateTimeToString(company.CompanySbs.FirstOrDefault().DebtRecordedDate),//"12/31/2021",
                    MNTotal = company.CompanySbs.FirstOrDefault().GuaranteesOfferedNc == null ? 0 : (double)company.CompanySbs.FirstOrDefault().GuaranteesOfferedNc,//852364459,
                    MNGuaranteesOffered = 209663451,

                    SbsComment = company.Traductions.Where(x => x.Identifier == "").FirstOrDefault().LargeValue == null ? "" : company.Traductions.Where(x => x.Identifier == "").FirstOrDefault().LargeValue,// "Maintains unused lines of credit in banks:\r\nSCOTIABANK for S/.43.543.802.44 for loans.\r\nCITIBANK DEL PERU for S/.1,263,675 for c..."
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
