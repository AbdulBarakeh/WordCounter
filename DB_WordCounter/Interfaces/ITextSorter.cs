﻿namespace DB_WordCounter.Interfaces
{
    public interface ITextSorter
    {
        public Task<IOrderedEnumerable<string>> WordSorting(FileStream stream);
        public Task WordSortingInsertion(List<string> approvedwords, ITextInserter inserter, string rootPath);


    }
}