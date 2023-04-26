using DB_WordCounter.Classes;

namespace Test_DB_WordCounter
{
    internal class WordAnalyzerTest
    {
        WordAnalyzer analyzer;
        WordInserter inserter;
        WordSorter sorter;
        WordExcluder excluder;
        [SetUp]
        public void Setup()
        {
            analyzer = new WordAnalyzer();
            inserter = new WordInserter();
            sorter = new WordSorter();
            excluder = new WordExcluder();
        }

        [TestCase(@".\Resources\Input\Source1.txt", @".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words insertion")]
        [TestCase(@".\Resources\Input\Source2.txt", @".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "400 Words insertion")]
        [TestCase(@".\Resources\Input\Source3.txt", @".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "800 Words insertion")]
        [TestCase(@".\Resources\Input\Source4.txt", @".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words insertion")]

        public async Task InsertWords(string filepathReader, string filepathOutput)
        {
            using (StreamReader sr = new StreamReader(filepathReader))
            {
                using (StreamWriter sw = new StreamWriter(filepathOutput, true))
                {
                    await analyzer.WordAnalysis(sr, sw, inserter);
                }
            }
        }

        [TestCase(@".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words Sorting")]
        [TestCase(@".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "400 Words Sorting")]
        [TestCase(@".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "800 Words Sorting")]
        [TestCase(@".\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words Sorting")]
        public async Task SortWords(string filepath)
        {
            IEnumerable<string> words;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                words = await sorter.WordSorting(fs);
            }
            var approvedWords = await excluder.WordExclusion(words.ToList(),inserter);
            await sorter.WordSortingInsertion(approvedWords,inserter,Constants.OutputFolder());
        }
    }
}
