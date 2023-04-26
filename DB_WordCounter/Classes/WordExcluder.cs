using DB_WordCounter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_WordCounter.Classes
{
    public class WordExcluder : ITextExcluder
    {
        public async Task<List<string>> WordExclusion(List<string> words, ITextInserter inserter)
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
                        //await sw.WriteLineAsync(exclusion.wordcount);
                        await inserter.InsertWord(exclusion.wordcount, sw);
                    }
                }
                words.RemoveAll(word => exclusionWords.Contains(word));
                return words;
            }

        }
    }
}