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
