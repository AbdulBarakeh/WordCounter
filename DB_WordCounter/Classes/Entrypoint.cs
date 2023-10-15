using DB_WordCounter.Interfaces;

namespace DB_WordCounter.Classes
{
    internal class Entrypoint : IEntrypoint
    {
        public ITextAnalyzer Analyzer { get; set; }
        public ITextInserter Inserter { get; set; }
        public ITextSorter Sorter { get; set; }
        public ITextExcluder Excluder { get; set; }
        public Entrypoint(ITextAnalyzer analyzer,ITextInserter inserter, ITextSorter sorter,ITextExcluder excluder)
        {
            Analyzer = analyzer;
            Inserter = inserter;
            Sorter = sorter;
            Excluder = excluder;
        }
        public async Task StartApplication()
        {
            bool dirNotSet = true;
            string? dir = string.Empty;
            while (dirNotSet)
            {
                Console.WriteLine("Insert Path to Resource folder");
                Console.Write("Path: ");
                dir = Console.ReadLine()?.Trim();
                if (dir == string.Empty)
                {
                    Console.WriteLine("Path can't be empty! Try again!");
                }
                else
                {
                    dirNotSet = false;
                }
            }
            //Assign utility classes
            var files = Directory.GetFiles(dir);
            var sourceFiles = files.Where(x => x.Contains("Source"));
            var wordAnalyzer = Analyzer;
            var wordInserter = Inserter;
            var wordSorter = Sorter;
            var wordExcluder = Excluder;
            var directorySetter = new DirectorySetter(dir);
            //Analyze words/count and insert in general file
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
            //Alphabetically sort words into general file
            IEnumerable<string> words;
            using (FileStream fs = new FileStream(directorySetter.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await wordSorter.WordSorting(fs);
            }
            //Count excluded words and sort them in corresponding file
            var approvedWords = await wordExcluder.WordExclusion(words.ToList(), wordInserter, directorySetter);
            //Sort remaining words alphabetically, and insert them in corresponding files 
            await wordSorter.WordSortingInsertion(approvedWords, wordInserter, directorySetter);
            Console.WriteLine($"sorting for all files - DONE");

            Console.WriteLine($"Program is done - press ENTER to terminate program");
            Console.ReadLine();
        }
    }
}