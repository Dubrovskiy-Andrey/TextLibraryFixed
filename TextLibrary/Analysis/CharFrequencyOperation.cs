using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Analysis
{
    public class CharFrequencyOperation : ITextOperation
    {
        public string Execute(string text)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }

            StringBuilder sb = new StringBuilder("Частота использования символов:\n");
            foreach (var kv in dict.OrderBy(k => k.Key))
                sb.AppendLine($"{kv.Key} = {kv.Value}");

            return sb.ToString();
        }
    }
}
