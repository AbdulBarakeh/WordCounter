using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //IEnumerable<IGrouping<string, string>> groupedWords;
            IEnumerable<string> words;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                //groupedWords = await sorter.WordSorting(fs);
                words = await sorter.WordSorting(fs);
            }
            var approvedWords = await sorter.WordExclusion(words.ToList());
            var groupedWords = approvedWords.GroupBy(x => x);
            await sorter.WordSortingInsertion(groupedWords);
        }
    }
}
