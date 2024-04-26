using DRRCore.Application.DTO.API;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO
{
    public static class ApiDummy
    {
        public static ReportDto Report()
        {
            return new ReportDto
            {
                RequestClient = RequestClient(),
                Information = Information(),
                Summary = Summary(),
                LegalBackground = LegalBackground(),
                Executives = ExecutiveShareholders(),
                WhoIsWho = WhoIsWhos(),
                Placeholders = Placeholders(),
                BussinessHistory = "Alicorp S.A.A. was incorporated in 1956 as Anderson Clayton & Company......",
                RelatedCompanies = RelatedCompanies(),
                Business= Business(),
                PaymentRecords= PaymentRecords(),
                BankingInformation= BankingInformation(),
                FinancialInformation= FinancialInformation(),
                News= "Alicorp: ventas en negocio de consumo masivo crecieron 4,7% en primer trimestre de 2023\r\n\r\nas ventas consolidadas de la empresa alcanzaron los S/3.326 millones, que, comparado al mismo periodo del 2022, decrece ligeramente en un 0,6%.\r\n\r\nAlicorp presentó sus resultados financieros del primer trimestre del año, periodo en el que la inflación se mantuvo a niveles elevados. En este escenario, la compañía informó que mantiene resiliencia gracias al soporte que le brindan ventajas competitivas como el valor marca, innovación y diversificación de sus negocios.\r\n\r\nAl cierre del primer trimestre, se observó un menor volumen de ventas, explicado por una reducción del consumo privado debido a los conflictos internos del país y al desempeño del negocio de Molienda, que vio afectada su abastecimiento de insumos por el bloqueo en la frontera con Bolivia, originado por los conflictos en el sur. Así las ventas consolidadas de Alicorp alcanzaron los S/3.326 millones, que, comparado al mismo periodo del 2022, decrece ligeramente en un 0,6%."

            };
        }
        private static RequestClientDto RequestClient()
        {
            return new RequestClientDto
            {
               
                RequestDate = DateTime.Now.ToString("MM/dd/yyyy"),
                Priority = "T3",
                Request = "ALICORP SAA",
                Environment = "Develop"
            };
        }
        private static InformationDto Information()
        {
            return new InformationDto()
            {
                CorrectCompanyName = "ALICORP S.A.A.",
                TradeName = "ALICORP",
                QualityInformation="A",
                TaxpayerRegistration = new DocumentTypeDto
                {
                    TypeDocument = "RUC",
                    NumberDocument = "2010005****"
                },
                TaxpayerSituation=new ValueDetailDto
                {
                    Code="TS1",
                    Description="Active"
                },
                JuridicForm=new ValueDetailDto
                {
                    Code= "JF26",
                    Description= "Publicly Held Corporation"
                },
                Main_Address = "Argentina, 4793, ****",
                CityProvincie = "Callao",
                PostalCode = "Callao, 3",
                Country = "PER",
                Phone = "+511  3150800 - 2154130-11054",
                Email = "******@alicorp.com.pe ; ******@alicorp.com.pe",
                WebUrl = "www.alicorp.com.pe",
                Comment = "Email: s*****@gromero.com.pe\r\n\r\nIt should be mentioned the currently investigated Company is NOT INCLUDED IN THE OFAC Sanctions List (List of companies and individuals linked with money from terrorism and narcotics trafficking published by the Office of Foreign Assets Control of the United States Department of the Treasury)."
            };
        }
        private static SummaryDto Summary()
        {
            return new SummaryDto()
            {
                Sector= new ValueDetailDto
                {
                    Code="SC2",
                    Description= "Industry, Manufacturing, Clothing, Production, Manufacturing, Construction\r\n"
                },
                Branch=new ValueDetailDto
                {
                    Code="BR6",
                    Description= "Food in general, solid and liquid food, stores.\r\n"
                },
                InscriptionYear = "1956",
                CapitalStock = new CurrencyAmountDto
                {
                    IsoCurrency = "PEN",
                    Amount = 555666664,
                    Comment = "Soles"
                },
                ShareholdersEquity = new CurrencyAmountWithDateDto
                {
                    IsoCurrency = "PEN",
                    Amount = 4555555555,
                    LastInformationDate = "12/31/2020"
                },
                AnnualRevenues = new CurrencyAmountWithDateDto
                {
                    IsoCurrency = "PEN",
                    Amount = 66665989,
                    LastInformationDate = "12/31/2020"

                },
                Profits = new CurrencyAmountWithDateDto
                {
                    IsoCurrency = "PEN",
                    Amount = 7655654654,
                    LastInformationDate = "12/31/2020"
                },
                Employees = 5000,
                ChiefExecutive = "PEREZ GUBBINS, ALFREDO *****",
                Disposition = new ValueDetailDto
                {
                    Code = "DI13",
                    Description = "Report prepared exclusively from outside sources."
                },
                FinalSituation = new ValueDetailDto
                {
                    Code = "SF3",
                    Description = "ACCEPTABLE Financial Situation"
                },
                PaymentsPolicy = new ValueDetailDto
                {
                    Code = "PP3",
                    Description = "IRREGULAR (Prompt and sometimes delayed payments)"
                },
                Credit = new ValueDetailDto
                {
                    Code = "RC3",
                    Description = "MODERATE RISK. (Slightly fair Financial Situation)"
                }

            };
        }
        private static LegalBackgroundDto LegalBackground()
        {
            return new LegalBackgroundDto
            {
                LegalStatus = "Publicly Held Corporation",
                IncorporationDate = DateTime.Now.ToShortDateString(),
                OperationStartDate = DateTime.Now.ToShortDateString(),
                RegisterPlace = "Lima",
                NotaryOffice = "Julio César*****",
                DurationTime = "Indefinite",
                RegistrationFolio = "Entry 1, Page 351, *****",
                PaidInCapital = new CurrencyAmountDto
                {
                    IsoCurrency = "PEN",
                    Amount = 23156421,
                    Comment = "Soles"
                },
                LastCapitalIncreaseDate = DateTime.Now.ToShortDateString(),
                ShareholdersEquity = new CurrencyAmountWithDateDto
                {
                    IsoCurrency = "PEN",
                    Amount = 23156421,
                    LastInformationDate = "12/31/2020"
                },
                ShareClass = "Common",
                StockExchangeListed = true,
                CurrentExchangeRate = new CurrencyAmountDto
                {
                    IsoCurrency = "PEN",
                    Amount = 3.38,
                    Comment = "Soles"
                },
                Membership = "Lima Chamber of Commerce",
                Comments = "The Subject is listed in the Stock Exchange of\tima under the  tickers ALICORC1 and ALICORI1....."

            };
        }
        private static ExecutiveShareholderDto ExecutiveShareholders()
        {
            return new ExecutiveShareholderDto
            {
                ListExecutives = new List<ListExecutiveShareholderDto> {

                    new ListExecutiveShareholderDto
                    {
                        Name = "ROMERO PAOLETTI, ****",
                        Title = "Chairman of BoD",
                        SinceDate = "04/01/2010"
                    },
                    new ListExecutiveShareholderDto
                    {
                        Name = "ROMERO BELISMELIS, ****",
                        Title = "Vice President",
                        SinceDate = "04/01/2010"
                    },
                     new ListExecutiveShareholderDto
                    {
                        Name = "DE MACEDO MURGEL, ****",
                        Title = "Director",
                        SinceDate = "04/01/2010"
                    }
                },
                OtherParticipationPercentage = 48.5,
                ParticipationPercentage = 100
            };
        }
        private static List<WhoIsWhoDto> WhoIsWhos()
        {
            return new List<WhoIsWhoDto>
            {
                new WhoIsWhoDto
                {
                    Name = "ROMERO PAOLETTI, ****",
                    Title = "Chairman of BoD",
                    Nacionality="Peruvian",
                    Birthday="10/19/1954",
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
        }
        private static List<PlaceholderDto> Placeholders()
        {
            return new List<PlaceholderDto>
            {
                new PlaceholderDto
                {
                    Name="PROFUTURO AFP S.A.",
                    IsoCountry="PER",
                    Relation="Shareholder / Member"
                },
                new PlaceholderDto
                {
                    Name="GRUPO PIURANO DE INVERSIONES S.A.",
                    IsoCountry="PER",
                    Relation="Shareholder / Member"
                }
            };
        }
        private static List<RelatedCompanyDto> RelatedCompanies()
        {
            return new List<RelatedCompanyDto>
            {
                new RelatedCompanyDto
                {
                    Name="AERO TRANSPORTE S.A.",
                    IsoCountry="PER",
                    SituationCompany="Activo",
                    RegistrationNumber="20100010721",
                    BussinessActivity="LAND - AIR - SEA TRANSPORT ",
                    Relation="Related Company"
                },
                new RelatedCompanyDto
                {
                    Name="AGASSYCORP S.A.",
                    IsoCountry="ECU",
                    SituationCompany="Inactivo",
                    RegistrationNumber="0992401435001",                   
                    Relation="Related Company"
                }
            };
        }
        private static BusinessDto Business()
        {
            return new BusinessDto
            {
                MainActivity = "Subject is engaged in manufacturing and sale of fatty-type food....",
                Sector = new ValueDetailDto
                {
                    Code = "SC2",
                    Description = "Industry, Manufacturing, Clothing, Production, Manufacturing, Construction\r\n"
                },
                Branch = new ValueDetailDto
                {
                    Code = "BR6",
                    Description = "Food in general, solid and liquid food, stores.\r\n"
                },
                Import = new BussinessImportExportDto
                {
                    HasImportedOrExported = true,
                    Countries = new List<string>
                    {
                        "PEN","ECU","PAN","CRC","USA"
                    },
                    Details = new List<BussinessAmountDetailDto> {
                        new BussinessAmountDetailDto
                        {
                            Year="2021",
                            Amount=647822282
                        },
                         new BussinessAmountDetailDto
                        {
                            Year="2020",
                            Amount=231233213
                        },
                          new BussinessAmountDetailDto
                        {
                            Year="2019",
                            Amount=434353455
                        }
                    }
                },
                Export = new BussinessImportExportDto
                {
                    HasImportedOrExported = true,
                    Countries = new List<string>
                    {
                        "PEN","ECU","PAN","CRC","USA"
                    },
                    Details = new List<BussinessAmountDetailDto> {
                        new BussinessAmountDetailDto
                        {
                            Year="2021",
                            Amount=647822282
                        },
                         new BussinessAmountDetailDto
                        {
                            Year="2020",
                            Amount=231233213
                        },
                          new BussinessAmountDetailDto
                        {
                            Year="2019",
                            Amount=434353455
                        }
                    }
                },
                CashSalesPercentage = new PercentageValue
                {
                    Value = 15
                },
                CreditSalesPercentage = new PercentageValue
                {
                    Value = 50,
                    Description = "15 days"
                },
                ForeignSalePercentage = new PercentageValue
                {
                    Value =50,
                    Description = "YES"
                },
                DomesticPourchasesPercentage = new PercentageValue
                {
                    Value = 30,
                    Description = "YES"
                },
                ForeignPourchasesPercentage = new PercentageValue
                {
                    Value = 80
                },
                SellingTerritoryPercentage = new PercentageValue
                {
                    Description = "Domestic and international market"
                },
                Employess=4150                
            };
            
        }
        private static FinancialInformationDto FinancialInformation()
        {
            return new FinancialInformationDto
            {
                Disposition = new ValueDetailDto
                {
                    Code = "DI13",
                    Description = "Report prepared exclusively from outside sources."
                },
                InformationProvided = "Directly personnel did not allow the coordination of an interview....",
                InterimBalanceSheets = new List<BalanceSheetDto> {
                    new BalanceSheetDto
                    {
                        Date = "09/30/2021",
                        TypeBalanceSheet = "Interim",
                        Period = "3 months",
                        IsoCurrency = "PEN",
                        ExchangeRate = "4.13",
                        Assets = new AssetsDto
                        {
                            CashBanks = 516955000,
                            Receivables = 1051239000,
                            Inventory = 2132132132,
                            OthersAssets = 85582828,
                            CurrentAssets = 65656464,
                            Fixed = 56532326,
                            OthersCurrentAssets = 1231321,
                            TotalAssets = 988121321
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = 4552465465,
                            OthersLiabilities = 1545645465,
                            CurrentLiabilities = 1321354564,
                            OthersCurrentLiabilities = 123165454
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = 456545465546,
                            Reserves = 986455665,
                            ProfitsLoots = 32154546,
                            TotalLiabilitiesShareholderEquity = 65546546,
                            TotalShareholderEquity = 323123132
                        },
                        Sales = 3325546654,
                        ProfitLoss = 222654321
                    },
                     new BalanceSheetDto
                    {
                        Date = "09/30/2020",
                        TypeBalanceSheet = "Interim",
                        Period = "3 months",
                        IsoCurrency = "PEN",
                        ExchangeRate = "3.70",
                        Assets = new AssetsDto
                        {
                            CashBanks = 26000000,
                            Receivables = 50000000,
                            Inventory = 250000,
                            OthersAssets = 30000065.25,
                            CurrentAssets = 69777777,
                            Fixed = 23000000,
                            OthersCurrentAssets = 12000000,
                            TotalAssets = 100000000
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = 4552465465,
                            OthersLiabilities = 1545645465,
                            CurrentLiabilities = 1321354564,
                            OthersCurrentLiabilities = 123165454
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = 456545465546,
                            Reserves = 986455665,
                            ProfitsLoots = 32154546,
                            TotalLiabilitiesShareholderEquity = 65546546,
                            TotalShareholderEquity = 323123132
                        },
                        Sales = 3325546654,
                        ProfitLoss = 222654321
                    }
                },
                RatioSituation = new RatioSituationDto
                {
                    LiquidityRatio = 0.26,
                    DebtToEquityRatio = 83.56,
                    ProfitabilityMargin = 5.66,
                    WorkingCapital = -12321236
                },
                SituationalFinancial = new ValueDetailDto
                {
                    Code = "SF3",
                    Description = "ACCEPTABLE Financial Situation"
                },
                Comments = "Land\r\nBuildings, plants and other constructions\r\nMachinery and equipment...",
                AnalystComments = "Alicorp S.A.A. was incorporated in Peru on July 16, 1956....",
                Insurances = new List<InsuranceCompaniesDto> {
                    new InsuranceCompaniesDto
                    {
                        Name = "EL PACIFICO PERUANO SUIZA CIA.DE SEGUROS",
                        Against = "All risk"
                    }
                },
                BalanceSheets = new List<BalanceSheetDto>
                {
                      new BalanceSheetDto
                    {
                          IsCurrent=true,
                        Date = "09/30/2021",
                        TypeBalanceSheet = "Interim",
                        Period = "3 months",
                        IsoCurrency = "PEN",
                        ExchangeRate = "4.13",
                        Assets = new AssetsDto
                        {
                            CashBanks = 516955000,
                            Receivables = 1051239000,
                            Inventory = 2132132132,
                            OthersAssets = 85582828,
                            CurrentAssets = 65656464,
                            Fixed = 56532326,
                            OthersCurrentAssets = 1231321,
                            TotalAssets = 988121321
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = 4552465465,
                            OthersLiabilities = 1545645465,
                            CurrentLiabilities = 1321354564,
                            OthersCurrentLiabilities = 123165454
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = 456545465546,
                            Reserves = 986455665,
                            ProfitsLoots = 32154546,
                            TotalLiabilitiesShareholderEquity = 65546546,
                            TotalShareholderEquity = 323123132
                        },
                        Sales = 3325546654,
                        ProfitLoss = 222654321
                    },
                        new BalanceSheetDto
                    {
                        Date = "09/30/2020",
                        TypeBalanceSheet = "Interim",
                        Period = "3 months",
                        IsoCurrency = "PEN",
                        ExchangeRate = "4.13",
                        Assets = new AssetsDto
                        {
                            CashBanks = 516955000,
                            Receivables = 1051239000,
                            Inventory = 2132132132,
                            OthersAssets = 85582828,
                            CurrentAssets = 65656464,
                            Fixed = 56532326,
                            OthersCurrentAssets = 1231321,
                            TotalAssets = 988121321
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = 4552465465,
                            OthersLiabilities = 1545645465,
                            CurrentLiabilities = 1321354564,
                            OthersCurrentLiabilities = 123165454
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = 456545465546,
                            Reserves = 986455665,
                            ProfitsLoots = 32154546,
                            TotalLiabilitiesShareholderEquity = 65546546,
                            TotalShareholderEquity = 323123132
                        },
                        Sales = 3325546654,
                        ProfitLoss = 222654321
                    },
                          new BalanceSheetDto
                    {
                        Date = "09/30/2019",
                        TypeBalanceSheet = "Interim",
                        Period = "3 months",
                        IsoCurrency = "PEN",
                        ExchangeRate = "3.80",
                        Assets = new AssetsDto
                        {
                            CashBanks = 1051239000,
                            Receivables = 454545200,
                            Inventory = 123000000,
                            OthersAssets = 16400000,
                            CurrentAssets = 12345600,
                            Fixed = 15975300,
                            OthersCurrentAssets = 45612300,
                            TotalAssets = 78912300
                        },
                        Liabilities = new LiabilitiesDto
                        {
                            BankSuppliers = 12345600,
                            OthersLiabilities = 778994500,
                            CurrentLiabilities = 765213400,
                            OthersCurrentLiabilities = 12455550
                        },
                        ShareholdersEquity = new ShareholdersEquityDto
                        {
                            Capital = 122311240,
                            Reserves = 780000000,
                            ProfitsLoots = 950000000,
                            TotalLiabilitiesShareholderEquity = 9600002300,
                            TotalShareholderEquity = 14000000
                        },
                        Sales = 15000000,
                        ProfitLoss = 18000000
                    }
                }
            };
        }

        private static BankingInformationDto BankingInformation()
        {
            return new BankingInformationDto
            {
                ExchangeRateSbs = 3.99,
                RiskCenter = "No delinquency was reported to Credit Bureau.",
                RegisterDate = "12/31/2021",
                MNTotal = 852364459,
                MNGuaranteesOffered = 209663451,
                Banks = new List<BankDto> {
                    new BankDto
                    {
                        Bank="SCOTIABANK",
                        DebtRating=new ValueDetailDto
                        {
                            Code="1C",
                            Description="Normal"
                        },
                        Amount=444572896,
                        IsoCurrency="PEN"
                    },
                    new BankDto
                    {
                        Bank="BBVA CONTINENTAL",
                        DebtRating=new ValueDetailDto
                        {
                            Code="1C",
                            Description="Normal"
                        },
                        Amount=236572896,
                        IsoCurrency="USD"
                    }

                },
                SbsComment = "Maintains unused lines of credit in banks:\r\nSCOTIABANK for S/.43.543.802.44 for loans.\r\nCITIBANK DEL PERU for S/.1,263,675 for c..."
            };
        }

        private static PaymentRecordsDto PaymentRecords()
        {
            return new PaymentRecordsDto
            {
                PrimaryProviders = new List<Provider>
                {
                    new Provider
                    {
                        Name="ENVASES MULTIPLES SA",
                        IsoCountry="PER",
                        Phone="(511) 6176700",
                        ProductsOrServicesRequires="Plastic wrappings",
                        ClientSince="Ser. Years",
                        Terms="90 days",
                        Comments="Meets payments",
                        Performance="Prompt"
                    },
                    new Provider
                    {
                        Name="INDUSTRIAS DEL ENVASE SA",
                        IsoCountry="PER",
                        Phone="(511) 6176700",
                        ProductsOrServicesRequires="Industrial packaging",
                        ClientSince="Ser. Years",
                        Terms="90 days",
                        Comments="Meets payments",
                        Performance="Prompt"
                    }
                },
                SecondaryProviders = new List<Provider>
                {
                     new Provider
                    {
                        Name="DESARROLLO LOGÍSTICO PERÚ S.A.C",
                        IsoCountry="PER",
                        Phone="(511) 6176700",
                        Comments="Meets payments",

                    },
                      new Provider
                    {
                        Name="GRANOTEC PERÚ SA",
                        IsoCountry="PER",
                        Phone="(511) 6176700"
                    }
                }
            };
        }
    }
}
