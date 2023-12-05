using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_12_OOP
{
    public class BVALog
    {
        public static void WriteLog()
        {
            string logPath = Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_12_OOP\Lab_12_OOP\bvalog.txt");

            using (StreamWriter sw = new StreamWriter(logPath, false, Encoding.Default))
            {
                sw.WriteLine("\n================= BVALog ===================");
                sw.WriteLine("Имя файла:    " + Path.GetFileName(logPath));
                sw.WriteLine("Путь файла:   " + logPath);
                sw.WriteLine("Время записи: " + DateTime.Now);
            }
        }

        public static void WriteInLog(string massage)
        {
            string logPath = Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_12_OOP\Lab_12_OOP\bvalog.txt");

            using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Default))
                sw.WriteLine(massage);
        }

        public static string ReadLog()
        {
            string logPath = Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_12_OOP\Lab_12_OOP\bvalog.txt");

            try
            {
                using (StreamReader sr = new StreamReader(logPath,  Encoding.Default))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
                return string.Empty;
            }
        }




        public static void SearchLog()
        {
            string logPath = Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_12_OOP\Lab_12_OOP\bvalog.txt");
            string logFile = BVALog.ReadLog();                                  
            FileInfo logFileInfo = new FileInfo(logPath);
            DateTime lastHour = DateTime.Now;
            lastHour.AddHours(-1);                                             

            if (logFileInfo.LastWriteTime < lastHour)                           
            {
                string writes = "\n =";                                          
                int i = 0, j = -1, count = -1;
                while (i != -1)                                                
                {
                    i = logFile.IndexOf(writes, j + 1);
                    j = i;
                    count++;
                }

                Console.WriteLine("Записей за текущий час: " + (count - 1));    
                Console.WriteLine("Вывод этих записей: ");
                Console.WriteLine(logFile);
            }
        }
    }
}
