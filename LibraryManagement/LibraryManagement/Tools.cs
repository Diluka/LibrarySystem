using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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

   class Logger
   {
       private static Logger _log;

       //private FileStream fs;
       private StreamWriter writer;
       private Logger(string path)
       {
           try
           {
               if (!Directory.Exists(@"logs\"))
               {
                   Directory.CreateDirectory(@"logs\");
               }
               writer = File.CreateText(path);
               //writer = new StreamWriter(fs);
           }
           catch (IOException ex)
           {
               Console.WriteLine(ex.Message);
           }
       }

       public static void Log(Exception ex)
       {
           if (_log == null)
           {
               _log = new Logger(string.Format(@"logs\log_{0}.txt", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss")));
           }

           _log.writer.WriteLine(string.Format(
@"记录时间：{0}
----------------------------------------------------------------------------
异常详细信息：{1}
============================================================================

"
                           , DateTime.Now, ex));

           _log.writer.Flush();
       }

   }
}
