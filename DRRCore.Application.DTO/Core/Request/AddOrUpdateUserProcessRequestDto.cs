using DRRCore.Application.DTO.Core.Response;

namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateUserProcessRequestDto
    {
        public List<UserProcessDto>? Gerencia { get; set; }
        public List<UserProcessDto>? Produccion { get; set; }
        public List<UserProcessDto>? Administracion { get; set; }
        public List<UserProcessDto>? Facturacion { get; set; }
    }
}
