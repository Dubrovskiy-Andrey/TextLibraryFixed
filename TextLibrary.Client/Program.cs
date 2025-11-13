using System;
using TextLibrary;
using TextLibrary.Analysis;
using TextLibrary.Fromatting;

namespace TextLibrary.Client
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== TextLibrary (SOLID версия) ===\n");

            while (true)
            {
                Console.Write("Введите текст (или пустую строку для выхода): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Завершение работы программы...");
                    break;
                }

                while (true)
                {
                    Console.WriteLine("\nВыберите режим обработки:");
                    Console.WriteLine("1 — Подсчёт слов");
                    Console.WriteLine("2 — Самое длинное слово");
                    Console.WriteLine("3 — Частота символов");
                    Console.WriteLine("4 — Удаление лишних пробелов");
                    Console.WriteLine("5 — Изменение регистра");
                    Console.WriteLine("6 — Выравнивание по ширине");
                    Console.WriteLine("7 — Ввести новый текст");
                    Console.WriteLine("0 — Выход");
                    Console.Write("Ваш выбор: ");

                    string choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        Console.WriteLine("Завершение работы программы...");
                        return;
                    }
                    if (choice == "7")
                        break;

                    if (!int.TryParse(choice, out int mode))
                    {
                        Console.WriteLine("Ошибка: введите номер операции!");
                        continue;
                    }

                    ITextOperation operation = mode switch
                    {
                        1 => new WordCountOperation(),
                        2 => new LongestWordOperation(),
                        3 => new CharFrequencyOperation(),
                        4 => new RemoveExtraSpacesOperation(),
                        5 => ChooseCaseOperation(),
                        6 => ChooseJustifyOperation(),
                        _ => null
                    };

                    if (operation == null)
                    {
                        Console.WriteLine("Неверный режим обработки!");
                        continue;
                    }

                    Console.WriteLine("\nРезультат:");
                    Console.WriteLine(operation.Execute(input));

                    Console.WriteLine("\nНажмите Enter для продолжения...");
                    Console.ReadLine();
                }
            }
        }

        private static ITextOperation ChooseCaseOperation()
        {
            Console.Write("Введите 1 — верхний регистр, 2 — нижний: ");
            string choice = Console.ReadLine();
            return choice == "1"
                ? new ChangeCaseOperation(true)
                : new ChangeCaseOperation(false);
        }

        private static ITextOperation ChooseJustifyOperation()
        {
            Console.Write("Введите желаемую длину строки: ");
            if (!int.TryParse(Console.ReadLine(), out int width))
                width = 40;
            return new JustifyTextOperation(width);
        }
    }
}
