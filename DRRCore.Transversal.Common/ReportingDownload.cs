using AspNetCore.Reporting;
using DRRCore.Transversal.Common.Interface;
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
    }

       
    }


