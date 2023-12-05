using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_12_OOP
{
    public class BVADirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"D:\3_SEM_LABS\OOP");
            string DirInfoLog = "";
            
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
                DirInfoLog = "\n ================= BVADirInfo ===================" +
                             "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                             "\nВремя изменения:          " + dirInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + dirInfo.Parent.Name;

            BVALog.WriteInLog(DirInfoLog);
        }
    }
}
