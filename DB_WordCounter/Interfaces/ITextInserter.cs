namespace DB_WordCounter.Interfaces
{
    public interface ITextInserter
    {
        public Task InsertWord(string word, StreamWriter writer);
    }
}