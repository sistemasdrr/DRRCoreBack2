using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyFinancialInformationResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? Interviewed { get; set; }

        public string? WorkPosition { get; set; }

        public int? IdCollaborationDegree { get; set; }

        public string? InterviewCommentary { get; set; }

        public string? Auditors { get; set; }

        public int? IdFinancialSituacion { get; set; }

        public string? ReportCommentWithBalance { get; set; }

        public string? ReportCommentWithoutBalance { get; set; }

        public string? FinancialCommentarySelected { get; set; }

        public string? MainFixedAssets { get; set; }

        public string? AnalystCommentary { get; set; }

        public string? TabCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();

    }
}
