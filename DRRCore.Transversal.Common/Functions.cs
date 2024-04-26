using DRRCore.Transversal.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DRRCore.Transversal.Common
{
    public class Functions:IFunction
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Functions(IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        private async Task<byte[]> Decrypt(byte[] bytesToBeDecrypted, byte[] jwtKeyBytes)
        {
            byte[]? decryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream stream = new MemoryStream())
            {
                using RijndaelManaged AES = new RijndaelManaged();
                var key = new Rfc2898DeriveBytes(jwtKeyBytes, saltBytes, 1000);

                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(stream, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    await cs.WriteAsync(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                decryptedBytes = stream.ToArray();
            }
            return decryptedBytes;
        }

        public async Task<string> Decrypt(string token)
        {
          
            if (string.IsNullOrEmpty(token)) return string.Empty;


            try
            {
                var bytesToBeDecrypted = Convert.FromBase64String(token);
                var jwtKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]??string.Empty);
                jwtKey = SHA512.Create().ComputeHash(jwtKey);
                var bytesDecrypted =await Decrypt(bytesToBeDecrypted, jwtKey);
                return Encoding.UTF8.GetString(bytesDecrypted);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private async Task<byte[]> Encrypt(byte[] bytesToBeEncrypted, byte[] jwtKeyBytes)
        {
            byte[]? encryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream stream = new MemoryStream())
            {
                using RijndaelManaged AES = new();
                var key = new Rfc2898DeriveBytes(jwtKeyBytes, saltBytes, 1000);

                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(stream, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    await cs.WriteAsync(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }

                encryptedBytes = stream.ToArray();
            }
            return encryptedBytes;
        }

        public async Task<string> Encrypt(string token)
        {
            if (string.IsNullOrEmpty(token))
                return string.Empty;
          
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(token);
            var jwtKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]??string.Empty);

            jwtKey = SHA512.Create().ComputeHash(jwtKey);

            var bytesEncrypted =await Encrypt(bytesToBeEncrypted, jwtKey);

            return Convert.ToBase64String(bytesEncrypted);
        }

        public async Task<string> GetTokenByHeader()
        {
            var rqt = _httpContextAccessor.HttpContext.Request;
            string token = string.Empty;
            if (rqt.Headers.TryGetValue("Authorization", out var authHeaders) &&
                authHeaders.ToString().StartsWith("Bearer "))
            {
                token = authHeaders.ToString()["Bearer ".Length..];
            }
            return token;
        }

       
    }
}
