using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8._6._3
{
    static class DirectorySize
    {
        public static long Size(string dirName)
        {
            long size = 0;
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (dir.Exists)
            {
                try
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        size += file.Length;
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        size += Size(di.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }

            return size;
        }
    }
}
