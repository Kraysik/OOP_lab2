using Lab2;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Чтение данных из файла и заполнение массива объектов Software
        List<Software> softwareList = new List<Software>();
        using (var reader = new StreamReader("software.txt"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var data = line.Split(',');
                try
                {
                    var software = new Software
                    {
                        Name = data[0],
                        Type = data[1],
                        Size = int.Parse(data[2]),
                        Price = float.Parse(data[3])
                    };
                    softwareList.Add(software);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Произошла ошибка формата: {0}", ex.Message);
                }

            }
        }

        // Поиск объектов в массиве по введенному значению
        Console.Write("Введите наименование программного обеспечения: ");
        var searchName = Console.ReadLine();
        var result = softwareList.Where(x => x.Name == searchName).ToList();

        // Вывод результатов поиска
        if (result.Count > 0)
        {
            Console.WriteLine("Результаты поиска:");
            foreach (var software in result)
            {
                Console.WriteLine($"{software.Name}, {software.Type}, {software.Size} МБ, {software.Price} руб.");
            }
        }
        else
        {
            Console.WriteLine("Ничего не найдено");
        }
    }
}