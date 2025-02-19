﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Entities.SqlCoreContext
{
    public  class StaticsByCountry
    {
        public int ConInforme { get; set; }
        public int SinInforme { get; set; }   
        public int Eliminado { get; set; }  
        public int A {  get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int SinQ { get; set; }
    }

    public class Report7_10_1
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Counting { get; set; }
        public string? About { get; set; }
        public string? LastSearched { get; set; }
    }
    public class Report7_10_2
    {
        public List<Report7_10_2_Main> Main { get; set; } = new List<Report7_10_2_Main>();
        public List<Report7_10_2_Details> Details { get; set; } = new List<Report7_10_2_Details>();
    }

    public class Report7_10_2_Main
    {
        public string? OrderDate { get; set; }
        public string? DispatchtDate { get; set; }
        public string? Name { get; set; }
        public string? ProcedureType { get; set; }
    }
    public class Report7_10_2_Details
    {
        public string? Name { get; set; }
        public int? Counting { get; set; }
    }
    public class GetAgentInvoice
    {
        public int IdTicketHistory { get; set; }
        public int IdAgent { get; set; }
        public string? Number { get; set; }
        public string? AsignedTo { get; set; }
        public string? RequestedName { get; set; }
        public string? OrderDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? RealExpireDate { get; set; }
        public int? IdCountry { get; set; }
        public string? Iso { get; set; }
        public string? Flag { get; set; }
        public string? Quality { get; set; }
        public string? ProcedureType { get; set; }
        public decimal? Price { get; set; }
        public bool? HasBalance { get; set; }
        public int? IdSpecialAgentBalancePrice{ get; set; }
        public bool? IsComplement { get; set; }
        public int? IdTicketComplement { get; set; }
    }
    public class GetInternalInvoice
    {
        public int? Id { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public bool? IsComplement { get; set; }
        public int? IdTicketHistory { get; set; }
        public int? Number { get; set; }
        public string? AsignedTo { get; set; }
        public string? AsignationType { get; set; }
        public string? RequestedName { get; set; }
        public string? Quality { get; set; }
        public string? Country { get; set; }
        public string? Flag { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public string? About { get; set; }
        public decimal Price { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }      
    }


    public class PriceResult
    {
        public decimal Price { get; set; }
    }

}
