using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.MODEL.Logger
{
    public class GenerateLog
    {
        #region Generate Log
        /// <summary>
        /// Code written to generate log
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            try
            {
                var logPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log";
                var fileName = @"\LogData_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt";
                try
                {
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                }
                catch (Exception ex)
                {
                    GenerateLog.WriteLog(ex.ToString());
                }
                fileName = logPath + fileName;
                using (var w = File.AppendText(fileName))
                {
                    var timeStamp = "[" + DateTime.Now.ToString("HH:mm:ss", null) + "] ";
                    w.WriteLine(timeStamp + msg);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        #endregion
    }
}
