using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{   
    public class ReportDto
    {
        [JsonPropertyName("DRR_REQCLI")]
        [JsonPropertyOrder(0)]
        public RequestClientDto RequestClient { get; set; }=new RequestClientDto();

        [JsonPropertyName("DRR_INFORM")]
        [JsonPropertyOrder(1)]
        public InformationDto Information { get; set; } =new InformationDto();

        [JsonPropertyName("DRR_SUMMAR")]
        [JsonPropertyOrder(2)]
        public SummaryDto Summary { get; set; } = new SummaryDto();

        [JsonPropertyName("DRR_LEGBAC")]
        [JsonPropertyOrder(3)]
        public LegalBackgroundDto LegalBackground { get; set; }= new LegalBackgroundDto();

        [JsonPropertyName("DRR_EXECUT")]
        [JsonPropertyOrder(4)]
        public ExecutiveShareholderDto Executives { get; set; } = new ExecutiveShareholderDto();

        [JsonPropertyName("DRR_WISWHO")]
        [JsonPropertyOrder(5)]
        public List<WhoIsWhoDto> WhoIsWho { get; set; }= new List<WhoIsWhoDto>();

        [JsonPropertyName("DRR_PLAHOL")]
        [JsonPropertyOrder(6)]
        public List<PlaceholderDto> Placeholders { get; set; }=new List<PlaceholderDto>();

        [JsonPropertyName("DRR_BUSHIS")]
        [JsonPropertyOrder(7)]
        public string BussinessHistory { get; set; } = string.Empty;

        [JsonPropertyName("DRR_RELCOM")]
        [JsonPropertyOrder(8)]
        public List<RelatedCompanyDto> RelatedCompanies { get; set;} = new List<RelatedCompanyDto>();

        [JsonPropertyName("DRR_BUSINE")]
        [JsonPropertyOrder(9)]
        public BusinessDto Business { get; set; } = new BusinessDto();

        [JsonPropertyName("DRR_FININF")]
        [JsonPropertyOrder(10)]
        public FinancialInformationDto FinancialInformation { get; set; }= new FinancialInformationDto();

        [JsonPropertyName("DRR_BANINF")]
        [JsonPropertyOrder(11)]
        public BankingInformationDto BankingInformation { get; set; }=new BankingInformationDto();

        [JsonPropertyName("DRR_PAYREC")]
        [JsonPropertyOrder(12)]
        public PaymentRecordsDto PaymentRecords { get; set; }=  new PaymentRecordsDto();

        [JsonPropertyName("DRR_NEWSTO")]
        [JsonPropertyOrder(13)]
        public string News { get; set; } = string.Empty;

    }
}
