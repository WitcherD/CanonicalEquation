using System;
using System.IO;
using CanonicalEquation.Lib;
using CanonicalEquation.Lib.Parsers;

namespace CanonicalEquation.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                RunInConsoleMode();
            }
            else
            {
                RunInFileMode(args[0]);
            }
        }

        private static void RunInConsoleMode()
        {
            Console.WriteLine("To exit press Ctrl+C");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter equation: ");

                var line = Console.ReadLine();
                if (String.IsNullOrEmpty(line))
                    continue;

                var originalColor = Console.ForegroundColor;
                Console.Write("Canonical form: ");
                try
                {
                    var equation = Equation.Parse(line);
                    Console.WriteLine(equation.ToString());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex);
                    Console.ForegroundColor = originalColor;
                }
            }
        }

        private static void RunInFileMode(string inputFileName)
        {
            Console.WriteLine("Processing started...");

            using (var inputFile = new StreamReader(inputFileName))
            {
                using (var outputFile = new StreamWriter(inputFileName + ".out"))
                {
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        try
                        {
                            var equation = Equation.Parse(line);
                            outputFile.WriteLine(equation.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }

            Console.WriteLine("Processing finished");
        }
    }
}
