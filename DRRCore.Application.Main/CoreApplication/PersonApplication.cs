using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DRRCore.Application.Main.CoreApplication
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IPersonDomain _personDomain;
        private readonly IPersonHomeDomain _personHomeDomain;
        private readonly IPersonJobDomain _personJobDomain;
        private readonly IPersonActivitiesDomain _personActivitiesDomain;
        private readonly IPersonPropertyDomain _personPropertyDomain;
        private readonly IProviderDomain _providerDomain;
        private readonly IComercialLatePaymentDomain _comercialLatePaymentDomain;
        private readonly IBankDebtDomain _bankDebtDomain;
        private readonly IPersonSBSDomain _personSBSDomain;
        private readonly IPersonHistoryDomain _personHistoryDomain;
        private readonly IPersonGeneralInfoDomain _personGeneralInfoDomain;
        private readonly ICompanyPartnersDomain _companyPartnersDomain;
        private readonly IPersonImagesDomain _personImagesDomain;
        private readonly IPersonPhotoDomain _personPhotoDomain;
        private readonly ITicketDomain _ticketDomain;

        public PersonApplication(IMapper mapper, ILogger logger, IPersonDomain personDomain, IPersonHomeDomain personHomeDomain,
            IPersonJobDomain personJobDomain, IPersonSBSDomain personSBSDomain, IProviderDomain providerDomain, 
            IComercialLatePaymentDomain comercialLatePaymentDomain, IBankDebtDomain bankDebtDomain, ICompanyPartnersDomain companyPartnersDomain,
            IPersonActivitiesDomain personActivitiesDomain, IPersonPropertyDomain personPropertyDomain, 
            IPersonHistoryDomain personHistoryDomain, IPersonGeneralInfoDomain personGeneralInfoDomain, IPersonImagesDomain personImagesDomain,
            IPersonPhotoDomain personPhotoDomain, ITicketDomain ticketDomain)
        {
            _mapper = mapper;
            _logger = logger;
            _personDomain = personDomain;
            _personHomeDomain = personHomeDomain;
            _personActivitiesDomain = personActivitiesDomain;
            _personPropertyDomain = personPropertyDomain;
            _personHistoryDomain = personHistoryDomain;
            _personGeneralInfoDomain = personGeneralInfoDomain;
            _personJobDomain = personJobDomain;
            _providerDomain = providerDomain;
            _comercialLatePaymentDomain = comercialLatePaymentDomain;
            _bankDebtDomain = bankDebtDomain;
            _personSBSDomain = personSBSDomain;
            _companyPartnersDomain = companyPartnersDomain;
            _personImagesDomain = personImagesDomain;
            _personPhotoDomain = personPhotoDomain;
            _ticketDomain= ticketDomain;
        }

        public async Task<Response<bool>> ActivateWebPerson(int id)
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
                response.Data = await _personDomain.ActivateWebAsync(id);
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
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<int>> AddOrUpdatePerson(AddOrUpdatePersonRequestDto obj)
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
                    var newPerson = _mapper.Map<Person>(obj);
                    newPerson.Traductions = traductions;
                    response.Data = await _personDomain.AddPersonAsync(newPerson);
                }
                else
                {
                    var existingPerson = await _personDomain.GetByIdAsync(obj.Id);
                    if (existingPerson == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFoundEmployee;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingPerson = _mapper.Map(obj, existingPerson);

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
                    existingPerson.Traductions = traductions;
                    existingPerson.UpdateDate = DateTime.Now;
                    await _personDomain.UpdateAsync(existingPerson);
                    response.Data = existingPerson.Id;
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

        public async Task<Response<int?>> AddOrUpdatePersonActivitiesAsync(AddOrUpdatePersonActivitiesRequestDto obj)
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
                    var newPersonActivities = _mapper.Map<PersonActivity>(obj);
                    response.Data = await _personActivitiesDomain.AddPersonActivitiesAsync(newPersonActivities, traductions);
                }
                else
                {
                    var existingPersonActivities = await _personActivitiesDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingPersonActivities == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingPersonActivities = _mapper.Map(obj, existingPersonActivities);

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
                    existingPersonActivities.UpdateDate = DateTime.Now;
                    response.Data = await _personActivitiesDomain.UpdatePersonActivitiesAsync(existingPersonActivities, traductions);
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

        public async Task<Response<int?>> AddOrUpdatePersonGeneralInfoAsync(AddOrUpdatePersonGeneralInfoRequestDto obj)
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
                    var newObj = _mapper.Map<PersonGeneralInformation>(obj);
                    response.Data = await _personGeneralInfoDomain.AddPersonGeneralInfoAsync(newObj, traductions);
                }
                else
                {
                    var existingObj = await _personGeneralInfoDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);

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
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _personGeneralInfoDomain.UpdatePersonGeneralInfoAsync(existingObj, traductions);
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

        public async Task<Response<int?>> AddOrUpdatePersonHistoryAsync(AddOrUpdatePersonHistoryRequestDto obj)
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
                    var newObj = _mapper.Map<PersonHistory>(obj);
                    response.Data = await _personHistoryDomain.AddPersonHistoryAsync(newObj, traductions);
                }
                else
                {
                    var existingObj= await _personHistoryDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);

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
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _personHistoryDomain.UpdatePersonHistoryAsync(existingObj, traductions);
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

        public async Task<Response<int?>> AddOrUpdatePersonHomeAsync(AddOrUpdatePersonHomeRequestDto obj)
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
                    var newPersonHome = _mapper.Map<PersonHome>(obj);
                    response.Data = await _personHomeDomain.AddPersonHomeAsync(newPersonHome, traductions);
                }
                else
                {
                    var existingPersonHome = await _personHomeDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingPersonHome == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingPersonHome = _mapper.Map(obj, existingPersonHome);

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
                    existingPersonHome.UpdateDate = DateTime.Now;
                    response.Data = await _personHomeDomain.UpdatePersonHomeAsync(existingPersonHome, traductions);
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

        public async Task<Response<int?>> AddOrUpdatePersonJobAsync(AddOrUpdatePersonJobRequestDto obj)
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
                    var newObj= _mapper.Map<PersonJob>(obj);
                    response.Data = await _personJobDomain.AddPersonJobAsync(newObj, traductions);
                }
                else
                {
                    var existingObj= await _personJobDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);

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
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _personJobDomain.UpdatePersonJobAsync(existingObj, traductions);
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

        public async Task<Response<bool>> AddOrUpdatePersonPartner(AddOrUpdateCompanyPartnersRequestDto obj)
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
                    var newObj = _mapper.Map<CompanyPartner>(obj);
                    response.Data = await _companyPartnersDomain.AddAsync(newObj);
                }
                else
                {
                    var existingObj = await _companyPartnersDomain.GetByIdAsync((int)obj.Id);
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

        public async Task<Response<int?>> AddOrUpdatePersonPropertyAsync(AddOrUpdatePersonPropertyRequestDto obj)
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
                    var newPersonProperty= _mapper.Map<PersonProperty>(obj);
                    response.Data = await _personPropertyDomain.AddPersonPropertiesAsync(newPersonProperty, traductions);
                }
                else
                {
                    var existingPersonProperty = await _personPropertyDomain.GetByIdPersonAsync((int)obj.IdPerson);
                    if (existingPersonProperty == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingPersonProperty = _mapper.Map(obj, existingPersonProperty);

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
                    existingPersonProperty.UpdateDate = DateTime.Now;
                    response.Data = await _personPropertyDomain.UpdatePersonPropertiesAsync(existingPersonProperty, traductions);
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

        public async Task<Response<int?>> AddOrUpdatePersonSBSAsync(AddOrUpdatePersonSbsRequestDto obj)
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
                    var newObj= _mapper.Map<PersonSb>(obj);
                    response.Data = await _personSBSDomain.AddPersonSBS(newObj, traductions);
                }
                else
                {
                    var existingObj= await _personSBSDomain.GetByIdPerson((int)obj.IdPerson);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);

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
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _personSBSDomain.UpdatePersonSBS(existingObj, traductions);
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

        public async Task<Response<bool>> AddOrUpdatePhotoAsync(AddOrUpdatePersonPhotoRequestDto obj)
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
                    var newPhoto = _mapper.Map<PhotoPerson>(obj);
                    response.Data = await _personPhotoDomain.AddAsync(newPhoto);
                }
                else
                {
                    var existingPhoto= await _personPhotoDomain.GetByIdAsync(obj.Id);
                    existingPhoto = _mapper.Map(obj, existingPhoto);
                    response.Data = await _personPhotoDomain.UpdateAsync(existingPhoto);
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
                if (obj == null)
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

        public async Task<Response<bool>> DeletePerson(int id)
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
                response.Data = await _personDomain.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeletePersonPartner(int id)
        {
            var response = new Response<bool>();
            try
            {
                var provider = await _companyPartnersDomain.GetByIdAsync(id);
                if (provider == null)
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

        public async Task<Response<bool>> DeletePhoto(int id)
        {
            var response = new Response<bool>();
            try
            {
                var photo = await _personPhotoDomain.GetByIdAsync(id);
                if (photo == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _personPhotoDomain.DeleteAsync(id);
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

        public async Task<Response<bool>> DesactivateWebPerson(int id)
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
                response.Data = await _personDomain.DesactivateWebAsync(id);
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

        public async Task<Response<List<GetListBankDebtResponseDto>>> GetListBankDebtAsync(int idPerson)
        {
            var response = new Response<List<GetListBankDebtResponseDto>>();
            try
            {
                var list = await _bankDebtDomain.GetBankDebtsByIdPerson(idPerson);
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

        public async Task<Response<List<GetListComercialLatePaymentResponseDto>>> GetListComercialLatePaymentAsync(int idPerson)
        {
            var response = new Response<List<GetListComercialLatePaymentResponseDto>>();
            try
            {
                var list = await _comercialLatePaymentDomain.GetComercialLatePaymetByIdPerson(idPerson);
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

        public async Task<Response<List<GetListPersonResponseDto>>> GetListPerson(string fullname, string form, int idCountry, bool haveReport, string filterBy)
        {
            var response = new Response<List<GetListPersonResponseDto>>();
            try
            {
                if (filterBy != "S")
                {
                    var list = await _personDomain.GetAllByAsync(fullname, form, idCountry, haveReport,filterBy);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetListPersonResponseDto>>(list);
                }
                else
                {
                    var ticket = await _ticketDomain.GetByNameAsync(fullname, "P");
                    var mapper = _mapper.Map<List<GetListPersonResponseDto>>(ticket);

                    var oldTicket = await _ticketDomain.GetSimilarByNameAsync(fullname, "P");
                    if (oldTicket.Any())
                    {
                        foreach (var item in oldTicket)
                        {
                            var person = await _personDomain.GetByOldCode(item.Empresa);
                            if (person != null)
                            {
                                mapper.Add(new GetListPersonResponseDto
                                {
                                    Fullname = item.NombreSolicitado,
                                    DispatchName = item.NombreDespachado,
                                    Language = item.Idioma,
                                    Id = person.Id,
                                    Country = person.IdCountryNavigation.Name,
                                    IsoCountry = person.IdCountryNavigation.Iso,
                                    FlagCountry = person.IdCountryNavigation.FlagIso,
                                    Code = person.OldCode
                                });
                            }
                        }
                    }
                    mapper = mapper.DistinctBy(x => x.Fullname).DistinctBy(x => x.Code).ToList();
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
       
        public async Task<Response<List<GetListPersonPartnerResponseDto>>> GetListPersonPartnerByIdPerson(int idPerson)
        {
            var response = new Response<List<GetListPersonPartnerResponseDto>>();
            try
            {
                var list = await _companyPartnersDomain.GetPartnersByIdPerson(idPerson);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetListPersonPartnerResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetPersonPhotoResponseDto>>> GetListPhotoAsync(int idPerson)
        {
            var response = new Response<List<GetPersonPhotoResponseDto>>();
            try
            {
                var list = await _personPhotoDomain.GetPhotosByIdPersonAsync(idPerson);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<List<GetPersonPhotoResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListProviderResponseDto>>> GetListProvidersAsync(int idPerson)
        {
            var response = new Response<List<GetListProviderResponseDto>>();
            try
            {
                var list = await _providerDomain.GetProviderByIdPerson(idPerson);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<List<GetListProviderResponseDto>>(list);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonActivitiesResponseDto>> GetPersonActivitiesByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonActivitiesResponseDto>();
            try
            {
                var personActivity = await _personActivitiesDomain.GetByIdPersonAsync(idPerson);
                if (personActivity == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonActivitiesResponseDto>(personActivity);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonResponseDto>> GetPersonById(int id)
        {
            var response = new Response<GetPersonResponseDto>();
            try
            {
                var person = await _personDomain.GetByIdAsync(id);
                if (person == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonResponseDto>(person);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonGeneralInfoResponseDto>> GetPersonGeneralInfoByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonGeneralInfoResponseDto>();
            try
            {
                var obj = await _personGeneralInfoDomain.GetByIdPersonAsync(idPerson);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonGeneralInfoResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonHistoryResponseDto>> GetPersonHistoryByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonHistoryResponseDto>();
            try
            {
                var obj = await _personHistoryDomain.GetByIdPersonAsync(idPerson);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonHistoryResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonHomeResponseDto>> GetPersonHomeByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonHomeResponseDto>();
            try
            {
                var personHome = await _personHomeDomain.GetByIdPersonAsync(idPerson);
                if (personHome == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonHomeResponseDto>(personHome);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonJobResponseDto>> GetPersonJobByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonJobResponseDto>();
            try
            {
                var obj = await _personJobDomain.GetByIdPersonAsync(idPerson);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonJobResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetCompanyPartnersResponseDto>> GetPersonPartnerById(int id)
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

        public async Task<Response<GetPersonPropertyResponseDto>> GetPersonPropertyByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonPropertyResponseDto>();
            try
            {
                var personProperty = await _personPropertyDomain.GetByIdPersonAsync(idPerson);
                if (personProperty == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonPropertyResponseDto>(personProperty);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonSbsResponseDto>> GetPersonSBSById(int idPerson)
        {
            var response = new Response<GetPersonSbsResponseDto>();
            try
            {
                var obj = await _personSBSDomain.GetByIdPerson(idPerson);
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonSbsResponseDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetPersonPhotoResponseDto>> GetPhotoById(int id)
        {
            var response = new Response<GetPersonPhotoResponseDto>();
            try
            {
                var photo = await _personPhotoDomain.GetByIdAsync(id);
                if (photo == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonPhotoResponseDto>(photo);
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

        public async Task<Response<GetStatusPersonResponseDto>> GetStatusPerson(int idPerson)
        {
            var response = new Response<GetStatusPersonResponseDto>();
            var status = new GetStatusPersonResponseDto();
            try
            {
                var person = await _personDomain.GetByIdAsync(idPerson);
                if(person != null)
                {
                    status.Person = true;
                    var home = await _personHomeDomain.GetByIdPersonAsync(idPerson);
                    status.Home = home != null ? true : false;
                    var job = await _personJobDomain.GetByIdPersonAsync(idPerson);
                    status.Job = job != null ? true : false;
                    var activities = await _personActivitiesDomain.GetByIdPersonAsync(idPerson);
                    status.Activities = activities != null ? true : false;
                    var properties = await _personPropertyDomain.GetByIdPersonAsync(idPerson);
                    status.Properties = properties != null ? true : false;
                    var sbs = await _personSBSDomain.GetByIdPerson(idPerson);
                    var provider = await _providerDomain.GetProviderByIdPerson(idPerson);
                    var bankDebt = await _bankDebtDomain.GetBankDebtsByIdPerson(idPerson);
                    var comercial = await _comercialLatePaymentDomain.GetComercialLatePaymetByIdPerson(idPerson);
                    status.Sbs = sbs != null || provider.Count > 0 || bankDebt.Count > 0 || comercial.Count > 0 ? true : false;
                    var history = await _personHistoryDomain.GetByIdPersonAsync(idPerson);
                    status.History = history != null ? true : false;
                    var infoGeneral = await _personGeneralInfoDomain.GetByIdPersonAsync(idPerson);
                    status.InfoGeneral = infoGeneral != null ? true : false;
                    using var context = new SqlCoreContext();
                    var photo = await context.PhotoPeople.Where(x => x.IdPerson == idPerson).ToListAsync();
                    status.Images = photo != null && photo.Count > 0 ? true : false;
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
    }
}
