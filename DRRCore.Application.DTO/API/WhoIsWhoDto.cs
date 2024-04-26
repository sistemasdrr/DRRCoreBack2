using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class WhoIsWhoDto
    {
        [JsonPropertyName("DRR_WISWHO_NAAMEE")]
        public string Name { get; set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_TITTLE")]
        public string Title { get; set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_NACINL")]
        public string Nacionality { get; set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_BIRTHD")]
        public string Birthday { get; set;} = string.Empty;
        [JsonPropertyName("DRR_WISWHO_DOCTYP")]
        public DocumentTypeDto Document { get; set; } = new DocumentTypeDto();
        [JsonPropertyName("DRR_WISWHO_CIVSTA")]
        public string CivilStatus { get; set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_ADRESE")]
        public string Adreess { get;set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_PROFES")]
        public string Profession { get; set; }=string.Empty;
        [JsonPropertyName("DRR_WISWHO_PAYPOL")]
        public ValueDetailDto PaymentPolitic { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_WISWHO_FATNAM")]
        public string FatherName { get; set;} = string.Empty;
        [JsonPropertyName("DRR_WISWHO_BACINF")]
        public string BackgroundInformation { get; set;} = string.Empty;
        [JsonPropertyName("DRR_WISWHO_CHIEFX")]
        public bool? ChiefExecutive { get; set; } = false;
        [JsonPropertyName("DRR_WISWHO_ASOCOM")]
        public List<Associated> AssociatedCompanies { get; set; }=new List<Associated>();
        [JsonPropertyName("DRR_WISWHO_PARCOM")]
        public List<Participate> ParticipateCompanies { get; set; } = new List<Participate>();

    }
    public class Associated
    {
        [JsonPropertyName("DRR_ASSOCI_NAAMEE")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("DRR_ASSOCI_TITTLE")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("DRR_ASSOCI_REGNAM")]
        public string RegistrationNumber { get; set; } = string.Empty;
        [JsonPropertyName("DRR_ASSOCI_ISOCOU")]
        public string IsoCountry { get; set; } = string.Empty;
       
    }
    public class Participate
    {
        [JsonPropertyName("DRR_PARTIC_NAAMEE")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PARTIC_SINDAT")]
        public string SinceDate { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PARTIC_ISOCOU")]
        public string IsoCountry { get; set; } = string.Empty;
       
    }
}
