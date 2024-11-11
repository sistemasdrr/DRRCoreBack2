using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DRRCore.Application.Main.CoreApplication
{
    public class UserApplication : IUserApplication
    {
        private readonly IProcessDomain _processDomain;
        private readonly IConfiguration _configuration;
        private readonly IUserLoginDomain _userLoginDomain;
        private readonly IUserProcessDomain _userProcessDomain;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsIdentity claims;

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public UserApplication(IProcessDomain processDomain, IUserLoginDomain userLoginDomain, ILogger logger, IMapper mapper
            , IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IUserProcessDomain userProcessDomain)
        {
            _processDomain = processDomain;
            _userLoginDomain = userLoginDomain;
            _httpContextAccessor = httpContextAccessor;
            claims = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _userProcessDomain = userProcessDomain;
        }
        public async Task<Response<List<GetProcessResponseDto>>> GetProcessAsync()
        {
            var response = new Response<List<GetProcessResponseDto>>();
            try
            {
                var list = await _processDomain.GetAllAsync();
                if (list != null)
                {
                    response.Data = _mapper.Map<List<GetProcessResponseDto>>(list);
                }
                else
                {
                    response.IsSuccess = false;
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

        public async Task<Response<GetUserProcessResponseDto>> getProcessByIdEmployee(int idEmployee)
        {
            var response = new Response<GetUserProcessResponseDto>();
            var data = new GetUserProcessResponseDto();
            var listGerencia = new List<UserProcessDto>();
            var listProduccion = new List<UserProcessDto>();
            var listAdministracion = new List<UserProcessDto>();
            var listFacturacion = new List<UserProcessDto>();
            var listConsultas = new List<UserProcessDto>();
            var listReportes = new List<UserProcessDto>();
            try
            {
                var idUser = await _userLoginDomain.GetIdUserByIdEmployee(idEmployee);
                if (idUser != 0 && idUser != null)
                {
                    var permissions = await _userProcessDomain.GetProcessByIdUser((int)idUser);
                    if (permissions != null && permissions.Count != 0)
                    {
                        var list1 = new List<UserProcess>();
                        var list2 = new List<UserProcess>();
                        var list3 = new List<UserProcess>();

                        list1 = permissions.Where(x => x.IdProcessNavigation.Level == 1).ToList();
                        list2 = permissions.Where(x => x.IdProcessNavigation.Level == 2).OrderBy(x => x.IdProcessNavigation.OrderItem).ToList();
                        list3 = permissions.Where(x => x.IdProcessNavigation.Level == 3).OrderBy(x => x.IdProcessNavigation.OrderItem).ToList();
                        foreach (var item1 in list1)
                        {
                            if (item1.IdProcessNavigation.Menu == "Gerencia")
                            {
                                var subLevel1 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Gerencia"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel2 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        subLevel2.Clear();
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Gerencia"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel2.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel2;
                                        subLevel1.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel1;
                                listGerencia.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                            else if (item1.IdProcessNavigation.Menu == "Administración")
                            {
                                var subLevel3 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Administración"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel4 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Administración"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel4.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel4;
                                        subLevel3.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel3;
                                listAdministracion.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                            else if (item1.IdProcessNavigation.Menu == "Producción")
                            {
                                var subLevel5 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Producción"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel6 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Producción"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel6.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel6;
                                        subLevel5.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel5;
                                listProduccion.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                            else if (item1.IdProcessNavigation.Menu == "Facturación")
                            {
                                var subLevel7 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Facturación"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel8 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Facturación"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel8.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel8;
                                        subLevel7.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel7;
                                listFacturacion.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                            else if (item1.IdProcessNavigation.Menu == "Consultas")
                            {
                                var subLevel9 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel10 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel10.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel10;
                                        subLevel9.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel9;
                                listConsultas.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                            else if (item1.IdProcessNavigation.Menu == "Reportes")
                            {
                                var subLevel11 = new List<UserProcessDto>();
                                var obj1 = _mapper.Map<UserProcessDto>(item1);
                                foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Reportes"))
                                {
                                    if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                    {
                                        var subLevel12 = new List<UserProcessDto>();
                                        var obj2 = _mapper.Map<UserProcessDto>(item2);
                                        foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Reportes"))
                                        {
                                            if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                            {
                                                var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                subLevel12.Add(obj3);
                                            }
                                        }
                                        obj2.SubLevel = subLevel12;
                                        subLevel11.Add(obj2);
                                    }
                                }
                                obj1.SubLevel = subLevel11;
                                listReportes.Add(_mapper.Map<UserProcessDto>(obj1));
                            }
                        }
                    }
                    else
                    {
                        var addProcess = await _userProcessDomain.AddAllProcess((int)idUser);
                        if (addProcess == true)
                        {
                            permissions = await _userProcessDomain.GetProcessByIdUser((int)idUser);
                            if (permissions != null && permissions.Count != 0)
                            {
                                var list1 = new List<UserProcess>();
                                var list2 = new List<UserProcess>();
                                var list3 = new List<UserProcess>();

                                list1 = permissions.Where(x => x.IdProcessNavigation.Level == 1).ToList();
                                list2 = permissions.Where(x => x.IdProcessNavigation.Level == 2).ToList();
                                list3 = permissions.Where(x => x.IdProcessNavigation.Level == 3).ToList();
                                foreach (var item1 in list1)
                                {
                                    if (item1.IdProcessNavigation.Menu == "Gerencia")
                                    {
                                        var subLevel1 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Gerencia"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel2 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                subLevel2.Clear();
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Gerencia"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel2.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel2;
                                                subLevel1.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel1;
                                        listGerencia.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                    else if (item1.IdProcessNavigation.Menu == "Administración")
                                    {
                                        var subLevel3 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Administración"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel4 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Administración"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel4.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel4;
                                                subLevel3.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel3;
                                        listAdministracion.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                    else if (item1.IdProcessNavigation.Menu == "Producción")
                                    {
                                        var subLevel5 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        subLevel5.Clear();
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Producción"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel6 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Producción"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel6.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel6;
                                                subLevel5.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel5;
                                        listProduccion.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                    else if (item1.IdProcessNavigation.Menu == "Facturación")
                                    {
                                        var subLevel7 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Facturación"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel8 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Facturación"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel8.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel8;
                                                subLevel7.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel7;
                                        listFacturacion.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                    else if (item1.IdProcessNavigation.Menu == "Consultas")
                                    {
                                        var subLevel9 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel10 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel10.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel10;
                                                subLevel9.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel9;
                                        listConsultas.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                    else if (item1.IdProcessNavigation.Menu == "Consultas")
                                    {
                                        var subLevel11 = new List<UserProcessDto>();
                                        var obj1 = _mapper.Map<UserProcessDto>(item1);
                                        foreach (var item2 in list2.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                        {
                                            if (item2.IdProcessNavigation.Father == item1.IdProcess)
                                            {
                                                var subLevel12 = new List<UserProcessDto>();
                                                var obj2 = _mapper.Map<UserProcessDto>(item2);
                                                foreach (var item3 in list3.Where(x => x.IdProcessNavigation.Menu == "Consultas"))
                                                {
                                                    if (item3.IdProcessNavigation.Father == item2.IdProcess)
                                                    {
                                                        var obj3 = _mapper.Map<UserProcessDto>(item3);
                                                        subLevel12.Add(obj3);
                                                    }
                                                }
                                                obj2.SubLevel = subLevel12;
                                                subLevel11.Add(obj2);
                                            }
                                        }
                                        obj1.SubLevel = subLevel11;
                                        listReportes.Add(_mapper.Map<UserProcessDto>(obj1));
                                    }
                                }
                            }
                        }
                    }
                    data.Gerencia = listGerencia;
                    data.Administracion = listAdministracion;
                    data.Produccion = listProduccion;
                    data.Facturacion = listFacturacion;
                    data.Consultas = listConsultas;
                    data.Reportes = listReportes;
                    response.Data = data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(response.Message, ex);
                return null;
            }
            return response;
        }

        public async Task<Response<GetUserResponseDto>> getUserById(int id)
        {
            var response = new Response<GetUserResponseDto>();
            try
            {
                var user = await _userLoginDomain.GetByIdAsync(id);
                if (user != null)
                {
                    response.Data = _mapper.Map<GetUserResponseDto>(user);
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                _logger.LogError(ex.Message, ex);
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<string>> LoginUser(string username, string password)
        {
            var response = new Response<string>();
            try
            {
                var user = await _userLoginDomain.UserLogin(username, password);

                if (user == null)
                {
                    response.Data = null;
                    response.IsSuccess = false;
                }
                else
                {
                    response.Data = await GenerateToken(user);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateProcess(AddOrUpdateUserProcessRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                foreach (var item in obj.Gerencia)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                foreach (var item in obj.Produccion)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                foreach (var item in obj.Administracion)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                foreach (var item in obj.Facturacion)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                foreach (var item in obj.Consultas)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                foreach (var item in obj.Reportes)
                {
                    if (item.SubLevel.Count > 0)
                    {
                        foreach (var item1 in item.SubLevel)
                        {
                            if (item1.SubLevel.Count > 0)
                            {
                                foreach (var item2 in item1.SubLevel)
                                {
                                    var process2 = await _userProcessDomain.GetByIdAsync(item2.Id);
                                    if (process2 != null)
                                    {
                                        process2 = _mapper.Map(item2, process2);
                                        await _userProcessDomain.UpdateAsync(process2);
                                    }
                                }
                            }
                            var process1 = await _userProcessDomain.GetByIdAsync(item1.Id);
                            if (process1 != null)
                            {
                                process1 = _mapper.Map(item1, process1);
                                await _userProcessDomain.UpdateAsync(process1);
                            }
                        }
                    }
                    var process = await _userProcessDomain.GetByIdAsync(item.Id);
                    if (process != null)
                    {
                        process = _mapper.Map(item, process);
                        await _userProcessDomain.UpdateAsync(process);
                    }
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateUserProcessAsync()
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var process = await context.Processes.ToListAsync();
                var userProcess = await context.UserProcesses.ToListAsync();
                var idUsers = userProcess.DistinctBy(x => x.IdUser);
                foreach (var item1 in idUsers)
                {
                    var up = userProcess.Where(x => x.IdUser == item1.IdUser).ToList();
                    if (up.Count != process.Count)
                    {
                        foreach (var item in process)
                        {
                            var process2 = userProcess.Where(x => x.IdProcess == item.Id).FirstOrDefault();
                            if (process2 == null)
                            {
                                await context.UserProcesses.AddAsync(new UserProcess
                                {
                                    IdProcess = item.Id,
                                    IdUser = item1.IdUser
                                });
                            }
                        }
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
                response.IsSuccess = false;
            }
            return response;
        }

        private async Task<string> GenerateToken(UserLogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            if(user.HasHolder == true)
            {
                user.Id = (int)user.IdHolder;
            }

            var claims = new[]
            {
                new Claim("IdUser",user.Id.ToString()),
                new Claim("IdEmployee",user.IdEmployee.ToString()),
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
