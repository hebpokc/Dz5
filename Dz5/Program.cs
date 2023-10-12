using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz5
{
    class Program
    {
        static int CountVowelsAndConsonants(out int consonants, char[] text)
        {
            string vowelsList = "аяуюоеёэиы";
            string consonantsList = "бвгджзйклмнпрстфхцчшщ";
            int vowels = 0;
            consonants = 0;

            foreach (char i in text)
            {
                if (char.IsLetter(i))
                {
                    if (vowelsList.Contains(char.ToLower(i)))
                    {
                        vowels++;
                    }
                    else if(consonantsList.Contains(char.ToLower(i)))
                    {
                        consonants++;
                    }
                }
            }
            return vowels;
        }
        static int CountVowelsAndConsonants(out int consonants, List<char> text)
        {
            string vowelsList = "аяуюоеёэиы";
            string consonantsList = "бвгджзйклмнпрстфхцчшщ";
            int vowels = 0;
            consonants = 0;

            foreach (char i in text)
            {
                if (char.IsLetter(i))
                {
                    if (vowelsList.Contains(char.ToLower(i)))
                    {
                        vowels++;
                    }
                    else if (consonantsList.Contains(char.ToLower(i)))
                    {
                        consonants++;
                    }
                }
            }
            return vowels;
        }
        static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void PrintMatrix(LinkedList<LinkedList<int>> a)
        {
            foreach (var lists in a)
            {
                foreach (int i in lists)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] MultMatrix(int[,] a, int[,] b)
        {
            int[,] c = new int[2, 2];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        //static LinkedList<LinkedList<int>> MultMatrix(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
        //{
        //    LinkedList<LinkedList<int>> c = new LinkedList<LinkedList<int>>();
        //    int first = 0;
        //    int second = 0;
        //    int third = 0;
        //    int fourth = 0;

        //    foreach (var lists in a)
        //    {
                
        //    }

        //    c.AddLast(new LinkedList<int>(new int[2] { first, second }));
        //    c.AddLast(new LinkedList<int>(new int[2] { third, fourth }));
        //    return c;
        //}
        static double[] AverageTemperatures(int [,] t)
        {
            double[] average = new double[12];

            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    average[i] += t[i, j];
                }
                average[i] = Math.Round(average[i] / 30, 1);
            }
            return average;
        }
        static Dictionary<string, double> AverageTemperatures(Dictionary<string, int[]> temperature)
        {
            Dictionary<string, double> monthAver = new Dictionary<string, double>();
            foreach (var month in temperature)
            {
                double sum = 0;

                for (int i = 0; i < 30; i++)
                {
                    sum += month.Value[i];
                }
                monthAver.Add(month.Key, sum / (double)30);
            }
            return monthAver;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.1");
            Console.Write("Введите имя файла(Пример: text.txt): ");
            string fullPath = Path.GetFullPath(Console.ReadLine());
            FileInfo fileInfo = new FileInfo(fullPath);

            if (fileInfo.Exists)
            {
                string text = File.ReadAllText(fullPath);
                char[] inputText = File.ReadAllText(fullPath).ToCharArray();
                int vowels = CountVowelsAndConsonants(out int consonants, inputText);

                Console.WriteLine($"\nТекст из файла: {text}");
                Console.WriteLine($"\nКоличество гласных букв: {vowels}\nКоличество согласных букв: {consonants}");
            }
            else
            {
                Console.WriteLine("\nТакого файла не сущетсвует");
            }

            Console.WriteLine("\nУпражнение 6.2");
            Console.WriteLine("Программа умножение двух матриц: \n1) Рандомные числа \n2) Ввести числа");
            Random rnd = new Random();
            int[,] mas1 = new int[2, 2];
            int[,] mas2 = new int[2, 2];
            int[,] mas3;
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    for (int i = 0; i < mas1.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas1.GetLength(1); j++)
                        {
                            mas1[i, j] = rnd.Next(-10, 10);
                        }
                    }
                    for (int i = 0; i < mas2.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas2.GetLength(1); j++)
                        {
                            mas2[i, j] = rnd.Next(-10, 10);
                        }
                    }
                    Console.WriteLine("\nМатрица 1");
                    PrintMatrix(mas1);
                    Console.WriteLine("\nМатрица 2");
                    PrintMatrix(mas2);

                    mas3 = MultMatrix(mas1, mas2);
                    Console.WriteLine("\nМатрица 3");
                    PrintMatrix(mas3);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nВведите числа для матрицы 1");
                    for (int i = 0; i < mas1.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas1.GetLength(1); j++)
                        {
                            if (int.TryParse(Console.ReadLine(), out int a))
                            {
                                mas1[i, j] = a;
                            }
                        }
                    }
                    Console.WriteLine("\nВведите числа для матрицы 2");
                    for (int i = 0; i < mas2.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas2.GetLength(1); j++)
                        {
                            if (int.TryParse(Console.ReadLine(), out int a))
                            {
                                mas2[i, j] = a;
                            }
                        }
                    }

                    Console.WriteLine("\nМатрица 1");
                    PrintMatrix(mas1);
                    Console.WriteLine("\nМатрица 2");
                    PrintMatrix(mas2);

                    mas3 = MultMatrix(mas1, mas2);
                    Console.WriteLine("\nМатрица 3");
                    PrintMatrix(mas3);
                }
                else
                {
                    Console.WriteLine("\nНеверный ввод");
                }
            }
            else
            {
                Console.WriteLine("\nВы ввели не число или дробное число");
            }

            Console.WriteLine("\nУпражнение 6.3");
            Console.WriteLine("Программа вычисляет среднюю температуру за год.");
            int[,] temperature = new int[12, 30];
            double averageYearTemp = 0;

            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rnd.Next(-20, 35);
                }
            }

            Console.WriteLine("\nВывести температуры? \n1) Да \n2) Нет");
            int choice2;
            double[] averageTemps = AverageTemperatures(temperature);
            if (int.TryParse(Console.ReadLine(), out choice2))
            {
                if (choice2 == 1)
                {
                    Console.WriteLine();
                    for (int i = 0; i < temperature.GetLength(0); i++)
                    {
                        Console.WriteLine($"Месяц {i + 1}");
                        for (int j = 0; j < temperature.GetLength(1); j++)
                        {
                            Console.WriteLine(temperature[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("Средние температуры");
                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        Console.WriteLine($"Месяц {i + 1} - {averageTemps[i]}");
                    }

                    Console.WriteLine("\nОтсортированный массив");
                    Array.Sort(averageTemps);

                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        Console.WriteLine(averageTemps[i]);
                    }

                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        averageYearTemp += averageTemps[i];
                    }
                    Console.WriteLine($"\nСредняя температура за год: {Math.Round(averageYearTemp / (double)12, 1)}");
                }
                else if (choice2 == 2)
                {
                    Console.WriteLine("\nСредние температуры");
                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        Console.WriteLine($"Месяц {i + 1} - {averageTemps[i]}");
                    }

                    Console.WriteLine("\nОтсортированный массив");
                    Array.Sort(averageTemps);

                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        Console.WriteLine(averageTemps[i]);
                    }

                    for (int i = 0; i < averageTemps.GetLength(0); i++)
                    {
                        averageYearTemp += averageTemps[i];
                    }
                    Console.WriteLine($"\nСредняя температура за год: {Math.Round(averageYearTemp / (double)12, 1)}");
                }
                else
                {
                    Console.WriteLine("\nНеверный ввод");
                }
            }
            else
            {
                Console.WriteLine("Введено не число или дробное число");
            }

            Console.WriteLine("\nДомашнее задание 6.1");
            Console.Write("Введите имя файла(Пример: text.txt): ");
            fullPath = Path.GetFullPath(Console.ReadLine());
            FileInfo fileInfo2 = new FileInfo(fullPath);

            if (fileInfo2.Exists)
            {
                string text = File.ReadAllText(fullPath);
                List<char> charList = new List<char>();
                charList.AddRange(File.ReadAllText(fullPath).ToCharArray());
                int vowels = CountVowelsAndConsonants(out int consonants, charList);

                Console.WriteLine($"\nТекст из файла: {text}");
                Console.WriteLine($"\nКоличество гласных букв: {vowels}\nКоличество согласных букв: {consonants}");
            }
            else
            {
                Console.WriteLine("\nТакого файла не сущетсвует");
            }

            Console.WriteLine("\nДомашнее задание 6.2");
            Console.WriteLine("Программа умножение двух матриц: \n1) Рандомные числа");
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix3 = new LinkedList<LinkedList<int>>();
            int choice3;
            if (int.TryParse(Console.ReadLine(), out choice3))
            {
                if (choice3 == 1)
                {
                    matrix1.AddLast(new LinkedList<int>(new int[2] { rnd.Next(-10, 10), rnd.Next(-10, 10) }));
                    matrix1.AddLast(new LinkedList<int>(new int[2] { rnd.Next(-10, 10), rnd.Next(-10, 10) }));

                    matrix2.AddLast(new LinkedList<int>(new int[2] { rnd.Next(-10, 10), rnd.Next(-10, 10) }));
                    matrix2.AddLast(new LinkedList<int>(new int[2] { rnd.Next(-10, 10), rnd.Next(-10, 10) }));

                    Console.WriteLine("\nМатрица 1");
                    PrintMatrix(matrix1);
                    Console.WriteLine("\nМатрица 2");
                    PrintMatrix(matrix2);

                    //matrix3 = MultMatrix(matrix1, matrix2);
                    //Console.WriteLine("\nМатрица 3");
                    //PrintMatrix(matrix3);
                }
                else
                {
                    Console.WriteLine("\nНеверный ввод");
                }
            }
            else
            {
                Console.WriteLine("\nВы ввели не число или дробное число");
            }

            Console.WriteLine("\nДомашнее задание 6.3");
            Console.WriteLine("Программа вычисляет среднюю температуру за год.");
            Dictionary<string, int[]> temperature2 = new Dictionary<string, int[]>();
            Dictionary<string, double> monthAver = new Dictionary<string, double>();
            averageYearTemp = 0;

            for (int i = 0; i < 12; i++)
            {
                int[] monthTemp = new int[30];

                for (int j = 0; j < 30; j++)
                {
                    monthTemp[j] = rnd.Next(-20, 35);
                }
                DateTime DateMonth = new DateTime(1, 1, 1).AddMonths(i);
                string month = DateMonth.ToString("MMMM");
                temperature2.Add(month, monthTemp);
            }
            monthAver = AverageTemperatures(temperature2);
            Console.WriteLine();
            foreach (var month in temperature2)
            {
                Console.WriteLine($"{month.Key}");
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine($"{month.Value[i]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Средние температуры:");
            Console.WriteLine();
            foreach (var month in monthAver)
            {
                Console.WriteLine($"Средняя температура в {month.Key} = {Math.Round(month.Value, 1)} градусов");
            }

            Console.WriteLine("\nОтсортированный массив");
            Console.WriteLine();
            monthAver = monthAver.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in monthAver)
            {
                Console.WriteLine(item.Key + " = " + Math.Round(item.Value, 1) + " градусов");
            }
            foreach (var mounth in monthAver)
            {
                averageYearTemp += mounth.Value;
            }

            Console.WriteLine($"\nСредняя температура за год: {Math.Round(averageYearTemp / (double)12, 1)}");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
