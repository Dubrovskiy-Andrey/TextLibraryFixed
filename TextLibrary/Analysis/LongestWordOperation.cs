using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Analysis
{
    public class LongestWordOperation : ITextOperation
    {
        public string Execute(string text)
        {
            string[] words = text.Split(
                new char[] { ' ', '\n', '\r', '\t', '!', '?', '.', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            string longest = words.OrderByDescending(w => w.Length).FirstOrDefault() ?? "";
            return $"Самое длинное слово: {longest}";
        }
    }
}
