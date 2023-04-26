using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_WordCounter.Interfaces
{
    internal interface ITextExcluder
    {
        public Task<List<string>> WordExclusion(List<string> words, ITextInserter inserter);

    }
}
