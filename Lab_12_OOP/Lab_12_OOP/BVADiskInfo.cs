using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_12_OOP
{
    public class BVADiskInfo
    {
        public static void DiskInfo()
        {
            var Drives = DriveInfo.GetDrives();
            string logData = "";

            foreach (var d in Drives)
            {
                if (d.IsReady)
                {
                    logData += "\n================= BVADiskInfo ===================";
                    logData += "\nИмя диска:                        " + d.Name;
                    logData += "\nФайловая система:                 " + d.DriveFormat;
                    logData += "\nРазмер диска:                     " + d.TotalSize;
                    logData += "\nOбъем свободного места на диске:  " + d.TotalFreeSpace;
                    logData += "\nМетка тома диска:                 " + d.VolumeLabel;
                    logData += "\n";
                }
            }

            BVALog.WriteInLog(logData);
        }
    }
}
