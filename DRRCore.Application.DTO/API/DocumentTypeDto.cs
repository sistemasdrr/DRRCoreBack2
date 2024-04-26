using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.API
{
    public class DocumentTypeDto
    {
        [JsonPropertyName("DRR_DOCTYP_TYPDOC")]
        public string TypeDocument { get; set; } = string.Empty;
        [JsonPropertyName("DRR_DOCTYP_NUMDOC")]
        public string NumberDocument { get; set; } = string.Empty;

    }
}
