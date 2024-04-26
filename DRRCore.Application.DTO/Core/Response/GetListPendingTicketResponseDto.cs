using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListPendingTicketResponseDto
    {
        public int Id { get; set; }
        public string Number { get; set; }=string.Empty;
        public string Name { get; set; }=string.Empty;
        public string ReportType { get;set; }=string.Empty;
        public string ProcedureType { get; set; } = string.Empty;
        public string OrderDate { get; set; }=string.Empty;
        public string RealExpireDate { get; set; } = string.Empty;
        public string ExpireDate { get; set; } = string.Empty;
        public string DispatchtDate { get; set; } = string.Empty;

        public int Receptor { get; set; }
        public int Receptor2 { get; set; }
        public string Commentary { get; set; }=string.Empty;
        public bool HasFiles { get; set; }
        public List<TicketFileResponseDto> Files { get; set; } = new List<TicketFileResponseDto>();
     }
    public class TicketFileResponseDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
    } 
}
