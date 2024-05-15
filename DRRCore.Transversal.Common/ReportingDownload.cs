using AspNetCore.Reporting;
using DRRCore.Transversal.Common.Interface;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using System.Text;

namespace DRRCore.Transversal.Common
{
    public class ReportingDownload : IReportingDownload
    {
        public async Task<byte[]> GenerateReportAsync(string reportName, ReportRenderType render, Dictionary<string, string> parameters)
        {
            try
            {

                ReportResponse result = null;

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("windows-1252");

                return new ServerReport(new ReportSettings()
                {
                    ReportServer = "https://sql5090.site4now.net/ReportServer",
                    Credential = new NetworkCredential("admindrrreports-001", "drrti2023"),

                }).Execute(new ReportRequest
                {
                    Name = reportName,
                    Path = "/admindrrreports-001/" + reportName,
                    RenderType = render,
                    ExecuteType = ReportExecuteType.Export,
                    Reset = true,
                    Parameters = parameters

                }).Data.Stream;
            }
            catch (Exception ex)
            {
                var xx = ex.InnerException; 
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<byte[]> GenerateSubReportAsync(string reportName, ReportRenderType render, Dictionary<string, string> parameters)
        {
            try
            {

                ReportResponse result = null;

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("windows-1252");

               
                return new ServerReport(new ReportSettings()
                {
                    ReportServer = "https://sql5090.site4now.net/ReportServer",
                    Credential = new NetworkCredential("admindrrreports-001", "drrti2023"),

                }).Execute(new ReportRequest
                {
                    Name = reportName,
                    Path = reportName,
                    RenderType = render,
                    ExecuteType = ReportExecuteType.Export,
                    Reset = true,
                    Parameters = parameters

                }).Data.Stream;
            }
            catch (Exception ex)
            {
                var xx = ex.InnerException;
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<byte[]> GenerateCombinedReportAsync(List<string> reportNames, ReportRenderType render, Dictionary<string, string> parameters)
        {
            List<byte[]> files = new List<byte[]>();
            try
            {
                foreach (var reportName in reportNames)
                {
                    byte[] reportData = await GenerateSubReportAsync(reportName, render, parameters);
                    files.Add(reportData);
                }

                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (Document document = new Document())
                    using (PdfCopy copy = new PdfCopy(document, outputStream))
                    {
                        document.Open();
                        document.SetMargins(1, 1, 1, 1);
                        document.SetPageSize(document.PageSize);
                        foreach (var file in files)
                        {
                            using (PdfReader reader = new PdfReader(file))
                            {
                                for (int i = 1; i <= reader.NumberOfPages; i++)
                                {
                                    copy.AddPage(copy.GetImportedPage(reader, i));
                                }
                            }
                        }
                    }
                    return outputStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generating report: {ex.Message}", ex);
            }
        }

    }
}


