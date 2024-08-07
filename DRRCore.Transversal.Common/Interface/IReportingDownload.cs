﻿using AspNetCore.Reporting;

namespace DRRCore.Transversal.Common.Interface
{
    public interface IReportingDownload
    {
        Task<byte[]> GenerateReportAsync(string reportName, ReportRenderType render, Dictionary<string, string> parameters);
        Task<byte[]> GenerateSubReportAsync(string reportName, ReportRenderType render, Dictionary<string, string> parameters);
        Task<byte[]> GenerateCombinedReportAsync(List<string> reportNames, ReportRenderType render, Dictionary<string, string> parameters);

    }
}
