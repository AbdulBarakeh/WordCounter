using DB_WordCounter.Interfaces;

namespace DB_WordCounter.Classes
{
    public class WordInserter : ITextInserter
    {
        public async Task InsertWord(string word, StreamWriter writer)
        {
            await writer.WriteLineAsync(word.ToLower());
        }
    }
}