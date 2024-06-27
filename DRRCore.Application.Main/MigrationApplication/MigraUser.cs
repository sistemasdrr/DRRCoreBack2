using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.MigrationApplication;
using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using DRRCore.Domain.Entities.MySqlContextFotos;
using Microsoft.IdentityModel.Tokens;
using DRRCore.Domain.Entities.SqlContext;
using System.Reflection.Emit;

namespace DRRCore.Application.Main.MigrationApplication
{
    public class MigraUser : IMigraUser

    {

        private readonly IMEmpresaDomain _mempresaDomain;
        private readonly IMPersonaDomain _impersonaDomain;
        private readonly ICompanyDomain _companyDomain;
        private readonly ICompanyBackgroundDomain _companyBackgroundDomain;
        private readonly ICompanyBranchDomain _companyBranchDomain;
        private readonly ICompanyFinancialInformationDomain _companyFinancialInformationDomain;
        private readonly ICompanySBSDomain _companySBSDomain;
        private readonly ICompanyCreditOpinionDomain _companyCreditOpinionDomain;
        private readonly ICompanyGeneralInformationDomain _companyGeneralInformationDomain;
        private readonly IFinancialBalanceDomain _financialBalanceDomain;
        private readonly IFinancialSalesHistoryDomain _financialSalesHistoryDomain;
        private readonly IImportsAndExportsDomain _importsAndExportsDomain;
        private readonly IProviderDomain _providerDomain;
        private readonly IComercialLatePaymentDomain _comercialLatePaymentDomain;
        private readonly IBankDebtDomain _bankDebtDomain;

        private readonly IPersonDomain _personDomain;
        private readonly IPersonHomeDomain _personHomeDomain;
        private readonly IPersonJobDomain _personJobDomain;
        private readonly IPersonActivitiesDomain _personActivitiesDomain;
        private readonly IPersonPropertyDomain _personPropertyDomain;
        private readonly IPersonSBSDomain _personSBSDomain;
        private readonly IPersonHistoryDomain _personHistoryDomain;
        private readonly IPersonGeneralInfoDomain _personGeneralInfoDomain;

        private readonly ILogger _logger;

        private REmpVsInfFin finanzas = new REmpVsInfFin();
        private REmpVsRamNeg ramo = new REmpVsRamNeg();
        private TCabEmpAval aval = new TCabEmpAval();
        private REmpVsAspLeg antecedentes = new REmpVsAspLeg();
        public MigraUser(IMEmpresaDomain mempresaDomain, ILogger logger, ICompanyDomain companyDomain,
            ICompanyBackgroundDomain companyBackgroundDomain, ICompanyBranchDomain companyBranchDomain,
            ICompanyFinancialInformationDomain companyFinancialInformationDomain, ICompanySBSDomain companySBSDomain,
            ICompanyCreditOpinionDomain companyCreditOpinionDomain, ICompanyGeneralInformationDomain companyGeneralInformationDomain,
            IFinancialBalanceDomain financialBalanceDomain, IImportsAndExportsDomain importsAndExportsDomain,
            IProviderDomain providerDomain, IComercialLatePaymentDomain comercialLatePaymentDomain,
            IBankDebtDomain bankDebtDomain
            , IMPersonaDomain mPersonaDomain, IPersonDomain personDomain, IPersonHomeDomain personHomeDomain,
            IPersonJobDomain personJobDomain, IPersonActivitiesDomain personActivitiesDomain, IPersonPropertyDomain personPropertyDomain,
            IPersonSBSDomain personSBSDomain, IPersonHistoryDomain personHistoryDomain, IPersonGeneralInfoDomain personGeneralInfoDomain,
            IFinancialSalesHistoryDomain financialSalesHistoryDomain
            )
        {

            _mempresaDomain = mempresaDomain;
            _logger = logger;
            _companyDomain = companyDomain;
            _companyBackgroundDomain = companyBackgroundDomain;
            _companyBranchDomain = companyBranchDomain;
            _companyFinancialInformationDomain = companyFinancialInformationDomain;
            _companySBSDomain = companySBSDomain;
            _companyCreditOpinionDomain = companyCreditOpinionDomain;
            _companyGeneralInformationDomain = companyGeneralInformationDomain;
            _financialBalanceDomain = financialBalanceDomain;
            _importsAndExportsDomain = importsAndExportsDomain;
            _providerDomain = providerDomain;
            _comercialLatePaymentDomain = comercialLatePaymentDomain;
            _bankDebtDomain = bankDebtDomain;
            _impersonaDomain = mPersonaDomain;
            _personDomain = personDomain;
            _personHomeDomain = personHomeDomain;
            _personJobDomain = personJobDomain;
            _personActivitiesDomain = personActivitiesDomain;
            _personPropertyDomain = personPropertyDomain;
            _personHistoryDomain = personHistoryDomain;
            _personGeneralInfoDomain = personGeneralInfoDomain;
            _financialSalesHistoryDomain = financialSalesHistoryDomain;
            _personSBSDomain = personSBSDomain;
        }

        public async Task<bool> MigrateCompany()
        {
            var empresas = await _mempresaDomain.GetNotMigratedEmpresa();
            foreach (var empresa in empresas)
            {
                finanzas = new REmpVsInfFin();
                ramo = new REmpVsRamNeg();
                aval = new TCabEmpAval();
                antecedentes = new REmpVsAspLeg();
                int idCompany = 0;
                using var context = new SqlCoreContext();
                var existCompany = await context.Companies.Where(x => x.OldCode == empresa.EmCodigo).FirstOrDefaultAsync();

                if (existCompany == null)
                {
                    try
                    {
                        var reputacion = await _mempresaDomain.GetmEmpresaReputacionByCodigoAsync(empresa.EmCodigo);
                        int idReputacion = 0;
                        if (reputacion != null)
                        {
                            idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                        }

                            var company = new Company
                            {
                                OldCode = empresa.EmCodigo,
                                Name = empresa.EmNombre,
                                SocialName = empresa.EmSiglas,
                                LastSearched = empresa.EmFecinf,
                                Language = Dictionary.LanguageMigra[empresa.IdiCodigo.Value],
                                TypeRegister = empresa.EmTipper == 0 ? "PJ" : "PN",
                                YearFundation = empresa.EmAnofun,
                                Quality = ObtenerCalidad(empresa.CalCodigo),
                                IdLegalPersonType = ObtenerPersoneriaLegal(empresa.JuCodigo),
                                TaxTypeCode = empresa.EmRegtri,
                                IdCountry = ObtenerCodigoPais(empresa.PaiCodigo),
                                HaveReport = ObtenerReportes(empresa.EmCodigo),
                                IdLegalRegisterSituation = GetLegalRegisterSituation(empresa.SitCodigo),
                                Address = empresa.EmDirecc,
                                Place = empresa.EmCiudad,
                                Telephone = empresa.EmTelef1,
                                SubTelephone = empresa.EmPrftlf,
                                Cellphone = empresa.EmPrffax,
                                PostalCode = empresa.EmCodpos,
                                WhatsappPhone = empresa.EmFax,
                                Email = empresa.EmEmail,
                                WebPage = empresa.EmPagweb,
                                IdCreditRisk = GetCreditRisk(empresa.CrCodigo),
                                IdPaymentPolicy = GetPaymentPolicy(empresa.PaCodigo),
                                IdReputation = idReputacion != 0 ? idReputacion : null,
                                NewsComentary = string.IsNullOrEmpty(empresa.EmPrensa) ? empresa.EmPrensasel : empresa.EmPrensa,
                                IdentificacionCommentary = empresa.EmComide,
                                Enable = empresa.EmActivo == 1,
                                LastUpdaterUser = 1,
                                OnWeb = empresa.EmOnline == "SI",
                                ReputationComentary = empresa.EmComrep,
                                Print = empresa.EmLogpre == 1,
                                CompanyBackgrounds = await GetCompanyBackground(empresa.EmCodigo),
                                CompanyBranches = await GetCompanyBranch(empresa.EmCodigo),
                                CompanyFinancialInformations = await GetCompanyFinancialInformations(empresa.EmCodigo, empresa.EmAudito ?? string.Empty),
                                CompanySbs = await GetCompanySbs(empresa),
                                CompanyCreditOpinions = await GetCompanyCreditOpinions(empresa),
                                CompanyGeneralInformations = await GetCompanyGeneralInformation(empresa.EmInfgen, empresa.EmCodigo),
                                FinancialBalances = await GetFinancialBalances(empresa.EmCodigo),
                                SalesHistories = await GetSalesHistories(empresa.EmCodigo),
                                ImportsAndExports = await GetImportsAndExports(empresa.EmCodigo),
                                Providers = await GetProviders(empresa.EmCodigo),
                                ComercialLatePayments = await GetComercialLatePayments(empresa.EmCodigo),
                                BankDebts = await GetBankDebts(empresa.EmCodigo),
                                WorkersHistories = await GetWorkersHistories(empresa),
                                TraductionCompanies = await GetAllTraductions(empresa)
                                
                        };

                        idCompany = await _companyDomain.AddCompanyAsync(company);
                        await _mempresaDomain.MigrateEmpresa(empresa.EmCodigo);
                    }
                        catch (Exception ex)
                        {
                            _logger.LogError("Error empresa :" + empresa.EmCodigo + " : " + ex.Message);
                            continue;
                        }                      
                    }
                }            

            return true;
        }
        public async Task<bool> MigrateCompanyOthers(int migra)
        {
            for (int i = 0; i < 200; i++)
            {
                var empresas = await _mempresaDomain.GetNotMigratedEmpresa(migra);
                foreach (var empresa in empresas)
                {
                    finanzas = new REmpVsInfFin();
                    ramo = new REmpVsRamNeg();
                    aval = new TCabEmpAval();
                    antecedentes = new REmpVsAspLeg();
                    int idCompany = 0;
                    using var context = new SqlCoreContext();
                    using var contextsql = new SqlContext();

                    using var imageMysqlContext = new FotoContext();
                    try
                    {
                        var reputacion = await _mempresaDomain.GetmEmpresaReputacionByCodigoAsync(empresa.EmCodigo);
                        int idReputacion = 0;
                        if (reputacion != null)
                        {
                            idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                        }
                        var images = await imageMysqlContext.REmpVsFotos.Where(x => x.EmCodigo == empresa.EmCodigo).FirstOrDefaultAsync();
                        var image = new List<CompanyImage>();
                        if (images != null)
                        {
                            image.Add(new CompanyImage
                            {
                                Img1 = images.EfLocal.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal) : "",
                                ImgDesc1 = images.EfLocaltxt.IsNullOrEmpty() == false ? images.EfLocaltxt : "",
                                ImgDescEng1 = images.EfLocaltxtIng.IsNullOrEmpty() == false ? images.EfLocaltxtIng : "",
                                ImgPrint1 = images.EfLocal.IsNullOrEmpty() == false ? true : false,
                                Img2 = images.EfLocal2.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal2) : "",
                                ImgDesc2 = images.EfLocal2txt.IsNullOrEmpty() == false ? images.EfLocal2txt : "",
                                ImgDescEng2 = images.EfLocal2txtIng.IsNullOrEmpty() == false ? images.EfLocal2txtIng : "",
                                ImgPrint2 = images.EfLocal2.IsNullOrEmpty() == false ? true : false,
                                Img3 = images.EfLocal3.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal3) : "",
                                ImgDesc3 = images.EfLocal3txt.IsNullOrEmpty() == false ? images.EfLocal3txt : "",
                                ImgDescEng3 = images.EfLocal3txtIng.IsNullOrEmpty() == false ? images.EfLocal3txtIng : "",
                                ImgPrint3 = images.EfLocal3.IsNullOrEmpty() == false ? true : false,
                                Img4 = images.EfLocal4.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal4) : "",
                                ImgDesc4 = images.EfLocal4txt.IsNullOrEmpty() == false ? images.EfLocal4txt : "",
                                ImgDescEng4 = images.EfLocal4txtIng.IsNullOrEmpty() == false ? images.EfLocal4txtIng : "",
                                ImgPrint4 = images.EfLocal4.IsNullOrEmpty() == false ? true : false,
                            });

                        }

                        var company = new Company
                        {
                            OldCode = empresa.EmCodigo,
                            Name = empresa.EmNombre,
                            SocialName = empresa.EmSiglas,
                            LastSearched = empresa.EmFecinf,
                            Language = Dictionary.LanguageMigra[empresa.IdiCodigo.Value],
                            TypeRegister = empresa.EmTipper == 0 ? "PJ" : "PN",
                            YearFundation = empresa.EmAnofun,
                            Quality = ObtenerCalidad(empresa.CalCodigo),
                            IdLegalPersonType = ObtenerPersoneriaLegal(empresa.JuCodigo),
                            TaxTypeCode = empresa.EmRegtri,
                            IdCountry = ObtenerCodigoPais(empresa.PaiCodigo),
                            HaveReport = ObtenerReportes(empresa.EmCodigo),
                            IdLegalRegisterSituation = GetLegalRegisterSituation(empresa.SitCodigo),
                            Address = empresa.EmDirecc,
                            Place = empresa.EmCiudad,
                            Telephone = empresa.EmTelef1,
                            SubTelephone = empresa.EmPrftlf,
                            Cellphone = empresa.EmPrffax,
                            PostalCode = empresa.EmCodpos,
                            WhatsappPhone = empresa.EmFax,
                            Email = empresa.EmEmail,
                            WebPage = empresa.EmPagweb,
                            IdCreditRisk = GetCreditRisk(empresa.CrCodigo),
                            IdPaymentPolicy = GetPaymentPolicy(empresa.PaCodigo),
                            IdReputation = idReputacion != 0 ? idReputacion : null,
                            NewsComentary = string.IsNullOrEmpty(empresa.EmPrensa) ? empresa.EmPrensasel : empresa.EmPrensa,
                            IdentificacionCommentary = empresa.EmComide,
                            Enable = empresa.EmActivo == 1,
                            LastUpdaterUser = 1,
                            OnWeb = empresa.EmOnline == "SI",
                            ReputationComentary = empresa.EmComrep,
                            Print = empresa.EmLogpre == 1,
                            CompanyBackgrounds = await GetCompanyBackground(empresa.EmCodigo),
                            CompanyBranches = await GetCompanyBranch(empresa.EmCodigo),
                            CompanyFinancialInformations = await GetCompanyFinancialInformations(empresa.EmCodigo, empresa.EmAudito ?? string.Empty),
                            CompanySbs = await GetCompanySbs(empresa),
                            CompanyCreditOpinions = await GetCompanyCreditOpinions(empresa),
                            CompanyGeneralInformations = await GetCompanyGeneralInformation(empresa.EmInfgen, empresa.EmCodigo),
                            FinancialBalances = await GetFinancialBalances(empresa.EmCodigo),
                            SalesHistories = await GetSalesHistories(empresa.EmCodigo),
                            ImportsAndExports = await GetImportsAndExports(empresa.EmCodigo),
                            Providers = await GetProviders(empresa.EmCodigo),
                            ComercialLatePayments = await GetComercialLatePayments(empresa.EmCodigo),
                            BankDebts = await GetBankDebts(empresa.EmCodigo),
                            WorkersHistories = await GetWorkersHistories(empresa),
                            CompanyImages = image,
                            TraductionCompanies = await GetAllTraductions(empresa),
                            
                        };
                        idCompany = await _companyDomain.AddCompanyAsync(company);
                        await _mempresaDomain.MigrateEmpresa(empresa.EmCodigo);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error empresa :" + empresa.EmCodigo + " : " + ex.Message);
                        continue;
                    }
                }
            }

            return true;
        }

        private async Task<List<WorkersHistory>> GetWorkersHistories(MEmpresa empresa)
        {
            var lista = new List<WorkersHistory>();
            int number;
            try
            {
                if (ramo != null && !string.IsNullOrEmpty(ramo.EmTraba1))
                {
                    int? workers = GetWorkers(ramo.EmTraba1);
                    if (workers != null)
                    {
                        lista.Add(new WorkersHistory
                        {
                            LastUpdateUser = 1,
                            NumberWorker = workers,
                            NumberYear = empresa.EmFecinf.Value.Year
                        });
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa Numero de trabajadores :" + empresa.EmCodigo);
                throw new Exception(ex.Message);

            }
            return new List<WorkersHistory>();
        }

        private async Task<List<TraductionCompany>> GetAllTraductions(MEmpresa empresa)
        {
            List<Traduction> traductions = new List<Traduction>();
            var trad = new List<TraductionCompany>();
            using var context = new SqlCoreContext();

            trad.Add(new TraductionCompany
            {
                TEcomide = empresa.EmComideIng ?? "",
                TEreputation = empresa.EmComrepIng ?? "",
                TEnew = string.IsNullOrEmpty(empresa.EmPrensaIng) ? empresa.EmPrensaselIng : empresa.EmPrensaIng,
                TBduration = antecedentes?.EmDuraciIng ?? "",
                TBregisterIn = antecedentes?.EmRegenIng ?? "",
                TBpublicRegis = antecedentes?.EmRegistIng ?? "",
                TBpaidCapital = antecedentes?.EmDuraciIng ?? "",
                TBincreaseDate = antecedentes?.EmFecaumIng ?? "",
                TBtacRate = antecedentes?.EmTipcamIng ?? "",
                TBlegalBack = antecedentes?.EmComentIng ?? "",
                TBhistory = antecedentes?.EmAnteceIng ?? "",
                TRtotalArea = ramo?.EmAreaIng ?? "",
                TRotherLocals= ramo?.EmObservIng ?? "",
                TRprincAct = ramo?.EmActiviIng ?? "",
                TRadiBus = ramo?.EmComenIng ?? "",
                TFjob = finanzas?.EmCargosIng ?? "",
                TFcomment = finanzas?.EmConinfIng ?? "",
                TFprincActiv = finanzas?.EmPropieIng ?? "",
                TFselectFin = finanzas?.EmSitfinIng ?? "",
                TFanalistCom = finanzas?.EmAnalistaIng ?? "",
                TScommentary = empresa.EmCenrieIng ?? "",
                TSbancarios = empresa.EmSupbanIng ?? "",
                TSavales = aval?.AvObservacionIng ?? "",
                TSlitig = empresa.EmComlitIng ?? "",
                TScredHis = empresa.EmAntcreIng ?? "",
                TOqueryCredit = empresa.EmMtopcrIng ?? "",
                TOsugCredit = empresa.EmCrerecIng ?? "",
                TOcommentary = empresa.EmOcDescriIng ?? "",
                TIgeneral = empresa.EmInfgenIng ?? ""
            });

            //foreach (var item in Constants.TRADUCTIONS_FORMS)
            //{
            //    string? shortValue = null;
            //    string? largeValue = null;
            //    if (item == "L_E_COMIDE")
            //    {
            //        if (empresa.EmComideIng != null)
            //        {
            //            largeValue = empresa.EmComideIng;
            //        }
            //    }
            //    else if (item == "L_E_REPUTATION")
            //    {
            //        if (empresa.EmComrepIng != null)
            //        {
            //            largeValue = empresa.EmComrepIng;
            //        }
            //    }
            //    else if (item == "L_E_NEW")
            //    {
            //        if (empresa.EmPrensaIng != null || empresa.EmPrensaselIng != null)
            //        {
            //            largeValue = string.IsNullOrEmpty(empresa.EmPrensaIng) ? empresa.EmPrensaselIng : empresa.EmPrensaIng;
            //        }
            //    }
            //    if (antecedentes != null)
            //    {
            //        if (item == "S_B_DURATION")
            //        {
            //            if (antecedentes.EmDuraciIng != null)
            //            {
            //                shortValue = antecedentes.EmDuraciIng;
            //            }
            //        }
            //        else if (item == "S_B_REGISTERIN")
            //        {
            //            if (antecedentes.EmRegenIng != null)
            //            {
            //                shortValue = antecedentes.EmRegenIng;
            //            }
            //        }
            //        else if (item == "S_B_PUBLICREGIS")
            //        {
            //            if (antecedentes.EmRegistIng != null)
            //            {
            //                shortValue = antecedentes.EmRegistIng;
            //            }
            //        }
            //        else if (item == "L_B_PAIDCAPITAL")
            //        {
            //            if (antecedentes.EmDuraciIng != null)
            //            {
            //                largeValue = "";
            //            }
            //        }
            //        else if (item == "S_B_INCREASEDATE")
            //        {
            //            if (antecedentes.EmFecaumIng != null)
            //            {
            //                shortValue = antecedentes.EmFecaumIng;
            //            }
            //        }
            //        else if (item == "S_B_TAXRATE")
            //        {
            //            if (antecedentes.EmTipcamIng != null)
            //            {
            //                shortValue = antecedentes.EmTipcamIng;
            //            }
            //        }
            //        else if (item == "L_B_LEGALBACK")
            //        {
            //            if (antecedentes.EmComentIng != null)
            //            {
            //                largeValue = antecedentes.EmComentIng;
            //            }
            //        }
            //        else if (item == "L_B_HISTORY")
            //        {
            //            if (antecedentes.EmAnteceIng != null)
            //            {
            //                largeValue = antecedentes.EmAnteceIng;
            //            }
            //        }
            //    }
            //    if (ramo != null)
            //    {
            //        if (item == "S_R_TOTALAREA")
            //        {
            //            if (ramo.EmAreaIng != null)
            //            {
            //                shortValue = ramo.EmAreaIng;
            //            }
            //        }
            //        else if (item == "L_R_OTRHERLOCALS")
            //        {
            //            if (ramo.EmObservIng != null)
            //            {
            //                largeValue = ramo.EmObservIng;
            //            }
            //        }
            //        else if (item == "L_R_PRINCACT")
            //        {
            //            if (ramo.EmActiviIng != null)
            //            {
            //                largeValue = ramo.EmActiviIng;
            //            }
            //        }
            //        else if (item == "L_R_ADIBUS")
            //        {
            //            if (ramo.EmComenIng != null)
            //            {
            //                largeValue = ramo.EmComenIng;
            //            }
            //        }
            //    }
            //    if (finanzas != null)
            //    {
            //        if (item == "S_F_JOB")
            //        {
            //            if (finanzas.EmCargosIng != null)
            //            {
            //                shortValue = finanzas.EmCargosIng;
            //            }
            //        }
            //        else if (item == "L_F_COMENT")
            //        {
            //            if (finanzas.EmConinfIng != null)
            //            {
            //                largeValue = finanzas.EmConinfIng;
            //            }
            //        }
            //        else if (item == "L_F_PRINCACTIV")
            //        {
            //            if (finanzas.EmPropieIng != null)
            //            {
            //                largeValue = finanzas.EmPropieIng;
            //            }
            //        }
            //        else if (item == "L_F_SELECTFIN")
            //        {
            //            if (finanzas.EmSitfinIng != null)
            //            {
            //                largeValue = finanzas.EmSitfinIng;
            //            }
            //        }
            //        else if (item == "L_F_ANALISTCOM")
            //        {
            //            if (finanzas.EmAnalistaIng != null)
            //            {
            //                largeValue = finanzas.EmAnalistaIng;
            //            }
            //        }
            //    }
            //    if (item == "L_S_COMENTARY")
            //    {
            //        if (empresa.EmCenrieIng != null)
            //        {
            //            largeValue = empresa.EmCenrieIng;
            //        }
            //    }
            //    else if (item == "L_S_BANCARIOS")
            //    {
            //        if (empresa.EmSupbanIng != null)
            //        {
            //            largeValue = empresa.EmSupbanIng;
            //        }
            //    }
            //    else if (item == "L_S_AVALES")
            //    {
            //        if (aval != null)
            //        {
            //            largeValue = aval.AvObservacionIng;
            //        }
            //    }
            //    else if (item == "L_S_LITIG")
            //    {
            //        if (empresa.EmComlitIng != null)
            //        {
            //            largeValue = empresa.EmComlitIng;
            //        }
            //    }
            //    else if (item == "L_S_CREDHIS")
            //    {
            //        if (empresa.EmAntcreIng != null)
            //        {
            //            largeValue = empresa.EmAntcreIng;
            //        }
            //    }
            //    else if (item == "S_O_QUERYCREDIT")
            //    {
            //        if (empresa.EmMtopcrIng != null)
            //        {
            //            shortValue = empresa.EmMtopcrIng;
            //        }
            //    }
            //    else if (item == "S_O_SUGCREDIT")
            //    {
            //        if (empresa.EmCrerecIng != null)
            //        {
            //            largeValue = empresa.EmCrerecIng;
            //        }
            //    }
            //    else if (item == "L_O_COMENTARY")
            //    {
            //        if (empresa.EmOcDescriIng != null)
            //        {
            //            largeValue = empresa.EmOcDescriIng;
            //        }
            //    }
            //    else if (item == "L_I_GENERAL")
            //    {
            //        if (empresa.EmInfgenIng != null)
            //        {
            //            largeValue = empresa.EmInfgenIng;
            //        }
            //    }
            //    traductions.Add(new Traduction
            //    {
            //        IdPerson = null,
            //        Identifier = item,
            //        IdLanguage = 1,
            //        LastUpdaterUser = 1,
            //        ShortValue = shortValue,
            //        LargeValue = largeValue
            //    });
            //}
            //return traductions;
            return trad;

        }
        private async Task<List<BankDebt>> GetBankDebts(string emCodigo)
        {
            var lista = new List<BankDebt>();
            try
            {
                var endBancario = await _mempresaDomain.GetmEmpresaEndBancByCodigoAsync(emCodigo);

                foreach (var item in endBancario)
                {
                    var objeto = new BankDebt
                    {
                        BankName = item.SbdNombre,
                        Qualification = item.SbdCalifi,
                        QualificationEng = item.SbdCalifiIng,
                        DebtNc = (decimal)item.SbdMonto,
                        DebtFc = (decimal)item.SbdMonMe,
                        Memo = item.SbdMemo,
                        MemoEng = item.SbdMemoIng,
                    };
                    lista.Add(objeto);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa endeudamiento bancario :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<BankDebt>();
        }

        private async Task<List<ComercialLatePayment>> GetComercialLatePayments(string emCodigo)
        {
            var lista = new List<ComercialLatePayment>();

            try
            {

                var morComercial = await _mempresaDomain.GetmEmpresaMorComByCodigoAsync(emCodigo);

                foreach (var item in morComercial)
                {
                    var objeto = new ComercialLatePayment
                    {
                        CreditorOrSupplier = item.PaGirador,
                        DocumentType = item.PaTitulo,
                        DocumentTypeEng = item.PaTituloIng,
                        Date = item.PaFecpro,
                        AmountNc = (decimal)item.PaMonmn,
                        AmountFc = (decimal)item.PaMonme,
                        PendingPaymentDate = item.PaFecreg,
                        DaysLate = item.PaDiaatr,
                    };
                    lista.Add(objeto);
                }

                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa proveedores :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<ComercialLatePayment>();
        }

        private async Task<List<Provider>> GetProviders(string emCodigo)
        {
            var lista = new List<Provider>();
            try
            {
                var providers = await _mempresaDomain.GetmEmpresaProvByCodigoAsync(emCodigo);

                foreach (var item in providers)
                {

                    var objeto = new Provider
                    {
                        IdCountry = ObtenerCodigoPais(item.PaiCodigo),
                        Name = item.ProvNombre,
                        Qualification = item.CumCodigo == "02" ? "Puntual" : item.CumCodigo == "03" ? "Lento Eventual" :
                     item.CumCodigo == "04" ? "Lento Siempre" : item.CumCodigo == "05" ? "Moroso" :
                      item.CumCodigo == "06" ? "Sin Experiencia" : item.CumCodigo == "01" ? "" : null,
                        QualificationEng = item.CumCodigo == "02" ? "Prompt" : item.CumCodigo == "03" ? "Sometimes delayed" :
                     item.CumCodigo == "04" ? "Always delayed" : item.CumCodigo == "05" ? "Delinquent" :
                      item.CumCodigo == "06" ? "No experience" : item.CumCodigo == "01" ? "" : null,
                        Date =StaticFunctions.VerifyDate(item.ProvFecha),
                        Telephone = item.ProvTelefo,
                        AttendedBy = item.ProvAtendio,
                        IdCurrency = item.ProvMnLiCr == "US$" ? 1 : item.ProvMnLiCr == "MN" ? 31 : item.ProvMnLiCr == "EUR" ? 2 : null,
                        MaximumAmount = item.ProvLinCre,
                        MaximumAmountEng = item.ProvLinCreIng,
                        TimeLimit = item.ProvPlazos,
                        TimeLimitEng = item.ProvPlazosIng,
                        Compliance = item.ProvCumple,
                        ClientSince = item.ProvTiempo,
                        ClientSinceEng = item.ProvTiempoIng,
                        ProductsTheySell = item.ProvVenden,
                        ProductsTheySellEng = item.ProvVendenIng,
                        AdditionalCommentary = item.ProvComen,
                        AdditionalCommentaryEng = item.ProvComenIng,
                        ReferentCommentary = item.ProvTexto,
                       

                    };
                    lista.Add(objeto);
                   
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa proveedores :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<Provider>();

        }

        private async Task<List<ImportsAndExport>> GetImportsAndExports(string emCodigo)
        {
            var lista = new List<ImportsAndExport>();
            var imports = await _mempresaDomain.GetmEmpresaImpByCodigoAsync(emCodigo);
            try
            {
                foreach (var imp in imports)
                {
                    var import = new ImportsAndExport
                    {
                        Type = "I",
                        Year = imp.EiAno,
                        Amount = imp.EiMonto
                    };
                    lista.Add(import);
                }

                //exportaciones 

                var exports = await _mempresaDomain.GetmEmpresaExpByCodigoAsync(emCodigo);

                foreach (var exp in exports)
                {

                    var export = new ImportsAndExport
                    {
                        Type = "E",
                        Year = exp.ExAno,
                        Amount = exp.ExMonto
                    };
                    lista.Add(export);
                }

                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa import export :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<ImportsAndExport>();
        }

        private async Task<List<SalesHistory>> GetSalesHistories(string emCodigo)
        {
            var list = new List<SalesHistory>();
            try
            {
                var historico = await _mempresaDomain.GetmEmpresaHistVentByCodigoAsync(emCodigo);
                foreach (var item in historico)
                {
                    if (item != null)
                    {

                        var objeto = new SalesHistory
                        {
                            Date = StaticFunctions.VerifyDate(item.VeFecha),
                            IdCurrency = item.PaiMone == "USD020" ? 1 : item.PaiMone == "PEN015" ? 31 : item.PaiMone == "USD007" ? 1 :
                            item.PaiMone == "USD008" ? 1 : item.PaiMone == "PEN015" ? 31 :
                            item.PaiMone == "USD207" ? 1 : item.PaiMone == "USD016" ? 1 :
                            item.PaiMone == "USD213" ? 1 : item.PaiMone == "USD207" ? 1 :
                            item.PaiMone == "UYU019" ? 154 : item.PaiMone == "MXN039" ? 15 :
                            item.PaiMone == "PAB013" ? 120 : item.PaiMone == "DOP017" ? 126 :
                            item.PaiMone == "GTQ009" ? 80 : item.PaiMone == "COP004" ? 63 :
                            item.PaiMone == "BOB002" ? 51 : item.PaiMone == "ARS001" ? 38 :
                            item.PaiMone == "CRC005" ? 66 : item.PaiMone == "PYG014" ? 122 :
                            item.PaiMone == "CLP006" ? 29 : item.PaiMone == "BRL003" ? 20 :
                            item.PaiMone == "HNL010" ? 84 : item.PaiMone == "NIO012" ? 115 :
                            item.PaiMone == "JMD034" ? 93 : item.PaiMone == "MYR" ? 105 :
                            item.PaiMone == "EUR197" ? 2 : item.PaiMone == "COP004" ? 63 :
                            item.PaiMone == "EUR024" ? 2 : item.PaiMone == "COL" ? 63 :
                            item.PaiMone == "EUR041" ? 2 : item.PaiMone == "EUR048" ? 2 :
                            item.PaiMone == "EUR023" ? 2 : item.PaiMone == "EUR052" ? 2 :
                            item.PaiMone == "EUR025" ? 2 : item.PaiMone == "EUR219" ? 2 :
                            item.PaiMone == "EUR036" ? 2 : item.PaiMone == "EUR045" ? 2 :
                            item.PaiMone == "EUR068" ? 2 : item.PaiMone == "EUR068" ? 2 :
                            item.PaiMone == "EUR068" ? 2 : item.PaiMone == "EUR068" ? 2 :
                            item.PaiMone == "GYD025" ? 82 : item.PaiMone == "BBD038" ? 44 :
                            item.PaiMone == "TTD018" ? 148 : item.PaiMone == "KYD026" ? 88 :
                            item.PaiMone == "INR086" ? 16 : item.PaiMone == "BSD033" ? 42 :
                            item.PaiMone == "SRD058" ? 146 : item.PaiMone == "TRY093" ? 19 :
                            item.PaiMone == "CNY061" ? 8 : item.PaiMone == "XCD056" ? 36 :
                            item.PaiMone == "XCD049" ? 36 : item.PaiMone == "XCD047" ? 36 :
                            item.PaiMone == "XCD218" ? 36 : item.PaiMone == "XCD063" ? 36 :
                            item.PaiMone == "HUF" ? 26 : item.PaiMone == "AWG043" ? 40 :
                            item.PaiMone == "CHF083" ? 7 : item.PaiMone == "ANG027" ? 69 :
                            item.PaiMone == "ANG057" ? 69 : item.PaiMone == "ANG081" ? 69 : null,
                            Amount = (decimal)item.VeVentas,
                            ExchangeRate = (decimal)item.VeTipcam,
                            EquivalentToDollars = (decimal)item.VeTipcam == 0 ? 0 : (decimal)item.VeVentas / (decimal)item.VeTipcam,

                        };
                        list.Add(objeto);

                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa historico :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<SalesHistory>();
        }

        private async Task<List<FinancialBalance>> GetFinancialBalances(string emCodigo)
        {
            var list = new List<FinancialBalance>();
            var balance = await _mempresaDomain.GetmEmpresaBalanceByCodigoAsync(emCodigo);

            try
            {

                if (balance != null)
                {
                    if (balance.BaFecbal1 != null && balance.BaFecbal1 != "")
                    {
                        var balance1 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balance.BaFecbal1),
                            BalanceType = "GENERAL",
                            BalanceTypeEng = balance.BaTipBal1Ing,
                            Duration = balance.BaTimbal1,
                            DurationEng = balance.BaTimBal1Ing,
                            IdCurrency = GetBalanceCurrency(balance.BaMoneda1),
                            ExchangeRate = (decimal)balance.BaTipcam1,
                            Sales = (decimal)balance.BaVentas1,
                            Utilities = (decimal)balance.BaUtiper1,
                            TotalAssets = (decimal)balance.BaTotact1,
                            TotalCurrentAssets = (decimal)balance.BaTotcor1,
                            ACashBoxBank = (decimal)balance.BaCajban1,
                            AToCollect = (decimal)balance.BaPorcob1,
                            AInventory = (decimal)balance.BaInvent1,
                            AOtherCurrentAssets = (decimal)balance.BaActcorotr1,
                            TotalNonCurrentAssets = (decimal)balance.BaFijo1 + (decimal)balance.BaActotr1,
                            AFixed = (decimal)balance.BaFijo1,
                            AOtherNonCurrentAssets = (decimal)balance.BaActotr1,
                            TotalLliabilities = (decimal)balance.BaPastot1,
                            TotalCurrentLiabilities = (decimal)balance.BaTotcrr1,
                            LCashBoxBank = (decimal)balance.BaBanpro1,
                            LOtherCurrentLiabilities = (decimal)balance.BaPasotr1,
                            TotalNonCurrentLiabilities = (decimal)balance.BaLarpla1 + (decimal)balance.BaCorotr1,
                            LLongTerm = (decimal)balance.BaLarpla1,
                            LOtherNonCurrentLiabilities = (decimal)balance.BaCorotr1,
                            TotalPatrimony = (decimal)balance.BaTotpat1,
                            PCapital = (decimal)balance.BaCapita1,
                            PStockPile = (decimal)balance.BaReser1,
                            PUtilities = (decimal)balance.BaUtili1,
                            POther = (decimal)balance.BaPatotr1,
                            TotalLiabilitiesPatrimony = (decimal)balance.BaTotpas1,
                            LiquidityRatio = ((decimal)balance.BaTotcrr1 == 0) ? 0 : (decimal)balance.BaTotcor1 / (decimal)balance.BaTotcrr1,
                            DebtRatio = ((decimal)balance.BaTotcrr1 == 0) ? 0 : ((decimal)balance.BaTotpat1 / (decimal)balance.BaTotcrr1) * 100,
                            ProfitabilityRatio = ((decimal)balance.BaVentas1 == 0) ? 0 : ((decimal)balance.BaUtiper1 / (decimal)balance.BaVentas1) * 100,
                            WorkingCapital = (decimal)balance.BaTotcor1 - (decimal)balance.BaTotcrr1
                        };
                        list.Add(balance1);
                    }

                    if (balance.BaFecbal2 != null && balance.BaFecbal2 != "")
                    {

                        var balance2 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balance.BaFecbal2),
                            BalanceType = "GENERAL",
                            BalanceTypeEng = balance.BaTipBal2Ing,
                            Duration = balance.BaTimbal2,
                            DurationEng = balance.BaTimBal2Ing,
                            IdCurrency = GetBalanceCurrency(balance.BaMoneda2),
                            ExchangeRate = (decimal)balance.BaTipcam2,
                            Sales = (decimal)balance.BaVentas2,
                            Utilities = (decimal)balance.BaUtiper2,
                            TotalAssets = (decimal)balance.BaTotact2,
                            TotalCurrentAssets = (decimal)balance.BaTotcor2,
                            ACashBoxBank = (decimal)balance.BaCajban2,
                            AToCollect = (decimal)balance.BaPorcob2,
                            AInventory = (decimal)balance.BaInvent2,
                            AOtherCurrentAssets = (decimal)balance.BaActCorOtr2,
                            TotalNonCurrentAssets = (decimal)balance.BaFijo2 + (decimal)balance.BaActotr2,
                            AFixed = (decimal)balance.BaFijo2,
                            AOtherNonCurrentAssets = (decimal)balance.BaActotr2,
                            TotalLliabilities = (decimal)balance.BaPastot2,
                            TotalCurrentLiabilities = (decimal)balance.BaTotcrr2,
                            LCashBoxBank = (decimal)balance.BaBanpro2,
                            LOtherCurrentLiabilities = (decimal)balance.BaPasotr2,
                            TotalNonCurrentLiabilities = (decimal)balance.BaLarpla2 + (decimal)balance.BaCorotr2,
                            LLongTerm = (decimal)balance.BaLarpla2,
                            LOtherNonCurrentLiabilities = (decimal)balance.BaCorotr2,
                            TotalPatrimony = (decimal)balance.BaTotpat2,
                            PCapital = (decimal)balance.BaCapita2,
                            PStockPile = (decimal)balance.BaReser2,
                            PUtilities = (decimal)balance.BaUtili2,
                            POther = (decimal)balance.BaPatOtr2,
                            TotalLiabilitiesPatrimony = (decimal)balance.BaTotpas2,
                            LiquidityRatio = ((decimal)balance.BaTotcrr2 == 0) ? 0 : (decimal)balance.BaTotcor2 / (decimal)balance.BaTotcrr2,
                            WorkingCapital = (decimal)balance.BaTotcor2 - (decimal)balance.BaTotcrr2,
                            DebtRatio = ((decimal)balance.BaTotcrr2 == 0) ? 0 : ((decimal)balance.BaTotpat2 / (decimal)balance.BaTotcrr2) * 100,
                            ProfitabilityRatio = ((decimal)balance.BaVentas2 == 0) ? 0 : (((decimal)balance.BaUtiper2 / (decimal)balance.BaVentas2)) * 100
                        };
                        list.Add(balance2);

                    }
                    if (balance.BaFecbal3 != null && balance.BaFecbal3 != "")
                    {
                        var balance3 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balance.BaFecbal3),
                            BalanceType = "GENERAL",
                            BalanceTypeEng = balance.BaTipBal3Ing,
                            Duration = balance.BaTimbal3,
                            DurationEng = balance.BaTimBal3Ing,
                            IdCurrency = GetBalanceCurrency(balance.BaMoneda3),
                            ExchangeRate = (decimal)balance.BaTipcam3,
                            Sales = (decimal)balance.BaVentas3,
                            Utilities = (decimal)balance.BaUtiper3,
                            TotalAssets = (decimal)balance.BaTotact3,
                            TotalCurrentAssets = (decimal)balance.BaTotcor3,
                            ACashBoxBank = (decimal)balance.BaCajban3,
                            AToCollect = (decimal)balance.BaPorcob3,
                            AInventory = (decimal)balance.BaInvent3,
                            AOtherCurrentAssets = (decimal)balance.BaActCorOtr3,
                            TotalNonCurrentAssets = (decimal)balance.BaFijo3 + (decimal)balance.BaActotr3,
                            AFixed = (decimal)balance.BaFijo3,
                            AOtherNonCurrentAssets = (decimal)balance.BaActotr3,
                            TotalLliabilities = (decimal)balance.BaPastot3,
                            TotalCurrentLiabilities = (decimal)balance.BaTotcrr3,
                            LCashBoxBank = (decimal)balance.BaBanpro3,
                            LOtherCurrentLiabilities = (decimal)balance.BaPasotr3,
                            TotalNonCurrentLiabilities = (decimal)balance.BaLarpla3 + (decimal)balance.BaCorotr3,
                            LLongTerm = (decimal)balance.BaLarpla3,
                            LOtherNonCurrentLiabilities = (decimal)balance.BaCorotr3,
                            TotalPatrimony = (decimal)balance.BaTotpat3,
                            PCapital = (decimal)balance.BaCapita3,
                            PStockPile = (decimal)balance.BaReser3,
                            PUtilities = (decimal)balance.BaUtili3,
                            POther = (decimal)balance.BaPatOtr3,
                            TotalLiabilitiesPatrimony = (decimal)balance.BaTotpas3,
                            LiquidityRatio = ((decimal)balance.BaTotcrr3 == 0) ? 0 : (decimal)balance.BaTotcor3 / (decimal)balance.BaTotcrr3,
                            DebtRatio = ((decimal)balance.BaTotcrr3 == 0) ? 0 : ((decimal)balance.BaTotpat3 / (decimal)balance.BaTotcrr3) * 100,
                            ProfitabilityRatio = ((decimal)balance.BaVentas3 == 0) ? 0 : ((decimal)balance.BaUtiper3 / (decimal)balance.BaVentas3) * 100,
                            WorkingCapital = (decimal)balance.BaTotcor3 - (decimal)balance.BaTotcrr3
                        };
                        list.Add(balance3);
                    }
                    if (balance.BaFecbal4 != null && balance.BaFecbal4 != "")
                    {
                        var balance4 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balance.BaFecbal4),
                            BalanceType = "GENERAL",
                            BalanceTypeEng = balance.BaTipBal4Ing,
                            Duration = balance.BaTimbal4,
                            DurationEng = balance.BaTimBal4Ing,
                            IdCurrency = GetBalanceCurrency(balance.BaMoneda4),
                            ExchangeRate = (decimal)balance.BaTipcam4,
                            Sales = (decimal)balance.BaVentas4,
                            Utilities = (decimal)balance.BaUtiper4,
                            TotalAssets = (decimal)balance.BaTotact4,
                            TotalCurrentAssets = (decimal)balance.BaTotcor4,
                            ACashBoxBank = (decimal)balance.BaCajban4,
                            AToCollect = (decimal)balance.BaPorcob4,
                            AInventory = (decimal)balance.BaInvent4,
                            AOtherCurrentAssets = (decimal)balance.BaActCorOtr4,
                            TotalNonCurrentAssets = (decimal)balance.BaFijo4 + (decimal)balance.BaActotr4,
                            AFixed = (decimal)balance.BaFijo4,
                            AOtherNonCurrentAssets = (decimal)balance.BaActotr4,
                            TotalLliabilities = (decimal)balance.BaPastot4,
                            TotalCurrentLiabilities = (decimal)balance.BaTotcrr4,
                            LCashBoxBank = (decimal)balance.BaBanpro4,
                            LOtherCurrentLiabilities = (decimal)balance.BaPasotr4,
                            TotalNonCurrentLiabilities = (decimal)balance.BaLarpla4 + (decimal)balance.BaCorotr4,
                            LLongTerm = (decimal)balance.BaLarpla4,
                            LOtherNonCurrentLiabilities = (decimal)balance.BaCorotr4,
                            TotalPatrimony = (decimal)balance.BaTotpat4,
                            PCapital = (decimal)balance.BaCapita4,
                            PStockPile = (decimal)balance.BaReser4,
                            PUtilities = (decimal)balance.BaUtili4,
                            POther = (decimal)balance.BaPatOtr4,
                            TotalLiabilitiesPatrimony = (decimal)balance.BaTotpas4,
                            LiquidityRatio = ((decimal)balance.BaTotcrr4 == 0) ? 0 : (decimal)balance.BaTotcor4 / (decimal)balance.BaTotcrr4,
                            DebtRatio = ((decimal)balance.BaTotcrr4 == 0) ? 0 : ((decimal)balance.BaTotpat4 / (decimal)balance.BaTotcrr4) * 100,
                            ProfitabilityRatio = ((decimal)balance.BaVentas4 == 0) ? 0 : ((decimal)balance.BaUtiper4 / (decimal)balance.BaVentas4) * 100,
                            WorkingCapital = (decimal)balance.BaTotcor4 - (decimal)balance.BaTotcrr4
                        };
                        list.Add(balance4);
                    }
                }


                //balance S
                var balanceS = await _mempresaDomain.GetmEmpresaBalanceSitByCodigoAsync(emCodigo);


                if (balanceS != null)
                {
                    if (balanceS.BsFecbal1 != null && balanceS.BsFecbal1 != "")
                    {
                        var sbalance1 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balanceS.BsFecbal1),
                            BalanceType = "SITUACIONAL",
                            BalanceTypeEng = balanceS.BsTipBal1Ing,
                            Duration = balanceS.BsTimbal1,
                            DurationEng = balanceS.BsTimBal1Ing,
                            IdCurrency = GetBalanceCurrency(balanceS.BsMoneda1),
                            ExchangeRate = (decimal)balanceS.BsTipcam1,
                            Sales = (decimal)balanceS.BsVentas1,
                            Utilities = (decimal)balanceS.BsUtiper1,
                            TotalAssets = (decimal)balanceS.BsTotact1,
                            TotalCurrentAssets = (decimal)balanceS.BsTotcor1,
                            ACashBoxBank = (decimal)balanceS.BsCajban1,
                            AToCollect = (decimal)balanceS.BsPorcob1,
                            AInventory = (decimal)balanceS.BsInvent1,
                            AOtherCurrentAssets = (decimal)balanceS.BsActcorotr1,
                            TotalNonCurrentAssets = (decimal)balanceS.BsFijo1 + (decimal)balanceS.BsActotr1,
                            AFixed = (decimal)balanceS.BsFijo1,
                            AOtherNonCurrentAssets = (decimal)balanceS.BsActotr1,
                            TotalLliabilities = (decimal)balanceS.BsTotcrr1 + (decimal)balanceS.BsLarpla1 + (decimal)balanceS.BsCorotr1,
                            TotalCurrentLiabilities = (decimal)balanceS.BsTotcrr1,
                            LCashBoxBank = (decimal)balanceS.BsBanpro1,
                            LOtherCurrentLiabilities = (decimal)balanceS.BsPasotr1,
                            TotalNonCurrentLiabilities = (decimal)balanceS.BsLarpla1 + (decimal)balanceS.BsCorotr1,
                            LLongTerm = (decimal)balanceS.BsLarpla1,
                            LOtherNonCurrentLiabilities = (decimal)balanceS.BsCorotr1,
                            TotalPatrimony = (decimal)balanceS.BsTotpat1,
                            PCapital = (decimal)balanceS.BsCapita1,
                            PStockPile = (decimal)balanceS.BsReser1,
                            PUtilities = (decimal)balanceS.BsUtili1,
                            POther = (decimal)balanceS.BsPatotr1,
                            TotalLiabilitiesPatrimony = (decimal)balanceS.BsTotpas1,
                            LiquidityRatio = (decimal)balanceS.BsTotcrr1 == 0 ? 0 : (decimal)balanceS.BsTotcor1 / (decimal)balanceS.BsTotcrr1,
                            DebtRatio = (decimal)balanceS.BsTotcrr1 == 0 ? 0 : ((decimal)balanceS.BsTotpat1 / (decimal)balanceS.BsTotcrr1) * 100,
                            ProfitabilityRatio = (decimal)balanceS.BsVentas1 == 0 ? 0 : ((decimal)balanceS.BsUtiper1 / (decimal)balanceS.BsVentas1) * 100,
                            WorkingCapital = (decimal)balanceS.BsTotcor1 - (decimal)balanceS.BsTotcrr1
                        };
                        list.Add(sbalance1);

                    }
                    if (balanceS.BsFecbal2 != null && balanceS.BsFecbal2 != "")
                    {

                        var sbalance2 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balanceS.BsFecbal2),
                            BalanceType = "SITUACIONAL",
                            BalanceTypeEng = balanceS.BsTipBal2Ing,
                            Duration = balanceS.BsTimbal2,
                            DurationEng = balanceS.BsTimBal2Ing,
                            IdCurrency = GetBalanceCurrency(balanceS.BsMoneda2),
                            ExchangeRate = (decimal)balanceS.BsTipcam2,
                            Sales = (decimal)balanceS.BsVentas2,
                            Utilities = (decimal)balanceS.BsUtiper2,
                            TotalAssets = (decimal)balanceS.BsTotact2,
                            TotalCurrentAssets = (decimal)balanceS.BsTotcor2,
                            ACashBoxBank = (decimal)balanceS.BsCajban2,
                            AToCollect = (decimal)balanceS.BsPorcob2,
                            AInventory = (decimal)balanceS.BsInvent2,
                            AOtherCurrentAssets = (decimal)balanceS.BsActCorOtr2,
                            TotalNonCurrentAssets = (decimal)balanceS.BsFijo2 + (decimal)balanceS.BsActotr2,
                            AFixed = (decimal)balanceS.BsFijo2,
                            AOtherNonCurrentAssets = (decimal)balanceS.BsActotr2,
                            TotalLliabilities = (decimal)balanceS.BsTotcrr2 + (decimal)balanceS.BsLarpla2 + (decimal)balanceS.BsCorotr2,
                            TotalCurrentLiabilities = (decimal)balanceS.BsTotcrr2,
                            LCashBoxBank = (decimal)balanceS.BsBanpro2,
                            LOtherCurrentLiabilities = (decimal)balanceS.BsPasotr2,
                            TotalNonCurrentLiabilities = (decimal)balanceS.BsLarpla2 + (decimal)balanceS.BsCorotr2,
                            LLongTerm = (decimal)balanceS.BsLarpla2,
                            LOtherNonCurrentLiabilities = (decimal)balanceS.BsCorotr2,
                            TotalPatrimony = (decimal)balanceS.BsTotpat2,
                            PCapital = (decimal)balanceS.BsCapita2,
                            PStockPile = (decimal)balanceS.BsReser2,
                            PUtilities = (decimal)balanceS.BsUtili2,
                            POther = (decimal)balanceS.BsPatOtr2,
                            TotalLiabilitiesPatrimony = (decimal)balanceS.BsTotpas2,
                            LiquidityRatio = (decimal)balanceS.BsTotcrr2 == 0 ? 0 : (decimal)balanceS.BsTotcor2 / (decimal)balanceS.BsTotcrr2,
                            DebtRatio = (decimal)balanceS.BsTotcrr2 == 0 ? 0 : ((decimal)balanceS.BsTotpat2 / (decimal)balanceS.BsTotcrr2) * 100,
                            ProfitabilityRatio = (decimal)balanceS.BsVentas2 == 0 ? 0 : ((decimal)balanceS.BsUtiper2 / (decimal)balanceS.BsVentas2) * 100,
                            WorkingCapital = (decimal)balanceS.BsTotcor2 - (decimal)balanceS.BsTotcrr2
                        };
                        list.Add(sbalance2);
                    }
                    if (balanceS.BsFecbal3 != null && balanceS.BsFecbal3 != "")
                    {

                        var sbalance3 = new FinancialBalance
                        {
                            Date = StaticFunctions.VerifyDate(balanceS.BsFecbal3),
                            BalanceType = "SITUACIONAL",
                            BalanceTypeEng = balanceS.BsTipBal3Ing,
                            Duration = balanceS.BsTimbal3,
                            DurationEng = balanceS.BsTimBal3Ing,
                            IdCurrency = GetBalanceCurrency(balanceS.BsMoneda3),
                            ExchangeRate = (decimal)balanceS.BsTipcam3,
                            Sales = (decimal)balanceS.BsVentas3,
                            Utilities = (decimal)balanceS.BsUtiper3,
                            TotalAssets = (decimal)balanceS.BsTotact3,
                            TotalCurrentAssets = (decimal)balanceS.BsTotcor3,
                            ACashBoxBank = (decimal)balanceS.BsCajban3,
                            AToCollect = (decimal)balanceS.BsPorcob3,
                            AInventory = (decimal)balanceS.BsInvent3,
                            AOtherCurrentAssets = (decimal)balanceS.BsActCorOtr3,
                            TotalNonCurrentAssets = (decimal)balanceS.BsFijo3 + (decimal)balanceS.BsActotr3,
                            AFixed = (decimal)balanceS.BsFijo3,
                            AOtherNonCurrentAssets = (decimal)balanceS.BsActotr3,
                            TotalLliabilities = (decimal)balanceS.BsTotcrr3 + (decimal)balanceS.BsLarpla3 + (decimal)balanceS.BsCorotr3,
                            TotalCurrentLiabilities = (decimal)balanceS.BsTotcrr3,
                            LCashBoxBank = (decimal)balanceS.BsBanpro3,
                            LOtherCurrentLiabilities = (decimal)balanceS.BsPasotr3,
                            TotalNonCurrentLiabilities = (decimal)balanceS.BsLarpla3 + (decimal)balanceS.BsCorotr3,
                            LLongTerm = (decimal)balanceS.BsLarpla3,
                            LOtherNonCurrentLiabilities = (decimal)balanceS.BsCorotr3,
                            TotalPatrimony = (decimal)balanceS.BsTotpat3,
                            PCapital = (decimal)balanceS.BsCapita3,
                            PStockPile = (decimal)balanceS.BsReser3,
                            PUtilities = (decimal)balanceS.BsUtili3,
                            POther = (decimal)balanceS.BsPatOtr3,
                            TotalLiabilitiesPatrimony = (decimal)balanceS.BsTotpas3,
                            LiquidityRatio = (decimal)balanceS.BsTotcrr3 == 0 ? 0 : (decimal)balanceS.BsTotcor3 / (decimal)balanceS.BsTotcrr3,
                            DebtRatio = (decimal)balanceS.BsTotcrr3 == 0 ? 0 : ((decimal)balanceS.BsTotpat3 / (decimal)balanceS.BsTotcrr3) * 100,
                            ProfitabilityRatio = (decimal)balanceS.BsVentas3 == 0 ? 0 : ((decimal)balanceS.BsUtiper3 / (decimal)balanceS.BsVentas3) * 100,
                            WorkingCapital = (decimal)balanceS.BsTotcor3 - (decimal)balanceS.BsTotcrr3
                        };
                        list.Add(sbalance3);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa balance :" + emCodigo);
                throw new Exception(ex.Message);
            }
            return new List<FinancialBalance>();
        }

        private int? GetBalanceCurrency(string? baMoneda1)
        {
            return baMoneda1 == "USD" ? 1 : baMoneda1 == "PEN" ? 31 :
                   baMoneda1 == "UYU" ? 154 : baMoneda1 == "MXN" ? 15 :
                   baMoneda1 == "PAB" ? 120 : baMoneda1 == "DOP" ? 126 :
                   baMoneda1 == "GTQ" ? 80 : baMoneda1 == "COP" ? 63 :
                   baMoneda1 == "BOB" ? 51 : baMoneda1 == "ARS" ? 38 :
                   baMoneda1 == "CRC" ? 66 : baMoneda1 == "PYG" ? 122 :
                   baMoneda1 == "CLP" ? 29 : baMoneda1 == "BRL" ? 20 :
                   baMoneda1 == "HNL" ? 84 : baMoneda1 == "NIO" ? 115 :
                   baMoneda1 == "JMD" ? 93 : baMoneda1 == "MYR" ? 105 :
                   baMoneda1 == "EUR" ? 2 : baMoneda1 == "COL" ? 63 :
                   baMoneda1 == "VND" ? 156 : baMoneda1 == "GYD" ? 82 :
                   baMoneda1 == "UDS" ? 1 : baMoneda1 == "BBD" ? 44 :
                   baMoneda1 == "BZD" ? 46 : baMoneda1 == "GBP" ? 4 :
                   baMoneda1 == "TTD" ? 148 : baMoneda1 == "KYD" ? 88 :
                   baMoneda1 == "INR" ? 16 : baMoneda1 == "PKR" ? 119 :
                   baMoneda1 == "BSD" ? 42 : baMoneda1 == "SRD" ? 146 :
                   baMoneda1 == "TRY" ? 19 : baMoneda1 == "SAR" ? 37 :
                   baMoneda1 == "CNY" ? 8 : baMoneda1 == "XCD" ? 36 :
                   baMoneda1 == "HUF" ? 26 : baMoneda1 == "AWG" ? 40 :
                   baMoneda1 == "CHF" ? 7 : baMoneda1 == "TWD" ? 21 :
                   baMoneda1 == "DKK" ? 22 : baMoneda1 == "ANG" ? 69 :
                   baMoneda1 == "PLN" ? 23 : baMoneda1 == "MNX" ? 15 : null;
        }

        private async Task<List<CompanyGeneralInformation>> GetCompanyGeneralInformation(string texto, string emCodigo)
        {
            var lista = new List<CompanyGeneralInformation>();

            try
            {
                var objeto = new CompanyGeneralInformation
                {
                    GeneralInfo = texto

                };
                lista.Add(objeto);
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa informacion general :" + emCodigo);
                throw new Exception(ex.Message);
            }
        }
        private async Task<List<CompanyCreditOpinion>> GetCompanyCreditOpinions(MEmpresa empresa)
        {
            var lista = new List<CompanyCreditOpinion>();
            if (empresa != null)
            {

                try
                {
                    var objeto = new CompanyCreditOpinion
                    {
                        CreditRequest = true,
                        ConsultedCredit = empresa.EmMtopcr,
                        SuggestedCredit = empresa.EmCrerec,
                        CurrentCommentary = empresa.EmOcDescri,
                        PreviousCommentary = empresa.EmOpicre

                    };
                    lista.Add(objeto);
                    return lista;
                }

                catch (Exception ex)
                {
                    _logger.LogError("Error empresa opinion credito :" + empresa.EmCodigo);
                    throw new Exception(ex.Message);
                }
            }
            return new List<CompanyCreditOpinion>();
        }
        private async Task<List<CompanySb>> GetCompanySbs(MEmpresa empresa)
        {
            var lista = new List<CompanySb>();
            aval = await _mempresaDomain.GetmEmpresaAvalByCodigoAsync(empresa.EmCodigo);
            string? endorsement = string.Empty;
            if (aval == null)
            {
                endorsement = string.Empty;
            }
            else
            {
                endorsement = aval.AvObservacion ?? string.Empty;
            }
            if (empresa != null)
            {
                try
                {
                    var sbs = new CompanySb
                    {
                        IdOpcionalCommentarySbs = 1,
                        AditionalCommentaryRiskCenter = empresa.EmCenrie,
                        DebtRecordedDate = StaticFunctions.VerifyDate(empresa.EmFecreg), //*
                        ExchangeRate =empresa.EmTcsbs==null?null: (decimal)empresa.EmTcsbs,
                        BankingCommentary = empresa.EmSupban,
                        EndorsementsObservations = endorsement,
                        ReferentOrAnalyst = empresa.PerCodref,
                        Date = StaticFunctions.VerifyDate(empresa.EmFecref),
                        LitigationsCommentary = empresa.EmComlit,
                        CreditHistoryCommentary = empresa.EmAntcre,
                        GuaranteesOfferedNc = empresa.EmGaomn == null ? null : (decimal)empresa.EmGaomn,
                        GuaranteesOfferedFc = empresa.EmGaome == null ? null : (decimal)empresa.EmGaome

                    };
                    lista.Add(sbs);
                    return lista;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error empresa sbs :" + empresa.EmCodigo);
                    throw new Exception(ex.Message);
                }
            }
            return new List<CompanySb>();
        }

        private async Task<List<CompanyFinancialInformation>> GetCompanyFinancialInformations(string emCodigo, string auditor)
        {
            var lista = new List<CompanyFinancialInformation>();
            finanzas = await _mempresaDomain.GetmEmpresaFinanzasByCodigoAsync(emCodigo);

            try
            {
                if (finanzas != null)
                {
                    var objeto = new CompanyFinancialInformation
                    {
                        Interviewed = finanzas.EmEntrev,
                        WorkPosition = finanzas.EmCargos,
                        IdCollaborationDegree = finanzas.GcCodigo == 1 ? 1 : finanzas.GcCodigo == 2 ? 3 : finanzas.GcCodigo == 3 ? 4 :
                    finanzas.GcCodigo == 4 ? 5 : finanzas.GcCodigo == 5 ? 6 : finanzas.GcCodigo == 6 ? 7 : finanzas.GcCodigo == 7 ? 10 :
                    finanzas.GcCodigo == 8 ? 8 : finanzas.GcCodigo == 9 ? 9 : finanzas.GcCodigo == 13 ? 2 : null,
                        InterviewCommentary = finanzas.EmConinf,
                        Auditors = auditor,
                        IdFinancialSituacion = finanzas.SfCodigo == "00" ? 8 : finanzas.SfCodigo == "01" ? 9 : finanzas.SfCodigo == "02" ? 10 :
                     finanzas.SfCodigo == "03" ? 11 : finanzas.SfCodigo == "04" ? 12 : finanzas.SfCodigo == "05" ? 13 : finanzas.SfCodigo == "06" ? 14 :
                      finanzas.SfCodigo == "07" ? 15 : null,
                        FinancialCommentarySelected = finanzas.EmSitfin,
                        MainFixedAssets = finanzas.EmPropie,
                        AnalystCommentary = finanzas.EmAnalista
                    };
                    lista.Add(objeto);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa antecedentes :" + emCodigo);
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<CompanyBranch>> GetCompanyBranch(string emCodigo)
        {
            var lista = new List<CompanyBranch>();
            ramo = await _mempresaDomain.GetmEmpresaRamoByCodigoAsync(emCodigo);
            try
            {
                if (ramo != null)
                {
                    var branch = new CompanyBranch
                    {
                        IdBranchSector = ramo.EmCatciiu1 == "A" ? 3 : ramo.EmCatciiu1 == "B" ? 4 : ramo.EmCatciiu1 == "C" ? 5 : null,
                        IdBusinessBranch = ramo.CsCodigo == "0" ? 1 : ramo.CsCodigo == "1" ? 3 : ramo.CsCodigo == "2" ? 4 : ramo.CsCodigo == "3" ? 5 :
                    ramo.CsCodigo == "4" ? 6 : ramo.CsCodigo == "5" ? 7 : ramo.CsCodigo == "6" ? 8 : ramo.CsCodigo == "7" ? 9 : ramo.CsCodigo == "8" ? 10 :
                    ramo.CsCodigo == "9" ? 11 : ramo.CsCodigo == "10" ? 12 : ramo.CsCodigo == "11" ? 13 : ramo.CsCodigo == "12" ? 14 : ramo.CsCodigo == "13" ? 15 :
                    ramo.CsCodigo == "14" ? 16 : ramo.CsCodigo == "15" ? 17 : ramo.CsCodigo == "16" ? 18 : ramo.CsCodigo == "17" ? 19 : ramo.CsCodigo == "18" ? 20 :
                    ramo.CsCodigo == "19" ? 21 : ramo.CsCodigo == "20" ? 22 : ramo.CsCodigo == "21" ? 23 : ramo.CsCodigo == "22" ? 24 : ramo.CsCodigo == "23" ? 25 :
                    ramo.CsCodigo == "24" ? 26 : ramo.CsCodigo == "25" ? 27 : ramo.CsCodigo == "26" ? 28 : ramo.CsCodigo == "27" ? 29 : ramo.CsCodigo == "28" ? 30 :
                    ramo.CsCodigo == "29" ? 31 : ramo.CsCodigo == "30" ? 32 : null,
                        SpecificActivities = await _mempresaDomain.GetActividadesByCodigo(emCodigo),
                        Import = ramo.EmLogimp == "Si" ? true : ramo.EmLogimp == "No" ? false : null,
                        Export = ramo.EmLogexp == "Si" ? true : ramo.EmLogexp == "No" ? false : null,
                        CountriesImport = ramo.EmImport1,
                        CountriesExport = ramo.EmExport1,
                        CountriesImportEng = ramo.EmImport1Ing,
                        CountriesExportEng = ramo.EmExport1Ing,
                        CashSaleComentary = ramo.EmVencon,
                        CreditSaleComentary = ramo.EmVencre,
                        TerritorySaleComentary = ramo.EmTervta,
                        AbroadSaleComentary = ramo.EmVtaext,
                        NationalPurchasesComentary = ramo.EmComnac,
                        InternationalPurchasesComentary = ramo.EmComext,
                        WorkerNumber = GetWorkers(ramo.EmTraba1),
                        IdLandOwnership = ramo.EmTiploc == "Alquilado" ? 2 : ramo.EmTiploc == "Comodato" ? 3 :
                         ramo.EmTiploc == "Compartido" ? 4 : ramo.EmTiploc == "No Revelado" ? 5 : ramo.EmTiploc == "Oficina Virtual" ? 6 :
                         ramo.EmTiploc == "Propio Cancelado" ? 7 : ramo.EmTiploc == "Propio Pagandolo" ? 8 : null,
                        TotalArea = ramo.EmArea,
                        OtherLocations = ramo.EmObserv,
                        PreviousAddress = ramo.EmDomant,
                        ActivityDetailCommentary = ramo.EmActivi,
                        AditionalCommentary = ramo.EmComen,
                        TabCommentary = ramo.EmComenTab
                    };
                    lista.Add(branch);

                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa antecedentes :" + emCodigo);
                throw new Exception(ex.Message);
            }

        }
        private int? GetWorkers(string value)
        {
            if (string.IsNullOrEmpty(ramo.EmTraba1)) return null;
            if (value.Contains('|'))
            {
                var valores = value.Split('|')[0];
                if (string.IsNullOrEmpty(valores)) return null;

                int number;
                if (valores.Contains(','))
                {
                    valores = valores.Replace(",", "");
                }
                return int.TryParse(valores, out number) ? number : null;

            }
            else
            {
                int number;
                if (value.Contains(','))
                {
                    value = value.Replace(",", "");
                }
                int? xxx = int.TryParse(value, out number) ? number : null;
                return xxx;
            }
        }

        private async Task<List<CompanyBackground>> GetCompanyBackground(string emCodigo)
        {
            var lista = new List<CompanyBackground>();
            try
            {
                antecedentes = await _mempresaDomain.GetmEmpresaAspLegByCodigoAsync(emCodigo);


                if (antecedentes != null)
                {
                    var back = new CompanyBackground
                    {
                        ConstitutionDate = StaticFunctions.VerifyDate(antecedentes.EmFecest),
                        StartFunctionYear = antecedentes.EmIniope,
                        OperationDuration = antecedentes.EmDuraci,
                        RegisterPlace = antecedentes.EmRegen,
                        NotaryRegister = antecedentes.EmNotari,
                        PublicRegister = antecedentes.EmRegist,
                        CurrentPaidCapitalComentary = antecedentes.EmCapac1,
                        Origin = antecedentes.EmOrigen,
                        IncreaceDateCapital = antecedentes.EmFecaum,
                        Traded = antecedentes.EmCotbol == "SI" ? "Si" : antecedentes.EmCotbol == "Si" ? "Si" : antecedentes.EmCotbol == "SÍ" ? "Si" :
                           antecedentes.EmCotbol == "Sí" ? "Si" : antecedentes.EmCotbol == "NO" ? "No" : antecedentes.EmCotbol == "No" ? "No" : "",
                        TradedBy = antecedentes.EmTipfecaum,
                        TradedByEng = antecedentes.EmTipfecaumIng,
                        CurrentExchangeRate = antecedentes.EmTipcam,
                        LastQueryRrpp = StaticFunctions.VerifyDate(antecedentes.EmRrppFecha),
                        LastQueryRrppBy = antecedentes.EmRrppPor,
                        Background = antecedentes.EmComent,
                        History = antecedentes.EmAntece

                    };
                    lista.Add(back);
                }
                return lista;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa antecedentes :" + emCodigo);
                throw new Exception(ex.Message);
            }
        }

        private int? GetPaymentPolicy(string? paCodigo)
        {
            return paCodigo == "01" ? 8 : paCodigo == "02" ? 9 : paCodigo == "03" ? 10 : paCodigo == "04" ? 11 :
                   paCodigo == "05" ? 12 : paCodigo == "06" ? 13 : paCodigo == "07" ? 14 : null;
        }

        private int? GetCreditRisk(string? crCodigo)
        {
            return crCodigo == "0005" ? 1 : crCodigo == "0000" ? 2 : crCodigo == "0001" ? 3 :
                   crCodigo == "0002" ? 4 : crCodigo == "0003" ? 5 : crCodigo == "0011" ? 6 : crCodigo == "0004" ? 7 : null;
        }

        private int? GetLegalRegisterSituation(string? sitCodigo)
        {
            return sitCodigo == "03" ? 4 : sitCodigo == "04" ? 3 :
                   sitCodigo == "05" ? 16 : sitCodigo == "02" ? 1 : sitCodigo == "07" ? 2 :
                   sitCodigo == "06" ? 13 : sitCodigo == "08" ? 5 : sitCodigo == "09" ? 14 :
                   sitCodigo == "10" ? 6 : sitCodigo == "11" ? 8 : sitCodigo == "12" ? 11 :
                   sitCodigo == "13" ? 10 : sitCodigo == "14" ? 7 : sitCodigo == "15" ? 12 :
                   sitCodigo == "16" ? 15 : sitCodigo == "17" ? 9 : null;
        }

        private bool? ObtenerReportes(string emCodigo)
        {
            using (var context = new SqlCoreContext())
            {
                return context.OldTickets.Where(x => x.Empresa == emCodigo).Any();
            }
        }

        private int? ObtenerCodigoPais(string? PaiCodigo)
        {
            return PaiCodigo == "001" ? 11 : PaiCodigo == "002" ? 29 : PaiCodigo == "003" ? 34 :
            PaiCodigo == "004" ? 54 : PaiCodigo == "005" ? 57 : PaiCodigo == "006" ? 49 :
            PaiCodigo == "007" ? 70 : PaiCodigo == "008" ? 72 : PaiCodigo == "009" ? 100 :
            PaiCodigo == "010" ? 108 : PaiCodigo == "012" ? 168 : PaiCodigo == "013" ? 179 :
            PaiCodigo == "014" ? 181 : PaiCodigo == "015" ? 182 : PaiCodigo == "016" ? 187 :
            PaiCodigo == "017" ? 69 : PaiCodigo == "018" ? 237 : PaiCodigo == "019" ? 250 :
            PaiCodigo == "020" ? 249 : PaiCodigo == "021" ? 253 : PaiCodigo == "022" ? 105 :
            PaiCodigo == "023" ? 147 : PaiCodigo == "024" ? 98 : PaiCodigo == "025" ? 104 :
            PaiCodigo == "026" ? 46 : PaiCodigo == "027" ? 60 : PaiCodigo == "029" ? 256 :
            PaiCodigo == "030" ? 255 : PaiCodigo == "031" ? 43 : PaiCodigo == "032" ? 25 :
            PaiCodigo == "033" ? 18 : PaiCodigo == "034" ? 120 : PaiCodigo == "035" ? 183 :
            PaiCodigo == "036" ? 92 : PaiCodigo == "037" ? 15 : PaiCodigo == "038" ? 21 :
            PaiCodigo == "039" ? 151 : PaiCodigo == "040" ? 59 : PaiCodigo == "041" ? 220 :
            PaiCodigo == "042" ? 186 : PaiCodigo == "043" ? 13 : PaiCodigo == "044" ? 16 :
            PaiCodigo == "045" ? 24 : PaiCodigo == "046" ? 27 : PaiCodigo == "047" ? 68 : PaiCodigo == "075" ? null :
            PaiCodigo == "048" ? 84 : PaiCodigo == "049" ? 97 : PaiCodigo == "050" ? 265 : PaiCodigo == "064" ? 123 :
            PaiCodigo == "051" ? 109 : PaiCodigo == "052" ? 119 : PaiCodigo == "053" ? 121 :
            PaiCodigo == "054" ? 218 : PaiCodigo == "055" ? 196 : PaiCodigo == "056" ? 197 :
            PaiCodigo == "057" ? 198 : PaiCodigo == "058" ? 224 : PaiCodigo == "059" ? 8 :
            PaiCodigo == "060" ? 149 : PaiCodigo == "061" ? 50 : PaiCodigo == "062" ? 229 :
            PaiCodigo == "063" ? 10 : PaiCodigo == "065" ? 65 : PaiCodigo == "066" ? 239 :
            PaiCodigo == "067" ? 205 : PaiCodigo == "068" ? 83 : PaiCodigo == "069" ? 175 :
            PaiCodigo == "070" ? 62 : PaiCodigo == "071" ? 191 : PaiCodigo == "072" ? 245 :
            PaiCodigo == "073" ? 247 : PaiCodigo == "074" ? 200 : PaiCodigo == "076" ? 156 :
            PaiCodigo == "078" ? 194 : PaiCodigo == "080" ? 241 : PaiCodigo == "081" ? 265 :
            PaiCodigo == "079" ? 264 : PaiCodigo == "083" ? 227 : PaiCodigo == "084" ? 226 :
            PaiCodigo == "085" ? 131 : PaiCodigo == "086" ? 112 : PaiCodigo == "087" ? 118 :
            PaiCodigo == "088" ? 185 : PaiCodigo == "089" ? 137 : PaiCodigo == "090" ? 165 :
            PaiCodigo == "091" ? 94 : PaiCodigo == "092" ? 142 : PaiCodigo == "093" ? 243 :
            PaiCodigo == "095" ? 246 : PaiCodigo == "096" ? 124 : PaiCodigo == "097" ? 4 : PaiCodigo == "098" ? 216 :
            PaiCodigo == "099" ? 91 : PaiCodigo == "100" ? 95 : PaiCodigo == "101" ? 266 :
            PaiCodigo == "102" ? 210 : PaiCodigo == "103" ? 136 : PaiCodigo == "104" ? 177 :
            PaiCodigo == "105" ? 7 : PaiCodigo == "106" ? 26 : PaiCodigo == "107" ? 32 :
            PaiCodigo == "108" ? 38 : PaiCodigo == "109" ? 39 : PaiCodigo == "110" ? 42 :
            PaiCodigo == "111" ? 47 : PaiCodigo == "113" ? 48 : PaiCodigo == "114" ? 55 :
            PaiCodigo == "115" ? 267 : PaiCodigo == "116" ? 71 : PaiCodigo == "117" ? 102 :
            PaiCodigo == "118" ? 75 : PaiCodigo == "119" ? 78 : PaiCodigo == "120" ? 88 :
            PaiCodigo == "121" ? 90 : PaiCodigo == "122" ? 93 : PaiCodigo == "123" ? 103 :
            PaiCodigo == "124" ? 125 : PaiCodigo == "125" ? 134 : PaiCodigo == "126" ? 135 :
            PaiCodigo == "127" ? 140 : PaiCodigo == "128" ? 141 : PaiCodigo == "129" ? 144 :
            PaiCodigo == "130" ? 148 : PaiCodigo == "132" ? 157 : PaiCodigo == "133" ? 158 :
            PaiCodigo == "134" ? 160 : PaiCodigo == "135" ? 168 : PaiCodigo == "136" ? 192 :
            PaiCodigo == "137" ? 259 : PaiCodigo == "139" ? 206 : PaiCodigo == "140" ? 209 :
            PaiCodigo == "141" ? 215 : PaiCodigo == "142" ? 223 : PaiCodigo == "143" ? 77 :
            PaiCodigo == "145" ? 234 : PaiCodigo == "147" ? 244 : PaiCodigo == "148" ? 268 :
            PaiCodigo == "149" ? 261 : PaiCodigo == "150" ? 262 : PaiCodigo == "152" ? 1 :
            PaiCodigo == "153" ? 12 : PaiCodigo == "154" ? 17 : PaiCodigo == "155" ? 19 :
            PaiCodigo == "156" ? 20 : PaiCodigo == "157" ? 28 : PaiCodigo == "158" ? 36 :
            PaiCodigo == "159" ? 281 : PaiCodigo == "160" ? 41 : PaiCodigo == "161" ? 61 :
            PaiCodigo == "162" ? 113 : PaiCodigo == "163" ? 114 : PaiCodigo == "164" ? 115 :
            PaiCodigo == "166" ? 129 : PaiCodigo == "167" ? 128 : PaiCodigo == "168" ? 130 :
            PaiCodigo == "169" ? 154 : PaiCodigo == "170" ? 162 : PaiCodigo == "171" ? 176 :
            PaiCodigo == "172" ? 222 : PaiCodigo == "173" ? 188 : PaiCodigo == "174" ? 204 :
            PaiCodigo == "175" ? 221 : PaiCodigo == "176" ? 228 : PaiCodigo == "177" ? 230 :
            PaiCodigo == "178" ? 232 : PaiCodigo == "179" ? 240 : PaiCodigo == "181" ? 251 :
            PaiCodigo == "182" ? 254 : PaiCodigo == "183" ? 260 : PaiCodigo == "185" ? 3 :
            PaiCodigo == "186" ? 6 : PaiCodigo == "187" ? 31 : PaiCodigo == "188" ? 37 :
            PaiCodigo == "189" ? 23 : PaiCodigo == "190" ? 58 : PaiCodigo == "191" ? 76 :
            PaiCodigo == "192" ? 80 : PaiCodigo == "193" ? 110 : PaiCodigo == "194" ? 111 :
            PaiCodigo == "195" ? 116 : PaiCodigo == "197" ? 138 : PaiCodigo == "198" ? 172 :
            PaiCodigo == "199" ? 145 : PaiCodigo == "200" ? 152 : PaiCodigo == "201" ? 153 :
            PaiCodigo == "202" ? 190 : PaiCodigo == "203" ? 202 : PaiCodigo == "204" ? 155 :
            PaiCodigo == "205" ? 212 : PaiCodigo == "206" ? 213 : PaiCodigo == "208" ? 214 :
            PaiCodigo == "209" ? 252 : PaiCodigo == "210" ? 82 : PaiCodigo == "211" ? 161 :
            PaiCodigo == "212" ? 146 : PaiCodigo == "213" ? 99 : PaiCodigo == "214" ? 201 :
            PaiCodigo == "215" ? 178 : PaiCodigo == "216" ? 236 : PaiCodigo == "217" ? 86 :
            PaiCodigo == "221" ? 171 : PaiCodigo == "222" ? 282 : PaiCodigo == "219" ? 85 :
            PaiCodigo == "224" ? 117 : PaiCodigo == "220" ? 143 : PaiCodigo == "225" ? 139 :
            PaiCodigo == "011" ? 169 : PaiCodigo == "028" ? 164 : PaiCodigo == "207" ? 283 :
            PaiCodigo == "218" ? 284 : PaiCodigo == "223" ? 285 : PaiCodigo == "226" ? 63 :
            PaiCodigo == "227" ? 180 : PaiCodigo == "228" ? 286 : PaiCodigo == "229" ? 143 :
            PaiCodigo == "230" ? 208 : PaiCodigo == "231" ? 64 : PaiCodigo == "232" ? 263 :
            PaiCodigo == "233" ? 60 : PaiCodigo == "234" ? 30 : PaiCodigo == "235" ? 217 :
            PaiCodigo == "236" ? 231 : PaiCodigo == "237" ? 30 : PaiCodigo == "238" ? 30 :
            PaiCodigo == "239" ? 18 : PaiCodigo == "240" ? 207 : PaiCodigo == "241" ? 155 : null;
        }

        private int? ObtenerPersoneriaLegal(string? JuCodigo)
        {
            return JuCodigo == "000" ? 376 : JuCodigo == "001" ? 280 :
            JuCodigo == "002" ? 288 : JuCodigo == "003" ? 289 : JuCodigo == "005" ? 290 :
            JuCodigo == "006" ? 291 : JuCodigo == "007" ? 292 : JuCodigo == "009" ? 294 :
            JuCodigo == "010" ? 297 : JuCodigo == "011" ? 298 : JuCodigo == "012" ? 299 :
            JuCodigo == "013" ? 302 : JuCodigo == "014" ? 301 : JuCodigo == "016" ? 305 :
            JuCodigo == "017" ? 306 : JuCodigo == "018" ? 307 : JuCodigo == "020" ? 314 :
            JuCodigo == "022" ? 310 : JuCodigo == "023" ? 322 : JuCodigo == "024" ? 329 :
            JuCodigo == "025" ? 325 : JuCodigo == "026" ? 326 : JuCodigo == "027" ? 327 :
            JuCodigo == "028" ? 328 : JuCodigo == "030" ? 342 : JuCodigo == "031" ? 343 :
            JuCodigo == "032" ? 346 : JuCodigo == "033" ? 347 : JuCodigo == "034" ? 349 :
            JuCodigo == "035" ? 350 : JuCodigo == "037" ? 352 : JuCodigo == "039" ? 353 :
            JuCodigo == "040" ? 354 : JuCodigo == "041" ? 355 : JuCodigo == "043" ? 358 :
            JuCodigo == "044" ? 360 : JuCodigo == "045" ? 362 : JuCodigo == "046" ? 364 :
            JuCodigo == "047" ? 371 : JuCodigo == "048" ? 373 : JuCodigo == "049" ? 374 :
            JuCodigo == "050" ? 377 : JuCodigo == "051" ? 381 : JuCodigo == "052" ? 382 :
            JuCodigo == "053" ? 383 : JuCodigo == "055" ? 384 : JuCodigo == "056" ? 385 :
            JuCodigo == "058" ? 391 : JuCodigo == "059" ? 396 : JuCodigo == "060" ? 397 :
            JuCodigo == "061" ? 406 : JuCodigo == "062" ? 408 : JuCodigo == "063" ? 409 :
            JuCodigo == "064" ? 411 : JuCodigo == "065" ? 414 : JuCodigo == "067" ? 286 :
            JuCodigo == "068" ? 413 : JuCodigo == "069" ? 293 : JuCodigo == "070" ? 361 :
            JuCodigo == "072" ? 339 : JuCodigo == "074" ? 304 : JuCodigo == "075" ? 300 :
            JuCodigo == "076" ? 379 : JuCodigo == "077" ? 283 : JuCodigo == "078" ? 394 :
            JuCodigo == "079" ? 285 : JuCodigo == "080" ? 407 : JuCodigo == "081" ? 336 :
            JuCodigo == "082" ? 296 : JuCodigo == "083" ? 303 : JuCodigo == "084" ? 281 :
            JuCodigo == "085" ? 395 : JuCodigo == "086" ? 405 : JuCodigo == "087" ? 393 :
            JuCodigo == "088" ? 334 : JuCodigo == "089" ? 333 : JuCodigo == "090" ? 375 :
            JuCodigo == "091" ? 388 : JuCodigo == "092" ? 311 : JuCodigo == "093" ? 351 :
            JuCodigo == "095" ? 324 : JuCodigo == "096" ? 357 : JuCodigo == "097" ? 338 :
            JuCodigo == "098" ? 282 : JuCodigo == "099" ? 378 : JuCodigo == "100" ? 348 :
            JuCodigo == "101" ? 404 : JuCodigo == "102" ? 320 : JuCodigo == "103" ? 368 :
            JuCodigo == "104" ? 380 : JuCodigo == "105" ? 369 : JuCodigo == "106" ? 359 :
            JuCodigo == "107" ? 389 : JuCodigo == "108" ? 315 : JuCodigo == "109" ? 370 :
            JuCodigo == "110" ? 392 : JuCodigo == "111" ? 284 : JuCodigo == "112" ? 366 :
            JuCodigo == "113" ? 335 : JuCodigo == "114" ? 402 : JuCodigo == "115" ? 321 :
            JuCodigo == "116" ? 416 : JuCodigo == "117" ? 417 : JuCodigo == "118" ? 337 :
            JuCodigo == "119" ? 400 : JuCodigo == "120" ? 390 : JuCodigo == "121" ? 365 :
            JuCodigo == "122" ? 367 : JuCodigo == "123" ? 403 : JuCodigo == "124" ? 345 :
            JuCodigo == "125" ? 331 : JuCodigo == "126" ? 410 : JuCodigo == "127" ? 312 :
            JuCodigo == "128" ? 363 : JuCodigo == "129" ? 412 : JuCodigo == "130" ? 317 :
            JuCodigo == "131" ? 341 : JuCodigo == "132" ? 330 : JuCodigo == "133" ? 287 :
            JuCodigo == "134" ? 344 : JuCodigo == "135" ? 279 : JuCodigo == "136" ? 313 :
            JuCodigo == "137" ? 318 : JuCodigo == "138" ? 356 : JuCodigo == "139" ? 316 :
            JuCodigo == "140" ? 323 : JuCodigo == "141" ? 401 : JuCodigo == "142" ? 399 :
            JuCodigo == "143" ? 332 : JuCodigo == "144" ? 340 : JuCodigo == "145" ? 372 :
            JuCodigo == "146" ? 387 : JuCodigo == "147" ? 309 : JuCodigo == "148" ? 415 :
            JuCodigo == "149" ? 319 : JuCodigo == "150" ? 295 : JuCodigo == "151" ? 398 :
            JuCodigo == "152" ? 308 : JuCodigo == "153" ? 386 : null;
        }

        private string ObtenerCalidad(string? CalCodigo)
        {
            return CalCodigo == "1" ? "A" : CalCodigo == "2" ? "A" : CalCodigo == "3" ? "B" :
            CalCodigo == "4" ? "B" : CalCodigo == "5" ? "C" : CalCodigo == "6" ? "C" :
            CalCodigo == "7" ? "D" : "";
        }

        private int ObtenerReputacion(string RcCodigo)
        {
            return RcCodigo == "EAD" ? 1 : RcCodigo == "ECC" ? 25 : RcCodigo == "EDJ" ? 33 :
                    RcCodigo == "EJA" ? 34 : RcCodigo == "ELQ" ? 39 : RcCodigo == "EMO" ? 42 :
                    RcCodigo == "ENC" ? 4 : RcCodigo == "ERC" ? 49 : RcCodigo == "EXX" ? 2 :
                    RcCodigo == "PA1" ? 20 : RcCodigo == "PCC" ? 10 : RcCodigo == "PDJ" ? 11 :
                    RcCodigo == "PEF" ? 12 : RcCodigo == "PRE" ? 13 : RcCodigo == "PEX" ? 14 :
                    RcCodigo == "PQL" ? 24 : RcCodigo == "PIT" ? 26 : RcCodigo == "PNC" ? 17 :
                    RcCodigo == "PNN" ? 18 : RcCodigo == "PTC" ? 19 : RcCodigo == "PVC" ? 22 :
                    RcCodigo == "PBC" ? 21 : RcCodigo == "PNX" ? 29 : RcCodigo == "EBC" ? 6 :
                    RcCodigo == "ERN" ? 58 : RcCodigo == "PXX" ? 15 : RcCodigo == "ENR" ? 9 :
                    RcCodigo == "ELD" ? 37 : RcCodigo == "PLB" ? 16 : RcCodigo == "EDI" ? 3 :
                    RcCodigo == "PRP" ? 31 : RcCodigo == "EAE" ? 32 : RcCodigo == "EMR" ? 87 :
                    RcCodigo == "ETF" ? 23 : RcCodigo == "PMR" ? 46 : RcCodigo == "PTF" ? 47 :
                    RcCodigo == "ELC" ? 8 : RcCodigo == "PLC" ? 38 : RcCodigo == "ETR" ? 88 :
                    RcCodigo == "PTR" ? 55 : RcCodigo == "PVP" ? 63 : RcCodigo == "PAS" ? 64 :
                    RcCodigo == "PBS" ? 65 : RcCodigo == "PCS" ? 66 : RcCodigo == "PDS" ? 70 :
                    RcCodigo == "PSS" ? 71 : RcCodigo == "PRD" ? 48 : RcCodigo == "EAA" ? 7 :
                    RcCodigo == "PSC" ? 50 : RcCodigo == "PBR" ? 51 : RcCodigo == "PIA" ? 52 :
                    RcCodigo == "PDC" ? 53 : RcCodigo == "PDM" ? 54 : RcCodigo == "PRM" ? 35 :
                    RcCodigo == "PHE" ? 56 : RcCodigo == "PCP" ? 57 : RcCodigo == "ERD" ? 28 :
                    RcCodigo == "ENT" ? 27 : RcCodigo == "ERF" ? 30 : RcCodigo == "EBM" ? 5 :
                    RcCodigo == "EMN" ? 59 : RcCodigo == "PCT" ? 36 : RcCodigo == "PMC" ? 40 :
                    RcCodigo == "PCV" ? 41 : RcCodigo == "PGA" ? 43 : RcCodigo == "EMP" ? 60 :
                    RcCodigo == "EMB" ? 61 : RcCodigo == "ENX" ? 62 : RcCodigo == "PIR" ? 44 :
                    RcCodigo == "PDF" ? 45 : RcCodigo == "PDZ" ? 72 : RcCodigo == "PPJ" ? 73 :
                    RcCodigo == "PMZ" ? 74 : RcCodigo == "PRS" ? 75 : RcCodigo == "ESC" ? 67 :
                    RcCodigo == "ESO" ? 68 : RcCodigo == "ECP" ? 69 : RcCodigo == "ECN" ? 76 :
                    RcCodigo == "EQC" ? 77 : RcCodigo == "EQD" ? 78 : RcCodigo == "EQO" ? 79 :
                    RcCodigo == "EAR" ? 80 : RcCodigo == "EFS" ? 81 : RcCodigo == "ETP" ? 82 :
                    RcCodigo == "ETC" ? 83 : RcCodigo == "EAQ" ? 84 : RcCodigo == "ETO" ? 85 :
                    RcCodigo == "EDF" ? 86 : 0;
        }

        public async Task<bool> MigratePerson()
        {
            for (int i = 0; i < 460; i++)
            {
                using var contextSql = new SqlCoreContext();
                using var contextMysql = new MySqlContext();
                using var contextPhoto = new FotoContext();
                var personas = await contextMysql.MPersonas.Where(x => x.Migra == 0 && x.PeActivo == 1).Take(1000).ToListAsync();
                foreach (var persona in personas)
                {
                    int idPerson = 0;
                    bool success = false;
                    var reputacion = await _impersonaDomain.GetmPersonaReputacionByCodigoAsync(persona.PeCodigo);
                    int idReputacion = 0;
                    if (reputacion != null)
                    {
                        idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                    }
                    var existingPerson = await contextSql.People.Where(x => x.OldCode == persona.PeCodigo).FirstOrDefaultAsync();
                    try
                    {
                        var existinggPerson = new Person
                        {
                            OldCode = persona.PeCodigo,
                            Fullname = persona.PeNombre == null ? "" : persona.PeNombre,
                            LastSearched = persona.PeFecinf,
                            Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value],
                            Quality = ObtenerCalidad(persona.CalCodigoPer),
                            Nationality = persona.PeNacion == null ? "" : persona.PeNacion,
                            BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac,
                            BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac,
                            IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                                 persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                                 persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                                 persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                                 persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                                 persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                                 persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                                 persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                                 persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null,
                            CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide,
                            TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri,
                            IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                                 persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                                 persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                                 persona.EsCodigo == "07" ? 6 : null,
                            IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                 persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                 persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                 persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null,
                            Address = persona.PeDirecc == null ? "" : persona.PeDirecc,
                            Cp = persona.PeCodpos == null ? "" : persona.PeCodpos,
                            City = persona.PeCiudad == null ? "" : persona.PeCiudad,
                            OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome,
                            TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome,
                            IdCountry = ObtenerCodigoPais(persona.PaiCodigo),
                            CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf,
                            NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo,
                            IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                                 persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                                 persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null,
                            RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv,
                            RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null,
                            RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni,
                            FatherName = persona.PePadre == null ? "" : persona.PePadre,
                            MotherName = persona.PeMadre == null ? "" : persona.PeMadre,
                            Email = persona.PeEmail == null ? "" : persona.PeEmail,
                            Cellphone = persona.PeCelula == null ? "" : persona.PeCelula,
                            ClubMember = persona.PeClub == null ? "" : persona.PeClub,
                            Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur,
                            NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel,
                            PrintNewsCommentary = persona.PeLogpre == 1 ? true : false,
                            PrivateCommentary = persona.PeCompri == null ? "" : persona.PeCompri,
                            ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep,
                            IdCreditRisk = GetCreditRisk(persona.CrCodigo),
                            IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo),
                            IdReputation = idReputacion != 0 ? idReputacion : null,
                            Profession = persona.PfNombre == null ? "" : persona.PfNombre,
                            PersonActivities = await GetPersonActivities(persona),
                            PersonGeneralInformations = await GetPersonGeneralInformation(persona),
                            PersonHistories = await GetPersonHistory(persona),
                            PersonHomes = await GetPersonHome(persona),
                            PersonProperties = await GetPersonProperty(persona),
                            PersonSbs = await GetPersonSBS(persona),
                            PersonJobs = await GetPersonJob(persona),
                            PhotoPeople = await GetPersonPhoto(persona),
                            BankDebts = await GetPersonBankDebt(persona),
                            ComercialLatePayments = await GetPersonCommercialLate(persona),
                            Providers = await GetPersonProviders(persona),
                        };
                        if (existingPerson != null)
                        {/*
                            existingPerson.OldCode = persona.PeCodigo;
                            existingPerson.Fullname = persona.PeNombre == null ? "" : persona.PeNombre;
                            existingPerson.LastSearched = persona.PeFecinf;
                            existingPerson.Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value];
                            existingPerson.Nationality = persona.PeNacion == null ? "" : persona.PeNacion;
                            existingPerson.BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac;
                            existingPerson.BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac;
                            existingPerson.Quality = ObtenerCalidad(persona.CalCodigoPer);
                            existingPerson.IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                             persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                             persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                             persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                             persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                             persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                             persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                             persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                             persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null;
                            existingPerson.CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide;
                            existingPerson.TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri;
                            existingPerson.IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                             persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                             persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                             persona.EsCodigo == "07" ? 6 : null;
                            existingPerson.IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                 persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                 persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                 persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null;
                            existingPerson.Address = persona.PeDirecc == null ? "" : persona.PeDirecc;
                            existingPerson.Cp = persona.PeCodpos == null ? "" : persona.PeCodpos;
                            existingPerson.City = persona.PeCiudad == null ? "" : persona.PeCiudad;
                            existingPerson.OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome;
                            existingPerson.TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome;
                            existingPerson.IdCountry = ObtenerCodigoPais(persona.PaiCodigo);
                            existingPerson.CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf;
                            existingPerson.NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo;
                            existingPerson.IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                             persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                             persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null;
                            existingPerson.RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv;
                            existingPerson.RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null;
                            existingPerson.RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni;
                            existingPerson.FatherName = persona.PePadre == null ? "" : persona.PePadre;
                            existingPerson.MotherName = persona.PeMadre == null ? "" : persona.PeMadre;
                            existingPerson.Email = persona.PeEmail == null ? "" : persona.PeEmail;
                            existingPerson.Cellphone = persona.PeCelula == null ? "" : persona.PeCelula;
                            existingPerson.ClubMember = persona.PeClub == null ? "" : persona.PeClub;
                            existingPerson.Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur;
                            existingPerson.NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel;
                            existingPerson.PrintNewsCommentary = persona.PeLogpre == 1 ? true : false;
                            existingPerson.ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep;
                            existingPerson.IdCreditRisk = GetCreditRisk(persona.CrCodigo);
                            existingPerson.IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo);
                            existingPerson.IdReputation = idReputacion != 0 ? idReputacion : null;
                            existingPerson.Profession = persona.PfNombre == null ? "" : persona.PfNombre;
                            existingPerson.PersonActivities = await GetPersonActivities(persona);
                            existingPerson.PersonGeneralInformations = await GetPersonGeneralInformation(persona);
                            existingPerson.PersonHistories = await GetPersonHistory(persona);
                            existingPerson.PersonHomes = await GetPersonHome(persona);
                            existingPerson.PersonProperties = await GetPersonProperty(persona);
                            existingPerson.PersonSbs = await GetPersonSBS(persona);
                            existingPerson.PersonJobs = await GetPersonJob(persona);
                            existingPerson.PhotoPeople = await GetPersonPhoto(persona);
                            existingPerson.Traductions = await GetPersonTraductions(existingPerson.Id, persona);
                            existingPerson.BankDebts = await GetPersonBankDebt(persona);
                            existingPerson.ComercialLatePayments = await GetPersonCommercialLate(persona);
                            existingPerson.Providers = await GetPersonProviders(persona);
                        */
                            try
                            {
                                await _personDomain.UpdateAsync(existinggPerson);
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                continue;
                            }
                        }
                        else
                        {
                            var newPerson = new Person
                            {
                                OldCode = persona.PeCodigo,
                                Fullname = persona.PeNombre == null ? "" : persona.PeNombre,
                                LastSearched = persona.PeFecinf,
                                Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value],
                                Quality = ObtenerCalidad(persona.CalCodigoPer),
                                Nationality = persona.PeNacion == null ? "" : persona.PeNacion,
                                BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac,
                                BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac,
                                IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                                 persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                                 persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                                 persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                                 persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                                 persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                                 persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                                 persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                                 persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null,
                                CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide,
                                TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri,
                                IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                                 persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                                 persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                                 persona.EsCodigo == "07" ? 6 : null,
                                IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                 persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                 persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                 persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null,
                                Address = persona.PeDirecc == null ? "" : persona.PeDirecc,
                                Cp = persona.PeCodpos == null ? "" : persona.PeCodpos,
                                City = persona.PeCiudad == null ? "" : persona.PeCiudad,
                                OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome,
                                TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome,
                                IdCountry = ObtenerCodigoPais(persona.PaiCodigo),
                                CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf,
                                NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo,
                                IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                                 persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                                 persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null,
                                RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv,
                                RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null,
                                RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni,
                                FatherName = persona.PePadre == null ? "" : persona.PePadre,
                                MotherName = persona.PeMadre == null ? "" : persona.PeMadre,
                                Email = persona.PeEmail == null ? "" : persona.PeEmail,
                                Cellphone = persona.PeCelula == null ? "" : persona.PeCelula,
                                ClubMember = persona.PeClub == null ? "" : persona.PeClub,
                                Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur,
                                NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel,
                                PrintNewsCommentary = persona.PeLogpre == 1 ? true : false,
                                PrivateCommentary = persona.PeCompri == null ? "" : persona.PeCompri,
                                ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep,
                                IdCreditRisk = GetCreditRisk(persona.CrCodigo),
                                IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo),
                                IdReputation = idReputacion != 0 ? idReputacion : null,
                                Profession = persona.PfNombre == null ? "" : persona.PfNombre,
                                PersonActivities = await GetPersonActivities(persona),
                                PersonGeneralInformations = await GetPersonGeneralInformation(persona),
                                PersonHistories = await GetPersonHistory(persona),
                                PersonHomes = await GetPersonHome(persona),
                                PersonProperties = await GetPersonProperty(persona),
                                PersonSbs = await GetPersonSBS(persona),
                                PersonJobs = await GetPersonJob(persona),
                                PhotoPeople = await GetPersonPhoto(persona),
                                BankDebts = await GetPersonBankDebt(persona),
                                ComercialLatePayments = await GetPersonCommercialLate(persona),
                                Providers = await GetPersonProviders(persona),
                            };

                            try
                            {
                                idPerson = await _personDomain.AddPersonAsync(newPerson);

                                var pers = await _personDomain.GetByIdAsync(idPerson);
                                if (pers != null)
                                {

                                    pers.TraductionPeople = await GetPersonTraductions(persona);
                                    await _personDomain.UpdateAsync(pers);
                                    success = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                continue;
                            }

                        }
                        if (success == true)
                        {
                            persona.Migra = 1;
                            contextMysql.MPersonas.Update(persona);
                            await contextMysql.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error Persona :" + persona.PeCodigo + " : " + ex.Message);
                        success = false;
                        continue;
                    }
                }
            }

            return true;
        }
        public async Task<bool> MigratePersonByMigra(int migra)
        {
            for (int i = 0; i < 600; i++)
            {
                using var contextSql = new SqlCoreContext();
                using var contextMysql = new MySqlContext();
                using var contextPhoto = new FotoContext();
                var personas = await contextMysql.MPersonas.Where(x => x.Migra == migra && x.PeActivo == 1).Take(100).ToListAsync();
                foreach (var persona in personas)
                {
                    var reputacion = await _impersonaDomain.GetmPersonaReputacionByCodigoAsync(persona.PeCodigo);
                    int idReputacion = 0;
                    if (reputacion != null)
                    {
                        idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                    }
                    try
                    {
                        var newPerson = new Person
                        {
                            Id = 0,
                            OldCode = persona.PeCodigo,
                            Fullname = persona.PeNombre ?? "",
                            LastSearched = persona.PeFecinf,
                            Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value],
                            Quality = ObtenerCalidad(persona.CalCodigoPer),
                            Nationality = persona.PeNacion ?? "",
                            BirthDate = persona.PeFecnac ?? "",
                            BirthPlace = persona.PeLugnac ?? "",
                            IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                                     persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                                     persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                                     persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                                     persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                                     persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                                     persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                                     persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                                     persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null,
                            CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide,
                            TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri,
                            IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                                     persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                                     persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                                     persona.EsCodigo == "07" ? 6 : null,
                            IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                     persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                     persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                     persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null,
                            Address = persona.PeDirecc == null ? "" : persona.PeDirecc,
                            Cp = persona.PeCodpos == null ? "" : persona.PeCodpos,
                            City = persona.PeCiudad == null ? "" : persona.PeCiudad,
                            OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome,
                            TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome,
                            IdCountry = ObtenerCodigoPais(persona.PaiCodigo),
                            CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf,
                            NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo,
                            IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                                     persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                                     persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null,
                            RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv,
                            RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null,
                            RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni,
                            FatherName = persona.PePadre == null ? "" : persona.PePadre,
                            MotherName = persona.PeMadre == null ? "" : persona.PeMadre,
                            Email = persona.PeEmail == null ? "" : persona.PeEmail,
                            Cellphone = persona.PeCelula == null ? "" : persona.PeCelula,
                            ClubMember = persona.PeClub == null ? "" : persona.PeClub,
                            Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur,
                            NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel,
                            PrintNewsCommentary = persona.PeLogpre == 1 ? true : false,
                            PrivateCommentary = persona.PeCompri == null ? "" : persona.PeCompri,
                            ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep,
                            IdCreditRisk = GetCreditRisk(persona.CrCodigo),
                            IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo),
                            IdReputation = idReputacion != 0 ? idReputacion : null,
                            Profession = persona.PfNombre == null ? "" : persona.PfNombre,
                            PersonActivities = await GetPersonActivities(persona),
                            PersonGeneralInformations = await GetPersonGeneralInformation(persona),
                            PersonHistories = await GetPersonHistory(persona),
                            PersonHomes = await GetPersonHome(persona),
                            PersonProperties = await GetPersonProperty(persona),
                            PersonSbs = await GetPersonSBS(persona),
                            PersonJobs = await GetPersonJob(persona),
                            PhotoPeople = await GetPersonPhoto(persona),
                            BankDebts = await GetPersonBankDebt(persona),
                            ComercialLatePayments = await GetPersonCommercialLate(persona),
                            Providers = await GetPersonProviders(persona),
                            TraductionPeople = await GetPersonTraductions(persona)
                        };
                        await contextSql.People.AddAsync(newPerson);
                        await contextSql.SaveChangesAsync();
                        persona.Migra = 1;
                        contextMysql.MPersonas.Update(persona);
                        await contextMysql.SaveChangesAsync();


                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message.ToString());
                        continue;
                    }
                }
            }

            return true;
        }
        private async Task<List<PersonActivity>> GetPersonActivities(MPersona persona)
        {
            var lista = new List<PersonActivity>();
            try
            {
                if (persona != null)
                {
                    var activity = new PersonActivity
                    {
                        ActivitiesCommentary = persona.PeOtrrec ?? ""
                    };
                    lista.Add(activity);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Activity:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PersonGeneralInformation>> GetPersonGeneralInformation(MPersona persona)
        {
            var lista = new List<PersonGeneralInformation>();
            try
            {
                if (persona != null)
                {
                    var generalInformation = new PersonGeneralInformation
                    {
                        GeneralInformation = persona.PeObserv ?? ""
                    };
                    lista.Add(generalInformation);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person General Information:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PersonHistory>> GetPersonHistory(MPersona persona)
        {
            var lista = new List<PersonHistory>();
            try
            {
                if (persona != null)
                {
                    var history = new PersonHistory
                    {
                        HistoryCommentary = persona.PeAntece == null ? "" : persona.PeAntece
                    };
                    lista.Add(history);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person History:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PersonHome>> GetPersonHome(MPersona persona)
        {
            var lista = new List<PersonHome>();
            try
            {
                if (persona != null)
                {
                    var home = new PersonHome
                    {
                        OwnHome = persona.PeTipdom == null || persona.PeTipdom == "" ? null : persona.PeTipdom == "Si" || persona.PeTipdom == "Propia" ? true : false,
                        Value = persona.PeValdom == null ? "" : persona.PeValdom,
                        HomeCommentary = persona.PeCondoc == null ? "" : persona.PeCondoc,
                    };
                    lista.Add(home);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Home:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PersonProperty>> GetPersonProperty(MPersona persona)
        {
            var lista = new List<PersonProperty>();
            try
            {
                if (persona != null)
                {
                    var properties = new PersonProperty
                    {
                        PropertiesCommentary = persona.PeCombie == null ? "" : persona.PeCombie,
                    };
                    lista.Add(properties);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Properties:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PersonSb>> GetPersonSBS(MPersona persona)
        {
            var lista = new List<PersonSb>();
            try
            {
                if (persona != null)
                {
                    var sbs = new PersonSb
                    {
                        AditionalCommentaryRiskCenter = persona.PeCenrie == null ? "" : persona.PeCenrie,
                        DebtRecordedDate = persona.PeFecreg == null ? "" : persona.PeFecreg,
                        ExchangeRate = persona.PeTcsbs == null ? 0 : (decimal)persona.PeTcsbs,
                        BankingCommentary = persona.PeSubacu == null ? "" : persona.PeSubacu,
                        ReferentOrAnalyst = persona.PerCodref == null ? "" : persona.PerCodref,
                        Date = StaticFunctions.VerifyDate(persona.PeFecref),
                        LitigationsCommentary = persona.PeComlit == null ? "" : persona.PeComlit,
                        CreditHistoryCommentary = persona.PeAntcred == null ? "" : persona.PeAntcred,
                        GuaranteesOfferedNc = persona.PeGaomn == null ? 0 : (decimal)persona.PeGaomn,
                        GuaranteesOfferedFc = persona.PeGaome == null ? 0 : (decimal)persona.PeGaome,
                        SbsCommentary = persona.PeSupban == null ? "" : persona.PeSupban
                    };
                    lista.Add(sbs);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Sbs:" + persona.PeCodigo);
                return lista;
            }
        }
        private async Task<List<PhotoPerson>> GetPersonPhoto(MPersona persona)
        {
            var lista = new List<PhotoPerson>();
            try
            {
                using var context = new FotoContext();
                var images = await context.RPerVsFotos.Where(x => x.PeCodigo == persona.PeCodigo).FirstOrDefaultAsync();
                if (images != null)
                {
                    if (images.PfFoto != null)
                    {
                        string base64String1 = Convert.ToBase64String(images.PfFoto);
                        var photo1 = new PhotoPerson
                        {
                            NumImg = 1,
                            Base64 = base64String1 == null ? "" : base64String1,
                            Description = images.PfFotoTxt == null ? "" : images.PfFotoTxt,
                            DescriptionEng = images.PfFotoTxtIng == null ? "" : images.PfFotoTxtIng,
                            PrintImg = images.PfImprimir == "1" ? true : false
                        };
                        lista.Add(photo1);
                    }
                    if (images.PfFoto2 != null)
                    {
                        string base64String2 = Convert.ToBase64String(images.PfFoto2);
                        var photo2 = new PhotoPerson
                        {
                            NumImg = 2,
                            Base64 = base64String2 == null ? "" : base64String2,
                            Description = images.PfFoto2Txt == null ? "" : images.PfFoto2Txt,
                            DescriptionEng = images.PfFoto2TxtIng == null ? "" : images.PfFoto2TxtIng,
                            PrintImg = images.PfImprimir == "1" ? true : false
                        };
                        lista.Add(photo2);
                    }
                    if (images.PfFoto3 != null)
                    {
                        string base64String3 = Convert.ToBase64String(images.PfFoto3);
                        var photo3 = new PhotoPerson
                        {
                            NumImg = 3,
                            Base64 = base64String3 == null ? "" : base64String3,
                            Description = images.PfFoto3Txt == null ? "" : images.PfFoto3Txt,
                            DescriptionEng = images.PfFoto3TxtIng == null ? "" : images.PfFoto3TxtIng,
                            PrintImg = images.PfImprimir == "1" ? true : false
                        };
                        lista.Add(photo3);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Photo:" + persona.PeCodigo);
                return new List<PhotoPerson>();
            }
        }
        private async Task<List<PersonJob>> GetPersonJob(MPersona persona)
        {
            var lista = new List<PersonJob>();
            try
            {
                using var context = new MySqlContext();
                var trabajo = await context.RPerVsTrabs.Where(x => x.PeCodigo == persona.PeCodigo).FirstOrDefaultAsync();
                if (trabajo != null)
                {
                    var job = new PersonJob
                    {
                        IdCompany = null,
                        OldCode = trabajo.EmCodigo == null ? "" : trabajo.EmCodigo,
                        CurrentJob = trabajo.CaNombre,
                        StartDate = trabajo.PtFecing,
                        EndDate = trabajo.PtFecces,
                        MonthlyIncome = trabajo.PtEstadi + "",
                        AnnualIncome = trabajo.PtInganu,
                        JobDetails = trabajo.PtDetall
                    };
                    lista.Add(job);
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person Job:" + persona.PeCodigo);
                return new List<PersonJob>();
            }
        }
        private async Task<List<BankDebt>> GetPersonBankDebt(MPersona persona)
        {
            var lista = new List<BankDebt>();
            try
            {
                using var context = new MySqlContext();
                var deudas = await context.RPerVsSbds.Where(x => x.PeCodigo == persona.PeCodigo).ToListAsync();
                if (deudas.Count > 0)
                {
                    foreach (var deuda in deudas)
                    {
                        var debt = new BankDebt
                        {
                            IdCompany = null,
                            BankName = deuda.SbdNombre == null ? "" : deuda.SbdNombre,
                            Qualification = deuda.SbdCalifi == null ? "" : deuda.SbdCalifi,
                            QualificationEng = deuda.SbdCalifiIng == null ? "" : deuda.SbdCalifiIng,
                            DebtNc = deuda.SbdMonmn == null ? 0 : (decimal)deuda.SbdMonmn,
                            DebtFc = deuda.SbdMonme == null ? 0 : (decimal)deuda.SbdMonme,
                        };
                        lista.Add(debt);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person BankDebt:" + persona.PeCodigo);
                return new List<BankDebt>();
            }
        }
        private async Task<List<ComercialLatePayment>> GetPersonCommercialLate(MPersona persona)
        {
            var lista = new List<ComercialLatePayment>();
            try
            {
                using var context = new MySqlContext();
                var morosidades = await context.RPerVsProAceps.Where(x => x.PeCodigo == persona.PeCodigo).ToListAsync();
                if (morosidades.Count > 0)
                {
                    foreach (var morosidad in morosidades)
                    {
                        var comLate = new ComercialLatePayment
                        {
                            IdCompany = null,
                            CreditorOrSupplier = morosidad.PaGirador == null ? "" : morosidad.PaGirador,
                            DocumentType = morosidad.PaTitulo == null ? "" : morosidad.PaTitulo,
                            DocumentTypeEng = morosidad.PaTituloIng == null ? "" : morosidad.PaTituloIng,
                            Date = morosidad.PaFecpro == null ? "" : morosidad.PaFecpro,
                            AmountNc = morosidad.PaMonmn == null ? 0 : (decimal)morosidad.PaMonmn,
                            AmountFc = morosidad.PaMonme == null ? 0 : (decimal)morosidad.PaMonme,
                            PendingPaymentDate = morosidad.PaFecreg == null ? "" : morosidad.PaFecreg,
                            DaysLate = 0,
                        };
                        lista.Add(comLate);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person CommercialLatePayment:" + persona.PeCodigo);
                return new List<ComercialLatePayment>();
            }
        }
        private async Task<List<Provider>> GetPersonProviders(MPersona persona)
        {
            var lista = new List<Provider>();
            try
            {
                using var context = new MySqlContext();
                var proveedores = await context.RPerVsProvs.Where(x => x.PeCodigo == persona.PeCodigo).ToListAsync();
                if (proveedores.Count > 0)
                {
                    foreach (var proveedor in proveedores)
                    {
                        var provider = new Provider
                        {
                            IdCompany = null,
                            IdCountry = ObtenerCodigoPais(proveedor.PaiCodigo),
                            Name = proveedor.ProvNombre == null ? "" : proveedor.ProvNombre,
                            Qualification = proveedor.CumCodigo == "02" ? "Puntual" : proveedor.CumCodigo == "03" ? "Lento Eventual" :
                                     proveedor.CumCodigo == "04" ? "Lento Siempre" : proveedor.CumCodigo == "05" ? "Moroso" :
                                      proveedor.CumCodigo == "06" ? "Sin Experiencia" : proveedor.CumCodigo == "01" ? "" : null,
                            QualificationEng = proveedor.CumCodigo == "02" ? "Prompt" : proveedor.CumCodigo == "03" ? "Sometimes delayed" :
                                     proveedor.CumCodigo == "04" ? "Always delayed" : proveedor.CumCodigo == "05" ? "Delinquent" :
                                      proveedor.CumCodigo == "06" ? "No experience" : proveedor.CumCodigo == "01" ? "" : null,
                            Date = proveedor.ProvFecha.Value.Year > 1754 ? proveedor.ProvFecha : null,
                            Telephone = proveedor.ProvTelefo == null ? "" : proveedor.ProvTelefo,
                            AttendedBy = proveedor.ProvAtendio == null ? "" : proveedor.ProvAtendio,
                            IdCurrency = proveedor.ProvMnLiCr == "US$" ? 1 : proveedor.ProvMnLiCr == "MN" ? 31 : proveedor.ProvMnLiCr == "EUR" ? 2 : null,
                            MaximumAmount = proveedor.ProvLinCre == null ? "" : proveedor.ProvLinCre,
                            MaximumAmountEng = proveedor.ProvLinCreIng == null ? "" : proveedor.ProvLinCreIng,
                            TimeLimit = proveedor.ProvPlazos == null ? "" : proveedor.ProvPlazos,
                            TimeLimitEng = proveedor.ProvPlazosIng == null ? "" : proveedor.ProvPlazosIng,
                            Compliance = proveedor.ProvCumple == null ? "" : proveedor.ProvCumple,
                            ClientSince = proveedor.ProvTiempo == null ? "" : proveedor.ProvTiempo,
                            ClientSinceEng = proveedor.ProvTiempoIng == null ? "" : proveedor.ProvTiempoIng,
                            ProductsTheySell = proveedor.ProvVenden == null ? "" : proveedor.ProvVenden,
                            ProductsTheySellEng = proveedor.ProvVendenIng == null ? "" : proveedor.ProvVendenIng,
                            AdditionalCommentary = proveedor.ProvComen == null ? "" : proveedor.ProvComen,
                            AdditionalCommentaryEng = proveedor.ProvComenIng == null ? "" : proveedor.ProvComenIng,
                            ReferentCommentary = proveedor.ProvTexto == null ? "" : proveedor.ProvTexto,
                        };
                        lista.Add(provider);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Person CommercialLatePayment:" + persona.PeCodigo);
                return new List<Provider>();
            }
        }

        private async Task<List<TraductionPerson>> GetPersonTraductions(MPersona persona)
        {
            List<TraductionPerson> traductions = new List<TraductionPerson>();
            using var context = new SqlCoreContext();
            using var mysqlcontext = new MySqlContext();

            var trabajo = await mysqlcontext.RPerVsTrabs.Where(x => x.PeCodigo == persona.PeCodigo).FirstOrDefaultAsync();
            traductions.Add(new TraductionPerson
            {
                TPnacionality = persona.PeNacionIng ?? "",
                TPbirthPlace = persona.PeFecnacIng ?? "",
                TPmarriedTo = persona.PeRelcivIng ?? "",
                TPprofession = persona.PfNombreIng ?? "",
                TPnewcomm = persona.PePrensaselIng ?? "",
                TPreputation = persona.PeComRepIng ?? "",
                TAotherAct = persona.PeOtrRecIng ?? "",
                TIgdetails = persona.PeObservIng ?? "",
                THdetails = persona.PeAnteceIng ?? "",
                TDvalue = persona.PeValdomIng ?? "",
                TDresidence = persona.PeCondocIng ?? "",
                TPrdetails = persona.PeCombieIng ?? "",
                TSbsantecedente = persona.PeAntcredIng ?? "",
                TSbsrickCnt = persona.PeCenRieIng ?? "",
                TSbscommentBank = persona.PeSubacuIng ?? "",
                TSbscommentSbs = persona.PeSupbanIng ?? "",
                TSbslitig = persona.PeComlitIng ?? "",
                TCcurjob = trabajo?.CaNombreIng ?? "",
                TCstartDate = trabajo?.PtFecingIng ?? "",
                TCenddt = trabajo?.PtFeccesIng ?? "",
                TCincome = trabajo?.PtInganuIng ?? "",
                TCdetails = trabajo?.PtDetallIng ?? "",
            });

            //foreach (var item in Constants.TRADUCTIONS_FORMS_PERSON)
            //{
            //    string? shortValue = null;
            //    string? largeValue = null;
            //    //Person
            //    if (item == "S_P_NACIONALITY")
            //    {
            //        shortValue = persona.PeNacionIng == null ? "" : persona.PeNacionIng;
            //    }
            //    else if (item == "S_P_BIRTHDATE")
            //    {
            //        shortValue = persona.PeFecnacIng == null ? "" : persona.PeFecnacIng;
            //    }
            //    else if (item == "S_P_MARRIEDTO")
            //    {
            //        shortValue = persona.PeRelcivIng == null ? "" : persona.PeRelcivIng;
            //    }
            //    else if (item == "S_P_PROFESSION")
            //    {
            //        shortValue = persona.PfNombreIng == null ? "" : persona.PfNombreIng;
            //    }
            //    else if (item == "L_P_NEWSCOMM")
            //    {
            //        largeValue = persona.PePrensaselIng == null ? "" : persona.PePrensaselIng;
            //    }
            //    else if (item == "L_P_REPUTATION")
            //    {
            //        largeValue = persona.PeComRepIng == null ? "" : persona.PeComRepIng;
            //    }
            //    //Person Activities
            //    else if (item == "L_A_OTHERACT")
            //    {
            //        largeValue = persona.PeOtrRecIng == null ? "" : persona.PeOtrRecIng;
            //    }
            //    //Person General Information
            //    else if (item == "L_IG_DETAILS")
            //    {
            //        largeValue = persona.PeObservIng == null ? "" : persona.PeObservIng;
            //    }
            //    //Person History
            //    else if (item == "L_H_DETAILS")
            //    {
            //        largeValue = persona.PeAnteceIng == null ? "" : persona.PeAnteceIng;
            //    }
            //    //Person Home
            //    else if (item == "S_D_VALUE")
            //    {
            //        shortValue = persona.PeValdomIng == null ? "" : persona.PeValdomIng;
            //    }
            //    else if (item == "L_D_RESIDENCE")
            //    {
            //        largeValue = persona.PeCondocIng == null ? "" : persona.PeCondocIng;
            //    }
            //    //Person Properties
            //    else if (item == "L_PR_DETAILS")
            //    {
            //        largeValue = persona.PeCombieIng == null ? "" : persona.PeCombieIng;
            //    }
            //    //Person Sbs
            //    else if (item == "L_SBS_ANTEC")
            //    {
            //        largeValue = persona.PeAntcredIng == null ? "" : persona.PeAntcredIng;
            //    }
            //    else if (item == "L_SBS_RISKCNT")
            //    {
            //        largeValue = persona.PeCenRieIng == null ? "" : persona.PeCenRieIng;
            //    }
            //    else if (item == "L_SBS_COMMENTSBS")
            //    {
            //        largeValue = persona.PeSupbanIng == null ? "" : persona.PeSupbanIng;
            //    }
            //    else if (item == "L_SBS_COMMENTBANK")
            //    {
            //        largeValue = persona.PeSubacuIng == null ? "" : persona.PeSubacuIng;
            //    }
            //    else if (item == "L_SBS_LITIG")
            //    {
            //        largeValue = persona.PeComlitIng == null ? "" : persona.PeComlitIng;
            //    }
            //    //Person Job
            //    var trabajo = await mysqlcontext.RPerVsTrabs.Where(x => x.PeCodigo == persona.PeCodigo).FirstOrDefaultAsync();
            //    if (trabajo != null)
            //    {
            //        if (item == "S_C_CURJOB")
            //        {
            //            shortValue = trabajo.CaNombreIng == null ? "" : trabajo.CaNombreIng;
            //        }
            //        else if (item == "S_C_STARTDT")
            //        {
            //            shortValue = trabajo.PtFecingIng == null ? "" : trabajo.PtFecingIng;
            //        }
            //        else if (item == "S_C_ENDDT")
            //        {
            //            shortValue = trabajo.PtFeccesIng == null ? "" : trabajo.PtFeccesIng;
            //        }
            //        else if (item == "S_C_INCOME")
            //        {
            //            shortValue = trabajo.PtInganuIng == null ? "" : trabajo.PtInganuIng;
            //        }
            //        else if (item == "L_C_DETAILS")
            //        {
            //            largeValue = trabajo.PtDetallIng == null ? "" : trabajo.PtDetallIng;
            //        }
            //    }
            //    traductions.Add(new Traduction
            //    {
            //        IdPerson = null,
            //        Identifier = item,
            //        IdLanguage = 1,
            //        LastUpdaterUser = 1,
            //        ShortValue = shortValue,
            //        LargeValue = largeValue,
            //        CreationDate = DateTime.Now
            //    });
            //}
            return traductions;
        }
        public async Task<bool> MigrateSubscriber()
        {
            try
            {
                var mysqlContext = new MySqlContext();
                var sqlContext = new SqlCoreContext();
                var subscriberCategory = await sqlContext.SubscriberCategories.ToListAsync();
                var abonados = await mysqlContext.MAbonados.Where(x => x.Migra == 0).ToListAsync();
                foreach (var item in abonados)
                {
                    var success = false;
                    var newSubscriber = new Subscriber
                    {
                        Code = item.AboCodigo,
                        Name = item.AboNombre == null ? "" : item.AboNombre,
                        Acronym = item.AboSiglas == null ? "" : item.AboSiglas,
                        StartDate = ConvertStringToDateTime(item.AboFeccre.Substring(0, Math.Min(item.AboFeccre.Length, 10))),
                        Address = item.AboDirecc == null ? "" : item.AboDirecc,
                        City = item.AboCiudad == null ? "" : item.AboCiudad,
                        Telephone = item.AboTelefo == null ? "" : item.AboTelefo,
                        Fax = item.AboFax == null ? "" : item.AboFax,
                        WebPage = item.AboWww == null ? "" : item.AboWww,
                        TaxRegistration = item.AboRegtrib == null ? "" : item.AboRegtrib,
                        FacturationType = item.AboTipfac,
                        Email = item.AboEmail == null ? "" : item.AboEmail,
                        PrincipalContact = item.AboContac == null ? "" : item.AboContac,
                        SubscriberType = item.AboTipo,
                        Observations = item.AboObserv == null ? "" : item.AboObserv,
                        IdSubscriberCategory = subscriberCategory.Where(x => x.RubCodigo == item.RubCodigo).FirstOrDefault().Id,
                        IdCountry = ObtenerCodigoPais(item.PaiCodigo),
                        IdContinent = sqlContext.Countries.Where(x => x.Id == ObtenerCodigoPais(item.PaiCodigo)).FirstOrDefault().IdContinent,
                        IdCurrency = item.MonCodigo == "002" ? 1 : item.MonCodigo == "001" ? 31 : item.MonCodigo == "003" ? 2 : null,
                        Language = item.IdiCodigo == "002" ? "E" : item.IdiCodigo == "001" ? "I" : "",
                        SendReportToName = item.AboInfpara == null ? "" : item.AboInfpara,
                        SendReportToEmail = item.AboEmailci == null ? "" : item.AboEmailci,
                        SendReportToTelephone = item.AboTelefoci == null ? "" : item.AboTelefoci,

                        SendInvoiceToName = item.AboFacpara == null ? "" : item.AboFacpara,
                        SendInvoiceToEmail = item.AboEmailfact,
                        SendInvoiceToTelephone = item.AboTelefofact,

                        AdditionalContactName = item.AboContac2,
                        AdditionalContactEmail = item.AboEmailc2,
                        AdditionalContactTelephone = item.AboTelefoc2,

                        PrefTelef = item.AboPrftel,
                        PrefFax = item.AboPrffax,
                        Usr = item.AboLogin,
                        Psw = item.AboPwd,
                        Indications = item.AboIndica == null ? "" : item.AboIndica,
                        Enable = item.AboActivo == "1" ? true : false,

                        MaximumCredit = item.AboCremax == "1" ? true : false,
                        RevealName = item.AboRevnom == "1" ? true : false,
                        NormalPrice = item.AboPnonli == "Si" ? true : false
                    };
                    await sqlContext.Subscribers.AddAsync(newSubscriber);
                    await sqlContext.SaveChangesAsync();
                    success = true;
                    if (success == true)
                    {
                        var precios = await mysqlContext.TPrecioAbonados.Where(x => x.AboCodigo == item.AboCodigo && x.Migra == 0).ToListAsync();
                        if (precios.Count > 0)
                        {
                            foreach (var precio in precios)
                            {
                                var t1 = precio.PaPrenor.Split("/");
                                var t2 = precio.PaPreurg.Split("/");
                                var t3 = precio.PaPresup.Split("/");
                                var newSubscriberPrice = new SubscriberPrice();
                                newSubscriberPrice.IdSubscriber = newSubscriber.Id;
                                newSubscriberPrice.Date = precio.PaFecha;
                                newSubscriberPrice.IdContinent = sqlContext.Countries.Where(x => x.Id == ObtenerCodigoPais(precio.PaiCodigo)).FirstOrDefault() != null ? sqlContext.Countries.Where(x => x.Id == ObtenerCodigoPais(precio.PaiCodigo)).FirstOrDefault().IdContinent : null;
                                newSubscriberPrice.IdCountry = ObtenerCodigoPais(precio.PaiCodigo);
                                newSubscriberPrice.IdCurrency = precio.MonCodigo == "002" ? 1 : precio.MonCodigo == "001" ? 31 : precio.MonCodigo == "003" ? 2 : null;
                                newSubscriberPrice.PriceT1 = decimal.Parse(t1[0].Trim().IsNullOrEmpty() ? "0" : t1[0].Trim());
                                newSubscriberPrice.DayT1 = int.Parse(t1[1].Trim().IsNullOrEmpty() ? "0" : t1[1].Trim());
                                newSubscriberPrice.PriceT2 = decimal.Parse(t2[0].Trim().IsNullOrEmpty() ? "0" : t2[0].Trim());
                                newSubscriberPrice.DayT2 = int.Parse(t2[1].Trim().IsNullOrEmpty() ? "0" : t2[1].Trim());
                                newSubscriberPrice.PriceT3 = decimal.Parse(t3[0].Trim().IsNullOrEmpty() ? "0" : t3[0].Trim());
                                newSubscriberPrice.DayT3 = int.Parse(t3[1].Trim().IsNullOrEmpty() ? "0" : t3[1].Trim());
                                newSubscriberPrice.PriceB = decimal.Parse(precio.PaPreef2.Trim().IsNullOrEmpty() ? "0" : precio.PaPreef2.Trim());

                                await sqlContext.SubscriberPrices.AddAsync(newSubscriberPrice);
                                await sqlContext.SaveChangesAsync();
                                precio.Migra = 1;
                                mysqlContext.TPrecioAbonados.Update(precio);
                                await mysqlContext.SaveChangesAsync();
                            }
                        }
                    }
                    item.Migra = 1;
                    mysqlContext.MAbonados.Update(item);
                    await mysqlContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        static DateTime ConvertStringToDateTime(string dateString)
        {
            string format = "yyyy-MM-dd";

            try
            {
                return DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("El string no está en el formato correcto.");
            }
        }
        public async Task<bool> MigrateSubscriberType()
        {
            throw new NotImplementedException();
        }

        public Task MigrateUser()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MigrateOldTicket()
        {
            int[] year = { 2024, 2023, 2022, 2021, 2020, 2019, 2018, 2017, 2016, 2015, 2014, 2013, 2012, 2011, 2010, 2009, 2007, 2006 };

            using (var mysqlContext = new MySqlContext())
            using (var context = new SqlCoreContext())
            {
                for (int i = 0; i < year.Length; i++)
                {
                    var cupon = await mysqlContext.TCupons.Where(x => x.CupEstado == "J" &&
                    x.EpCodigo != "" && !string.IsNullOrEmpty(x.EpCodigo) && x.Migra == 0 && x.CupFecped.Value.Year == year[i]).ToListAsync();

                    foreach (var item in cupon)
                    {
                        try
                        {
                            context.OldTickets.Add(new OldTicket
                            {
                                Cupcodigo = item.CupCodigo.ToString(),
                                FechaPedido = item.CupFecped,
                                FechaDespacho = item.CupFecdes,
                                Abonado = item.AboCodigo,
                                Idioma = item.IdiCodigo == "001" ? "I" : item.IdiCodigo == "002" ? "E" : "A",
                                EmpresaPersona = item.EmpPer != null ? item.EmpPer : item.EpCodigo == null ? null : item.EpCodigo.StartsWith('P') ? "P" : "E",
                                FechaVencimiento = item.CupFecvcto,
                                TipoInforme = string.IsNullOrEmpty(item.CupTipinf) ? string.Empty : item.CupTipinf.Substring(0, 2),
                                Tramite = GetProcedureType(item.TramCodigo),
                                NombreDespachado = item.CupNomdes,
                                NombreSolicitado = item.CupNomsol,
                                Empresa = item.EpCodigo

                            });

                            await context.SaveChangesAsync();
                            item.Migra = 1;
                            mysqlContext.TCupons.Update(item);
                            await mysqlContext.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                            continue;

                        }

                    }
                }


            }
            return true;
        }
        private static string GetProcedureType(string? tram)
        {
            if (!string.IsNullOrEmpty(tram))
            {
                var value = int.Parse(tram);
                if (value <= 8)
                {
                    return "T" + value;
                }
                else
                {
                    switch (value)
                    {
                        case 9:
                            return "O1";
                        case 10:
                            return "O2";
                        case 11:
                            return "O3";
                    }
                }
            }
            return string.Empty;
        }

        public Task<bool> MigrateCountry()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MigrateSubscriberCategory()
        {
            try
            {
                var mysqlContext = new MySqlContext();
                var sqlContext = new SqlCoreContext();
                var categorias = await mysqlContext.TRubros.Where(x => x.Migra == false).ToListAsync();
                foreach (var item in categorias)
                {
                    await sqlContext.SubscriberCategories.AddAsync(new SubscriberCategory
                    {
                        Name = item.RubNombre,
                        Enable = item.RubActivo,
                        RubCodigo = item.RubCodigo
                    });
                    await sqlContext.SaveChangesAsync();

                    item.Migra = true;
                    mysqlContext.TRubros.Update(item);
                    await mysqlContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> MigratePersonByOldCode(string oldCode)
        {
            using var contextSql = new SqlCoreContext();
            using var contextMysql = new MySqlContext();
            using var contextPhoto = new FotoContext();
            var persona = await contextMysql.MPersonas.Where(x => x.PeCodigo == oldCode).FirstOrDefaultAsync();
            if (persona != null)
            {
                int idPerson = 0;
                bool success = false;
                var reputacion = await _impersonaDomain.GetmPersonaReputacionByCodigoAsync(persona.PeCodigo);
                int idReputacion = 0;
                if (reputacion != null)
                {
                    idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                }
                var existingPerson = await contextSql.People.Where(x => x.OldCode == persona.PeCodigo).FirstOrDefaultAsync();
                try
                {
                    var existinggPerson = new Person
                    {
                        Id = existingPerson.Id,
                        OldCode = persona.PeCodigo,
                        Fullname = persona.PeNombre == null ? "" : persona.PeNombre,
                        LastSearched = persona.PeFecinf,
                        Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value],
                        Quality = ObtenerCalidad(persona.CalCodigoPer),
                        Nationality = persona.PeNacion == null ? "" : persona.PeNacion,
                        BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac,
                        BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac,
                        IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                                 persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                                 persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                                 persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                                 persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                                 persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                                 persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                                 persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                                 persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null,
                        CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide,
                        TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri,
                        IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                                 persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                                 persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                                 persona.EsCodigo == "07" ? 6 : null,
                        IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                 persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                 persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                 persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null,
                        Address = persona.PeDirecc == null ? "" : persona.PeDirecc,
                        Cp = persona.PeCodpos == null ? "" : persona.PeCodpos,
                        City = persona.PeCiudad == null ? "" : persona.PeCiudad,
                        OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome,
                        TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome,
                        IdCountry = ObtenerCodigoPais(persona.PaiCodigo),
                        CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf,
                        NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo,
                        IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                                 persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                                 persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null,
                        RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv,
                        RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null,
                        RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni,
                        FatherName = persona.PePadre == null ? "" : persona.PePadre,
                        MotherName = persona.PeMadre == null ? "" : persona.PeMadre,
                        Email = persona.PeEmail == null ? "" : persona.PeEmail,
                        Cellphone = persona.PeCelula == null ? "" : persona.PeCelula,
                        ClubMember = persona.PeClub == null ? "" : persona.PeClub,
                        Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur,
                        NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel,
                        PrintNewsCommentary = persona.PeLogpre == 1 ? true : false,
                        ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep,
                        IdCreditRisk = GetCreditRisk(persona.CrCodigo),
                        IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo),
                        IdReputation = idReputacion != 0 ? idReputacion : null,
                        Profession = persona.PfNombre == null ? "" : persona.PfNombre,
                        PersonActivities = await GetPersonActivities(persona),
                        PersonGeneralInformations = await GetPersonGeneralInformation(persona),
                        PersonHistories = await GetPersonHistory(persona),
                        PersonHomes = await GetPersonHome(persona),
                        PersonProperties = await GetPersonProperty(persona),
                        PersonSbs = await GetPersonSBS(persona),
                        PersonJobs = await GetPersonJob(persona),
                        PhotoPeople = await GetPersonPhoto(persona),
                        TraductionPeople = await GetPersonTraductions(persona),
                        BankDebts = await GetPersonBankDebt(persona),
                        ComercialLatePayments = await GetPersonCommercialLate(persona),
                        Providers = await GetPersonProviders(persona),
                    };
                    if (existingPerson != null)
                    {
                        /*
                            existingPerson.OldCode = persona.PeCodigo;
                            existingPerson.Fullname = persona.PeNombre == null ? "" : persona.PeNombre;
                            existingPerson.LastSearched = persona.PeFecinf;
                            existingPerson.Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value];
                            existingPerson.Nationality = persona.PeNacion == null ? "" : persona.PeNacion;
                            existingPerson.BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac;
                            existingPerson.BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac;
                            existingPerson.Quality = ObtenerCalidad(persona.CalCodigoPer);
                            existingPerson.IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                             persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                             persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                             persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                             persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                             persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                             persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                             persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                             persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null;
                            existingPerson.CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide;
                            existingPerson.TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri;
                            existingPerson.IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                             persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                             persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                             persona.EsCodigo == "07" ? 6 : null;
                            existingPerson.IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                                 persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                                 persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                                 persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null;
                            existingPerson.Address = persona.PeDirecc == null ? "" : persona.PeDirecc;
                            existingPerson.Cp = persona.PeCodpos == null ? "" : persona.PeCodpos;
                            existingPerson.City = persona.PeCiudad == null ? "" : persona.PeCiudad;
                            existingPerson.OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome;
                            existingPerson.TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome;
                            existingPerson.IdCountry = ObtenerCodigoPais(persona.PaiCodigo);
                            existingPerson.CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf;
                            existingPerson.NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo;
                            existingPerson.IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                             persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                             persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null;
                            existingPerson.RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv;
                            existingPerson.RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null;
                            existingPerson.RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni;
                            existingPerson.FatherName = persona.PePadre == null ? "" : persona.PePadre;
                            existingPerson.MotherName = persona.PeMadre == null ? "" : persona.PeMadre;
                            existingPerson.Email = persona.PeEmail == null ? "" : persona.PeEmail;
                            existingPerson.Cellphone = persona.PeCelula == null ? "" : persona.PeCelula;
                            existingPerson.ClubMember = persona.PeClub == null ? "" : persona.PeClub;
                            existingPerson.Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur;
                            existingPerson.NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel;
                            existingPerson.PrintNewsCommentary = persona.PeLogpre == 1 ? true : false;
                            existingPerson.ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep;
                            existingPerson.IdCreditRisk = GetCreditRisk(persona.CrCodigo);
                            existingPerson.IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo);
                            existingPerson.IdReputation = idReputacion != 0 ? idReputacion : null;
                            existingPerson.Profession = persona.PfNombre == null ? "" : persona.PfNombre;
                            existingPerson.PersonActivities = await GetPersonActivities(persona);
                            existingPerson.PersonGeneralInformations = await GetPersonGeneralInformation(persona);
                            existingPerson.PersonHistories = await GetPersonHistory(persona);
                            existingPerson.PersonHomes = await GetPersonHome(persona);
                            existingPerson.PersonProperties = await GetPersonProperty(persona);
                            existingPerson.PersonSbs = await GetPersonSBS(persona);
                            existingPerson.PersonJobs = await GetPersonJob(persona);
                            existingPerson.PhotoPeople = await GetPersonPhoto(persona);
                            existingPerson.Traductions = await GetPersonTraductions(existingPerson.Id, persona);
                            existingPerson.BankDebts = await GetPersonBankDebt(persona);
                            existingPerson.ComercialLatePayments = await GetPersonCommercialLate(persona);
                            existingPerson.Providers = await GetPersonProviders(persona);*/

                        try
                        {
                            await _personDomain.UpdateAsync(existinggPerson);
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            success = false;
                        }
                    }
                    else
                    {
                        var newPerson = new Person
                        {
                            OldCode = persona.PeCodigo,
                            Fullname = persona.PeNombre == null ? "" : persona.PeNombre,
                            LastSearched = persona.PeFecinf,
                            Language = Dictionary.LanguageMigra[persona.IdiCodigo.Value],
                            Quality = ObtenerCalidad(persona.CalCodigoPer),
                            Nationality = persona.PeNacion == null ? "" : persona.PeNacion,
                            BirthDate = persona.PeFecnac == null ? "" : persona.PeFecnac,
                            BirthPlace = persona.PeLugnac == null ? "" : persona.PeLugnac,
                            IdDocumentType = persona.TiCodigo == "CExt" ? 2 : persona.TiCodigo == "C.I." ? 6 :
                             persona.TiCodigo == "C.C." ? 7 : persona.TiCodigo == "CPF/MF" ? 9 :
                             persona.TiCodigo == "CURP" ? 10 : persona.TiCodigo == "D.I." ? 11 :
                             persona.TiCodigo == "DNI" ? 1 : persona.TiCodigo == "DPI" ? 12 :
                             persona.TiCodigo == "DUI" ? 13 : persona.TiCodigo == "IDEH" ? 14 :
                             persona.TiCodigo == "LE" ? 15 : persona.TiCodigo == "LC" ? 16 :
                             persona.TiCodigo == "Pas." ? 4 : persona.TiCodigo == "RUT" ? 20 :
                             persona.TiCodigo == "S.S." ? 17 : persona.TiCodigo == "RUN" ? 18 :
                             persona.TiCodigo == "T.I." ? 19 : persona.TiCodigo == "DIM" ? 21 : null,
                            CodeDocumentType = persona.PeDocide == null ? "" : persona.PeDocide,
                            TaxTypeCode = persona.PeRegtri == null ? "" : persona.PeRegtri,
                            IdPersonSituation = persona.EsCodigo == "01" ? null : persona.EsCodigo == "02" ? 1 :
                             persona.EsCodigo == "05" ? 2 : persona.EsCodigo == "03" ? 3 :
                             persona.EsCodigo == "04" ? 4 : persona.EsCodigo == "06" ? 5 :
                             persona.EsCodigo == "07" ? 6 : null,
                            IdLegalRegisterSituation = persona.ErCodigo == "" ? null : persona.ErCodigo == "AC" ? 1 :
                             persona.ErCodigo == "BP" ? 4 : persona.ErCodigo == "BD" ? 3 :
                             persona.ErCodigo == "ST" ? 16 : persona.ErCodigo == "NL" ? 13 :
                             persona.ErCodigo == "BO" ? 2 : persona.ErCodigo == "IN" ? 10 : null,
                            Address = persona.PeDirecc == null ? "" : persona.PeDirecc,
                            Cp = persona.PeCodpos == null ? "" : persona.PeCodpos,
                            City = persona.PeCiudad == null ? "" : persona.PeCiudad,
                            OtherDirecctions = persona.PeDireccCome == null ? "" : persona.PeDireccCome,
                            TradeName = persona.PeNombreCome == null ? "" : persona.PeNombreCome,
                            IdCountry = ObtenerCodigoPais(persona.PaiCodigo),
                            CodePhone = persona.PePrftlf == null ? "" : persona.PePrftlf,
                            NumberPhone = persona.PeTelefo == null ? "" : persona.PeTelefo,
                            IdCivilStatus = persona.EcCodigo == "01" ? 5 : persona.EcCodigo == "02" ? 2 :
                             persona.EcCodigo == "03" ? 1 : persona.EcCodigo == "04" ? 4 :
                             persona.EcCodigo == "05" ? 6 : persona.EcCodigo == "06" ? 3 : null,
                            RelationshipWith = persona.PeRelciv == null ? "" : persona.PeRelciv,
                            RelationshipDocumentType = string.IsNullOrEmpty(persona.PeRelcivDni) ? 1 : null,
                            RelationshipCodeDocument = persona.PeRelcivDni == null ? "" : persona.PeRelcivDni,
                            FatherName = persona.PePadre == null ? "" : persona.PePadre,
                            MotherName = persona.PeMadre == null ? "" : persona.PeMadre,
                            Email = persona.PeEmail == null ? "" : persona.PeEmail,
                            Cellphone = persona.PeCelula == null ? "" : persona.PeCelula,
                            ClubMember = persona.PeClub == null ? "" : persona.PeClub,
                            Insurance = persona.PeAsegur == null ? "" : persona.PeAsegur,
                            NewsCommentary = persona.PePrensasel == null ? "" : persona.PePrensasel,
                            PrintNewsCommentary = persona.PeLogpre == 1 ? true : false,
                            ReputationCommentary = persona.PeComRep == null ? "" : persona.PeComRep,
                            IdCreditRisk = GetCreditRisk(persona.CrCodigo),
                            IdPaymentPolicy = GetPaymentPolicy(persona.PaCodigo),
                            IdReputation = idReputacion != 0 ? idReputacion : null,
                            Profession = persona.PfNombre == null ? "" : persona.PfNombre,
                            PersonActivities = await GetPersonActivities(persona),
                            PersonGeneralInformations = await GetPersonGeneralInformation(persona),
                            PersonHistories = await GetPersonHistory(persona),
                            PersonHomes = await GetPersonHome(persona),
                            PersonProperties = await GetPersonProperty(persona),
                            PersonSbs = await GetPersonSBS(persona),
                            PersonJobs = await GetPersonJob(persona),
                            PhotoPeople = await GetPersonPhoto(persona),
                            BankDebts = await GetPersonBankDebt(persona),
                            ComercialLatePayments = await GetPersonCommercialLate(persona),
                            Providers = await GetPersonProviders(persona),
                        };

                        try
                        {
                            idPerson = await _personDomain.AddPersonAsync(newPerson);

                            var pers = await _personDomain.GetByIdAsync(idPerson);
                            if (pers != null)
                            {

                                pers.TraductionPeople = await GetPersonTraductions(persona);
                                await _personDomain.UpdateAsync(pers);
                                success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            success = false;
                        }

                    }
                    if (success == true)
                    {
                        persona.Migra = 1;
                        contextMysql.MPersonas.Update(persona);
                        await contextMysql.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error Persona :" + persona.PeCodigo + " : " + ex.Message);
                    success = false;
                }
            }

            return true;
        }

        public async Task<bool> MigratePersonal()
        {
            using var contextSql = new SqlCoreContext();
            using var contextMysql = new MySqlContext();
            var personal = await contextMysql.MPersonals.Where(x => x.Migra == 0).ToListAsync();
            foreach (var item in personal)
            {
                var employee = await contextSql.Employees.Where(x => x.Email == item.PerEmail).FirstOrDefaultAsync();
                if (!item.PerCoddig.IsNullOrEmpty())
                {
                    await contextSql.Personals.AddAsync(new Personal
                    {
                        IdEmployee = employee != null ? employee.Id : null,
                        Type = "DI",
                        Code = item.PerCoddig
                    });
                    await contextSql.SaveChangesAsync();
                }
                if (!item.PerCodrep.IsNullOrEmpty())
                {
                    await contextSql.Personals.AddAsync(new Personal
                    {
                        IdEmployee = employee != null ? employee.Id : null,
                        Type = "RP",
                        Code = item.PerCodrep
                    });
                    await contextSql.SaveChangesAsync();
                }
                if (!item.PerCodtra.IsNullOrEmpty())
                {
                    await contextSql.Personals.AddAsync(new Personal
                    {
                        IdEmployee = employee != null ? employee.Id : null,
                        Type = "TR",
                        Code = item.PerCodtra
                    });
                    await contextSql.SaveChangesAsync();
                }
                if (!item.PerCodsup.IsNullOrEmpty())
                {
                    await contextSql.Personals.AddAsync(new Personal
                    {
                        IdEmployee = employee != null ? employee.Id : null,
                        Type = "SU",
                        Code = item.PerCodsup
                    });
                    await contextSql.SaveChangesAsync();
                }
                if (!item.PerCodref.IsNullOrEmpty())
                {
                    await contextSql.Personals.AddAsync(new Personal
                    {
                        IdEmployee = employee != null ? employee.Id : null,
                        Type = "RF",
                        Code = item.PerCodref
                    });
                    await contextSql.SaveChangesAsync();
                }
                item.Migra = 1;
                contextMysql.MPersonals.Update(item);
                await contextMysql.SaveChangesAsync();
            }

            return true;
        }
               
        

        public Task<bool> MigrateAgent()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CorrecPersona(int migra)
        {
            using var mysqlcontext = new MySqlContext();
            using var context = new SqlCoreContext();
            for (int i = 0; i < 3000; i++)
            {
                var list = await mysqlcontext.MPersonas.Where(X => X.Migra == migra).Take(100).ToListAsync();
                foreach (var item in list)
                {
                    try
                    {
                        var personaExistente = await context.People.Where(x => x.OldCode == item.PeCodigo).FirstOrDefaultAsync();
                        if (personaExistente != null)
                        {
                            item.Migra = 1;
                            mysqlcontext.MPersonas.Update(item);
                            await mysqlcontext.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }


            return true;
        }

        public async Task<bool> MigrateCompanyImageOthers(int migra)
        {
            //using var coreContext = new SqlCoreContext();
            //using var context = new SqlContext();
            //using var mysqlContext = new MySqlContext();
            //using var imageMysqlContext = new FotoContext();
            
               
            //var images = await imageMysqlContext.REmpVsFotos.ToListAsync();

            //foreach (var item in images)
            //{
            //    try
            //    {
            //        var empresas = await mysqlContext.MEmpresas.Where(x => x.Migra == migra && x.EmActivo == 1).Take(100).ToListAsync();
            //        foreach (var item in empresas)
            //        {
            //            var company = await coreContext.Companies.Where(x => x.OldCode == item.EmCodigo).FirstOrDefaultAsync();
            //            if(company != null)
            //            {
            //                var images = await imageMysqlContext.REmpVsFotos.Where(x => x.EmCodigo == item.EmCodigo).FirstOrDefaultAsync();
            //                if (images != null)
            //                {
            //                        //await context.CompanyImages.AddAsync(new Domain.Entities.SQLContext.CompanyImage
            //                        //{
            //                        //    IdCompany = company.Id,
            //                        //    Img1 = images.EfLocal.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal) : "",
            //                        //    ImgDesc1 = images.EfLocaltxt.IsNullOrEmpty() == false ? images.EfLocaltxt : "",
            //                        //    ImgDescEng1 = images.EfLocaltxtIng.IsNullOrEmpty() == false ? images.EfLocaltxtIng : "",
            //                        //    ImgPrint1 = images.EfLocal.IsNullOrEmpty() == false ? true : false,
            //                        //    Img2 = images.EfLocal2.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal2) : "",
            //                        //    ImgDesc2 = images.EfLocal2txt.IsNullOrEmpty() == false ? images.EfLocal2txt : "",
            //                        //    ImgDescEng2 = images.EfLocal2txtIng.IsNullOrEmpty() == false ? images.EfLocal2txtIng : "",
            //                        //    ImgPrint2 = images.EfLocal2.IsNullOrEmpty() == false ? true : false,
            //                        //    Img3 = images.EfLocal3.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal3) : "",
            //                        //    ImgDesc3 = images.EfLocal3txt.IsNullOrEmpty() == false ? images.EfLocal3txt : "",
            //                        //    ImgDescEng3 = images.EfLocal3txtIng.IsNullOrEmpty() == false ? images.EfLocal3txtIng : "",
            //                        //    ImgPrint3 = images.EfLocal3.IsNullOrEmpty() == false ? true : false,
            //                        //    Img4 = images.EfLocal4.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal4) : "",
            //                        //    ImgDesc4 = images.EfLocal4txt.IsNullOrEmpty() == false ? images.EfLocal4txt : "",
            //                        //    ImgDescEng4 = images.EfLocal4txtIng.IsNullOrEmpty() == false ? images.EfLocal4txtIng : "",
            //                        //    ImgPrint4 = images.EfLocal4.IsNullOrEmpty() == false ? true : false,
            //                        //});
            //                    item.Migra = 1;
            //                    mysqlContext.MEmpresas.Update(item);
            //                    await context.SaveChangesAsync();
            //                    await mysqlContext.SaveChangesAsync();
            //                }
            //            }
                       
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        _logger.LogError(ex.Message);
            //        continue;
            //    }
            //}
            

            return true;

        }

        

        public async Task<bool> MigrateProfesion()
        {
            try
            {
                using var context = new SqlCoreContext();
                using var mysqlcontext = new MySqlContext();
                var profesiones = await mysqlcontext.TProfesions.ToListAsync();
                foreach(var prof in profesiones)
                {
                    if (prof != null)
                    {
                        await context.Professions.AddAsync(new Profession
                        {
                            Id = 0,
                            Name = prof.PfNombre,
                            EnglishName = prof.PfNombreIng == null ? "" : prof.PfNombreIng
                        });
                        await context.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
        }

        public async Task<bool> MigrateCompanyRelationated(int migra)
        {
            using var mysqlcontext = new MySqlContext();
            using var context = new SqlCoreContext();
            for (int i = 0; i < 360; i++)
            {
                try
                {
                    var listCompanies = await context.Companies
                                                     .Where(x => x.Migra == migra)
                                                     .Take(100)
                                                     .ToListAsync();

                    foreach (var item in listCompanies)
                    {
                        var listRelation = await mysqlcontext.REmpVsEmps
                                                             .Where(x => x.EmCodigo == item.OldCode)
                                                             .ToListAsync();

                        foreach (var relation in listRelation)
                        {
                            bool isShareholder = relation.ReCodigo.Contains("07") || relation.ReCodigo.Contains("08") || relation.ReCodigo.Contains("09");
                            if (!string.IsNullOrEmpty(relation.EeCodigo))
                            {
                                Company targetCompany = await context.Companies
                                                                     .FirstOrDefaultAsync(x => x.OldCode == relation.EeCodigo);

                                if (targetCompany != null)
                                {
                                    await AddCompanyRelation(context, item.Id, targetCompany.Id, relation, isShareholder);
                                }
                            }
                        }

                        item.Migra = 1;
                        context.Companies.Update(item);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    continue;
                }
            }
            return true;
        }

        private async Task AddCompanyRelation(SqlCoreContext context, int idCompany, int idRelationCompany, REmpVsEmp relationData, bool isShareholder)
        {
            if (isShareholder)
            {
                await context.CompanyShareHolders.AddAsync(new CompanyShareHolder
                {
                    IdCompany = idCompany,
                    IdCompanyShareHolder = idRelationCompany,
                    Relation = relationData.ReNombre ?? "",
                    RelationEng = relationData.ReNombreIng ?? "",
                    ParticipacionStr = relationData.EePorAcc ?? "",
                    StartDateStr = relationData.EeDesde,
                    Commentary = relationData.EeComen ?? "",
                    CommentaryEng = relationData.EeComenIng ?? "",
                });
            }
            else
            {
                await context.CompanyRelations.AddAsync(new CompanyRelation
                {
                    IdCompany = idCompany,
                    IdCompanyRelation = idRelationCompany,
                    Relation = relationData.ReNombre ?? "",
                    RelationEng = relationData.ReNombreIng ?? "",
                    Participation = relationData.EePorAcc ?? "",
                    StartDateStr = relationData.EeDesde,
                    Commentary = relationData.EeComen ?? "",
                    CommentaryEng = relationData.EeComenIng ?? "",
                });
            }
        }


        public Task<bool> MigrateCompanyShareholder()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MigrateCompanyPerson(int migra)
        {
            using var mysqlcontext = new MySqlContext();
            using var context = new SqlCoreContext();
            for (int i = 0; i < 360; i++)
            {
                try
                {
                    var listCompanies = await context.Companies.Where(x => x.Migra == migra).Take(100).ToListAsync();
                    foreach (var item in listCompanies)
                    {
                        var partners = await mysqlcontext.REmpVsPes.Where(x => x.EmCodigo == item.OldCode).ToListAsync();
                        foreach (var item1 in partners)
                        {
                            var person = await context.People.Where(x => x.OldCode == item1.PeCodigo).FirstOrDefaultAsync();
                            if(person != null)
                            {
                                await context.CompanyPartners.AddAsync(new CompanyPartner
                                {
                                    Id = 0,
                                    IdCompany = item.Id,
                                    IdPerson = person.Id,
                                    Profession = item1.EpCargo,
                                    ProfessionEng = item1.EpCargoIng,
                                    StartDate = StaticFunctions.VerifyDate(item1.EpDesde),
                                    MainExecutive = item1.EpPrinci == 0 ? false : true,
                                    StartDateStr = item1.EpDesde,
                                    ParticipationStr = item1.EpPoracc,
                                });
                            }
                        }
                        item.Migra = 1;
                        context.Companies.Update(item);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    continue;
                }
                //try
                //{
                //    var list = await mysqlcontext.REmpVsPes.Where(x => x.Migra == migra).Take(100).ToListAsync();
                //    foreach (var item in list)
                //    {
                //        var company = await context.Companies.Where(x => x.OldCode == item.EmCodigo).Take(1).FirstOrDefaultAsync();
                //        if(company != null)
                //        {
                //            var person = await context.People.Where(x => x.OldCode == item.PeCodigo).Take(1).FirstOrDefaultAsync();
                //            if(person != null)
                //            {
                //                await context.CompanyPartners.AddAsync(new CompanyPartner
                //                {
                //                    Id = 0,
                //                    IdCompany = company.Id,
                //                    IdPerson = person.Id,
                //                    Profession = item.EpCargo,
                //                    ProfessionEng = item.EpCargoIng,
                //                    StartDate = StaticFunctions.VerifyDate(item.EpDesde),
                //                    MainExecutive = item.EpPrinci == 0 ? false : true
                //                });
                //                await context.SaveChangesAsync();
                //                item.Migra = 1;
                //                mysqlcontext.REmpVsPes.Update(item); 
                //                await mysqlcontext.SaveChangesAsync();
                //            }
                //            else
                //            {
                //                var listPerson= await mysqlcontext.REmpVsPes.Where(x => x.PeCodigo == item.PeCodigo && x.Migra == 0).ToListAsync();
                //                foreach (var item1 in listPerson)
                //                {
                //                    item1.Migra = 2;
                //                    mysqlcontext.REmpVsPes.Update(item1);
                //                }
                //                item.Migra = 1;
                //                mysqlcontext.REmpVsPes.Update(item);
                //                await mysqlcontext.SaveChangesAsync();
                //            }
                //        }
                //        else
                //        {
                //            var listCompany = await mysqlcontext.REmpVsPes.Where(x => x.EmCodigo == item.EmCodigo && x.Migra == 0).ToListAsync();
                //            foreach (var item1 in listCompany)
                //            {
                //                item1.Migra = 2;
                //                mysqlcontext.REmpVsPes.Update(item1);
                //            }
                //            item.Migra = 1;
                //            mysqlcontext.REmpVsPes.Update(item);
                //            await mysqlcontext.SaveChangesAsync();
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogError(ex.Message);
                //    continue;
                //}
            }
            return true;
        }

        public async Task<bool> MigrateCompanyBankDebt(int migra)
        {
            using var mysqlcontext = new MySqlContext();
            using var context = new SqlCoreContext();
            for (int i = 0; i < 360; i++)
            {
                try
                {
                    var listCompanies = await context.Companies.Where(x => x.Migra == migra).Take(100).ToListAsync();
                    foreach (var item in listCompanies)
                    {
                        var listBankDebt = await mysqlcontext.REmpVsSbds.Where(x => x.EmCodigo == item.OldCode).ToListAsync();
                        if(listBankDebt != null)
                        {
                            foreach (var item1 in listBankDebt)
                            {
                                await context.BankDebts.AddAsync(new BankDebt
                                {
                                    Id = 0,
                                    IdCompany = item.Id,
                                    BankName = item1.SbdNombre,
                                    Qualification = item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("1c") || item1.SbdCalifi.Trim().ToLower().Contains("normal")) ? "NORMAL / 1C" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("2a") || item1.SbdCalifi.Trim().ToLower().Contains("problema")) ? "PROBLEMA POTENCIAL / 2A" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("2b") || item1.SbdCalifi.Trim().ToLower().Contains("deficiente")) ? "DEFICIENTE / 2B" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("3") || item1.SbdCalifi.Trim().ToLower().Contains("4") || item1.SbdCalifi.Trim().ToLower().Contains("dudoso")) ? "DUDOSO / 3-4" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("5") || item1.SbdCalifi.Trim().ToLower().Contains("perdida")) ? "PERDIDA / 5" : "",
                                    QualificationEng = item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("1c") || item1.SbdCalifi.Trim().ToLower().Contains("normal")) ? "NORMAL / 1C" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("2a") || item1.SbdCalifi.Trim().ToLower().Contains("problema")) ? "POTENTIAL PROBLEM / 2A" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("2b") || item1.SbdCalifi.Trim().ToLower().Contains("deficiente")) ? "DEFICIENT / 2B" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("3") || item1.SbdCalifi.Trim().ToLower().Contains("4") || item1.SbdCalifi.Trim().ToLower().Contains("dudoso")) ? "DOUBTFUL / 3-4" :
                                    item1.SbdCalifi != null && (item1.SbdCalifi.Trim().ToLower().Contains("5") || item1.SbdCalifi.Trim().ToLower().Contains("perdida")) ? "LOSS / 5" : "",
                                    Memo = item1.SbdMemo.IsNullOrEmpty() == false ? item1.SbdMemo : "",
                                    MemoEng = item1.SbdMemoIng.IsNullOrEmpty() == false ? item1.SbdMemoIng : "",
                                    DebtNc = (decimal)item1.SbdMonto,
                                    DebtFc = (decimal)item1.SbdMonMe
                                });
                            }
                            
                        }
                        var listComLate = await mysqlcontext.REmpVsProAceps.Where(x => x.EmCodigo == item.OldCode).ToListAsync();
                        if (listComLate != null)
                        {
                            foreach (var item1 in listComLate)
                            {
                                await context.ComercialLatePayments.AddAsync(new ComercialLatePayment
                                {
                                    Id = 0,
                                    IdCompany = item.Id,
                                    CreditorOrSupplier = item1.PaGirador != null ? item1.PaGirador : "",
                                    DocumentType = (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("letr")) ? "Letra Protestada" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("pagar")) ? "Pagaré Protestado" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("cheq")) ? "Cheque Devuelto" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("fac")) ? "Factura(s) Impaga(s)" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("rec")) ? "Recibo(s) Impago(s)" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("war")) ? "Warrant" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("cuo")) ? "Cuota(s) Impaga(s)" : "",
                                    DocumentTypeEng = (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("letr")) ? "Protested Letter" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("pagar")) ? "Protested Promissory Note" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("cheq")) ? "Returned check" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("fac")) ? "Unpaid invoice(s)" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("rec")) ? "Receipt(s) Non-payment(s)" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("war")) ? "Warrant" :
                                    (item1.PaTitulo != null) && (item1.PaTitulo.Trim().ToLower().Contains("cuo")) ? "Unpaid quota" : "",
                                    AmountNc = (decimal) item1.PaMonmn,
                                    AmountFc = (decimal) item1.PaMonme,
                                    Date = item1.PaFecpro != null ? item1.PaFecpro : "",
                                    PendingPaymentDate = item1.PaFecreg != null ? item1.PaFecreg : "",
                                    DaysLate = item1.PaDiaatr == null ? 0 : item1.PaDiaatr,
                                });
                             }
                        }
                        item.Migra = 1;
                        context.Companies.Update(item);
                        await context.SaveChangesAsync();
                    }
                }catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                    continue;
                }
            }
            return true;
        }

        public async Task<bool> UpdatePersonJob()
        {
            using var context = new SqlCoreContext();

            var companies = await context.PersonJobs.Where(x => x.OldCode != null && x.OldCode != "").ToListAsync();
            foreach (var item in companies)
            {
                
                try
                {
                    var company = await context.Companies.Where(x => x.OldCode ==  item.OldCode).FirstOrDefaultAsync();
                    if(company != null)
                    {
                        item.IdCompany = company.Id;
                        context.PersonJobs.Update(item);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.Message);
                    continue;
                }
            }
           
            return true;
        }

        public async Task<bool> UpdateSubscriber()
        {
            using var context = new SqlCoreContext();
            using var mysqlcontext = new MySqlContext();
            try
            {
                var mAbonado = await mysqlcontext.MAbonados.ToListAsync();
                var mAgentes = await mysqlcontext.MAgentes.ToListAsync();
                foreach (var item in mAbonado)
                {
                    if (item.AboTipo.Contains("CA"))
                    {
                        var mAgent = mAgentes.Where(x => x.AgeNombre.ToLower().Trim() == item.AboNombre.ToLower().Trim()).FirstOrDefault();
                        var subscriber = await context.Subscribers.Where(x => x.Code == item.AboCodigo).FirstOrDefaultAsync();
                        if (subscriber != null && mAgent != null)
                        {
                            var agent = await context.Agents.Where(x => x.Code.Contains(mAgent.AgeCodigo.Trim())).FirstOrDefaultAsync();
                            if (agent != null)
                            {
                                agent.AgentSubscriber = true;
                                subscriber.IdAgent = agent.Id;
                            }
                        }
                    }
                }
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> MigrateCompanyByOldCode(string oldCode)
        {
            finanzas = new REmpVsInfFin();
            ramo = new REmpVsRamNeg();
            aval = new TCabEmpAval();
            antecedentes = new REmpVsAspLeg();
            int idCompany = 0;
            using var context = new SqlCoreContext();
            using var contextsql = new SqlContext();
            using var contextMysql = new MySqlContext();
            using var imageMysqlContext = new FotoContext();
            var empresa = await contextMysql.MEmpresas.Where(x => x.EmCodigo == oldCode).FirstOrDefaultAsync();
            try
            {
                var images = await imageMysqlContext.REmpVsFotos.Where(x => x.EmCodigo == oldCode).FirstOrDefaultAsync();
                var image = new List<CompanyImage>();
                if (images != null)
                {
                    image.Add(new CompanyImage
                    {
                        Img1 = images.EfLocal.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal) : "",
                        ImgDesc1 = images.EfLocaltxt.IsNullOrEmpty() == false ? images.EfLocaltxt : "",
                        ImgDescEng1 = images.EfLocaltxtIng.IsNullOrEmpty() == false ? images.EfLocaltxtIng : "",
                        ImgPrint1 = images.EfLocal.IsNullOrEmpty() == false ? true : false,
                        Img2 = images.EfLocal2.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal2) : "",
                        ImgDesc2 = images.EfLocal2txt.IsNullOrEmpty() == false ? images.EfLocal2txt : "",
                        ImgDescEng2 = images.EfLocal2txtIng.IsNullOrEmpty() == false ? images.EfLocal2txtIng : "",
                        ImgPrint2 = images.EfLocal2.IsNullOrEmpty() == false ? true : false,
                        Img3 = images.EfLocal3.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal3) : "",
                        ImgDesc3 = images.EfLocal3txt.IsNullOrEmpty() == false ? images.EfLocal3txt : "",
                        ImgDescEng3 = images.EfLocal3txtIng.IsNullOrEmpty() == false ? images.EfLocal3txtIng : "",
                        ImgPrint3 = images.EfLocal3.IsNullOrEmpty() == false ? true : false,
                        Img4 = images.EfLocal4.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal4) : "",
                        ImgDesc4 = images.EfLocal4txt.IsNullOrEmpty() == false ? images.EfLocal4txt : "",
                        ImgDescEng4 = images.EfLocal4txtIng.IsNullOrEmpty() == false ? images.EfLocal4txtIng : "",
                        ImgPrint4 = images.EfLocal4.IsNullOrEmpty() == false ? true : false,
                    });
                    
                }
                var reputacion = await _mempresaDomain.GetmEmpresaReputacionByCodigoAsync(empresa.EmCodigo);
                int idReputacion = 0;
                if (reputacion != null)
                {
                    idReputacion = ObtenerReputacion(reputacion.RcCodigo);
                }

                var company = new Company
                {
                    OldCode = empresa.EmCodigo,
                    Name = empresa.EmNombre,
                    SocialName = empresa.EmSiglas,
                    LastSearched = empresa.EmFecinf,
                    Language = Dictionary.LanguageMigra[empresa.IdiCodigo.Value],
                    TypeRegister = empresa.EmTipper == 0 ? "PJ" : "PN",
                    YearFundation = empresa.EmAnofun,
                    Quality = ObtenerCalidad(empresa.CalCodigo),
                    IdLegalPersonType = ObtenerPersoneriaLegal(empresa.JuCodigo),
                    TaxTypeCode = empresa.EmRegtri,
                    IdCountry = ObtenerCodigoPais(empresa.PaiCodigo),
                    HaveReport = ObtenerReportes(empresa.EmCodigo),
                    IdLegalRegisterSituation = GetLegalRegisterSituation(empresa.SitCodigo),
                    Address = empresa.EmDirecc,
                    Place = empresa.EmCiudad,
                    Telephone = empresa.EmTelef1,
                    SubTelephone = empresa.EmPrftlf,
                    Cellphone = empresa.EmPrffax,
                    PostalCode = empresa.EmCodpos,
                    WhatsappPhone = empresa.EmFax,
                    Email = empresa.EmEmail,
                    WebPage = empresa.EmPagweb,
                    IdCreditRisk = GetCreditRisk(empresa.CrCodigo),
                    IdPaymentPolicy = GetPaymentPolicy(empresa.PaCodigo),
                    IdReputation = idReputacion != 0 ? idReputacion : null,
                    NewsComentary = string.IsNullOrEmpty(empresa.EmPrensa) ? empresa.EmPrensasel : empresa.EmPrensa,
                    IdentificacionCommentary = empresa.EmComide,
                    Enable = empresa.EmActivo == 1,
                    LastUpdaterUser = 1,
                    OnWeb = empresa.EmOnline == "SI",
                    ReputationComentary = empresa.EmComrep,
                    Print = empresa.EmLogpre == 1,
                    CompanyBackgrounds = await GetCompanyBackground(empresa.EmCodigo),
                    CompanyBranches = await GetCompanyBranch(empresa.EmCodigo),
                    CompanyFinancialInformations = await GetCompanyFinancialInformations(empresa.EmCodigo, empresa.EmAudito ?? string.Empty),
                    CompanySbs = await GetCompanySbs(empresa),
                    CompanyCreditOpinions = await GetCompanyCreditOpinions(empresa),
                    CompanyGeneralInformations = await GetCompanyGeneralInformation(empresa.EmInfgen, empresa.EmCodigo),
                    CompanyImages = image,
                    FinancialBalances = await GetFinancialBalances(empresa.EmCodigo),
                    SalesHistories = await GetSalesHistories(empresa.EmCodigo),
                    ImportsAndExports = await GetImportsAndExports(empresa.EmCodigo),
                    Providers = await GetProviders(empresa.EmCodigo),
                    ComercialLatePayments = await GetComercialLatePayments(empresa.EmCodigo),
                    BankDebts = await GetBankDebts(empresa.EmCodigo),
                    WorkersHistories = await GetWorkersHistories(empresa),
                    TraductionCompanies = await GetAllTraductions(empresa)
                };
                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error empresa :" + empresa.EmCodigo + " : " + ex.Message);
                
            }
            return true;
        }
        public async Task<bool> MigrateCompanyImageByOldCode(string oldCode)
        {
            using var coreContext = new SqlCoreContext();
            using var context = new SqlContext();
            using var mysqlContext = new MySqlContext();
            using var imageMysqlContext = new FotoContext();

            try
            {
                var empresa = await mysqlContext.MEmpresas.Where(x => x.EmCodigo == oldCode && x.EmActivo == 1).FirstOrDefaultAsync();
                if (empresa != null)
                {
                    var company = await coreContext.Companies.Where(x => x.OldCode == oldCode).FirstOrDefaultAsync();
                    if (company != null)
                    {
                        var images = await imageMysqlContext.REmpVsFotos.Where(x => x.EmCodigo == oldCode).FirstOrDefaultAsync();
                        if (images != null)
                        {
                            await context.CompanyImages.AddAsync(new Domain.Entities.SQLContext.CompanyImage
                            {
                                IdCompany = company.Id,
                                Img1 = images.EfLocal.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal) : "",
                                ImgDesc1 = images.EfLocaltxt.IsNullOrEmpty() == false ? images.EfLocaltxt : "",
                                ImgDescEng1 = images.EfLocaltxtIng.IsNullOrEmpty() == false ? images.EfLocaltxtIng : "",
                                ImgPrint1 = images.EfLocal.IsNullOrEmpty() == false ? true : false,
                                Img2 = images.EfLocal2.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal2) : "",
                                ImgDesc2 = images.EfLocal2txt.IsNullOrEmpty() == false ? images.EfLocal2txt : "",
                                ImgDescEng2 = images.EfLocal2txtIng.IsNullOrEmpty() == false ? images.EfLocal2txtIng : "",
                                ImgPrint2 = images.EfLocal2.IsNullOrEmpty() == false ? true : false,
                                Img3 = images.EfLocal3.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal3) : "",
                                ImgDesc3 = images.EfLocal3txt.IsNullOrEmpty() == false ? images.EfLocal3txt : "",
                                ImgDescEng3 = images.EfLocal3txtIng.IsNullOrEmpty() == false ? images.EfLocal3txtIng : "",
                                ImgPrint3 = images.EfLocal3.IsNullOrEmpty() == false ? true : false,
                                Img4 = images.EfLocal4.IsNullOrEmpty() == false ? Convert.ToBase64String(images.EfLocal4) : "",
                                ImgDesc4 = images.EfLocal4txt.IsNullOrEmpty() == false ? images.EfLocal4txt : "",
                                ImgDescEng4 = images.EfLocal4txtIng.IsNullOrEmpty() == false ? images.EfLocal4txtIng : "",
                                ImgPrint4 = images.EfLocal4.IsNullOrEmpty() == false ? true : false,
                            });
                            empresa.Migra = 1;
                            mysqlContext.MEmpresas.Update(empresa);
                            await context.SaveChangesAsync();
                            await mysqlContext.SaveChangesAsync();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }
    }
}
