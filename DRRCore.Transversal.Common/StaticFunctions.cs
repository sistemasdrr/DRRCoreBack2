using AspNetCore.Reporting;
using System.Globalization;

namespace DRRCore.Transversal.Common
{
    public static class StaticFunctions
    {
        public static DateTime? VerifyDate(string date)
        {
            var cultureInfo = new CultureInfo("es-ES");
            DateTime result;

            if (string.IsNullOrEmpty(date)) return null;

            // Intentar parsear la fecha en diferentes formatos comunes
            string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/MM/yy" };

            if (DateTime.TryParseExact(date, formats, cultureInfo, DateTimeStyles.None, out result))
            {
                // Verificar que la fecha está dentro del rango permitido
                if (result >= DateTime.ParseExact("01/01/1753", "dd/MM/yyyy", cultureInfo) && result <= DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", cultureInfo))
                {
                    return result;
                }
            }

            return null;
        }

        public static DateTime? VerifyDate(DateTime? date)
        {
            var cultureInfo = new CultureInfo("es-ES");
            string valueDate= DateTimeToString(date);
            DateTime result;
            if (string.IsNullOrEmpty(valueDate)) return null;

            if (DateTime.TryParse(valueDate, out result))
            {
                ////publicado
                //if (result >= DateTime.Parse("01/01/1753") && result <= DateTime.Parse("12/31/9999"))

                if (result >= DateTime.ParseExact("01/01/1753", "dd/MM/yyyy", cultureInfo) && result <= DateTime.ParseExact("01/01/9999", "dd/MM/yyyy", cultureInfo))
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
                    return ".xls";
                case ReportRenderType.Word:
                    return "application/msword";
                default:
                    return string.Empty;
            }
        }
    }
}
