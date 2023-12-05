using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab_12_OOP
{
    public class BVAFileInfo 
    {
        public static void FileInfo()
        {
            string filePath = Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_12_OOP\Lab_12_OOP\file.txt");

            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
                fileInfoLog = " ================= BVAFileInfo ===================" +
                              "\nПолный путь:              " + filePath +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length + " KB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;
           
            BVALog.WriteInLog(fileInfoLog);
        }
    }
}
