using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8._6._3
{
    static class CleanDirectory
    {
        public static bool DeleteTime(FileSystemInfo obj)
        {
            bool result;

            DateTime dateTime = DateTime.Now;
            DateTime lastTime = obj.LastAccessTime;

            TimeSpan timeSpan = TimeSpan.FromMinutes(30);

            TimeSpan time = dateTime - lastTime;

            if (time >= timeSpan)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static void Cleaner(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
            {
                try
                {
                    var files = dirInfo.GetFiles();
                    foreach (var file in files)
                    {
                        if (DeleteTime(file))
                        {
                            file.Delete();
                        }
                    }

                    foreach (var dir in dirInfo.GetDirectories())
                    {
                        Cleaner(dir.FullName);
                        if (DeleteTime(dir))
                        {
                            dir.Delete(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
        }
    }
}
