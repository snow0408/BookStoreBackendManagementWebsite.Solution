using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BookStore202401.Models.Infra
{
    public class HashUtility
    {
        //這裡是寫加密的程式碼
        public static string ToSHA256(string plainText, string salt)
        {
            using (var mySHA256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(salt + plainText);
                var hash = mySHA256.ComputeHash(passwordBytes);
                var sb = new StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("X2"));

                return sb.ToString();
            }
        }

        //這裡是寫產生salt的程式碼
        //salt為亂數，用來增加密碼的複雜度
        public static string GetSalt()
        {
            return System.Configuration.ConfigurationManager.AppSettings["salt"];
        }
    }
}