using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MTiendaDrr
{
    public int? Id { get; set; }

    public string? Proveedor { get; set; }

    public DateTime? Fecha { get; set; }

    public string? TxId { get; set; }

    public string? TxIdioma { get; set; }

    public string? TxFecha { get; set; }

    public string? TxContacto { get; set; }

    public string? TxEmpresa { get; set; }

    public string? TxRuc { get; set; }

    public string? TxPais { get; set; }

    public string? TxEmail { get; set; }

    public int? TxCantidad { get; set; }

    public decimal? TxPrecioTotal { get; set; }

    public string? InfCodigo { get; set; }

    public string? InfNombre { get; set; }

    public string? InfIdioma { get; set; }

    public decimal? InfPrecio { get; set; }

    public string? InfTipo { get; set; }

    public int? InfFlag { get; set; }

    public sbyte? Migra { get; set; }
}
