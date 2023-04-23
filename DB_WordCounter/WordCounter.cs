using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DB_WordCounter
{
    public class WordCounter : ITextAnalyzer
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

#region futureImplementation

        public int ParagraphCount(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public int LineCount(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public int CharacterCount(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public int ChapterCount(StreamReader reader)
        {
            throw new NotImplementedException();
        }



        #endregion


    }
}
