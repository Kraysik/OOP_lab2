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

        List<Software> list = softwareList;
        // сортировка по цене
        list = list.OrderBy(x => x, new SoftwarePriceComparer()).ToList();
        Console.WriteLine("Sorting by price:");
        foreach (var soft in list)
        {
            Console.WriteLine($"neme: {soft.Name}, price: {soft.Price}");
        }

        // сортировка по размеру
        softwareList.Sort();
        Console.WriteLine("Sorting by size:");
        foreach (var soft in softwareList)
        {
            Console.WriteLine($"neme: {soft.Name}, size: {soft.Size}");
        }
    }
}