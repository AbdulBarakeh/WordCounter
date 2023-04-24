﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DB_WordCounter
{
    public class WordAnalyzer
    {
        public WordAnalyzer() { }
        public async Task WordAnalysis(StreamReader reader, WordInserter inserter, WordSorter sorter) {
            try
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var regex = @"\b[\S]+\b"; // \b = wordboundary \S all char excluding spaces 

                    var matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    foreach (Match match in matches)
                    {
                        string filepathWriter = inserter.GeneralFilepath();
                        using (StreamWriter sw = new StreamWriter(filepathWriter, true))
                        {
                            await inserter.Insert(match.Value, sw);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Stream is closed");
                Debug.WriteLine($"{e.Message}");
            }


        }
    }
}
