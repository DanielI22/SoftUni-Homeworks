using System;

namespace _3._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();
            string[] fileNameExt = filePath.Split('\\', StringSplitOptions.RemoveEmptyEntries);
            string[] fileNExt = fileNameExt[fileNameExt.Length - 1].Split('.');
            string fileName = fileNExt[0];
            string fileExt = fileNExt[1];
            Console.WriteLine("File name: " + fileName);
            Console.WriteLine("File extension: " + fileExt);

        }
    }
}
