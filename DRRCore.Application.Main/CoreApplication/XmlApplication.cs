using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using Microsoft.IdentityModel.Tokens;

namespace DRRCore.Application.Main.CoreApplication
{
    public class XmlApplication : IXmlApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ITicketDomain _ticketDomain;
        private readonly ICompanyDomain _companyDomain;
        private readonly ICompanyBackgroundDomain _companyBackgroundDomain;
        private readonly ICompanyBranchDomain _companyBranchDomain;
        private readonly ICompanyFinancialInformationDomain _companyFinancialInformationDomain;
        private readonly ICompanyGeneralInformationDomain _companyGeneralInformationDomain;
        private readonly ICompanyCreditOpinionDomain _companyCreditOpinionDomain;
        private readonly ICompanySBSDomain _companySBSDomain;
        private readonly IFinancialBalanceDomain _financialBalanceDomain;
        private readonly ICompanyPartnersDomain _companyPartnersDomain;
        private readonly ICompanyShareHolderDomain _companyShareHolderDomain;
        private readonly ICompanyRelationDomain _companyRelationDomain;
        private readonly IImportsAndExportsDomain _importsAndExportsDomain;
        private readonly IFinancialSalesHistoryDomain _financialSalesHistoryDomain;
        private readonly IComercialLatePaymentDomain _comercialLatePaymentDomain;
        private readonly IBankDebtDomain _bankDebtDomain;
        private readonly IProviderDomain _providerDomain;
        public XmlApplication(ILogger logger,IMapper mapper, ICompanyDomain companyDomain,
            ICompanyBackgroundDomain companyBackgroundDomain, ICompanyBranchDomain companyBranchDomain, 
            ICompanyFinancialInformationDomain companyFinancialInformationDomain, ITicketDomain ticketDomain, 
            ICompanyGeneralInformationDomain companyGeneralInformationDomain, IFinancialBalanceDomain financialBalanceDomain, 
            ICompanyPartnersDomain companyPartnersDomain, ICompanyCreditOpinionDomain companyCreditOpinionDomain,
            ICompanySBSDomain companySBSDomain, ICompanyShareHolderDomain companyShareHolderDomain,
            ICompanyRelationDomain companyRelationDomain, IImportsAndExportsDomain importsAndExportsDomain,
            IFinancialSalesHistoryDomain financialSalesHistoryDomain, IProviderDomain providerDomain,
            IComercialLatePaymentDomain comercialLatePaymentDomain, IBankDebtDomain bankDebtDomain
            )
        {
            _ticketDomain = ticketDomain;
            _companyDomain = companyDomain;
            _companyBackgroundDomain = companyBackgroundDomain;
            _companyBranchDomain = companyBranchDomain;
            _companyFinancialInformationDomain = companyFinancialInformationDomain;
            _companyGeneralInformationDomain = companyGeneralInformationDomain;
            _financialBalanceDomain = financialBalanceDomain;
            _companyPartnersDomain = companyPartnersDomain;
            _companyCreditOpinionDomain = companyCreditOpinionDomain;
            _companySBSDomain = companySBSDomain;
            _companyShareHolderDomain = companyShareHolderDomain;
            _companyRelationDomain = companyRelationDomain;
            _importsAndExportsDomain = importsAndExportsDomain;
            _financialSalesHistoryDomain = financialSalesHistoryDomain;
            _providerDomain = providerDomain;
            _comercialLatePaymentDomain = comercialLatePaymentDomain;
            _bankDebtDomain = bankDebtDomain;
            _logger = logger;
            _mapper = mapper;
        }
        public string? GetCreditRiskCode(int? idCreditRisk)
        {
            return idCreditRisk == 1 ? "0005" : idCreditRisk == 2 ? "0000" : idCreditRisk == 3 ? "0001" :
                           idCreditRisk == 4 ? "0002" : idCreditRisk == 5 ? "0003" : idCreditRisk == 6 ? "0011" : idCreditRisk == 7 ? "0004" : "";
        }
        public string? GetBusinessBranchCode(int? idBusinessBranch)
        {
            return idBusinessBranch == 1 ? "0" : idBusinessBranch == 3 ? "1" : idBusinessBranch == 4 ? "2" : idBusinessBranch == 5 ? "3" :
            idBusinessBranch == 6 ? "4" : idBusinessBranch == 7 ? "5" : idBusinessBranch == 8 ? "6" : idBusinessBranch == 9 ? "7" : idBusinessBranch == 10 ? "8" :
            idBusinessBranch == 11 ? "9" : idBusinessBranch == 12 ? "10" : idBusinessBranch == 13 ? "11" : idBusinessBranch == 14 ? "12" : idBusinessBranch == 15 ? "13" :
            idBusinessBranch == 16 ? "14" : idBusinessBranch == 17 ? "15" : idBusinessBranch == 18 ? "16" : idBusinessBranch == 19 ? "17" : idBusinessBranch == 20 ? "18" :
            idBusinessBranch == 21 ? "19" : idBusinessBranch == 22 ? "20" : idBusinessBranch == 23 ? "21" : idBusinessBranch == 24 ? "22" : idBusinessBranch == 25 ? "23" :
            idBusinessBranch == 26 ? "24" : idBusinessBranch == 27 ? "25" : idBusinessBranch == 28 ? "26" : idBusinessBranch == 29 ? "27" : idBusinessBranch == 30 ? "28" :
            idBusinessBranch == 31 ? "29" : idBusinessBranch == 32 ? "30" : "";
        }
        public string? GetCountryCode(int? idCountry)
        {
            return idCountry == null ? "" : idCountry == 11 ? "001" : idCountry == 29 ? "002" : idCountry == 34 ? "003" :
            idCountry == 54 ? "004" : idCountry == 57 ? "005" : idCountry == 49 ? "006" :
            idCountry == 70 ? "007" : idCountry == 72 ? "008" : idCountry == 100 ? "009" :
            idCountry == 108 ? "010" : idCountry == 168 ? "012" : idCountry == 179 ? "013" :
            idCountry == 181 ? "014" :idCountry == 182 ? "015" : idCountry == 187 ? "016" :
            idCountry == 69 ? "017" : idCountry == 237 ? "018" : idCountry == 250 ? "019" :
            idCountry == 249 ? "020" :idCountry == 253 ? "021" : idCountry  == 105 ? "022" :
            idCountry == 147 ? "023" :idCountry == 98 ? "024" :idCountry == 104 ? "025" :
            idCountry == 46 ? "026" : idCountry == 60 ? "027" : idCountry == 256 ? "029" :
            idCountry == 255 ? "030" :idCountry == 43 ? "031" :idCountry == 25 ? "032" :
            idCountry == 18 ? "033" : idCountry == 120 ? "034" :idCountry == 183 ? "035" :
            idCountry == 92 ? "036" : idCountry == 15 ? "037" : idCountry == 21 ? "038" :
            idCountry == 151 ? "039" :idCountry == 59 ? "040" :idCountry == 220 ? "041" :
            idCountry == 186 ? "042" :idCountry == 13 ? "043" :idCountry == 16 ? "044" :
            idCountry == 24 ? "045" : idCountry == 27 ? "046" : idCountry  == 68 ? "047" :
            idCountry == 84 ? "048" : idCountry == 97 ? "049" : idCountry == 123 ? "064" :
            idCountry == 109 ? "051" :idCountry == 119 ? "052" : idCountry == 121 ? "053" :
            idCountry == 218 ? "054" :idCountry == 196 ? "055" : idCountry == 197 ? "056" :
            idCountry == 198 ? "057" :idCountry == 224 ? "058" : idCountry == 8 ? "059" :
            idCountry == 149 ? "060" :idCountry == 50 ? "061" :idCountry == 229 ? "062" :
            idCountry == 10 ? "063" : idCountry == 65 ? "065" : idCountry == 239 ? "066" :
            idCountry == 205 ? "067" :idCountry == 83 ? "068" :idCountry == 175 ? "069" :
            idCountry == 62 ? "070" : idCountry == 191 ? "071" : idCountry  == 245 ? "072" :
            idCountry == 247 ? "073" :idCountry == 200 ? "074" : idCountry == 156 ? "076" :
            idCountry == 194 ? "078" :idCountry == 241 ? "080" : idCountry == 265 ? "081" :
            idCountry == 264 ? "079" :idCountry == 227 ? "083" : idCountry == 226 ? "084" :
            idCountry == 131 ? "085" :idCountry == 112 ? "086" : idCountry == 118 ? "087" :
            idCountry == 185 ? "088" :idCountry == 137 ? "089" : idCountry == 165 ? "090" :
            idCountry == 94 ? "091" : idCountry == 142 ? "092" : idCountry == 243 ? "093" :
            idCountry == 246 ? "095" :idCountry == 124 ? "096" : idCountry  == 4 ? "097" :
            idCountry == 91 ? "099" : idCountry == 95 ? "100" : idCountry == 266 ? "101" :
            idCountry == 210 ? "102" :idCountry == 136 ? "103" : idCountry == 177 ? "104" :
            idCountry == 7 ? "105" : idCountry == 26 ? "106" : idCountry == 32 ? "107" :
            idCountry == 38 ? "108" : idCountry == 39 ? "109" :idCountry == 42 ? "110" :
            idCountry == 47 ? "111" : idCountry == 48 ? "113" : idCountry  == 55 ? "114" :
            idCountry == 267 ? "115" :idCountry == 71 ? "116" :idCountry== 102 ? "117" :
            idCountry == 75 ? "118" : idCountry == 78 ? "119" : idCountry== 88 ? "120" :
            idCountry == 90 ? "121" : idCountry == 93 ? "122" : idCountry == 103 ? "123" :
            idCountry == 125 ? "124" :idCountry == 134 ? "125" : idCountry == 135 ? "126" :
            idCountry == 140 ? "127" :idCountry == 141 ? "128" : idCountry == 144 ? "129" :
            idCountry == 148 ? "130" :idCountry == 157 ? "132" : idCountry == 158 ? "133" :
            idCountry == 160 ? "134" :idCountry == 168 ? "135" : idCountry == 192 ? "136" :
            idCountry == 259 ? "137" :idCountry == 206 ? "139" : idCountry == 209 ? "140" :
            idCountry == 215 ? "141" :idCountry == 223 ? "142" : idCountry == 77 ? "143" :
            idCountry == 234 ? "145" :idCountry == 244 ? "147" : idCountry == 268 ? "148" :
            idCountry == 261 ? "149" :idCountry == 262 ? "150" : idCountry == 1 ? "152" :
            idCountry == 12 ? "153" : idCountry == 17 ? "154" : idCountry == 19 ? "155" :
            idCountry == 20 ? "156" : idCountry == 28 ? "157" : idCountry == 36 ? "158" :
            idCountry == 281 ? "159" : idCountry  == 41 ? "160" : idCountry == 61 ? "161" :
            idCountry == 113 ? "162" : idCountry == 114 ? "163" : idCountry == 115 ? "164" :
            idCountry == 129 ? "166" : idCountry == 128 ? "167" : idCountry == 130 ? "168" :
            idCountry == 154 ? "169" : idCountry == 162 ? "170" : idCountry == 176 ? "171" :
            idCountry == 222 ? "172" : idCountry == 188 ? "173" : idCountry == 204 ? "174" :
            idCountry == 221 ? "175" : idCountry == 228 ? "176" : idCountry == 230 ? "177" :
            idCountry == 232 ? "178" : idCountry == 240 ? "179" : idCountry == 251 ? "181" :
            idCountry == 254 ? "182" : idCountry == 260 ? "183" : idCountry == 3 ? "185" :
            idCountry == 6 ? "186" : idCountry == 31 ? "187" : idCountry == 37 ? "188" :
            idCountry == 23 ? "189" :idCountry == 58 ? "190" : idCountry == 76 ? "191" :
            idCountry == 80 ? "192" : idCountry == 110 ? "193" : idCountry == 111 ? "194" :
            idCountry == 116 ? "195" : idCountry == 138 ? "197" :idCountry == 172 ? "198" :
            idCountry == 145 ? "199" : idCountry == 152 ? "200" :idCountry == 153 ? "201" :
            idCountry == 190 ? "202" : idCountry == 202 ? "203" :idCountry == 155 ? "204" :
            idCountry == 212 ? "205" : idCountry == 213 ? "206" :idCountry == 214 ? "208" :
            idCountry == 252 ? "209" : idCountry == 82 ? "210" : idCountry == 161 ? "211" :
            idCountry == 146 ? "212" : idCountry == 99 ? "213" : idCountry == 201 ? "214" :
            idCountry == 178 ? "215" : idCountry == 236 ? "216" :idCountry == 86 ? "217" :
            idCountry == 171 ? "221" : idCountry == 282 ? "222" :idCountry == 85 ? "219" :
            idCountry == 117 ? "224" : idCountry == 143 ? "220" :idCountry == 139 ? "225" :
            idCountry == 169 ? "011" : idCountry == 164 ? "028" :idCountry == 283 ? "207" :
            idCountry == 284 ? "218" : idCountry == 285 ? "223" :idCountry == 63 ? "226" :
            idCountry == 180 ? "227" : idCountry == 286 ? "228" :idCountry == 143 ? "229" :
            idCountry == 208 ? "230" : idCountry == 64 ? "231" : idCountry == 263 ? "232" :
            idCountry == 60 ? "233" : idCountry == 30 ? "234" : idCountry == 217 ? "235" :
            idCountry == 231 ? "236" : idCountry == 30 ? "237" :idCountry == 30 ? "238" :
           idCountry == 18 ? "239" : idCountry == 207 ? "240" : idCountry == 155 ? "241" : "";
        }
        public Boolean isNumeric(String numero)
        {
            try
            {
                double.Parse(numero);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<Response<GetFileResponseDto>> GetXmlCredendoAsync(int idTicket)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var idParameter = new SqlParameter("@idTicket", idTicket);
                var resultCompany = context.Set<CompanyXmlData>()
                                     .FromSqlRaw("EXECUTE DataCompanyCredendo @idTicket", idParameter)
                                     .AsEnumerable()
                                     .FirstOrDefault();
                var resultBalance = context.Set<CompanyBalanceData>()
                                    .FromSqlRaw("EXECUTE BalanceCompanyCredendo @idTicket", idParameter)
                                    .AsEnumerable()
                                    .ToList();
                var resultFunction =  context.Set<CompanyFunctionData>()
                                    .FromSqlRaw("EXECUTE FunctionCompanyCredendo @idTicket", idParameter)
                                    .AsEnumerable()
                                    .ToList();
                var resultLegalEvents =  context.Set<CompanyLegalEventsData>()
                                    .FromSqlRaw("EXECUTE LegalEventsCompanyCredendo @idTicket", idParameter)
                                    .AsEnumerable()
                                    .ToList();
                var resultRelated=  context.Set<CompanyRelatedData>()
                                    .FromSqlRaw("EXECUTE RelatedCompanyCredendo @idTicket", idParameter)
                                    .AsEnumerable()
                                    .ToList();
                if (resultCompany != null)
                {
                    string[] telefono = null;
                    string cadena = "";
                    List<XElement> TelefonoArray = new List<XElement>();
                    if (resultCompany.ContactPhoneNumber != "" && resultCompany.ContactPhoneNumber != null)
                    {
                        telefono = resultCompany.ContactPhoneNumber.Split(new char[] { ',', ';', '-' });
                        telefono = (from e in telefono
                                    select e.Trim()).ToArray();

                        for (int n = 0; n <= telefono.Length - 1; n++)
                        {
                            cadena = "<contact><contactPhoneNumber>" + resultCompany.ContactPrefixPhoneNumber + " " + telefono[n] + "</contactPhoneNumber></contact>";
                            TelefonoArray.Add(new XElement(XElement.Parse(cadena)));
                        }
                    }

                    string[] correo = null;
                    cadena = "";
                    List<XElement> CorreoArray = new List<XElement>();
                    if (resultCompany.ContactEmailAddress != "" && resultCompany.ContactPhoneNumber != null)
                    {
                        correo = resultCompany.ContactEmailAddress.Split(new char[] { ',', ';' });
                        correo = (from e in correo
                                  select e.Trim()).ToArray();

                        for (int n = 0; n <= correo.Length - 1; n++)
                        {
                            cadena = "<contact><contactEmailAddress>" + correo[n] + "</contactEmailAddress></contact>";
                            CorreoArray.Add(new XElement(XElement.Parse(cadena)));
                        }
                    }
                    Boolean bMaximumSingleCreditAdviceAmount = true;
                    if (String.IsNullOrEmpty(resultCompany.SourceEvaluationMaximumSingleCreditAdviceAmount) == true)
                    {
                        bMaximumSingleCreditAdviceAmount = false;
                    }
                    else
                    {
                        if (isNumeric(resultCompany.SourceEvaluationMaximumSingleCreditAdviceAmount) == true)
                        {
                            double valor = Convert.ToDouble(resultCompany.SourceEvaluationMaximumSingleCreditAdviceAmount);
                            if (valor == 0)
                            {
                                bMaximumSingleCreditAdviceAmount = false;
                            }
                        }
                    }

                    XNamespace xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                    XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-8", ""),
                        new XElement("credendoCanonicalReport",
                            new XAttribute(XNamespace.Xmlns + "xsi", xsiNs),
                            //new XAttribute("noNamespaceSchemaLocation", filePahthXsd ),
                            new XElement("version",
                                new XElement("major"),
                                new XElement("minor"),
                                new XElement("mappingVersion", (resultCompany == null ? "" : resultCompany.DebtorName))
                            ),
                            new XElement("inquiry",
                                new XElement("debtorName", (resultCompany == null ? "" : resultCompany.DebtorName)),
                                new XElement("debtorCountry", (resultCompany == null ? "" : GetCountryCode(resultCompany.Country))),
                                //new XElement("providerName"),
                                new XElement("providerReportReference", (resultCompany == null ? "" : resultCompany.ProviderReportReference)),
                                //new XElement("financialFiguresDate"),
                                new XElement("reportDefaultCurrency", (resultCompany == null ? "" : resultCompany.ReportDefaultCurrency)),
                                new XElement("reportDefaultMonetaryFactorCode", (resultCompany == null ? "" : resultCompany.ReportDefaultMonetaryFactorCode)),
                                new XElement("language", (resultCompany == null ? "" : resultCompany.Language))
                            ),
                            new XElement("key",
                                new XElement("taxIdentificationKey",
                                    new XElement("key", (resultCompany == null ? "" : resultCompany.TaxIdentificationKey))
                                //new XElement("category", (bussines.FirstOrDefault() == null ? "" : bussines.FirstOrDefault().taxIdentificationCategory))
                                ),

                                new XElement("sourceIdentificationKey",
                                    new XElement("key", (resultCompany == null ? "" : resultCompany.SourceIdentificationKey))
                                //new XElement("category", (bussines.FirstOrDefault() ?? "").sourceIdentificationCategory)
                                )
                            ),
                            new XElement("operatingStatus",
                                new XElement("operatingStatus", (resultCompany == null ? "" : resultCompany.OperatingStatus)),
                                new XElement("operatingStatusObservationDate", (resultCompany == null ? "" : resultCompany.OperatingStatusObservationDate))
                            ),
                            new XElement("masterDataBusinessPartner",
                                //new XElement("branchIndicator", "No branch"),
                                new XElement("name",
                                    new XElement("companyName", (resultCompany == null ? "" : resultCompany.CompanyName)),
                                    new XElement("companyNameType", (resultCompany == null ? "" : resultCompany.CompanyNameType)),
                                    new XElement("languageAndAlphabetType", (resultCompany == null ? "" : resultCompany.LanguageAndAlphabetType))
                                ),
                                resultCompany.CompanyTradName == "" ? null :
                                new XElement("name",
                                    new XElement("companyName", (resultCompany == null ? "" : resultCompany.CompanyTradName)),
                                    new XElement("companyNameType", (resultCompany == null ? "" : resultCompany.CompanyTradeNameType)),
                                    new XElement("languageAndAlphabetType", (resultCompany == null ? "" : resultCompany.LanguageAndAlphabetTradeType))
                                ),
                                new XElement("address",
                                    new XElement("addressType", (resultCompany == null ? "" : resultCompany.AddressType)),
                                    new XElement("languageAndAlphabetType", (resultCompany == null ? "" : resultCompany.LanguageAndAlphabetType)),
                                    new XElement("street", (resultCompany == null ? "" : resultCompany.Street)),
                                    //bussines.FirstOrDefault().postCode == "" ? null : new XElement("postCode", (bussines.FirstOrDefault().postCode)),
                                    new XElement("postCode", (resultCompany == null ? "" : resultCompany.PostCode)),
                                    new XElement("city", (resultCompany == null ? "" : resultCompany.City)),
                                    new XElement("stateRegion", (resultCompany == null ? "" : resultCompany.StateRegion)),
                                    new XElement("country", (resultCompany == null ? "" : GetCountryCode(resultCompany.Country)))
                                ),
                                resultCompany.FormerAddressStreet == "" ? null :
                                 new XElement("address",
                                    new XElement("addressType", (resultCompany == null ? "" : resultCompany.FormerAddressType)),
                                    new XElement("languageAndAlphabetType", (resultCompany == null ? "" : resultCompany.FormerAddresslanguageAndAlphabetType)),
                                    new XElement("street", (resultCompany == null ? "" : resultCompany.FormerAddressStreet)),
                                    new XElement("country", (resultCompany == null ? "" : GetCountryCode(resultCompany.FormerAddressCountry)))
                                ),
                                //bussines.Where(p => p.cR_MDBP_ADDRESS_street2 != "")
                                //.Select(p => 
                                //    new XElement("address",
                                //        new XElement("addressType", p.CR_MDBP_ADDRESS_street2NombreIng),
                                //        new XElement("languageAndAlphabetType", (bussines.FirstOrDefault() ?? "").CR_MDBP_ADDRESS_languageAndAlphabetType),
                                //        new XElement("street",p.CR_MDBP_ADDRESS_street2),
                                //        new XElement("postCode", (bussines.FirstOrDefault() ?? "").CR_MDBP_ADDRESS_postCode),
                                //        new XElement("city", (bussines.FirstOrDefault() ?? "").CR_MDBP_ADDRESS_city), 
                                //        new XElement("stateRegion", (bussines.FirstOrDefault() ?? "").CR_MDBP_ADDRESS_stateRegion), 
                                //        new XElement("country", (bussines.FirstOrDefault() ?? "").CR_MDBP_ADDRESS_country) 
                                //    )
                                //),


                                resultCompany.NumberOfEmployeesWithinTheCompanyRangeFrom == 0 ? null :
                                new XElement("numberOfEmployees",
                                    new XElement("numberOfEmployeesType", (resultCompany == null ? "" : resultCompany.NumberOfEmployeesType)),
                                    new XElement("numberOfEmployeesWithinTheCompanyRangeFrom", (resultCompany == null ? "" : resultCompany.NumberOfEmployeesWithinTheCompanyRangeFrom))
                                ),
                                new XElement("companyLegalForm", (resultCompany == null ? "" : resultCompany.CompanyLegalForm)),

                                new XElement("companyListedStockExchange", (resultCompany == null ? "" : resultCompany.CompanyListedStockExchange)),

                                CorreoArray.Count == 0 ? null : CorreoArray,

                                TelefonoArray.Count == 0 ? null : TelefonoArray,

                                new XElement("contact",
                                     new XElement("contactWebsiteAddress", (resultCompany == null ? "" : resultCompany.ContactWebsiteAddress))
                                ),
                                new XElement("incorporationDate", (resultCompany == null ? "" : resultCompany.IncorporationDate)),
                                new XElement("registrationDate", (resultCompany == null ? "" : resultCompany.RegistrationDate)),
                                new XElement("companyMainSector",
                                    new XElement("companyMainSectorCode", (resultCompany == null ? "" : GetBusinessBranchCode(resultCompany.CompanyMainSectorCode))),
                                    new XElement("companyMainSectorCodeType", (resultCompany == null ? "" : resultCompany.CompanyMainSectorCodeType)),
                                    new XElement("companyMainSectorDescription", (resultCompany == null ? "" : resultCompany.CompanyMainSectorDescription))
                                ),
                                new XElement("companyNature", (resultCompany == null ? "" : resultCompany.CompanyNature))
                            //new XElement("companyNatureFromProvider", (bussines.FirstOrDefault() ?? "").companyNatureFromProvider)
                            ),
                            resultBalance.Select(balance =>
                                new XElement("financialData",
                                    new XElement("keyFigures",
                                        new XElement("accountingPeriod", balance.CR_FD_keyFigures_accountingPeriod),
                                        new XElement("endDateOfAccountingPeriod", balance.CR_FD_keyFigures_endDateOfAccountingPeriod),
                                        new XElement("typeOfFigures", balance.CR_FD_keyFigures_typeOfFigures),
                                        new XElement("balancesheetDefaultCurrency", balance.CR_FD_keyFigures_balancesheetDefaultCurrency),
                                        new XElement("balancesheetDefaultMonetaryFactorCode", balance.CR_FD_keyFigures_balancesheetDefaultMonetaryFactorCode),
                                        //new XElement("keyFigure",
                                        //new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalAssets), 
                                        //new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueTotalAssets), 
                                        //new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeTotalAssets)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueTotalAssets == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalAssets),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueTotalAssets)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeTotalAssets)
                                        ),
                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeFixedAssets), 
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueFixedAssets), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeFixedAssets)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueFixedAssets == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeFixedAssets),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueFixedAssets)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeFixedAssets)
                                        ),
                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeCurrentAssets),
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCurrentAssets), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCurrentAssets)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCurrentAssets == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeCurrentAssets),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCurrentAssets)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCurrentAssets)
                                        ),

                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueNonCurrentAssets == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeNonCurrentAssets),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueNonCurrentAssets)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeNonCurrentAssets)
                                        ),

                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalEquityLiabilities), 
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCodeTotalEquityLiabilities), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCodeTotalEquityLiabilities)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCodeTotalEquityLiabilities == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalEquityLiabilities),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueCodeTotalEquityLiabilities)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCodeTotalEquityLiabilities)
                                        ),
                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquity),
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquity),
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquity)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquity == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquity),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquity)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquity)
                                        ),

                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueLTLiabilities == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeLTLiabilities),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueLTLiabilities)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeLTLiabilities)
                                        ),

                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueSTLiabilities == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeSTLiabilities),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueSTLiabilities)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeSTLiabilities)
                                        ),

                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityPaiduPCapital), 
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityPaiduPCapital), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityPaiduPCapital)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityPaiduPCapital == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityPaiduPCapital),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityPaiduPCapital)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityPaiduPCapital)
                                        ),
                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityRevenueSales), 
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityRevenueSales), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityRevenueSales)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityRevenueSales == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityRevenueSales),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityRevenueSales)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityRevenueSales)
                                        ),
                                        //new XElement("keyFigure",
                                        //    new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityNetResult), 
                                        //    new XElement("keyFigureItemValue", balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityNetResult), 
                                        //    new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityNetResult)
                                        balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityNetResult == 0 ? null :
                                            new XElement("keyFigure",
                                                new XElement("keyFigureItemCode", balance.CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityNetResult),
                                                new XElement("keyFigureItemValue", Math.Truncate((decimal)balance.CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityNetResult)),
                                                new XElement("keyFigureUnitPrefixCode", balance.CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityNetResult)
                                        )
                                    )
                                )
                            ),
                             // SERA UNA LISTA
                             resultFunction.Select(function =>
                                 new XElement("function",
                                    new XElement("functionType", function.FunctionType == null ? "" : function.FunctionType),
                                    new XElement("nameOfPerson", function.NameOfPerson == null ? "" : function.NameOfPerson)
                                )
                             ),

                             //legalEvents.Select(legalEvent =>
                             //    new XElement("legalEvent",
                             //         new XElement("event", legalEvent.legalEvent),
                             //         new XElement("sourceEvent", legalEvent.sourceEvent),
                             //         new XElement("endDate", legalEvent.endDate),
                             //         new XElement("startDate", legalEvent.startDate)
                             //     )
                             //),

                             resultLegalEvents.Select(legalEvent =>
                               legalEvent.LegalEvent == null ? null : new XElement("legalEvent",
                                                            new XElement("event", legalEvent.LegalEvent == null ? "" : legalEvent.LegalEvent),
                                                            new XElement("sourceEvent", legalEvent.SourceEvent == null ? "" : legalEvent.SourceEvent),
                                                            new XElement("endDate", legalEvent.EndDate == null ? "" : legalEvent.EndDate),
                                                            new XElement("startDate", legalEvent.StartDate == null ? "" : legalEvent.StartDate))
                             ),

                            new XElement("sourceEvaluation",
                                new XElement("sourceEvaluationOriginalPaymentExperience", (resultCompany == null ? "" : resultCompany.SourceEvaluationOriginalPaymentExperience)),
                                new XElement("sourceEvaluationSimplePaymentExperience", (resultCompany == null ? "" : GetCreditRiskCode(resultCompany.SourceEvaluationSimplePaymentExperience))),
                                new XElement("sourceEvaluationExtendedPaymentExperience", (resultCompany == null ? "" : resultCompany.SourceEvaluationExtendedPaymentExperience)),
                                new XElement("sourceEvaluationCreditAdviceAmount", (resultCompany == null ? "" : resultCompany.SourceEvaluationCreditAdviceAmount)),
                                new XElement("sourceEvaluationCreditAdviceExplanation", (resultCompany == null ? "" : resultCompany.SourceEvaluationCreditAdviceExplanation)),
                                new XElement("sourceEvaluationMaximumCreditAdviceAmount", (resultCompany == null ? "" : resultCompany.SourceEvaluationMaximumCreditAdviceAmount)),
                                //new XElement("sourceEvaluationMaximumSingleCreditAdviceAmount", (bussines.FirstOrDefault() == null ? "" : bussines.FirstOrDefault().sourceEvaluationMaximumSingleCreditAdviceAmount)),
                                //new XElement("sourceEvaluationCurrency", (bussines.FirstOrDefault() == null ? "" : bussines.FirstOrDefault().sourceEvaluationCurrency)),
                                bMaximumSingleCreditAdviceAmount == false ? null : new XElement("sourceEvaluationMaximumSingleCreditAdviceAmount", resultCompany.SourceEvaluationMaximumSingleCreditAdviceAmount == null ? "" : resultCompany.SourceEvaluationMaximumSingleCreditAdviceAmount),
                                bMaximumSingleCreditAdviceAmount == false ? null : new XElement("sourceEvaluationCurrency", resultCompany.SourceEvaluationCurrency == null ? "" : resultCompany.SourceEvaluationCurrency),
                                new XElement("sourceRating", (resultCompany == null ? "" : resultCompany.SourceRating)),
                                new XElement("sourceRatingRange", (resultCompany == null ? "" : resultCompany.SourceRatingRange)),
                                new XElement("sourceRatingComments", (resultCompany == null ? "" : resultCompany.SourceRatingComments)),
                                new XElement("sourceEvaluationComments", (resultCompany == null ? "" : resultCompany.SourceEvaluationComments)),

                               resultRelated.Select(related =>
                                  new XElement("relatedCompany",
                                       new XElement("relatedName", related.RelatedName == null ? "" : related.RelatedName),
                                       new XElement("relatedTaxReg", related.RelatedTaxReg == null ? "" : related.RelatedTaxReg),
                                       new XElement("relatedCountry", related.RelatedCountry == null ? "" : GetCountryCode(related.RelatedCountry)),
                                       new XElement("dateInc", related.DateInc == null ? "" : related.DateInc),
                                       new XElement("relationType", related.RelationType == null ? "" : related.RelationType)
                                   )
                               )
                            )
                        )
                    );
                    string xmlString = xDoc.ToString();

                    // Convertir la cadena XML en un MemoryStream
                    byte[] byteArray = Encoding.UTF8.GetBytes(xmlString);
                    response.Data = new GetFileResponseDto
                    {
                        File = byteArray,
                        ContentType = "application/xml",
                        Name = "N" + resultCompany.TicketNumber.ToString("D6") + "_" + resultCompany.DebtorName.Replace(" ","_") + ".xml"
                    };
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> GetXmlAtradiusAsync(int idTicket)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var idParameter = new SqlParameter("@idTicket", idTicket);
                var ticket = await _ticketDomain.GetByIdAsync(idTicket);
                if (ticket != null)
                {
                    var company = await _companyDomain.GetByIdAsync((int)ticket.IdCompany);
                    var companyBackground = await _companyBackgroundDomain.GetByIdAsync(((int)ticket.IdCompany));
                    var companyBranch = await _companyBranchDomain.GetCompanyBranchByIdCompany((int)ticket.IdCompany);
                    var companyFinancial = await _companyFinancialInformationDomain.GetByIdCompany((int)ticket.IdCompany);
                    var companyInfoGeneral = await _companyGeneralInformationDomain.GetByIdCompany((int)ticket.IdCompany);
                    var companySbs = await _companySBSDomain.GetByIdCompany((int)ticket.IdCompany);
                    var balanceG = await _financialBalanceDomain.GetFinancialBalanceByIdCompany((int)ticket.IdCompany, "GENERAL");
                    var balanceS = await _financialBalanceDomain.GetFinancialBalanceByIdCompany((int)ticket.IdCompany, "SITUACIONAL");
                    var companyCreditOpinion = await _companyCreditOpinionDomain.GetByIdCompany((int)ticket.IdCompany);
                    var companyPartner = await _companyPartnersDomain.GetPartnersByIdCompany((int)ticket.IdCompany);
                    var companyShareholder = await _companyShareHolderDomain.GetShareHoldersByIdCompany((int)ticket.IdCompany);
                    var companyRelation = await _companyRelationDomain.GetCompanyRelationByIdCompany((int)ticket.IdCompany);
                    var salesHistory = await _financialSalesHistoryDomain.GetByIdCompany((int)ticket.IdCompany);
                    var providers = await _providerDomain.GetProvidersByIdCompany((int)ticket.IdCompany);
                    var morComercial = await _comercialLatePaymentDomain.GetComercialLatePaymetByIdCompany((int)ticket.IdCompany);
                    var bankDebt = await _bankDebtDomain.GetBankDebtsByIdCompany((int)ticket.IdCompany);

                    var resultCompanyShareholder = context.Set<CompanyShareholderSP>()
                                         .FromSqlRaw("EXECUTE ShareholderCompany @idTicket", idParameter)
                                         .AsEnumerable()
                                         .ToList();
                    var resultWhoIsWho = context.Set<WhoIsWhoSP>()
                                         .FromSqlRaw("EXECUTE WhoIsWho @idTicket", idParameter)
                                         .AsEnumerable()
                                         .ToList();
                    // Crear el documento XML
                    XmlDocument xmlDoc = new XmlDocument();
                    // Agregar la instrucción de procesamiento XML y la declaración de la hoja de estilo
                    XmlProcessingInstruction styleSheetInstruction = xmlDoc.CreateProcessingInstruction("xml-stylesheet", "href='templateA_ingles.xsl' type='text/xsl'");
                    xmlDoc.AppendChild(styleSheetInstruction);
                    // Crear el nodo raíz
                    XmlElement rootElement = xmlDoc.CreateElement("CompanyReport");
                    xmlDoc.AppendChild(rootElement);

                    //Client_Data
                    XmlElement clientDataElement = xmlDoc.CreateElement("Client_Data");
                    rootElement.AppendChild(clientDataElement);
                    AddCDataElement(xmlDoc, clientDataElement, "Client", ticket.IdSubscriberNavigation.Code);
                    AddCDataElement(xmlDoc, clientDataElement, "FecInf", ticket.OrderDate.ToString("dddd, MMMM dd, yyyy"));
                    AddCDataElement(xmlDoc, clientDataElement, "Status", ticket.IdSubscriberNavigation.Enable == true ? "Active" : "Inactive");
                    AddCDataElement(xmlDoc, clientDataElement, "Status_Desde", ticket.IdSubscriberNavigation.Code);
                    AddCDataElement(xmlDoc, clientDataElement, "Ordered_On", ticket.OrderDate.ToString("dddd, MMMM dd, yyyy"));
                    if (!ticket.ReferenceNumber.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, clientDataElement, "ClientReference", ticket.ReferenceNumber);
                    }
                    if (!ticket.ReferenceNumber.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, clientDataElement, "Order_Num", ticket.ReferenceNumber);
                    }
                    AddCDataElement(xmlDoc, clientDataElement, "Priority", ticket.ProcedureType);
                    AddCDataElement(xmlDoc, clientDataElement, "Your_Request", ticket.RequestedName);

                    //Identification
                    XmlElement identificationElement = xmlDoc.CreateElement("Identification");
                    rootElement.AppendChild(identificationElement);
                    AddCDataElement(xmlDoc, identificationElement, "Correct_Company_Name", ticket.IdCompanyNavigation.Name);
                    if (!company.SocialName.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Trade_Name", company.SocialName);
                    }
                    if (!company.TaxTypeCode.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Taxpayer_Registration", company.TaxTypeCode);
                    }
                    if (!company.Address.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Main_Address", company.Address);
                    }
                    if (!company.Place.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "City_Province", company.Place);
                    }
                    if (!company.PostalCode.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Postal_Code", company.PostalCode);
                    }
                    if (company.IdCountry != 0 && company.IdCountry != null)
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Country", company.IdCountryNavigation.EnglishName);
                    }
                    if (!company.Telephone.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Telephone", company.Telephone);
                    }
                    if (!company.Cellphone.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Phone_Mobile", company.Cellphone);
                    }
                    if (!company.WhatsappPhone.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "WhatsApp", company.WhatsappPhone);
                    }
                    if (!company.Email.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Email", company.Email);
                    }
                    if (!company.WebPage.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Web", company.WebPage);
                    }
                    if (!company.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, identificationElement, "Comment", company.Traductions.Where(x => x.Identifier == "L_E_COMIDE").FirstOrDefault().LargeValue);
                    }

                    //Summary
                    XmlElement summaryElement = xmlDoc.CreateElement("Summary");
                    rootElement.AppendChild(summaryElement);
                    if (!companyInfoGeneral.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Ver_Resumen", companyInfoGeneral.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue);
                    }
                    if (companyBackground.ConstitutionDate != null)
                    {
                        DateTime date = (DateTime)companyBackground.ConstitutionDate;
                        AddCDataElement(xmlDoc, summaryElement, "Incorporation", date.ToString("yyyy"));
                    }
                    if (companyBackground.CurrentPaidCapital > 0)
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Capital_Stock", companyBackground.CurrentPaidCapitalCurrencyNavigation.Abreviation + companyBackground.CurrentPaidCapital.ToString() +
                            companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue == null ? "" : companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue);
                    }
                    if (balanceG.Count > 0)
                    {
                        DateTime date = (DateTime)balanceG[0].Date;
                        AddCDataElement(xmlDoc, summaryElement, "Shareholders_Equity", balanceG[0].TotalPatrimony.ToString() + " " + balanceG[0].IdCurrencyNavigation.Abreviation + " (" + date.ToString("ddMMMyyyy") + ")");
                        AddCDataElement(xmlDoc, summaryElement, "Annual_Revenues", balanceG[0].Sales.ToString() + " " + balanceG[0].IdCurrencyNavigation.Abreviation + " (" + date.ToString("ddMMMyyyy") + ")");
                        AddCDataElement(xmlDoc, summaryElement, "Profits", balanceG[0].Utilities.ToString() + " " + balanceG[0].IdCurrencyNavigation.Abreviation + " (" + date.ToString("ddMMMyyyy") + ")");
                    }
                    if (companyBranch.WorkerNumber != null)
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Employees", companyBranch.WorkerNumber.ToString());
                    }
                    if (companyPartner.Count > 0)
                    {
                        string principalExec = "";
                        foreach (var item in companyPartner)
                        {
                            principalExec = item.MainExecutive == true ? item.IdPersonNavigation.Fullname : "";
                        }
                        if (!principalExec.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, summaryElement, "Chief_Executive", principalExec);
                        }
                    }
                    if(companyFinancial != null)
                    {
                        if(companyFinancial.IdFinancialSituacion != null)
                        {

                            AddCDataElement(xmlDoc, summaryElement, "SitFin", companyFinancial.IdFinancialSituacionNavigation.EnglishName);
                        }
                        if(companyFinancial.IdCollaborationDegree != null)
                        {
                            AddCDataElement(xmlDoc, summaryElement, "Disposition", companyFinancial.IdCollaborationDegreeNavigation.EnglishName);
                        }
                    }
                    if (company.IdPaymentPolicy != null)
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Payments_Policy", company.IdPaymentPolicyNavigation.EnglishName);
                    }
                    if (company.IdCreditRisk != null)
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Credit", company.IdCreditRiskNavigation.EnglishName);
                    }

                    //Credit_Opinion
                    if(companyCreditOpinion != null)
                    {
                        XmlElement creditOpinionElement = xmlDoc.CreateElement("Credit_Opinion");
                        summaryElement.AppendChild(creditOpinionElement);
                        if (!companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_O_QUERYCREDIT").FirstOrDefault().ShortValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, creditOpinionElement, "Requested_Credit", companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_O_QUERYCREDIT").FirstOrDefault().ShortValue);
                        }
                        if (!companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_O_SUGCREDIT").FirstOrDefault().ShortValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, creditOpinionElement, "Suggested_Credit", companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_O_SUGCREDIT").FirstOrDefault().ShortValue);
                        }
                        if (!companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_O_COMENTARY").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, creditOpinionElement, "Comment", companyCreditOpinion.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_O_COMENTARY").FirstOrDefault().LargeValue);
                        }
                    }

                    //Legal_Backgrounds
                    XmlElement legalBackgElement = xmlDoc.CreateElement("Legal_Backgrounds");
                    rootElement.AppendChild(legalBackgElement);
                    if(company.IdLegalPersonType != null)
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Legal_Status", company.IdLegalPersonTypeNavigation.EnglishName);
                    }
                    if (companyBackground.ConstitutionDate != null)
                    {
                        DateTime date = (DateTime)companyBackground.ConstitutionDate;
                        AddCDataElement(xmlDoc, legalBackgElement, "Date_Of_Incorporation", date.ToString("ddMMMyyyy"));
                    }
                    if (!companyBackground.StartFunctionYear.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Starting_Date", companyBackground.StartFunctionYear);
                    }
                    if (!companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Place_Of_Registry", companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_REGISTERIN").FirstOrDefault().ShortValue);
                    }
                    if (!companyBackground.NotaryRegister.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Notary_Office", companyBackground.NotaryRegister);
                    }
                    if (!companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Duration", companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_DURATION").FirstOrDefault().ShortValue);
                    }
                    if (!companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Registration", companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_B_PUBLICREGIS").FirstOrDefault().ShortValue);
                    }
                    if (companyBackground.CurrentPaidCapital > 0)
                    {
                        AddCDataElement(xmlDoc, summaryElement, "Capital_Stock", companyBackground.CurrentPaidCapitalCurrencyNavigation.Abreviation + companyBackground.CurrentPaidCapital.ToString() +
                            companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue == null ? "" : companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_PAIDCAPITAL").FirstOrDefault().LargeValue);
                    }
                    if (companyBackground.IncreaceDateCapital != null)
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Last_Capital_Increase", companyBackground.IncreaceDateCapital);
                    }
                    if (balanceG.Count > 0)
                    {
                        DateTime date = (DateTime)balanceG[0].Date;
                        AddCDataElement(xmlDoc, legalBackgElement, "Shareholders_Equity", balanceG[0].TotalPatrimony.ToString() + " " + balanceG[0].IdCurrencyNavigation.Abreviation + " (" + date.ToString("ddMMMyyyy") + ")");
                    }
                    if (!companyBackground.Traded.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Listed_At_Stock_Exchange", companyBackground.Traded == "Si" ? "Yes" : "No");
                    }
                    if (!companyBackground.CurrentExchangeRate.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Current_Exchange_Rate", companyBackground.CurrentExchangeRate);
                    }
                    if (!companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, legalBackgElement, "Comments", companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_LEGALBACK").FirstOrDefault().LargeValue);
                    }

                    //Directors_Executives_Shareholders
                    if(resultCompanyShareholder.Count > 0)
                    {
                        XmlElement shareholdersElement = xmlDoc.CreateElement("Directors_Executives_Shareholders");
                        rootElement.AppendChild(shareholdersElement);
                        int i = 0;
                        foreach (var item in resultCompanyShareholder)
                        {
                            i++;
                            XmlElement itemElement = xmlDoc.CreateElement("Name");
                            itemElement.SetAttribute("Item",i.ToString());
                            shareholdersElement.AppendChild(itemElement);
                            if (!item.Name.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "ApeNom", item.Name);
                            }
                            if (!item.Title.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Title", item.Title);
                            }
                            if (item.Participation != null && item.Participation > 0)
                            {
                                AddCDataElement(xmlDoc, itemElement, "Part", item.Participation.ToString());
                            }
                            if (item.StartDate != null && item.Participation > 0)
                            {
                                AddCDataElement(xmlDoc, itemElement, "Since", item.StartDate);
                            }
                            if (item.ExecPrinc == 1)
                            {
                                AddCDataElement(xmlDoc, itemElement, "CheckPrin", "YES");
                            }
                        }
                    }

                    //Who_Is_Who
                    if(resultWhoIsWho.Count > 0)
                    {
                        XmlElement whoiswhoElement = xmlDoc.CreateElement("Who_Is_Who");
                        rootElement.AppendChild(whoiswhoElement);
                        foreach (var item in resultWhoIsWho)
                        {
                            int j = 0;
                            for(int k = 1; k < resultCompanyShareholder.Count(); k++)
                            {
                                if (item.Fullname == resultCompanyShareholder[k].Name)
                                {
                                    j = k; break;
                                }
                            }
                            XmlElement itemElement = xmlDoc.CreateElement("Name");
                            itemElement.SetAttribute("Item", j.ToString());
                            whoiswhoElement.AppendChild(itemElement);
                           
                            AddCDataElement(xmlDoc, itemElement, "ApeNom", item.Fullname);
                            if (!item.Profession.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Title", item.Profession);
                            }
                            if (!item.Nacionality.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Nationality", item.Nacionality);
                            }
                            if (!item.Nacionality.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Nationality", item.Nacionality);
                            }
                            if (!item.birthDate.IsNullOrEmpty())
                            {
                                if (!item.BirthPlace.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "D_O_B", item.birthDate + " ("+item.BirthPlace+")");
                                }
                                else
                                {
                                    AddCDataElement(xmlDoc, itemElement, "D_O_B", item.birthDate);
                                }
                            }
                            if (!item.IdentificationDoc.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "ID", item.IdentificationDoc);
                            }
                            if (!item.NumberPhone.IsNullOrEmpty())
                            {
                                if (!item.CodePhone.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Telephone", item.CodePhone + " " + item.NumberPhone + "");
                                }
                                else
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Telephone", item.NumberPhone);
                                }
                            }
                            if (!item.Profession.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Profession", item.Profession);
                            }
                            if (!item.TaxCode.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Tax_Id", item.TaxName + " " + item.TaxCode);
                            }
                            if (!item.FatherName.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Father_Name", item.FatherName);
                            }
                            if (!item.MotherName.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Mother_Name", item.MotherName);
                            }
                            if (!item.History.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Background_Information", item.FatherName);
                            }
                            if (!item.References.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "References", item.References);
                            }
                            if (!item.Properties.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Properties", item.Properties);
                            }
                            var personPartner = await _companyPartnersDomain.GetPartnersByIdPerson(item.Id);
                            if(personPartner.Count > 0)
                            {
                                XmlElement subitemElement = xmlDoc.CreateElement("Associated");
                                itemElement.AppendChild(subitemElement);
                                int l = 0;
                                foreach (var item1 in personPartner)
                                {
                                    if(item1.IdCompany != ticket.IdCompany)
                                    {
                                        l++;
                                        XmlElement subitem1Element = xmlDoc.CreateElement("Company");
                                        subitem1Element.SetAttribute("Item", l.ToString());
                                        subitemElement.AppendChild(subitem1Element);
                                        AddCDataElement(xmlDoc, subitem1Element, "ApeNom", item1.IdCompanyNavigation.Name);
                                        if (!item1.Profession.IsNullOrEmpty())
                                        {
                                            AddCDataElement(xmlDoc, subitem1Element, "Title", item1.Profession);
                                        }
                                        if (!item1.IdCompanyNavigation.TaxTypeCode.IsNullOrEmpty())
                                        {
                                            AddCDataElement(xmlDoc, subitem1Element, "Tax_Id", item1.IdCompanyNavigation.TaxTypeCode);
                                        }
                                        if (item1.IdCompanyNavigation.IdLegalRegisterSituation != null)
                                        {
                                            AddCDataElement(xmlDoc, subitem1Element, "SIT", item1.IdCompanyNavigation.IdLegalRegisterSituationNavigation.Abreviation);
                                        }
                                        if (item1.IdCompanyNavigation.IdCountry != null)
                                        {
                                            AddCDataElement(xmlDoc, subitem1Element, "Country", item1.IdCompanyNavigation.IdCountryNavigation.Name);
                                        }
                                    }
                                }
                            }


                        }
                    }

                    //Business_History
                    if(companyBackground != null)
                    {
                        if (!companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            var st = companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue;
                            AddCDataElement(xmlDoc, rootElement, "Business_History", companyBackground.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_B_HISTORY").FirstOrDefault().LargeValue);
                        }
                    }

                    //Related_Companies
                    if(companyRelation.Count > 0)
                    {
                        XmlElement relationElement = xmlDoc.CreateElement("Related_Companies");
                        rootElement.AppendChild(relationElement);
                        int m = 0;
                        foreach (var item in companyRelation)
                        {
                            m++; 
                            XmlElement itemElement = xmlDoc.CreateElement("Name");
                            itemElement.SetAttribute("Item", m.ToString());
                            relationElement.AppendChild(itemElement);
                            if (item.IdCompanyRelationNavigation.Name != null)
                            {
                                AddCDataElement(xmlDoc, itemElement, "ApeNom", item.IdCompanyRelationNavigation.Name);
                            }
                            if (item.IdCompanyRelationNavigation.IdCountry != null)
                            {
                                AddCDataElement(xmlDoc, itemElement, "Country", item.IdCompanyRelationNavigation.IdCountryNavigation.Name);
                            }
                            if (item.IdCompanyRelationNavigation.IdLegalRegisterSituation != null)
                            {
                                AddCDataElement(xmlDoc, itemElement, "Sta", item.IdCompanyRelationNavigation.IdLegalRegisterSituationNavigation.Abreviation);
                            }
                            if (!item.IdCompanyRelationNavigation.TaxTypeCode.IsNullOrEmpty())
                            {
                                if(item.IdCompanyRelationNavigation.IdLegalRegisterSituation != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Tax_Id", "(" + item.IdCompanyRelationNavigation.IdLegalRegisterSituationNavigation.Abreviation + ") " + item.IdCompanyRelationNavigation.TaxTypeCode);
                                }
                                else
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Tax_Id", item.IdCompanyRelationNavigation.TaxTypeCode);
                                }
                            }
                            if (!item.RelationEng.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Relation", item.RelationEng);
                            }
                            var companyBranchAux = await _companyBranchDomain.GetCompanyBranchByIdCompany((int)item.IdCompanyRelation);
                            if (companyBranchAux != null)
                            {
                                if (!companyBranchAux.SpecificActivitiesEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Business_Activity", companyBranchAux.SpecificActivitiesEng);
                                }
                            }
                        }
                    }

                    //Business
                    if(companyBranch != null)
                    {
                        XmlElement branchElement = xmlDoc.CreateElement("Business");
                        rootElement.AppendChild(branchElement);

                        //Import
                        XmlElement importElement = xmlDoc.CreateElement("Import");
                        branchElement.AppendChild(importElement);

                        if (companyBranch.Import != null)
                        {
                            if (companyBranch.Import == true)
                            {
                                AddCDataElement(xmlDoc, importElement, "Conditional", "Yes");
                                if (!companyBranch.CountriesImportEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, importElement, "Country", companyBranch.CountriesImportEng);
                                }
                                var imports = await _importsAndExportsDomain.GetImports((int)ticket.IdCompany);
                                if (imports.Count() > 0)
                                {
                                    int n = 0;
                                    foreach (var item in imports)
                                    {
                                        n++;
                                        XmlElement itemElement = xmlDoc.CreateElement("Name");
                                        itemElement.SetAttribute("Item", n.ToString());
                                        importElement.AppendChild(itemElement);
                                        if (item.Year != null)
                                        {
                                            AddCDataElement(xmlDoc, itemElement, "Year", item.Year.ToString());
                                        }
                                        if (item.Year != null)
                                        {
                                            AddCDataElement(xmlDoc, itemElement, "Mount", item.Amount.ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AddCDataElement(xmlDoc, importElement, "Conditional", "No");
                            }
                        }
                        else
                        {
                            AddCDataElement(xmlDoc, importElement, "Conditional", "");
                        }

                        //Export
                        XmlElement exportElement = xmlDoc.CreateElement("Export");
                        branchElement.AppendChild(exportElement);

                        if (companyBranch.Export != null)
                        {
                            if (companyBranch.Export == true)
                            {
                                AddCDataElement(xmlDoc, exportElement, "Conditional", "Yes");
                                if (!companyBranch.CountriesExportEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, exportElement, "Country", companyBranch.CountriesExportEng);
                                }
                                var exports = await _importsAndExportsDomain.GetExports((int)ticket.IdCompany);
                                if (exports.Count() > 0)
                                {
                                    int o = 0;
                                    foreach (var item in exports)
                                    {
                                        o++;
                                        XmlElement itemElement = xmlDoc.CreateElement("Name");
                                        itemElement.SetAttribute("Item", o.ToString());
                                        exportElement.AppendChild(itemElement);
                                        if (item.Year != null)
                                        {
                                            AddCDataElement(xmlDoc, itemElement, "Year", item.Year.ToString());
                                        }
                                        if (item.Year != null)
                                        {
                                            AddCDataElement(xmlDoc, itemElement, "Mount", item.Amount.ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AddCDataElement(xmlDoc, exportElement, "Conditional", "No");
                            }
                        }
                        else
                        {
                            AddCDataElement(xmlDoc, exportElement, "Conditional", "");
                        }

                        //Cash_Sales
                        if(companyBranch.CashSalePercentage != null)
                        {
                            XmlElement cashSaleElement = xmlDoc.CreateElement("Cash_Sales");
                            branchElement.AppendChild(cashSaleElement);
                            if(companyBranch.CashSalePercentage != null)
                            {
                                AddCDataElement(xmlDoc, cashSaleElement, "Value", companyBranch.CashSalePercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_SALEPER").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, cashSaleElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_SALEPER").FirstOrDefault().ShortValue);
                            }
                        }
                        //Credit_Sales
                        if (companyBranch.CreditSalePercentage != null)
                        {
                            XmlElement creditSaleElement = xmlDoc.CreateElement("Credit_Sales");
                            branchElement.AppendChild(creditSaleElement);
                            if (companyBranch.CreditSalePercentage != null)
                            {
                                AddCDataElement(xmlDoc, creditSaleElement, "Value", companyBranch.CreditSalePercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_CREDITPER").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, creditSaleElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_CREDITPER").FirstOrDefault().ShortValue);
                            }
                        }
                        //Foreign_Sales
                        if (companyBranch.AbroadSalePercentage != null)
                        {
                            XmlElement foreignSaleElement = xmlDoc.CreateElement("Foreign_Sales");
                            branchElement.AppendChild(foreignSaleElement);
                            if (companyBranch.AbroadSalePercentage != null)
                            {
                                AddCDataElement(xmlDoc, foreignSaleElement, "Value", companyBranch.AbroadSalePercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_EXTSALES").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, foreignSaleElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_EXTSALES").FirstOrDefault().ShortValue);
                            }
                        }
                        //Domestic_Purchases
                        if (companyBranch.TerritorySalePercentage != null)
                        {
                            XmlElement territorySaleElement = xmlDoc.CreateElement("Selling_Territory");
                            branchElement.AppendChild(territorySaleElement);
                            if (companyBranch.TerritorySalePercentage != null)
                            {
                                AddCDataElement(xmlDoc, territorySaleElement, "Value", companyBranch.TerritorySalePercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_TERRITORY").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, territorySaleElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_TERRITORY").FirstOrDefault().ShortValue);
                            }
                        }
                        //National
                        if (companyBranch.NationalPurchasesPercentage != null)
                        {
                            XmlElement nationalElement = xmlDoc.CreateElement("Domestic_Purchases");
                            branchElement.AppendChild(nationalElement);
                            if (companyBranch.NationalPurchasesPercentage != null)
                            {
                                AddCDataElement(xmlDoc, nationalElement, "Value", companyBranch.NationalPurchasesPercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_NATIBUY").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, nationalElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_NATIBUY").FirstOrDefault().ShortValue);
                            }
                        }
                        //International
                        if (companyBranch.InternationalPurchasesPercentage != null)
                        {
                            XmlElement internationalElement = xmlDoc.CreateElement("Foreign_Purchases");
                            branchElement.AppendChild(internationalElement);
                            if (companyBranch.InternationalPurchasesPercentage != null)
                            {
                                AddCDataElement(xmlDoc, internationalElement, "Value", companyBranch.InternationalPurchasesPercentage.ToString());
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_INTERBUY").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, internationalElement, "Comment", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_INTERBUY").FirstOrDefault().ShortValue);
                            }
                        }
                        if(companyBranch.WorkerNumber != null)
                        {
                            AddCDataElement(xmlDoc, branchElement, "Employees", companyBranch.WorkerNumber.ToString());
                        }

                        //Location
                        if (companyBranch.IdLandOwnership != null || 
                            !companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue.IsNullOrEmpty() 
                            || !companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue.IsNullOrEmpty() 
                            || !companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue.IsNullOrEmpty() 
                            || !companyBranch.TabCommentary.IsNullOrEmpty() 
                            || !companyBranch.PreviousAddress.IsNullOrEmpty())
                        {
                            XmlElement locationElement = xmlDoc.CreateElement("Location");
                            branchElement.AppendChild(locationElement);
                            if(companyBranch.IdLandOwnership != null)
                            {
                                AddCDataElement(xmlDoc, locationElement, "Premises", companyBranch.IdLandOwnershipNavigation.EnglishName.ToString());
                            }
                            if(!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, locationElement, "Area", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_R_TOTALAREA").FirstOrDefault().ShortValue);
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, locationElement, "Other_Premises", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_OTRHERLOCALS").FirstOrDefault().LargeValue);
                            }
                            if (!companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, locationElement, "Comments", companyBranch.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_R_ADIBUS").FirstOrDefault().LargeValue);
                            }
                            if (!companyBranch.TabCommentary.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, locationElement, "CommentsTab", companyBranch.TabCommentary);
                            }
                            if (!companyBranch.PreviousAddress.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, locationElement, "Previous_Address", companyBranch.PreviousAddress);
                            }
                        }
                    }
                    if(companyFinancial != null)
                    {
                        XmlElement financialElement = xmlDoc.CreateElement("Financial_Information");
                        rootElement.AppendChild(financialElement);
                        if (!companyFinancial.Interviewed.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, financialElement, "Interviewee", companyFinancial.Interviewed);
                        }
                        if (!companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_F_JOB").FirstOrDefault().ShortValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, financialElement, "Position", companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "S_F_JOB").FirstOrDefault().ShortValue);
                        }
                        if (companyFinancial.IdCollaborationDegree != null)
                        {
                            AddCDataElement(xmlDoc, financialElement, "Disposition", companyFinancial.IdCollaborationDegreeNavigation.EnglishName);
                        }
                        if (!companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, financialElement, "Information_Provided", companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_COMENT").FirstOrDefault().LargeValue);
                        }
                        if (!companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_TABCOMM").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, financialElement, "Comment_Tab", companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_TABCOMM").FirstOrDefault().LargeValue);
                        }
                        if(balanceS.Count > 0)
                        {
                            XmlElement balanceSitElement = xmlDoc.CreateElement("Interim_Balance_Sheet");
                            financialElement.AppendChild(balanceSitElement);
                            int q = 0;
                            foreach (var item in balanceS)
                            {
                                q++;
                                XmlElement itemElement = xmlDoc.CreateElement("Balance");
                                itemElement.SetAttribute("Item", q.ToString());
                                balanceSitElement.AppendChild(itemElement);
                                DateTime date = (DateTime)item.Date;
                                AddCDataElement(xmlDoc, itemElement, "Date", date.ToString("ddMMMyyyy"));
                                if(!item.BalanceTypeEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Type_Of_Balance_Sheet", item.BalanceTypeEng);
                                }
                                if (!item.DurationEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Period", item.DurationEng);
                                }
                                if (item.IdCurrency != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Currency", item.IdCurrencyNavigation.Abreviation);
                                }
                                if (item.ExchangeRate != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Exchange_Rate", item.ExchangeRate.ToString());
                                }
                                if (item.Sales != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Sales", item.Sales.ToString());
                                }
                                if (item.Utilities != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Net_Profits", item.Utilities.ToString());
                                }
                                //Assets
                                XmlElement assetsElement = xmlDoc.CreateElement("Assets");
                                itemElement.AppendChild(assetsElement); 
                                if (item.ACashBoxBank != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Cash_Banks", item.ACashBoxBank.ToString());
                                }
                                if (item.AToCollect != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Receivables", item.AToCollect.ToString());
                                }
                                if (item.AInventory != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Inventory", item.AInventory.ToString());
                                }
                                if (item.AOtherCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Other_Current_Assets", item.AOtherCurrentAssets.ToString());
                                }
                                if (item.TotalCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Current_Assets", item.TotalCurrentAssets.ToString());
                                }
                                if (item.AFixed != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Fixed", item.AFixed.ToString());
                                }
                                if (item.AOtherNonCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Other_Non_Current_Assets", item.AOtherNonCurrentAssets.ToString());
                                }
                                if (item.TotalNonCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Non_Current_Assets", item.TotalNonCurrentAssets.ToString());
                                }
                                if (item.TotalAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Assets", item.TotalAssets.ToString());
                                }

                                //Liabilities
                                XmlElement LiabilitiesElement = xmlDoc.CreateElement("Liabilities");
                                itemElement.AppendChild(LiabilitiesElement);
                                if (item.LCashBoxBank != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Bank_Suppliers", item.LCashBoxBank.ToString());
                                }
                                if (item.LOtherCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Others_Current_Liabilities", item.LOtherCurrentLiabilities.ToString());
                                }
                                if (item.TotalCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Current_Liabilities", item.TotalCurrentLiabilities.ToString());
                                }
                                if (item.LLongTerm != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Long_Term", item.LLongTerm.ToString());
                                }
                                if (item.LOtherNonCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Others_Non_Current_Liabilities", item.LOtherNonCurrentLiabilities.ToString());
                                }
                                if (item.TotalNonCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Current_Liabilities", item.TotalNonCurrentLiabilities.ToString());
                                }
                                if (item.TotalLliabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Liabilities", item.TotalLliabilities.ToString());
                                }
                                //Shareholders_Equity
                                XmlElement patrimonyElement = xmlDoc.CreateElement("Shareholders_Equity");
                                itemElement.AppendChild(patrimonyElement);
                                if (item.PCapital != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Capital", item.PCapital.ToString());
                                }
                                if (item.PStockPile != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Reserves", item.PStockPile.ToString());
                                }
                                if (item.PUtilities != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Utilities", item.PUtilities.ToString());
                                }
                                if (item.POther != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Others", item.POther.ToString());
                                }
                                if (item.TotalPatrimony != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Total_Shareholders_Equity", item.TotalPatrimony.ToString());
                                }
                                if (item.TotalLiabilitiesPatrimony != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Total_Liabilities_Shareholders_Equity", item.TotalLiabilitiesPatrimony.ToString());
                                }
                                //Shareholders_Equity
                                XmlElement ratiosElement = xmlDoc.CreateElement("Ratios");
                                itemElement.AppendChild(ratiosElement);
                                if (item.LiquidityRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Liquidity_Ratio", item.LiquidityRatio.ToString());
                                }
                                if (item.DebtRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Debt_Ratio", item.DebtRatio.ToString() + "%");
                                }
                                if (item.ProfitabilityRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Profitability_Ratio", item.ProfitabilityRatio.ToString() + "%");
                                }
                                if (item.WorkingCapital != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Working_Capital", item.WorkingCapital.ToString());
                                }
                            }
                        }
                        if (balanceG.Count > 0)
                        {
                            XmlElement balanceGenElement = xmlDoc.CreateElement("Balance_Sheet");
                            financialElement.AppendChild(balanceGenElement);
                            int r = 0;
                            foreach (var item in balanceG)
                            {
                                r++;
                                XmlElement itemElement = xmlDoc.CreateElement("Balance");
                                itemElement.SetAttribute("Item", r.ToString());
                                if (!companyFinancial.Auditors.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Auditors", companyFinancial.Auditors);
                                }
                                balanceGenElement.AppendChild(itemElement);
                                DateTime date = (DateTime)item.Date;
                                AddCDataElement(xmlDoc, itemElement, "Date", date.ToString("ddMMMyyyy"));
                                if (!item.BalanceTypeEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Type_Of_Balance_Sheet", item.BalanceTypeEng);
                                }
                                if (!item.DurationEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Period", item.DurationEng);
                                }
                                if (item.IdCurrency != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Currency", item.IdCurrencyNavigation.Abreviation);
                                }
                                if (item.ExchangeRate != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Exchange_Rate", item.ExchangeRate.ToString());
                                }
                                if (item.Sales != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Sales", item.Sales.ToString());
                                }
                                if (item.Utilities != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Net_Profits", item.Utilities.ToString());
                                }
                                //Assets
                                XmlElement assetsElement = xmlDoc.CreateElement("Assets");
                                itemElement.AppendChild(assetsElement);
                                if (item.ACashBoxBank != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Cash_Banks", item.ACashBoxBank.ToString());
                                }
                                if (item.AToCollect != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Receivables", item.AToCollect.ToString());
                                }
                                if (item.AInventory != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Inventory", item.AInventory.ToString());
                                }
                                if (item.AOtherCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Other_Current_Assets", item.AOtherCurrentAssets.ToString());
                                }
                                if (item.TotalCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Current_Assets", item.TotalCurrentAssets.ToString());
                                }
                                if (item.AFixed != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Fixed", item.AFixed.ToString());
                                }
                                if (item.AOtherNonCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Other_Non_Current_Assets", item.AOtherNonCurrentAssets.ToString());
                                }
                                if (item.TotalNonCurrentAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Non_Current_Assets", item.TotalNonCurrentAssets.ToString());
                                }
                                if (item.TotalAssets != null)
                                {
                                    AddCDataElement(xmlDoc, assetsElement, "Total_Assets", item.TotalAssets.ToString());
                                }

                                //Liabilities
                                XmlElement LiabilitiesElement = xmlDoc.CreateElement("Liabilities");
                                itemElement.AppendChild(LiabilitiesElement);
                                if (item.LCashBoxBank != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Bank_Suppliers", item.LCashBoxBank.ToString());
                                }
                                if (item.LOtherCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Others_Current_Liabilities", item.LOtherCurrentLiabilities.ToString());
                                }
                                if (item.TotalCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Current_Liabilities", item.TotalCurrentLiabilities.ToString());
                                }
                                if (item.LLongTerm != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Long_Term", item.LLongTerm.ToString());
                                }
                                if (item.LOtherNonCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Others_Non_Current_Liabilities", item.LOtherNonCurrentLiabilities.ToString());
                                }
                                if (item.TotalNonCurrentLiabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Current_Liabilities", item.TotalNonCurrentLiabilities.ToString());
                                }
                                if (item.TotalLliabilities != null)
                                {
                                    AddCDataElement(xmlDoc, LiabilitiesElement, "Total_Liabilities", item.TotalLliabilities.ToString());
                                }
                                //Shareholders_Equity
                                XmlElement patrimonyElement = xmlDoc.CreateElement("Shareholders_Equity");
                                itemElement.AppendChild(patrimonyElement);
                                if (item.PCapital != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Capital", item.PCapital.ToString());
                                }
                                if (item.PStockPile != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Reserves", item.PStockPile.ToString());
                                }
                                if (item.PUtilities != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Utilities", item.PUtilities.ToString());
                                }
                                if (item.POther != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Others", item.POther.ToString());
                                }
                                if (item.TotalPatrimony != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Total_Shareholders_Equity", item.TotalPatrimony.ToString());
                                }
                                if (item.TotalLiabilitiesPatrimony != null)
                                {
                                    AddCDataElement(xmlDoc, patrimonyElement, "Total_Liabilities_Shareholders_Equity", item.TotalLiabilitiesPatrimony.ToString());
                                }
                                //Shareholders_Equity
                                XmlElement ratiosElement = xmlDoc.CreateElement("Ratios");
                                itemElement.AppendChild(ratiosElement);
                                if (item.LiquidityRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Liquidity_Ratio", item.LiquidityRatio.ToString());
                                }
                                if (item.DebtRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Debt_Ratio", item.DebtRatio.ToString() + "%");
                                }
                                if (item.ProfitabilityRatio != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Profitability_Ratio", item.ProfitabilityRatio.ToString() + "%");
                                }
                                if (item.WorkingCapital != null)
                                {
                                    AddCDataElement(xmlDoc, ratiosElement, "Working_Capital", item.WorkingCapital.ToString());
                                }
                            }
                        }
                        if (companyFinancial != null)
                        {
                            if(companyFinancial.IdFinancialSituacion != null)
                            {
                                AddCDataElement(xmlDoc, financialElement, "Situational_Financial", companyFinancial.IdFinancialSituacionNavigation.EnglishName);
                            }
                            if (salesHistory.Count > 0)
                            {
                                XmlElement salesElement = xmlDoc.CreateElement("Sales_Annual");
                                financialElement.AppendChild(salesElement);
                                int s = 0;
                                foreach (var item in salesHistory)
                                {
                                    s++;
                                    XmlElement itemElement = xmlDoc.CreateElement("Name");
                                    itemElement.SetAttribute("Item", s.ToString());
                                    salesElement.AppendChild(itemElement);
                                    if(item.Date != null)
                                    {
                                        DateTime date = (DateTime)item.Date;
                                        AddCDataElement(xmlDoc, itemElement, "Date", date.ToString("dd/MM/yyyy"));
                                    }
                                    if (item.IdCurrency != null)
                                    {
                                        AddCDataElement(xmlDoc, itemElement, "Currency", item.IdCurrencyNavigation.Abreviation);
                                    }
                                    if (item.Amount != null)
                                    {
                                        AddCDataElement(xmlDoc, itemElement, "Sales", item.Amount.ToString());
                                    }
                                    if (item.ExchangeRate != null)
                                    {
                                        AddCDataElement(xmlDoc, itemElement, "TC", item.ExchangeRate.ToString());
                                    }
                                    if (item.EquivalentToDollars != null)
                                    {
                                        AddCDataElement(xmlDoc, itemElement, "SalesUS", item.EquivalentToDollars.ToString());
                                    }
                                }
                            }
                            if (!companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, financialElement, "Comment_Property", companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_PRINCACTIV").FirstOrDefault().LargeValue);
                            }
                            if (!companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, financialElement, "Comment_Analyst", companyFinancial.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_F_ANALISTCOM").FirstOrDefault().LargeValue);
                            }
                        }
                    }

                    //Payments_Record

                    if(companySbs != null)
                    {
                        XmlElement paymentElement = xmlDoc.CreateElement("Payments_Record");
                        rootElement.AppendChild(paymentElement);
                        if(companySbs.IdOpcionalCommentarySbs != null)
                        {
                            AddCDataElement(xmlDoc, paymentElement, "Comment_Payments_Record", companySbs.IdOpcionalCommentarySbsNavigation.EnglishName);
                        }
                        if(providers.Count > 0)
                        {
                            XmlElement provPrimElement = xmlDoc.CreateElement("ProvPrim");
                            paymentElement.AppendChild(provPrimElement);
                            int s = 0;
                            foreach (var item in providers)
                            {
                                s++;
                                XmlElement itemElement = xmlDoc.CreateElement("Name");
                                itemElement.SetAttribute("Item", s.ToString());
                                provPrimElement.AppendChild(itemElement);
                                if (!item.Name.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "ApeNom", item.Name);
                                }
                                if (item.IdCountry != null)
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Country", item.IdCountryNavigation.Name);
                                }
                                if (!item.Telephone.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Telephone", item.Telephone);
                                }
                                if (!item.ProductsTheySellEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Goods_Services", item.ProductsTheySellEng);
                                }
                                if (!item.MaximumAmountEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Highest_Credit", item.MaximumAmountEng);
                                }
                                if (!item.ClientSinceEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Client_Since", item.ClientSinceEng);
                                }
                                if (!item.TimeLimitEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Terms", item.TimeLimitEng);
                                }
                                if (!item.ComplianceEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Performance", item.ComplianceEng);
                                }
                                if (!item.AdditionalCommentaryEng.IsNullOrEmpty())
                                {
                                    AddCDataElement(xmlDoc, itemElement, "Comment", item.AdditionalCommentaryEng);
                                }
                            }
                        }
                    }

                    //Risk_Information_Center
                    if(companySbs != null && morComercial.Count > 0)
                    {
                        XmlElement morComElement = xmlDoc.CreateElement("Risk_Information_Center");
                        rootElement.AppendChild(morComElement);
                        XmlElement protElement = xmlDoc.CreateElement("Protested_Drafs");
                        morComElement.AppendChild(protElement);
                        Decimal mn = 0, me = 0;
                        int s = 0;
                        foreach (var item in morComercial)
                        {
                            s++;
                            XmlElement itemElement = xmlDoc.CreateElement("Name");
                            itemElement.SetAttribute("Item", s.ToString());
                            protElement.AppendChild(itemElement);
                            if (!item.CreditorOrSupplier.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Drawer", item.CreditorOrSupplier);
                            }
                            if (!item.DocumentTypeEng.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Document", item.DocumentTypeEng);
                            }
                            if (item.AmountNc != null)
                            {
                                mn += (Decimal)item.AmountNc; 
                                AddCDataElement(xmlDoc, itemElement, "Amount_N_C", item.AmountNc.ToString());
                            }
                            if (item.AmountFc != null)
                            {
                                me += (Decimal)item.AmountFc;
                                AddCDataElement(xmlDoc, itemElement, "Amount_F_C", item.AmountFc.ToString());
                            }
                            if (!item.Date.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Protest_Date", item.Date);
                            }
                            if (!item.PendingPaymentDate.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Payment_Date", item.PendingPaymentDate);
                            }
                        }
                        AddCDataElement(xmlDoc, morComElement, "Moro_Docs", morComercial.Count.ToString());
                        AddCDataElement(xmlDoc, morComElement, "Moro_MN", mn.ToString());
                        AddCDataElement(xmlDoc, morComElement, "Moro_ME", me.ToString());
                    }

                    //Banking_Information
                    if (companySbs != null || bankDebt.Count > 0)
                    {
                        XmlElement bankingElement = xmlDoc.CreateElement("Risk_Information_Center");
                        rootElement.AppendChild(bankingElement);
                        if(companySbs.ExchangeRate != null)
                        {
                            AddCDataElement(xmlDoc, bankingElement, "EM_TCSBS", companySbs.ExchangeRate.ToString());
                        }
                        if (!companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_COMENTARY").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, bankingElement, "EM_CENRIE", companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_COMENTARY").FirstOrDefault().LargeValue);
                        }
                        if (companySbs.DebtRecordedDate != null)
                        {
                            DateTime date = (DateTime)companySbs.DebtRecordedDate;
                            AddCDataElement(xmlDoc, bankingElement, "EM_FECREG", date.ToString("dd/MM/yyyy"));
                        }
                        XmlElement bankDebtElement = xmlDoc.CreateElement("Banq");
                        bankingElement.AppendChild(bankDebtElement);
                        Decimal nc = 0, fc = 0;
                        int r = 0;
                        foreach (var item in bankDebt)
                        {
                            r++;
                            XmlElement itemElement = xmlDoc.CreateElement("Name");
                            itemElement.SetAttribute("Item", r.ToString());
                            bankDebtElement.AppendChild(itemElement);
                            if (!item.BankName.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Bank", item.BankName);
                            }
                            if (!item.QualificationEng.IsNullOrEmpty())
                            {
                                AddCDataElement(xmlDoc, itemElement, "Debt_Rating", item.QualificationEng);
                            }
                            if (item.DebtNc != null)
                            {
                                nc += (Decimal) item.DebtNc;
                                AddCDataElement(xmlDoc, itemElement, "MN", item.DebtNc.ToString());
                            }
                            if (item.DebtFc != null)
                            {
                                fc += (Decimal)item.DebtFc;
                                AddCDataElement(xmlDoc, itemElement, "ME", item.DebtFc.ToString());
                            }
                        }

                        AddCDataElement(xmlDoc, bankDebtElement, "TOT_MN", nc.ToString());
                        AddCDataElement(xmlDoc, bankDebtElement, "TOT_ME", fc.ToString());
                        if (companySbs.GuaranteesOfferedNc != null)
                        {
                            AddCDataElement(xmlDoc, bankDebtElement, "EM_GAOMN", companySbs.GuaranteesOfferedNc.ToString());
                        }
                        if (companySbs.GuaranteesOfferedFc != null)
                        {
                            AddCDataElement(xmlDoc, bankDebtElement, "EM_GAOME", companySbs.GuaranteesOfferedFc.ToString());
                        }
                        if (!companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_BANCARIOS").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, bankDebtElement, "Comment_SBS", companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_BANCARIOS").FirstOrDefault().LargeValue);
                        }
                        //Lawsuits
                        if (!companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_LITIG").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, bankDebtElement, "Coment_Lawsuits", companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_LITIG").FirstOrDefault().LargeValue);
                        }
                        //Credit_History
                        if (!companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_CREDHIS").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, bankDebtElement, "Credit_History", companySbs.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_S_CREDHIS").FirstOrDefault().LargeValue);
                        }
                    }

                    //General_Information
                    if (companyInfoGeneral != null && 
                        !companyInfoGeneral.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue.IsNullOrEmpty() ||
                        company.IdReputation != null ||
                        !company.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue.IsNullOrEmpty())
                    {
                        XmlElement generalInfoElement = xmlDoc.CreateElement("General_Information");
                        rootElement.AppendChild(generalInfoElement);
                        if (!companyInfoGeneral.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, generalInfoElement, "Comment", companyInfoGeneral.IdCompanyNavigation.Traductions.Where(x => x.Identifier == "L_I_GENERAL").FirstOrDefault().LargeValue);
                        }
                        if (company.IdReputation != null)
                        {
                            AddCDataElement(xmlDoc, generalInfoElement, "Name_Rep", company.IdReputationNavigation.EnglishName);
                        }
                        if (!company.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue.IsNullOrEmpty())
                        {
                            AddCDataElement(xmlDoc, generalInfoElement, "Comment_Rep", company.Traductions.Where(x => x.Identifier == "L_E_REPUTATION").FirstOrDefault().LargeValue);
                        }
                    }

                    //Comment_News
                    if (company != null && company.Print == true && !company.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue.IsNullOrEmpty())
                    {
                        AddCDataElement(xmlDoc, rootElement, "Comment_News", company.Traductions.Where(x => x.Identifier == "L_E_NEW").FirstOrDefault().LargeValue);
                    }




                    // Guardar el XML con formato
                    string xmlString = null;
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                        {
                            xmlTextWriter.Formatting = Formatting.Indented;
                            xmlDoc.WriteTo(xmlTextWriter);
                            xmlString = stringWriter.ToString();
                        }
                    }

                    // Convertir la cadena XML en un MemoryStream
                    byte[] byteArray = Encoding.UTF8.GetBytes(xmlString);
                    response.Data = new GetFileResponseDto
                    {
                        File = byteArray,
                        ContentType = "application/xml",
                        Name = "N" + ticket.Number.ToString("D6") + "_" + company.Name.Replace(" ", "_") + ".xml"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);
            }
            return response;
        }
        static void AddCDataElement(XmlDocument xmlDoc, XmlElement parentElement, string elementName, string value)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            XmlCDataSection cdata = xmlDoc.CreateCDataSection(value);
            element.AppendChild(cdata);
            parentElement.AppendChild(element);
        }
    }
}
