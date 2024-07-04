using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Transversal.Common.JsonReader
{
    public class EmailSettings
    {
        public bool IsDebugging { get; set; }
        public bool IsMultipleDomain { get; set; }
        public DomainConfiguration? PrincipalDomain { get; set; }
        public List<DomainConfiguration>? OtherDomainsConfiguration { get; set; }

    }
    public partial class Traduction
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string Identifier { get; set; } = null!;

        public int? IdLanguage { get; set; }

        public string? ShortValue { get; set; }

        public string? LargeValue { get; set; }

        public decimal? NumberValue { get; set; }

        public int? IntValue { get; set; }

        public bool? Flag1 { get; set; }

        public bool? Flag2 { get; set; }

        public bool? Flag3 { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? LastUpdaterUser { get; set; }

        public DateTime? DeleteDate { get; set; }

        public bool? Enable { get; set; }
    }
    public class SpecialPriceAgent
    {
        public string? CodeAgent {get; set;}
        public List<QualityAgent>? QualityAgent { get; set; }
    }

    public class TicketPath
    {
       public string Path { get; set; }
    }
    public class QualityAgent
    {
        public string? Quality { get; set; }
        public ProcedureTypePrice? Price { get; set; }
    }
    public class ProcedureTypePrice
    {
        public decimal? T1 { get; set; }
        public decimal? T2 { get; set; }
        public decimal? T3 { get; set; }
    }
    public class DomainConfiguration
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public Credential? Credential { get; set; }

    }
    public class Credential
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
