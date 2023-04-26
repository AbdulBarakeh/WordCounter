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
        [SetUp]
        public void Setup()
        {
            analyzer = new WordAnalyzer();
            inserter = new WordInserter();
            sorter = new WordSorter();
            counter = new WordCounter();

        }

        /// <summary>
        /// Reads the text within the sourcefiles and inserts them in an output file.
        /// The test then counts the words to see if all the words were analysed and inserted
        /// </summary>
        /// <param name="filepathInput"></param>
        /// <param name="filepathOutput"></param>
        /// <returns>returns word count</returns>
        [TestCase(@".\Resources\Input\Source1.txt", @".\Resources\Output\FILE_GENERAL.txt",ExpectedResult = 200, Author = "AABD", Description = "Analyze words", TestName =  "Analyzer test - 200")]
        [TestCase(@".\Resources\Input\Source2.txt", @".\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 400, Author = "AABD", Description = "Analyze words", TestName = "Analyzer test - 400")]
        [TestCase(@".\Resources\Input\Source3.txt", @".\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 800, Author = "AABD", Description = "Analyze words", TestName = "Analyzer test - 800")]
        [TestCase(@".\Resources\Input\Source4.txt", @".\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 1600, Author = "AABD", Description = "Analyze words", TestName ="Analyzer test - 1600")]
        public async Task<int> InsertWords(string filepathInput,string filepathOutput)
        {
            int wordCount = 0;
            var outputRoot = Path.GetDirectoryName(filepathOutput);
            var files = Directory.GetFiles(outputRoot);
            foreach (var item in files)
            {
                File.Delete(item);
            }
            
            using (StreamReader sr = new StreamReader(filepathInput))
            {
                using (StreamWriter sw = new StreamWriter(filepathOutput, true))
                {
                    await analyzer.WordAnalysis(sr, sw, inserter);
                }
            }
            using (StreamReader sr = new StreamReader(filepathOutput))
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
        [TestCase(@".\Resources\Input\Source1.txt", @".\Resources\Output\FILE_GENERAL.txt", @".\Resources\Output", Author = "AABD", Description = "Sort words", TestName = "Sorter test - 200")]
        [TestCase(@".\Resources\Input\Source2.txt", @".\Resources\Output\FILE_GENERAL.txt", @".\Resources\Output", Author = "AABD", Description = "Sort words", TestName = "Sorter test - 400")]
        [TestCase(@".\Resources\Input\Source3.txt", @".\Resources\Output\FILE_GENERAL.txt", @".\Resources\Output", Author = "AABD", Description = "Sort words", TestName = "Sorter test - 800")]
        [TestCase(@".\Resources\Input\Source4.txt", @".\Resources\Output\FILE_GENERAL.txt", @".\Resources\Output", Author = "AABD", Description = "Sort words", TestName = "Sorter test - 1600")]
        public async Task SortWords(string filepathInput, string filepathGeneral, string filepathOutput)
        {
            await InsertWords(filepathInput, filepathGeneral);
            IEnumerable<string> words;
            using (FileStream stream = new FileStream(filepathGeneral, FileMode.Open, FileAccess.Read))
            {
                words = await sorter.WordSorting(stream);
            }
            await sorter.WordSortingInsertion(words.ToList(),inserter,filepathOutput);

        }
    }
}
