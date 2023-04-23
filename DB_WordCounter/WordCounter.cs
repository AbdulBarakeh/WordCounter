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
        public StreamReader Reader { get; set; }
        public WordCounter(StreamReader reader) {
            Reader = reader;
        }
        ~WordCounter() { 
            Reader.Dispose();
        }
        /// <summary>
        /// Reads a file and returns number of words
        /// </summary>
        /// <returns> number of words</returns>
        public int WordCount()
        {
            try
            {
                var wordCount = 0;
                using (StreamReader sr = Reader)
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
#if DEBUG
                        Debug.WriteLine(line);
#endif
                        var regex = @"\b[\S]+\b"; // \b = wordboundary \S all char excluding spaces 

                        var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        wordCount += matches.Count;
                    }
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
        
        public int ChapterCount()
        {
            throw new NotImplementedException();
        }

        public int CharacterCount()
        {
            throw new NotImplementedException();
        }

        public int LineCount()
        {
            throw new NotImplementedException();
        }

        public int ParagraphCount()
        {
            throw new NotImplementedException();
        }
#endregion


    }
}
