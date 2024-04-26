using DRRCore.Application.DTO.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Request
{
    
    public class AssignTicketRequestDto
    {
        public string? UserFrom { get; set; }
        public string? UserTo { get; set; }
        public string? AssignedFromCode { get; set; }
        public string? AssignedToCode { get; set; }
        public string? AssignedToName { get; set; }      
        public bool References { get; set; }
        public string? Observations { get; set; }
        public string? Type { get; set; }
       // public string? Commentary { get; set; }
        public string? Quality { get; set; }
        public bool Internal { get; set; }
        public bool Balance { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int IdTicket { get; set; }
        public int? NumberAssign { get; set; }
    }
    public class NewAsignationDto
    {

        public int? IdTicketHistory { get; set; }
        public string? AsignedTo { get; set; }
        public List<AssignTicketRequestDto>? Asignacion { get; set; }
        public List<UserCode>? OtherUserCode { get; set; }
    }
}


