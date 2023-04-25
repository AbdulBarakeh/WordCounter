namespace DB_WordCounter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
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
                    await wordAnalyzer.WordAnalysis(sr, wordInserter);
                }
                Console.WriteLine($"insertion for file: {file} - DONE");
            }

            IEnumerable<string> words;
            using (FileStream fs = new FileStream(Constants.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await wordSorter.WordSorting(fs);
            }
            var approvedWords = await wordSorter.WordExclusion(words.ToList());
            var groupedWords = approvedWords.GroupBy(x => x);
            await wordSorter.WordSortingInsertion(groupedWords);
            Console.WriteLine($"sorting for all files - DONE");


            Console.ReadLine();
        }
    }
}