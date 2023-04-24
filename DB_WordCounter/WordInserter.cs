namespace DB_WordCounter
{
    public class WordInserter
    {


        internal async Task Insert(string word, StreamWriter writer)
        {
            await writer.WriteLineAsync(word.ToLower());
        }
    }
}