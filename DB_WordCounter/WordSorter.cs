using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace DB_WordCounter
{
    public class WordSorter
    {

        //public async Task WordSorting(StreamReader reader, StreamWriter writer)
        public async Task<IEnumerable<IGrouping<string, string>>> WordSorting(FileStream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var lines = await sr.ReadToEndAsync();
                return lines.TrimEnd().Split("\r\n").OrderBy(x => x).GroupBy(x => x);

            }

        }

        public async Task WordSortingInsertion(IEnumerable<IGrouping<string, string>> groupedWords)
        {
            var rootPath = @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\";
            foreach (var word in groupedWords.OrderByDescending(x => x.Count()))
            {
                var currentFilepath = $"FILE_{word.Key.ToUpper().First()}.txt";
                var fullPath = $@"{rootPath}\{currentFilepath}";
                using (StreamWriter sw = new StreamWriter(fullPath,true))//new FileStreamOptions() { Access=FileAccess.Write,Mode=FileMode.OpenOrCreate,Options=FileOptions.Asynchronous}))
                {
                    await sw.WriteLineAsync($"{word.Key} {word.Count()}");
                }
            }
        }
    }
}