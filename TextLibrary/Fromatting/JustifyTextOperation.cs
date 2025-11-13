using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Fromatting
{
    public class JustifyTextOperation : ITextOperation
    {
        private readonly int _width;

        public JustifyTextOperation(int width)
        {
            _width = width;
        }

        public string Execute(string text)
        {
            if (_width <= 0)
                return text;

            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            foreach (var w in words)
            {
                if (line.Length + w.Length + 1 > _width)
                {
                    string[] parts = line.ToString().Split(' ');
                    if (parts.Length > 1)
                    {
                        int spaces = _width - parts.Sum(p => p.Length);
                        int i = 0;
                        while (spaces-- > 0)
                        {
                            parts[i % (parts.Length - 1)] += " ";
                            i++;
                        }
                    }
                    result.AppendLine(string.Join(" ", parts));
                    line.Clear();
                }

                if (line.Length > 0)
                    line.Append(" ");
                line.Append(w);
            }

            if (line.Length > 0)
                result.AppendLine(line.ToString());

            return $"Текст, выровненный по ширине:\n{result}";
        }
    }
}
