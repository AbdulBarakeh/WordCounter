using System.Text.RegularExpressions;

namespace DB_WordCounter.Classes
{
    /// <summary>
    /// Support class - helps with testing
    /// </summary>
    public class WordCounter
    {


        /// <summary>
        /// Reads a file and returns number of words
        /// </summary>
        /// <returns> number of words</returns>
        public async Task<int> WordCount(StreamReader reader)
        {
            try
            {
                var wordCount = 0;
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var regex = @"\b[\S]+\b"; // \b = wordboundary \S all char excluding spaces 

                    var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    wordCount += matches.Count;
                }

                return wordCount;
            }
            catch
            {
                Console.WriteLine("The file could not be read:");
                throw new System.IO.FileLoadException();
            }

        }
    }
}
