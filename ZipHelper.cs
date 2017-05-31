using System.IO;
using System.IO.Compression;

namespace SyUtilsCore
{
    public static class ZipHelper
    {
        public static void CompressDir(string dirPath, string zipFilePath)
        {
            if (Directory.Exists(dirPath))
            {
                ZipFile.CreateFromDirectory(dirPath, zipFilePath);
            }
        }

        public static void CompressFile(string zipFile, params string[] sourceFiles)
        {
            if (sourceFiles == null || sourceFiles.Length == 0)
                return;

            if (File.Exists(zipFile))
                File.Delete(zipFile);

            using (FileStream fs = new FileStream(zipFile, FileMode.Create))
            {
                using (ZipArchive zipArchive = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    foreach (string sourceFile in sourceFiles)
                    {
                        zipArchive.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile));
                    }
                }
            }
        }

        public static void UnCompressDir(string zipFilePath, string dirPath)
        {
            if (!File.Exists(zipFilePath))
                return;

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            ZipFile.ExtractToDirectory(zipFilePath, dirPath);
        }
    }
}
