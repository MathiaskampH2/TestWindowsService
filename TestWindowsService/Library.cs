using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsService
{
    /// <summary>
    /// Library class has 2 methods
    /// WriteErrorLog( Exception exception) method handles exceptions
    /// WriteErrorLog (String Message) gets the message
    /// </summary>
    public static class Library
    {
        public static void WriteErrorLog(Exception exception)
        {
            // new instance of streamWriter
            StreamWriter streamWriter = null;

            try
            {
                // adds the streamWriter to LogFile.txt in the root of this project
                streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                // adds timeStamp, Exception and exception message to the stremWriter
                streamWriter.WriteLine(DateTime.Now.ToString() + ": " + exception.Source.ToString().Trim() + "; " + exception.Message.ToString().Trim());
                // clean streamWriter
                streamWriter.Flush();
                // close StreamWriter
                streamWriter.Close();
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                streamWriter.WriteLine(DateTime.Now.ToString() + ": " + Message);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
    }
}
