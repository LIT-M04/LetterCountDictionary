using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication25.Models;

namespace MvcApplication25.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string text)
        {
            var viewModel = new IndexViewModel();
            viewModel.Text = text;
            if (!String.IsNullOrEmpty(text))
            {
                Stopwatch sw = Stopwatch.StartNew();
                viewModel.LetterCount = GetWordCount(text);
                sw.Stop();
                viewModel.ListElapsed = sw.Elapsed;
                sw.Reset();
                sw.Start();
                viewModel.LetterCountDictionary = GetWordCountDictionary(text);
                sw.Stop();
                viewModel.DictionaryElapsed = sw.Elapsed;
            }
            return View(viewModel);
        }


        private IEnumerable<LetterCount> GetWordCount(string text)
        {
            List<LetterCount> letterCounts = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => new LetterCount
            {
                Letter = c,
                Count = 0
            }).ToList();

            foreach (char c in text.ToUpper())
            {
                foreach (LetterCount lc in letterCounts)
                {
                    if (lc.Letter == c)
                    {
                        lc.Count++;
                    }
                }
            }

            return letterCounts;
        }

        private Dictionary<char, int> GetWordCountDictionary(string text)
        {
            Dictionary<char, int> results = new Dictionary<char, int>();
            foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                results.Add(letter, 0);
            }

            foreach(char c in text.ToUpper())
            {
                if (results.ContainsKey(c))
                {
                    results[c]++;
                }
            }

            return results;
        } 
    }
}
