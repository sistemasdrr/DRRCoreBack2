namespace DRRCore.Transversal.Common.Interface
{
    public interface IMailFormatter
    {
        Task<string> GetEmailBody(string emailKey,string body, List<string> parameters, List<List<string>> table);
    }
}
