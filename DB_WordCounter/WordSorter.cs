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

        public async Task WordSortingInsertion(FileStream stream, IEnumerable<IGrouping<string, string>> groupedWords)
        {
            //TODO: Make loop to write words into their own respective files :D 
            using (StreamWriter sw = new StreamWriter(stream))
            {
                foreach (var word in groupedWords.OrderByDescending(x => x.Count()))
                {
                    await sw.WriteLineAsync($"{word.Key} {word.Count()}");
                }
            }
        }
    }
}