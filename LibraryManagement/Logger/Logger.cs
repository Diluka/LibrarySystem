using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger
    {
        private FileStream fs;
        private StreamWriter writer;
        public Logger(string path)
        {
            try
            {
                fs = File.OpenWrite(path);
                writer = new StreamWriter(fs);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ~Logger()
        {
            try
            {
                writer.Close();
                fs.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Log(Exception ex)
        {
            writer.WriteLine(string.Format(
@"记录时间：{0}
----------------------------------------------------------------------------
异常详细信息：{1}
============================================================================

"
                            , DateTime.Now, ex));
        }


    }
}
