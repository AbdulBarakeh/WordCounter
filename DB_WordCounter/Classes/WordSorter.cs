using DB_WordCounter.Interfaces;

namespace DB_WordCounter.Classes
{
    public class WordSorter : ITextSorter
    {

        public async Task<IOrderedEnumerable<string>> WordSorting(FileStream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var lines = await sr.ReadToEndAsync();
                return lines.TrimEnd().Split("\r\n").OrderBy(x => x);
            }

        }

        public async Task WordSortingInsertion(List<string> approvedwords, ITextInserter inserter, string rootPath)
        {
            var groupedWords = approvedwords.GroupBy(x => x);
            foreach (var word in groupedWords.OrderByDescending(x => x.Count()))
            {
                var currentFilepath = $"FILE_{word.Key.ToUpper().First()}.txt";
                var fullPath = $@"{rootPath}\{currentFilepath}";

                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    await inserter.InsertWord($"{word.Key} {word.Count()}", sw);
                }
            }
        }
    }
}