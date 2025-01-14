using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketHistoryToDeleteResponseDto
    {
        public int Id { get; set; }
        public string AsignedName { get; set; } = string.Empty;
        public string AsignedType { get; set; } = string.Empty;
        public string AsignedDate { get; set; } = string.Empty;
        public string AsignedEnd { get; set; } = string.Empty;
    }
}
