using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SyUtilsCore
{
    public class IOHelper
    {
        public static readonly char DirectorySeparatorChar = Path.DirectorySeparatorChar;

        public static string Combine(string[] paths)
        {
            return Path.Combine(paths);
        }

        public static string GetFolderName(string folderPath)
        {
            return Path.GetDirectoryName(folderPath);
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string GetFileNameWithoutExt(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static bool ExistsFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
                return false;
            return Directory.Exists(folderPath);
        }

        public static bool ExistsFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;
            return File.Exists(filePath);
        }

        public static bool IsFolder(string path)
        {
            System.IO.FileAttributes attr = File.GetAttributes(path);
            return (attr & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory;
        }

        public static long GetFileSize(string filePath)
        {
            long result = -1;
            if (ExistsFile(filePath))
            {
                result = new FileInfo(filePath).Length;
            }
            return result;
        }

        public static void CreateFolder(string folderPath)
        {
            if (!ExistsFolder(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static string[] GetFileSystems(string folderPath, bool children)
        {
            string[] result = null;
            if (ExistsFolder(folderPath))
            {
                if (children)
                {
                    result = Directory.GetFileSystemEntries(folderPath, "*.*", SearchOption.AllDirectories);
                }
                else
                {
                    result = Directory.GetFileSystemEntries(folderPath, "*.*", SearchOption.TopDirectoryOnly);
                }
            }
            return result;
        }

        public static string[] GetFiles(string folderPath, bool children)
        {
            string[] result = null;
            if (ExistsFolder(folderPath))
            {
                if (children)
                {
                    result = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                }
                else
                {
                    result = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
                }
            }
            return result;
        }
    }
}
