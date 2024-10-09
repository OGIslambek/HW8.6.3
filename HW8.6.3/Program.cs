namespace HW8._6._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к каталогу");
            string path = Console.ReadLine();
            long sizeBefore = DirectorySize.Size(path);
            Console.WriteLine($"Исходный размер папки: {sizeBefore} байт");
            CleanDirectory.Cleaner(path);
            long sizeAfter = DirectorySize.Size(path);
            long difSize = sizeBefore - sizeAfter;
            Console.WriteLine($"Освобождено: {difSize} байт");
            Console.WriteLine($"Текущий размер папки: {sizeAfter} байт");
        }
    }
}
