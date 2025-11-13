using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Analysis
{
    public class WordCountOperation : ITextOperation
    {
        public string Execute(string text)
        {
            string[] words = text.Split(
                new char[] { ' ', '\n', '\r', '\t', '!', '?', '.', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            return $"Количество слов: {words.Length}";
        }
    }
}
