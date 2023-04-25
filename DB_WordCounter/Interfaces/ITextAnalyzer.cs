﻿namespace DB_WordCounter.Interfaces
{
    public interface ITextAnalyzer
    {
        public Task WordAnalysis(StreamReader reader, ITextInserter inserter);
    }
}
