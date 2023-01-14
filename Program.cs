using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Linq;

namespace Anagrams
{   
    /// <summary>
    /// Please refer to the top level README.md file for instructions
    /// </summary>
    public static class Program
    {     
       
        public static void Main(string[] args)
        {
            try
            {
                var localPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(AnagramService)).Location);
                var dictionaryPath = Path.Combine(localPath, "Dictionary1.txt");
                var words = File.ReadAllLines(dictionaryPath);
                var timer = new Stopwatch();

                timer.Start();
                var anagramResults = new AnagramService().Compute(words);
                timer.Stop();

                Console.WriteLine();
                Console.WriteLine($"Anagram Results (completed in {timer.ElapsedMilliseconds} ms):");
                Console.WriteLine();

                foreach (var anagramCounter in anagramResults)
                {
                    Console.WriteLine(
                        $"Words with the character length of {anagramCounter.WordLength} had {anagramCounter.Count} anagrams");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following exception occurred:");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
