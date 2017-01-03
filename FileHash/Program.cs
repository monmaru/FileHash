using System;
using System.IO;
using System.Linq;

namespace FileHash
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Input file path");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.Write($"{filePath} is not exist");
                return;
            }

            Enum.GetValues(typeof(Algorithm))
                .Cast<Algorithm>()
                .ToList()
                .ForEach(a => Console.WriteLine($"{a}: {HashGenerator.Get(filePath, a)}"));
        }
    }
}
