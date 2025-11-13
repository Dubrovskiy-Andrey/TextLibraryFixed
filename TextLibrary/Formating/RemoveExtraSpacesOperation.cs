using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Fromatting
{
    public class RemoveExtraSpacesOperation : ITextOperation
    {
        public string Execute(string text)
        {
            string clean = string.Join(" ", text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            return $"Текст без лишних пробелов:\n{clean}";
        }
    }
}
