// A utility to analyze text files and provide statistics
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Read the file content
                string content = File.ReadAllText(filePath);

                // TODO: Implement analysis functionality
                // 1. Count words
                // 2. Count characters (with and without whitespace)
                // 3. Count sentences
                // 4. Identify most common words
                // 5. Average word length

                // Example implementation for counting lines:
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");

                // TODO: Additional analysis to be implemented

                //count
                String[] words = content.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                int countwords = words.Length;
                Console.WriteLine($"Number of words: {countwords}");

                //count characters with whitspace
                int countcw = content.Length;
                Console.WriteLine($"Number of charactes with whitespace: {countcw}");

                //count characters without whitespace
                int countcwtw = content.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace(".", "").Replace(",", "").Replace(";", "").Replace("!", "").Replace("?", "").Length;
                Console.WriteLine($"Number of charactes without whitespace: {countcwtw}");

                // count sentences
                String[] sens = content.Split(new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
                int csen = sens.Length;
                Console.WriteLine($"The number of sentences: {csen}");

                //Indentify most common words\]
                Console.WriteLine("\n");
              String[] a = words.Select(w => w.ToLower()).ToArray();
                var wordcounttime =a.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
                var mostcommonwords = wordcounttime.OrderByDescending(w => w.Value).Take(10);
                Console.WriteLine("Most common words:");
                foreach(var word in mostcommonwords)
                {
                    Console.WriteLine($" - {word.Key}: {word.Value} time(s).");
                }

                //Average word length
                Console.WriteLine("\n");
                double totallength = words.Sum(w => w.Length);
                Console.WriteLine($"The Average word lenght is: {totallength / words.Length}.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }
    }
}