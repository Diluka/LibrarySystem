using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public static class EncryptionHelper
    {
        public static string ToSHA1(string source_String)
        {
            byte[] strRes = Encoding.Unicode.GetBytes(source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            strRes = iSHA.ComputeHash(strRes);
            iSHA.Dispose();
            return Convert.ToBase64String(strRes);
        }
    }
}
