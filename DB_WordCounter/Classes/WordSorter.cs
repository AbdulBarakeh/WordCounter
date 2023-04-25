using DB_WordCounter.Interfaces;

namespace DB_WordCounter.Classes
{
    public class WordSorter : ITextSorter
    {
        public async Task<List<string>> WordExclusion(List<string> words)
        {

            using (StreamReader sr = new StreamReader(Constants.ExclusionSourceFilepath()))
            {
                List<string> exclusionWords = new List<string>();
                while (!sr.EndOfStream)
                {
                    var word = await sr.ReadLineAsync();
                    if (word != null)
                    {
                        exclusionWords.Add(word);
                    }
                }
                //Could be achieved with GroupBy... Just showing alternative ways :) 
                var exclusions = exclusionWords.GroupJoin(words, ew => ew, w => w, (ew, w) => new { wordcount = $"{ew} {w.Count()}" });
                using (StreamWriter sw = new StreamWriter(Constants.ExclusionFilepath(), true))
                {
                    foreach (var exclusion in exclusions)
                    {
                        await sw.WriteLineAsync(exclusion.wordcount);
                    }
                }
                words.RemoveAll(word => exclusionWords.Contains(word));
                return words;
            }
        }

        public async Task<IOrderedEnumerable<string>> WordSorting(FileStream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var lines = await sr.ReadToEndAsync();
                return lines.TrimEnd().Split("\r\n").OrderBy(x => x);
            }

        }

        public async Task WordSortingInsertion(List<string> approvedwords)
        {
            var groupedWords = approvedwords.GroupBy(x => x);
            var rootPath = Constants.OutputFolder();
            foreach (var word in groupedWords.OrderByDescending(x => x.Count()))
            {
                var currentFilepath = $"FILE_{word.Key.ToUpper().First()}.txt";
                var fullPath = $@"{rootPath}\{currentFilepath}";
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    await sw.WriteLineAsync($"{word.Key} {word.Count()}");
                }
            }
        }
    }
}