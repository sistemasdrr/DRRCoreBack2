using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Request
{
    public class GetTicketToDeleteRequestDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }=string.Empty;
        public string RequestName { get; set; } = string.Empty;
        public string Country { get; set; }= string.Empty;
        public string IsoFlagCountry { get; set; } = string.Empty;
        public string SubscriberCode { get; set; } = string.Empty;
        public string ProcedureType { get; set; } = string.Empty;
        public string ReportType { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string ExpireDate { get; set; } = string.Empty;
    }
}
