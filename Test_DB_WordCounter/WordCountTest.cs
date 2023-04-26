namespace Test_DB_WordCounter
{
    public class WordCountTest
    {
        DB_WordCounter.Classes.WordCounter counter;
        [SetUp]
        public void Setup()
        {
            counter = new DB_WordCounter.Classes.WordCounter();
        }

        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source1.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 200, TestName = "200 Words")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source2.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 400, TestName = "400 Words")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source3.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 800, TestName = "800 Words")]
        [TestCase(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source4.txt", Author = "AABD", Description = "Get wordcount from stream", ExpectedResult = 1600, TestName = "1600 Words")]
        public async Task<int> CountWords(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                return await counter.WordCount(sr);
            }
        }
    }
}