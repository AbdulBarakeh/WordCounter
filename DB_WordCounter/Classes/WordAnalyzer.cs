using System.Diagnostics;
using System.Text.RegularExpressions;
using DB_WordCounter.Interfaces;

namespace DB_WordCounter.Classes
{
    public class WordAnalyzer : ITextAnalyzer
    {
        public WordAnalyzer() { }
        public async Task WordAnalysis(StreamReader reader, ITextInserter inserter)
        {
            try
            {
                string line;
                while ((line= await reader.ReadLineAsync()) != null)
                {
                    var regex = @"\b[\S]+\b"; // \b = wordboundary \S all char excluding spaces 

                    var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    string filepathWriter = Constants.GeneralFilepath();
                    using (StreamWriter sw = new StreamWriter(filepathWriter, true))
                    {
                        foreach (Match match in matches)
                        {
                            await inserter.InsertWord(match.Value, sw);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Stream is closed");
                Debug.WriteLine($"{e.Message}");
            }


        }
    }
}
