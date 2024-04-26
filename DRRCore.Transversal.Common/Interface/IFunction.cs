namespace DRRCore.Transversal.Common.Interface
{
    public interface IFunction
    {
        Task<string> Decrypt (string input);
        Task<string> Encrypt(string token);
        Task<string> GetTokenByHeader();
       

    }
}
