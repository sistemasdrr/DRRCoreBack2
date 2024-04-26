using AspNetCore.Reporting;

namespace DRRCore.Transversal.Common
{
    public static class StaticFunctions
    {
        public static DateTime? VerifyDate(string date)
        {
            DateTime result;
            if (string.IsNullOrEmpty(date)) return null;

            if(DateTime.TryParse(date, out result))
            {
                if(result>=DateTime.Parse("01/01/1753") && result<= DateTime.Parse("31/12/9999"))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            return null;
            
        }
        public static DateTime? VerifyDate(DateTime? date)
        {
            string valueDate= DateTimeToString(date);
            DateTime result;
            if (string.IsNullOrEmpty(valueDate)) return null;

            if (DateTime.TryParse(valueDate, out result))
            {
                if (result >= DateTime.Parse("01/01/1753") && result <= DateTime.Parse("31/12/9999"))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            return null;

        }

        public static string DateTimeToString(DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy");
        }
        public static ReportRenderType GetReportRenderType(string typeFile)
        {
            switch (typeFile)
            {
                case "pdf":
                    return ReportRenderType.Pdf;
                case "excel":
                    return ReportRenderType.ExcelOpenXml;
                case "word":
                    return ReportRenderType.WordOpenXml;
                default:
                    return ReportRenderType.Null;
            }
        }
        public static string GetContentType(ReportRenderType reportRenderType)
        {
            switch (reportRenderType)
            {
                case ReportRenderType.Pdf:
                    return "application/pdf";
                case ReportRenderType.ExcelOpenXml:
                    return "application/vnd.ms-excel";
                case ReportRenderType.WordOpenXml:
                    return "application/msword";
                default:
                    return string.Empty;
            }
        }
        public static string FileExtension(ReportRenderType reportRenderType)
        {
            switch (reportRenderType)
            {
                case ReportRenderType.Pdf:
                    return ".pdf";
                case ReportRenderType.Excel:
                    return "xls";
                case ReportRenderType.Word:
                    return "application/msword";
                default:
                    return string.Empty;
            }
        }
    }
}
