using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Utils.SecurityUtils
{
    public class SecurityUtils
    {

        public static String HashSHA1(String plainText)
        {
            return GetSHA1HashData(plainText);
        }

        public static bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            string getHashInputData = GetSHA1HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
                return true;
            else
                return false;
        }

        public static String HashHMAC256(String plainText, string secretKey)
        {
            return GetHMACSHA256HashData(plainText, secretKey);
        }

        public static string GenerateUniqueKey()
        {
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] data = new byte[128];
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int _);
        }


        public static bool ValidateHMAC256HashData(string inputData, string signature, string secretKey)
        {
            string getHashInputData = GetHMACSHA256HashData(inputData, secretKey);

            if (string.Compare(getHashInputData, signature) == 0)
                return true;
            else
                return false;
        }

        public static string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        public static bool ValidateToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
                return false;

            return true;

        }
        public static string GeneratePassword(int len = 12)
        {
            string res = "";
            Random rnd = new Random();
            while (res.Length < len) res += (new Func<Random, string>((r) => {
                char c = (char)((r.Next(123) * DateTime.Now.Millisecond % 123));
                return (Char.IsLetterOrDigit(c)) ? c.ToString() : "";
            }))(rnd);
            return res;
        }

        #region Private Methods
        private static string GetSHA1HashData(string data)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] byteV = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteH = SHA1.ComputeHash(byteV);

            SHA1.Clear();

            return Convert.ToBase64String(byteH);
        }


        private static string GetHMACSHA256HashData(string plainText, string secretKey)
        {
            var byteKey = Encoding.UTF8.GetBytes(secretKey);
            string hashString;

            using (var hmac = new HMACSHA256(byteKey))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                hashString = Convert.ToBase64String(hash);
            }

            return hashString;
        }

        public static string GetShortUniqueKey(int maxSize = 8)
        {

            char[] chars = new char[62];
            string a;

            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();

            int size = maxSize;
            byte[] data = new byte[1];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];

            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);

            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }

            return result.ToString();
        }



        #endregion

    }
}
