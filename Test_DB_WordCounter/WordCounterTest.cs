using DB_WordCounter;
using DB_WordCounter.Classes;
using DB_WordCounter.Interfaces;

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


        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source1.txt", @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt",ExpectedResult = 200, Author = "AABD", Description = "Analyze words", TestName = "200 - Analyzer test")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source2.txt", @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 400, Author = "AABD", Description = "Analyze words", TestName = "400 - Analyzer test")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source3.txt", @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 800, Author = "AABD", Description = "Analyze words", TestName = "800 - Analyzer test")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source4.txt", @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", ExpectedResult = 1600, Author = "AABD", Description = "Analyze words", TestName = "1600 - Analyzer test")]
        public async Task<int> InsertWords(string filepathInput,string filepathOutput)
        {
            int wordCount = 0;
            File.Delete(filepathOutput);
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
            //Assert.That(wordCount, Is.EqualTo(expectedResult));

        }
        //[TestCase(Author ="AABD",Description ="",ExpectedResult = 56)]
        //public int Test()
        //{
        //    int num = 56;
        //    return num;
        //    //Assert.That(num, Is.EqualTo(5));
        //}

        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words Sorting")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "400 Words Sorting")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "800 Words Sorting")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt", Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words Sorting")]
        //public async Task SortWords(string filepath)
        //{
        //    IEnumerable<string> words;
        //    using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
        //    {
        //        words = await sorter.WordSorting(fs);
        //    }
        //    var approvedWords = await sorter.WordExclusion(words.ToList());
        //    var groupedWords = approvedWords.GroupBy(x => x);
        //    await sorter.WordSortingInsertion(groupedWords);
        //}
    }
}
