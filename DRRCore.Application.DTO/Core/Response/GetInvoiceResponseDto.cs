using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetInvoiceResponseDto
    {
    }
    public class GetPersonalResponseDto
    {
        public int IdUser { get; set; }
        public int? IdEmployee { get; set; }
        public string? Type { get; set; }
        public string? Code { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }

    }

}
