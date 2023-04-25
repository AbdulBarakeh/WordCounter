namespace DB_WordCounter.Interfaces
{
    public interface ITextSorter
    {
        public Task<IOrderedEnumerable<string>> WordSorting(FileStream stream);
    }
}