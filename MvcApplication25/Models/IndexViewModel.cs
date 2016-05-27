using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication25.Models
{
    public class IndexViewModel
    {
        public string Text { get; set; }
        public IEnumerable<LetterCount> LetterCount { get; set; } 
        public Dictionary<char, int> LetterCountDictionary { get; set; }
        public TimeSpan ListElapsed { get; set; }
        public TimeSpan DictionaryElapsed { get; set; }
        
    }

    public class LetterCount
    {
        public char Letter { get; set; }
        public int Count { get; set; }
    }
}