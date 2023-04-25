using DB_WordCounter.Classes;

namespace DB_WordCounter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var dir = "./Resources";
            var dir = args[0];
            var files = Directory.GetFiles(dir + @"\Input");
            var sourceFiles = files.Where(x => x.Contains("Source"));
            var wordAnalyzer = new WordAnalyzer();
            var wordInserter = new WordInserter();
            var wordSorter = new WordSorter();

            foreach (var file in sourceFiles)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    using (StreamWriter sw = new StreamWriter(Constants.GeneralFilepath(), true))
                    {
                        await wordAnalyzer.WordAnalysis(sr,sw, wordInserter);
                    }
                }
                Console.WriteLine($"insertion for file: {file} - DONE");
            }

            IEnumerable<string> words;
            using (FileStream fs = new FileStream(Constants.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await wordSorter.WordSorting(fs);
            }
            var approvedWords = await wordSorter.WordExclusion(words.ToList());
            await wordSorter.WordSortingInsertion(approvedWords);
            Console.WriteLine($"sorting for all files - DONE");

            Console.WriteLine($"Program is done - click ENTER to terminate program");
            Console.ReadLine();
        }
    }
}