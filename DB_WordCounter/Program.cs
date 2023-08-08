using DB_WordCounter.Classes;
using System.Runtime.CompilerServices;

namespace DB_WordCounter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {   bool DirNotSet = true;
            string dir = "";
            while (DirNotSet)
            {
                Console.WriteLine("Insert Path to Resource folder");
                Console.Write("Path: ");
                dir = Console.ReadLine()?.Trim();
                if (dir == "")
                {
                    Console.WriteLine("Path can't be empty! Try again!");
                }
                else
                {
                    DirNotSet = false;
                }
            }
            var files = Directory.GetFiles(dir);
            var sourceFiles = files.Where(x => x.Contains("Source"));
            var wordAnalyzer = new WordAnalyzer();
            var wordInserter = new WordInserter();
            var wordSorter = new WordSorter();
            var wordExcluder = new WordExcluder();
            var directorySetter = new DirectorySetter(dir);
            foreach (var file in sourceFiles)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    using (StreamWriter sw = new StreamWriter(directorySetter.GeneralFilepath(), true))
                    {
                        await wordAnalyzer.WordAnalysis(sr, sw, wordInserter);
                    }
                }
                Console.WriteLine($"insertion for file: {file} - DONE");
            }

            IEnumerable<string> words;
            using (FileStream fs = new FileStream(directorySetter.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await wordSorter.WordSorting(fs);
            }
            var approvedWords = await wordExcluder.WordExclusion(words.ToList(), wordInserter, directorySetter);
            await wordSorter.WordSortingInsertion(approvedWords, wordInserter, directorySetter);
            Console.WriteLine($"sorting for all files - DONE");

            Console.WriteLine($"Program is done - press ENTER to terminate program");
            Console.ReadLine();
        }
    }
}