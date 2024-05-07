using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace z2pr16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строки, разделенные пробелом: ");
            string[] inputArray = Console.ReadLine().Split(' ');

            // A) Определение количества содержащихся в ней цифр и вывода их на экран и их количества.
            int totalDigits = 0;
            foreach (string str in inputArray)
            {
                int digitCount = str.Count(char.IsDigit);
                totalDigits += digitCount;
                Console.WriteLine($"В строке '{str}' содержится {digitCount} цифр.");
            }
            Console.WriteLine($"Общее количество цифр: {totalDigits}");
            Console.WriteLine();

            // Б) Вывод на экран всех элементов массива, пока не встретится символ "/"
            Console.Write("Элементы до '/': ");
            bool slashFound = false;
            foreach (string str in inputArray)
            {
                if (str.Contains("/"))
                {
                    slashFound = true;
                    break;
                }
                Console.Write($"{str} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // В) Вывод на экран всех элементов массива, которые содержатся после символа "/", с заменой регистра
            List<string> postSlashElements = new List<string>();
            if (slashFound)
            {
                bool startPrinting = false;
                foreach (string str in inputArray)
                {
                    if (startPrinting)
                    {
                        string modifiedStr = new string(str.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray());
                        postSlashElements.Add(modifiedStr);
                    }
                    if (str.Contains("/"))
                    {
                        startPrinting = true;
                    }
                }
            }

            Console.Write("Элементы после '/' с измененным регистром: ");
            Console.WriteLine(string.Join(" ", postSlashElements));

            // Запись нового массива в файл
            string filePath = "output.txt";
            File.WriteAllLines(filePath, postSlashElements);
            Console.WriteLine($"Новый массив записан в файл '{filePath}'");
            Console.ReadKey();
        }
        
    }
}

