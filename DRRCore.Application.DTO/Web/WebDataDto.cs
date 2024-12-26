namespace DRRCore.Application.DTO.Web
{
    public class WebDataDto
    {
        public string TaxId { get; set; }=string.Empty;
        public string NombreEmpresa { get; set; } = string.Empty;
        public string PaisEmpresa { get; set; } = string.Empty;
        public string UltimoReporte { get; set; } = string.Empty;
        public string FundacionEmpresa { get; set; } = string.Empty;
        public string DireccionEmpresa { get; set; } = string.Empty;
        public string DepartamentoEmpresa { get; set; } = string.Empty;
        public string SectorEmpresa { get; set; } = string.Empty;
        public string SectorEmpresaIngles { get; set; } = string.Empty;
        public string CeoEmpresa { get; set; } = string.Empty;
        public string UltimobalanceEmpresa { get; set; } = string.Empty;
        public string CalidadDisponibleEsp { get; set; } = string.Empty;
        public string CalidadDisponibleEng { get; set; } = string.Empty;
        public int CodigoIdioma { get; set; } = 0;
        public object CodigoEmpresaWeb { get; set; } = string.Empty;
    }
    public class WebDTO
    {
        public string? TransactionCode { get; set; }
        public string? TypeTransaction { get; set; }
        public string? Date { get; set; }
        public string? User { get; set; }
        public string? UserCountry { get; set; }
        public string? UserEmail { get; set; }
        public string? OldCode { get; set; }
        public string? Name { get; set; }
        public string? RequestedName { get; set; }
        public string? TaxCode { get; set; }
        public string? Language { get; set; }
        public decimal? Price { get; set; }
        public string? Quality { get; set; }
    }
}

  
  
