using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.ConsoleApp
{
    public class Logger
    {
        public async Task Log(string logMessage)
        {
            try
            {
                string dirPath = @"D:\Log";
                string fileName = Path.Combine(@"D:\Log", "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                await WriteToLog(dirPath, fileName, logMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task WriteToLog(string dir, string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file), true))
            {
                await outputFile.WriteLineAsync(string.Format("Logged on: {1} at: {2}{0}Message: {3} at {4}{0}--------------------{0}",
                          Environment.NewLine, DateTime.Now.ToLongDateString(),
                          DateTime.Now.ToLongTimeString(), content, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss.fff")));
            }
        }
    }
}
