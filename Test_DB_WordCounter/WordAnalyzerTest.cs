using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DB_WordCounter
{
    internal class WordAnalyzerTest
    {
        DB_WordCounter.WordAnalyzer analyzer;
        DB_WordCounter.WordInserter inserter;
        DB_WordCounter.WordSorter sorter;
        [SetUp]
        public void Setup()
        {
            analyzer = new DB_WordCounter.WordAnalyzer();
            inserter = new DB_WordCounter.WordInserter();
            sorter = new DB_WordCounter.WordSorter();
        }

        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source1.txt", Author = "AABD", Description = "Insert word from stream", TestName = "200 Words insertion")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source2.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 400, TestName = "400 Words")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source3.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 800, TestName = "800 Words")]
        //[TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source4.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 1600, TestName = "1600 Words")]
        public void InsertWords(string filepathReader)
        {
            using (StreamReader sr = new StreamReader(filepathReader))
            {
                     analyzer.WordAnalysis(sr,inserter,sorter);
            }
        }
    }
}
