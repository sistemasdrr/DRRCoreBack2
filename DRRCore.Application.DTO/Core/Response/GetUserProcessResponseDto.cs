namespace DRRCore.Application.DTO.Core.Response
{
    public class GetUserProcessResponseDto
    {
        public List<UserProcessDto>? Gerencia { get; set; }
        public List<UserProcessDto>? Produccion { get; set; }
        public List<UserProcessDto>? Administracion { get; set; }
        public List<UserProcessDto>? Facturacion { get; set; }
    }
    public class UserProcessDto
    {
        public int Id { get; set; }
        public int IdProcess { get; set; }
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }
        public bool Enable { get; set; }
        public List<UserProcessDto>? SubLevel{ get; set; }
    }
}
