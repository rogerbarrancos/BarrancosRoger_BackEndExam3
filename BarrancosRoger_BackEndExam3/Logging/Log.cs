using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BarrancosRoger_BackEndExam3.Logging
{
    public class Log
    {

        public void logToFile(string exceptionMessage) {
            try
            {
                //Ruta de arhivo = BarrancosRoger_BackEndExam3\BarrancosRoger_BackEndExam3\bin\Debug\netcoreapp2.1
                using (FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "log.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    
                    StreamWriter streamWriter = new StreamWriter(file);
                    streamWriter.WriteLine((((System.DateTime.Now + " - ") + " - ") + " - ") + exceptionMessage);
                    streamWriter.Close();
                }
            }
            catch (IOException IOex) { }
            catch (UnauthorizedAccessException UAex) { }
        }
    }
}
