using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextLibrary
{
    public class TextProcessor
    {
        public string Text;

        public TextProcessor(string text)
        {
            Text = text;
        }

        public void ProcessText(int mode)
        {
            if (mode == 1)
            {
                string[] words = Text.Split(new char[] { ' ', '\n', '\r', '\t', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"Количество слов: {words.Length}");
            }
            else if (mode == 2)
            {
                string[] words = Text.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string longest = "";
                foreach (string w in words)
                    if (w.Length < longest.Length)
                        longest = w;
                Console.WriteLine($"Самое длинное слово: {longest}");
            }
            else if (mode == 3)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in Text)
                {
                    if (dict.ContainsKey(c))
                        dict[c]++;
                    else
                        dict[c] = 1;
                }
                Console.WriteLine("Частота использования символов:");
                foreach (var kv in dict)
                    Console.WriteLine($"{kv.Key} = {kv.Value}");
            }
            else if (mode == 4)
            {
                while (Text.Contains(" "))
                    Text = Text.Replace(" ", "");
                Console.WriteLine("Текст без лишних пробелов:");
                Console.WriteLine(Text);
            }
            else if (mode == 5)
            {
                Console.WriteLine("Введите 1 — верхний регистр, 2 — нижний:");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    Text = Text.ToLower();
                else
                    Text = Text.ToUpper();
                Console.WriteLine("Изменённый текст:");
                Console.WriteLine(Text);
            }
            else if (mode == 6)
            {
                Console.WriteLine("Введите желаемую длину строки:");
                int width = int.Parse(Console.ReadLine());
                string[] words = Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder result = new StringBuilder();
                StringBuilder line = new StringBuilder();

                foreach (var w in words)
                {
                    if (line.Length + w.Length + 1 > width)
                    {
                        int spaces = width - line.Length;
                        string lineText = line.ToString();
                        if (lineText.Contains(" "))
                        {
                            string[] parts = lineText.Split(' ');
                            int i = 0;
                            while (spaces > 0)
                            {
                                parts[i % (parts.Length - 1)] += " ";
                                spaces--;
                                i++;
                            }
                            result.AppendLine(string.Join(" ", parts));
                        }
                        else
                        {
                            result.AppendLine(lineText);
                        }
                        line.Clear();
                    }
                    if (line.Length > 0)
                        line.Append(" ");
                    line.Append(w);
                }
                if (line.Length > 0)
                    result.AppendLine(line.ToString());

                Console.WriteLine("Текст, выровненный по ширине:");
                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine("Неверный режим обработки!");
            }
        }
    }
}
