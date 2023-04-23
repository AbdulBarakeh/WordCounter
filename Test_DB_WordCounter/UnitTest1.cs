namespace Test_DB_WordCounter
{
    public class Tests
    {
        DB_WordCounter.WordCounter counter; 
        [SetUp]
        public void Setup()
        {
            var reader = new StreamReader(@"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Input\Source1.txt");
            counter = new DB_WordCounter.WordCounter(reader);
        }

        [Test( Author = "AABD",Description = "Get wordcount from stream",ExpectedResult = 200)]
        public int CountWords()
        {
            return counter.WordCount();
        }
    }
}