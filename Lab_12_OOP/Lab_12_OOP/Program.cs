using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BVALog.WriteLog();
                BVADiskInfo.DiskInfo();
                BVAFileInfo.FileInfo();
                BVADirInfo.GetDirInfo();
                BVAFileManager.BVAFiles();
                BVAFileManager.MakeArchive();
                BVAFileManager.BVAInspect();

                BVALog.ReadLog();
                BVALog.SearchLog();

            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка! Директорий не найден.\n");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Ошибка! Файл уже существует или используется другим процессом.\n");                               
            }
            catch (Exception)
            {
                Console.WriteLine("Непредвиденная ошибка!\n");                      
            }

        }
    }
}
