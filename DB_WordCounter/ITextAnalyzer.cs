namespace DB_WordCounter
{
    internal interface ITextAnalyzer
    {
        public Task<int> WordCount(StreamReader reader);
        public int ParagraphCount(StreamReader reader);
        public int LineCount(StreamReader reader);
        public int CharacterCount(StreamReader reader);
        public int ChapterCount(StreamReader reader);
    }
}
