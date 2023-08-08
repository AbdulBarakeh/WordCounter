using DB_WordCounter;
using DB_WordCounter.Classes;
using DB_WordCounter.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Test_DB_WordCounter
{
    internal class WordCounterTest
    {
        ITextAnalyzer analyzer;
        ITextInserter inserter;
        ITextSorter sorter;
        WordCounter counter;
        DirectorySetter directorySetter;
        [SetUp]
        public void Setup()
        {
            analyzer = new WordAnalyzer();
            inserter = new WordInserter();
            sorter = new WordSorter();
            counter = new WordCounter();
            directorySetter = new DirectorySetter(@".\Resources\");

        }

        /// <summary>
        /// Reads the text within the sourcefiles and inserts them in an output file.
        /// The test then counts the words to see if all the words were analysed and inserted
        /// </summary>
        /// <param name="filepathInput"></param>
        /// <param name="filepathOutput"></param>
        /// <returns>returns word count</returns>
        [TestCase(ExpectedResult = 200, Author = "AABD", Description = "Analyze words", TestName =  "Analyzer test - 200")]
        [TestCase(ExpectedResult = 400, Author = "AABD", Description = "Analyze words", TestName = "Analyzer test - 400")]
        [TestCase(ExpectedResult = 800, Author = "AABD", Description = "Analyze words", TestName = "Analyzer test - 800")]
        [TestCase(ExpectedResult = 1600, Author = "AABD", Description = "Analyze words", TestName ="Analyzer test - 1600")]
        public async Task<int> InsertWords()
        {
            int wordCount = 0;
            var outputRoot = Path.GetDirectoryName(directorySetter.OutputFolder());
            var files = Directory.GetFiles(outputRoot);
            foreach (var item in files)
            {
                File.Delete(item);
            }
            
            using (StreamReader sr = new StreamReader(directorySetter.RootFilepath()))
            {
                using (StreamWriter sw = new StreamWriter(directorySetter.OutputFolder(), true))
                {
                    await analyzer.WordAnalysis(sr, sw, inserter);
                }
            }
            using (StreamReader sr = new StreamReader(directorySetter.OutputFolder()))
            {
                wordCount = await counter.WordCount(sr);
            }
            return wordCount;

        }

        /// <summary>
        /// Sorts words into files
        /// </summary>
        /// <param name="filepathInput"></param>
        /// <param name="filepathGeneral"></param>
        /// <param name="filepathOutput"></param>
        [TestCase(Author = "AABD", Description = "Sort words", TestName = "Sorter test - 200")]
        [TestCase(Author = "AABD", Description = "Sort words", TestName = "Sorter test - 400")]
        [TestCase(Author = "AABD", Description = "Sort words", TestName = "Sorter test - 800")]
        [TestCase(Author = "AABD", Description = "Sort words", TestName = "Sorter test - 1600")]
        public async Task SortWords()
        {
            await InsertWords();
            IEnumerable<string> words;
            using (FileStream stream = new FileStream(directorySetter.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await sorter.WordSorting(stream);
            }
            await sorter.WordSortingInsertion(words.ToList(),inserter,directorySetter);

        }
    }
}
