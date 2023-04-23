using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DB_WordCounter
{
    public class WordAnalyzer
    {
        public WordAnalyzer() { }
        public async void WordAnalysis(StreamReader reader, WordInserter inserter, WordSorter sorter) {
            string line;            
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var regex = @"\b[\S]+\b"; // \b = wordboundary \S all char excluding spaces 

                var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                foreach (Match match in matches)
                {
                    string filepathWriter = inserter.FindFilepath(match.Value);
                    using (StreamWriter sw = new StreamWriter(filepathWriter))
                    {
                        inserter.Insert(match.Value, sw);
                    }
                    //sorter.Sort(match.Value, writer);
                }
            }


        }
    }
}
