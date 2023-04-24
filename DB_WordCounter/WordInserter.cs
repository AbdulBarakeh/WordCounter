namespace DB_WordCounter
{
    public class WordInserter
    {
        internal string GeneralFilepath()
        {
            return @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_GENERAL.txt";
        }

        internal async Task Insert(string word, StreamWriter writer)
        {
            var firstLetter = word.ToLower().First();
            await writer.WriteLineAsync(word + " ");

            
        }
    }
}