using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab_12_OOP
{
    public class BVAFileManager
    {
        public static void BVAInspect()
        {
            string inspectLog = "";

            DirectoryInfo directory = new DirectoryInfo(@"D:\3_SEM_LABS\Lab12");

            directory.Create();
            directory.CreateSubdirectory(@"BVAInspect");

            DirectoryInfo BVAInspectFiles = new DirectoryInfo(Path.GetFullPath(@"D:\3_SEM_LABS\Lab12\BVAInspect\BVAFile"));
            if (BVAInspectFiles.Exists)
                BVAInspectFiles.Delete(true);

            string filePath = Path.GetFullPath(@"D:\3_SEM_LABS\Lab12\BVAInspect\bvafile.txt");
            FileInfo fileInfo = new FileInfo(filePath);

            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Создать класс XXXFileManager. Набор методов определите самостоятельно.\n"
                    + "С его помощью выполнить следующие действия");
                sw.Close();
            }

            string renamePath = Path.GetFullPath(@"D:\3_SEM_LABS\Lab12\BVAInspect\bvafileRenamed.txt");
            FileInfo renameBuf = new FileInfo(renamePath);
            renameBuf.Delete();

            fileInfo.CopyTo(renamePath);
            fileInfo.Delete();

            DirectoryInfo inspectDirInfo = new DirectoryInfo(Path.GetFullPath(@"D:\3_SEM_LABS\Lab12\BVAInspect"));
            string files = "";

            for (var i = 0; i < inspectDirInfo.GetFiles().Length; i++)
                files += inspectDirInfo.GetFiles()[i].Name + "; ";

            string directories = "";

            for (var i = 0; i < inspectDirInfo.GetDirectories().Length; i++)
                directories += inspectDirInfo.GetDirectories()[i].Name + "; ";

            if (inspectDirInfo.Exists)
                inspectLog = "\n ================= BVAFileManager ===================" +
                             "\nФайлы:" + files +
                             "\nПоддиректории:" + directories +
                             "\nРодительский директорий:" + inspectDirInfo.Parent.Name;

            BVALog.WriteInLog(inspectLog);
        }

        public static void BVAFiles()
        {
            string rootDrivePath = Path.GetFullPath(@"D:\");
            string BVAFilesPath = Path.GetFullPath(rootDrivePath + @"3_SEM_LABS\Lab12\BVAFiles");
            string BVAInspectFilesPath = Path.GetFullPath(rootDrivePath + @"3_SEM_LABS\Lab12\BVAInspect\BVAFiles");
            string BVAUnzipPath = Path.GetFullPath(rootDrivePath + @"3_SEM_LABS\Lab12\BVAInspect\BVAUnzip");
            string testPath = Path.GetFullPath(rootDrivePath + @"testLab12");
            string ZIPPath = Path.GetFullPath(rootDrivePath + @"3_SEM_LABS\Lab12\BVAInspect\BVAFiles.zip");

            DirectoryInfo BVAFiles = new DirectoryInfo(BVAFilesPath);
            DirectoryInfo BVAInspectFiles = new DirectoryInfo(BVAInspectFilesPath);
            DirectoryInfo BVAUnzip = new DirectoryInfo(BVAUnzipPath);

            if (!BVAFiles.Exists)
                BVAFiles.Create();

            if (BVAUnzip.Exists)
                BVAUnzip.Delete(true);

            if (File.Exists(ZIPPath))
                File.Delete(ZIPPath);

            DirectoryInfo testFileDirInfo = new DirectoryInfo(testPath);
            FileInfo[] filesInTest = testFileDirInfo.GetFiles();

            foreach (FileInfo file in filesInTest)
                if (file.Extension == ".txt")
                    file.CopyTo(Path.Combine(BVAFilesPath.ToString(), file.Name), true);

            if (BVAInspectFiles.Exists)
                BVAInspectFiles.Delete(true);
            if (BVAFiles.Exists)
                BVAFiles.MoveTo(BVAInspectFilesPath);
        }

        public static void MakeArchive()
        {
            string lab12Path = Path.GetFullPath(@"D:\3_SEM_LABS\Lab12\");
            string BVAFilesPath = Path.GetFullPath(lab12Path + @"BVAFiles");
            string BVAInspectFilesPath = Path.GetFullPath(lab12Path + @"BVAInspect\BVAFiles");
            string BVAInspectUnzipPath = Path.GetFullPath(lab12Path + @"BVAInspect\BVAUnzip");
            string ZIPpath = Path.GetFullPath(lab12Path + @"BVAInspect\BVAFiles.zip");

            DirectoryInfo BVAFiles = new DirectoryInfo(BVAFilesPath);
            ZipFile.CreateFromDirectory(BVAInspectFilesPath, ZIPpath);

            DirectoryInfo BVAInspectFiles = new DirectoryInfo(BVAInspectFilesPath);
            if (BVAInspectFiles.Exists)
                BVAInspectFiles.Delete(true);

            DirectoryInfo BVAInspectUnzip = new DirectoryInfo(BVAInspectUnzipPath);
            if (BVAInspectUnzip.Exists)
                BVAInspectUnzip.Delete(true);
            BVAInspectUnzip.Create();

            using (ZipArchive archive = ZipFile.OpenRead(ZIPpath))
            {
                var result = from currEntry in archive.Entries
                             where !String.IsNullOrEmpty(currEntry.Name)
                             select currEntry;
                foreach (ZipArchiveEntry entry in result)
                    entry.ExtractToFile(Path.Combine(BVAInspectUnzipPath, entry.Name));
            }

            
        }
    }
}

//  GZipStream(Stream stream, CompressionLevel level)

//	GZipStream(Stream stream, CompressionMode.Compress/Decompress)