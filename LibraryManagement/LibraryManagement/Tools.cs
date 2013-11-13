using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace LibraryManagement
{
   static class Tools
    {
        public static string ToSHA1(string str)
        {
            using (SHA1 sha1=new SHA1CryptoServiceProvider())
            {
                ASCIIEncoding enc=new ASCIIEncoding ();
                byte[] bytes = enc.GetBytes(str);
                byte[] hash = sha1.ComputeHash(bytes);

                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
