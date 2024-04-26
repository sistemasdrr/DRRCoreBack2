using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Transversal.Common
{
    public class MailFormatter : IMailFormatter
    {
        public async Task<string> GetEmailBody(string emailKey,string body,List<string> parameters, List<List<string>> table)
        {
           switch (emailKey)
            {
                case Constants.DRR_SYS_ENG_0003:
                case Constants.DRR_SYS_0001:
                case Constants.DRR_SYS_0002:
                case Constants.DRR_SYS_ESP_0003:
                case Constants.DRR_WORKFLOW_ENG_0023:
                case Constants.DRR_WORKFLOW_ENG_0032:
                case Constants.DRR_WORKFLOW_ENG_0039:
                case Constants.DRR_WORKFLOW_ENG_0039_ERROR:
                case Constants.DRR_WORKFLOW_ESP_0016:
                case Constants.DRR_WORKFLOW_ESP_0017:
                case Constants.DRR_WORKFLOW_ESP_0018:
                case Constants.DRR_WORKFLOW_ESP_0021:
                case Constants.DRR_WORKFLOW_ESP_0022:
                case Constants.DRR_WORKFLOW_ESP_0023:
                case Constants.DRR_WORKFLOW_ESP_0024:
                case Constants.DRR_WORKFLOW_ESP_0025:
                case Constants.DRR_WORKFLOW_ESP_0026:
                case Constants.DRR_WORKFLOW_ESP_0027:
                    return GetHtmlStringBody(body, parameters);
                case Constants.DRR_WORKFLOW_ENG_0027:
                    return GetHtmlStringBody(body, parameters);
                case Constants.DRR_WORKFLOW_ESP_0032:
                case Constants.DRR_WORKFLOW_ESP_0033:
                case Constants.DRR_WORKFLOW_ESP_0034:
                case Constants.DRR_WORKFLOW_ESP_0035:
                case Constants.DRR_WORKFLOW_ESP_0036:
                case Constants.DRR_WORKFLOW_ESP_0037:
                case Constants.DRR_WORKFLOW_ESP_0038:
                case Constants.DRR_WORKFLOW_ESP_0039:
                case Constants.DRR_WORKFLOW_ESP_0039_ERROR:
                case Constants.DRR_EECORE_ENG_QUERYTICKET:
                case Constants.DRR_EECORE_ESP_QUERYTICKET:
                    return GetHtmlStringBody(body,parameters);
                case Constants.DRR_WORKFLOW_ENG_0001:
                case Constants.DRR_WORKFLOW_ESP_0001:
                case Constants.DRR_WORKFLOW_ESP_0003:
                case Constants.DRR_WORKFLOW_ESP_0005:
                case Constants.DRR_WORKFLOW_ESP_0007:
                case Constants.DRR_WORKFLOW_ESP_0008:
                case Constants.DRR_WORKFLOW_ESP_0009:
                    return GetHtmlStringBodyWithTable_DRR_WORKFLOW_SIXCOLUMN(body,parameters,table);
                case Constants.DRR_WORKFLOW_ENG_0002:
                case Constants.DRR_WORKFLOW_ESP_0002:
                    return GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_ENG_0002(body, parameters, table);
                case Constants.DRR_WORKFLOW_ENG_0020:
                case Constants.DRR_WORKFLOW_ESP_0020:
                case Constants.DRR_WORKFLOW_ESP_0028:
                case Constants.DRR_WORKFLOW_ESP_0029:
                case Constants.DRR_WORKFLOW_ESP_0030:
                case Constants.DRR_WORKFLOW_ESP_0031:
                    return GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_ENG_0020(body, parameters, table);
                case Constants.DRR_WORKFLOW_ESP_0004:
                case Constants.DRR_WORKFLOW_ESP_0006:
                    return GetHtmlStringBodyWithTable_DRR_WORKFLOW_FIVECOLUMN(body, parameters, table);
                case Constants.DRR_WORKFLOW_ESP_0019:
                    return GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_0019(body, table);
                default:
                    return body;

            }
        }

        private string GetHtmlStringBody(string body, List<string> parameters)
        {
            return StringFormat(body,parameters);
        }
        private string StringFormat(string body, List<string> parameters)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                body = body.Replace("{" + i + "}", parameters[i]);
            }
            return body;
        }
        private string GetHtmlStringBodyWithTable_DRR_WORKFLOW_SIXCOLUMN(string body, List<string> parameters, List<List<string>> table)
        {
            body = StringFormat(body, parameters);
            
            string tableString=string.Empty;
            int i = 0;
            string rowStyle = "";
            foreach (var tableItem in table)
            {
                if ((i % 2) == 0) rowStyle = "  ";
                else rowStyle = " background-color: #FAF7F7; ";

                i++;
                var rowString = string.Empty;
                rowString = "<tr style='" + rowStyle + "'>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;'> {0}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{1}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{2}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{3}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{4}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{5}</td>" +
                    "</tr>";
                rowString= StringFormat(rowString, tableItem);
                tableString += rowString;
            }
            return body.Replace(Constants.TABLEBODY, tableString);
           
        }
        private string GetHtmlStringBodyWithTable_DRR_WORKFLOW_FIVECOLUMN(string body, List<string> parameters, List<List<string>> table)
        {
            body = StringFormat(body, parameters);

            string tableString = string.Empty;
            int i = 0;
            string rowStyle = "";
            foreach (var tableItem in table)
            {
                if ((i % 2) == 0) rowStyle = "  ";
                else rowStyle = " background-color: #FAF7F7; ";

                i++;
                var rowString = string.Empty;
                rowString = "<tr style='" + rowStyle + "'>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;'> {0}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{1}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{2}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{3}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{4}</td>" +                  
                    "</tr>";
                rowString = StringFormat(rowString, tableItem);
                tableString += rowString;
            }
            return body.Replace(Constants.TABLEBODY, tableString);

        }
        private string GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_ENG_0002(string body, List<string> parameters, List<List<string>> table)
        {
            body = StringFormat(body, parameters);

            string tableString = string.Empty;
            int i = 0;
            string rowStyle = "";
            foreach (var tableItem in table)
            {
                if ((i % 2) == 0) rowStyle = "  ";
                else rowStyle = " background-color: #FAF7F7; ";

                i++;
                var rowString = string.Empty;
                rowString = "<tr style='" + rowStyle + "'>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{0}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;'> {1}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{2}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{3}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{4}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{5}</td>" +
                    "</tr>";
                rowString = StringFormat(rowString, tableItem);
                tableString += rowString;
            }
            return body.Replace(Constants.TABLEBODY, tableString);

        }
        private string GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_ENG_0020(string body, List<string> parameters, List<List<string>> table)
        {
            body = StringFormat(body, parameters);

            string tableString = string.Empty;
            int i = 0;
            string rowStyle = "";
            foreach (var tableItem in table)
            {
                if ((i % 2) == 0) rowStyle = "  ";
                else rowStyle = " background-color: #FAF7F7; ";

                i++;
                var rowString = string.Empty;
                rowString = "<tr style='" + rowStyle + "'>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{0}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{1}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{2}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{3}</td>" +
                    "</tr>";
                rowString = StringFormat(rowString, tableItem);
                tableString += rowString;
            }
            return body.Replace(Constants.TABLEBODY, tableString);

        }
        private string GetHtmlStringBodyWithTable_DRR_WORKFLOW_ESP_0019(string body, List<List<string>> table)
        {

            
            string tableString = string.Empty;
            int i = 0;
            string rowStyle = "";
            foreach (var tableItem in table)
            {
                if ((i % 2) == 0) rowStyle = "  ";
                else rowStyle = " background-color: #FAF7F7; ";

                i++;
                var rowString = string.Empty;
                rowString = "<tr style='" + rowStyle + "'>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{0}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{1}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{2}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;'>{3}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{4}</td>" +
                    "<td style='padding:5px;Margin:0;font-size:13px;text-align: center;'>{5}</td>" +
                    "</tr>";
                rowString = StringFormat(rowString, tableItem);
                tableString += rowString;
            }
            return body.Replace(Constants.TABLEBODY, tableString);

        }
       
    }
}
