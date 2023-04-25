using DB_WordCounter.Classes;

namespace Test_DB_WordCounter
{
    internal class WordAnalyzerTest
    {
        WordAnalyzer analyzer;
        WordInserter inserter;
        WordSorter sorter;
        [SetUp]
        public void Setup()
        {
            analyzer = new WordAnalyzer();
            inserter = new WordInserter();
            sorter = new WordSorter();
        }

        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source1.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words insertion")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source2.txt", Author = "AABD", Description = "Insert word from stream", TestName = "400 Words insertion")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source3.txt", Author = "AABD", Description = "Insert word from stream", TestName = "800 Words insertion")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source4.txt", Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words insertion")]

        public async Task InsertWords(string filepathReader)
        {
            using (StreamReader sr = new StreamReader(filepathReader))
            {
                await analyzer.WordAnalysis(sr, inserter);
            }
        }

        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words Sorting")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "400 Words Sorting")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "800 Words Sorting")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words Sorting")]
        public async Task SortWords(string filepath)
        {
            IEnumerable<string> words;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                words = await sorter.WordSorting(fs);
            }
            var approvedWords = await sorter.WordExclusion(words.ToList());
            await sorter.WordSortingInsertion(approvedWords);
        }
    }
}
