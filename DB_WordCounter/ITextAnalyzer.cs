using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_WordCounter
{
    internal interface ITextAnalyzer
    {
        public int WordCount();
        public int ParagraphCount();
        public int LineCount();
        public int CharacterCount();
        public int ChapterCount();
    }
}
