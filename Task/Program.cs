using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace Task
{
    class Program
    {
        public static void Shuffle<T>(List<T> list)
        {
            Random rand = new Random();

            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }
        struct Student
        {
            public string name;
            public string surname;
            public string birthday;
            public string examName;
            public int points;
            public Student(string n, string s, string b, string e, int p)
            {
                name = n;
                surname = s;
                birthday = b;
                examName = e;
                points = p;
            }
            public void ReedFile(string[] info)
            {
                name = info[0];
                surname = info[1];
                birthday = info[2];
                examName = info[3];
                points = int.Parse(info[4]);
            }
        }
        struct GrandMother
        {
            public string name;
            public int age;
            public List<string> illnesses;
            public List<string> medicines;
            public GrandMother(string n, int a, List<string> i, List<string> m)
            {
                name = n;
                age = a;
                illnesses = i;
                medicines = m;
            }
            public void Print()
            {
                Console.Write($"Имя: {name}\nВозраст: {age}\nБолезни: ");
                foreach (var i in illnesses)
                {
                    Console.Write(i + ", ");
                }
                Console.Write($"\nЛекарства: ");
                foreach (var i in medicines)
                {
                    Console.Write(i + ", ");
                }
                Console.WriteLine();
            }
        }
        struct Hospital
        {
            public string name;
            public List<string> illnesses;
            public int occupancy;
            public int capacity;
            public Hospital(string n, List<string> i, int o, int c)
            {
                name = n;
                illnesses = i;
                occupancy = o;
                capacity = c;
            }
            public void Print()
            {
                Console.Write($"Название: {name}\nЛечит болезни: ");
                foreach (var i in illnesses)
                {
                    Console.Write(i + ", ");
                }
                Console.Write($"\nЗаполненость: {occupancy}\nВместимость: {capacity}");
                Console.WriteLine();
            }
        }
        static bool Distributor(List<GrandMother> grandMothers, Stack<Hospital> sH)
        {
            int count = 0;
            foreach (var grandmother in grandMothers)
            {
                foreach (var hospital in sH)
                {
                    foreach(var diseases in grandmother.illnesses)
                    {
                        if (hospital.illnesses.Contains(diseases))
                        {
                            count++;
                        }
                    }
                    if (count >= (double)grandmother.illnesses.Count / 2.0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Программа перемешивает лист с картинками");
            List<string> imagesList = new List<string>(64);

            for (int i = 1; i < 33; i++)
            {
                imagesList.Add($"image{i.ToString()}.jpg");
            }
            for (int i = 1; i < 33; i++)
            {
                imagesList.Add($"image{i.ToString()}.jpg");
            }

            Console.WriteLine("Были: ");
            imagesList.Sort();
            foreach (var i in imagesList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nСтали:");
            Shuffle<string>(imagesList);
            foreach (var i in imagesList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nЗадание 2");
            Dictionary<string, Student> stDict = new Dictionary<string, Student>(10);

            bool flag = true;
            Console.WriteLine("Выберите действие(словами): \n1) Новый студент \n2) Удалить \n3) Сортировать \n4) Вывод \n5) Прочитать с файла \n6) Закрыть");
            while (flag)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "новый студент":
                        {
                            if (stDict.Count == 10)
                            {
                                Console.WriteLine("Словарь переполнен");
                            }
                            else
                            {
                                Console.Write("Введите имя: ");
                                string name = Console.ReadLine();
                                Console.Write("Введите фамилию: ");
                                string surname = Console.ReadLine();
                                Console.Write("Введите дату рождения: ");
                                string birthday = Console.ReadLine();
                                Console.Write("Введите экзамен: ");
                                string examName = Console.ReadLine();
                                Console.Write("Введите баллы: ");
                                int points = int.Parse(Console.ReadLine());

                                stDict.Add((name + surname).ToLower(), new Student(name, surname, birthday, examName, points));
                                Console.WriteLine("\nДобавлен новый студент");
                            }
                            break;
                        }
                    case "удалить":
                        {
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            string surname = Console.ReadLine();

                            if (stDict.ContainsKey((name + surname).ToLower()))
                            {
                                stDict.Remove((name + surname).ToLower());
                            }
                            Console.WriteLine("\nСтудент удален");
                            break;
                        }
                    case "сортировать":
                        {
                            stDict = stDict.OrderBy(dict => dict.Value.points).ToDictionary(dict => dict.Key, dict => dict.Value);
                            Console.WriteLine("\nОтсортировано");
                            break;
                        }
                    case "вывод":
                        {
                            Console.WriteLine();
                            for (int i = 0; i < stDict.Count; i++)
                            {
                                var student = stDict.ElementAt(i);
                                Console.WriteLine($"Имя: {student.Value.name}\nФамилия: {student.Value.surname}\nДата рождения: {student.Value.birthday}" +
                                    $"\nЭкзамен: {student.Value.examName}\nБаллы: {student.Value.points}");
                                Console.WriteLine();
                            }
                            break;
                        }
                    case "прочитать с файла":
                        {
                            Console.Write("Введите имя файла(Пример: text.txt): ");
                            string fullPath = Path.GetFullPath(Console.ReadLine());
                            FileInfo fileInfo = new FileInfo(fullPath);

                            if (fileInfo.Exists)
                            {
                                string[] inputData = File.ReadAllLines(fullPath);
                                for (int i = 0; i < inputData.Length; i++)
                                {
                                    Student student = new Student();
                                    student.ReedFile(inputData);
                                    stDict.Add((inputData[0] + inputData[1]).ToLower(), student);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nТакого файла не сущетсвует");
                            }
                            break;
                        }
                    case "закрыть":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                }
            }

            Console.WriteLine("\nЗадание 3");
            Console.WriteLine("Программа распределяет бабушек по больницам");

            List<GrandMother> grandMothers = new List<GrandMother>();
            Queue<GrandMother> grandMothersQueue = new Queue<GrandMother>();
            Stack<Hospital> hospitals = new Stack<Hospital>();

            Hospital hosptal1 = new Hospital("Городская", new List<string> { "Простуда", "Ковид", "Грипп", "Мигрень", "Пневмония", "Туберкулез" }, 2, 5);
            Hospital hosptal2 = new Hospital("Сельская", new List<string> { "Грипп", "Пневмония", "Туберкулез", "Диабет", "Инфаркт" }, 9, 10);
            hospitals.Push(hosptal1);
            hospitals.Push(hosptal2);

            Console.Write("\nВведите количество бабушек: ");
            if (int.TryParse(Console.ReadLine(), out int grandmaCount))
            {
                for (int i = 0; i < grandmaCount; i++)
                {
                    GrandMother grandMother = new GrandMother();
                    Console.Write("Введите имя: ");
                    grandMother.name = Console.ReadLine();
                    Console.Write("Введите возраст бабушки: ");
                    grandMother.age = int.Parse(Console.ReadLine());
                    Console.Write("Введите болезни бабушки через пробел: ");
                    string[] input = Console.ReadLine().Split();
                    var ilnList = input.ToList();
                    grandMother.illnesses = ilnList;
                    Console.Write("Введите лекарства от болезней через пробел: ");
                    input = Console.ReadLine().Split();
                    var medList = input.ToList();
                    grandMother.medicines = medList;
                    Console.WriteLine();
                    grandMothers.Add(grandMother);

                    if (Distributor(grandMothers, hospitals))
                    {
                        grandMothersQueue.Enqueue(grandMother);
                        Console.WriteLine("Бабушка попала в больницу");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Бабушка осталась на улице");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }

            foreach (var grand in grandMothersQueue)
            {
                grand.Print();
                Console.WriteLine();
            }

            foreach (var hospital in hospitals)
            {
                double procent = (double)grandMothersQueue.Count / hospital.capacity * 100;
                hospital.Print();
                Console.WriteLine($"Бабушек в больнице: {grandMothersQueue.Count}");
                Console.WriteLine($"Процент заполненности: {procent}");
                Console.WriteLine();
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
