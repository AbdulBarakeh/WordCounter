using DB_WordCounter.Classes;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace Test_DB_WordCounter
{
    internal class WordAnalyzerTest
    {
        WordAnalyzer analyzer;
        WordInserter inserter;
        WordSorter sorter;
        WordExcluder excluder;
        DirectorySetter directorySetter;
        [SetUp]
        public void Setup()
        {
            analyzer = new WordAnalyzer();
            inserter = new WordInserter();
            sorter = new WordSorter();
            excluder = new WordExcluder();
            directorySetter = new DirectorySetter(@".\Resources\");
        }

        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "200 Words insertion")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "400 Words insertion")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "800 Words insertion")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words insertion")]

        public async Task InsertWords()
        {
            
            using (StreamReader sr = new StreamReader(directorySetter.RootFilepath()))
            {
                using (StreamWriter sw = new StreamWriter(directorySetter.OutputFolder(), true))
                {
                    await analyzer.WordAnalysis(sr, sw, inserter);
                }
            }
        }

        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "200 Words Sorting")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "400 Words Sorting")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "800 Words Sorting")]
        [TestCase(Author = "AABD", Description = "Insert word from stream", TestName = "1600 Words Sorting")]
        public async Task SortWords()
        {
            
            IEnumerable<string> words;
            using (FileStream fs = new FileStream(directorySetter.GeneralFilepath(), FileMode.Open, FileAccess.Read))
            {
                words = await sorter.WordSorting(fs);
            }
            var approvedWords = await excluder.WordExclusion(words.ToList(),inserter,directorySetter);
            await sorter.WordSortingInsertion(approvedWords,inserter,directorySetter);
        }
    }
}
