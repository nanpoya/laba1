
using System;
using System.Collections.Generic;
using System.Linq;

struct Buggage
{
    public int Id;          
    public int Count;      
    public double Weight;   
    public string Type;    

    public double AverageWeight => Weight / Count;  // Средний вес одной вещи
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество пассажиров:");
        int n = int.Parse(Console.ReadLine());

        Buggage[] array = new Buggage[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nПассажир {i + 1}:");

            Console.Write("Номер пассажира: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Количество вещей: ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Общий вес багажа (кг, используйте запятую): ");
            double weight;
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out weight) || weight <= 0)
            {
                Console.Write("Ошибка! Введите вес правильно (например: 15,5): ");
            }

            Console.Write("Тип багажа (1-габаритный, 2-негабаритный): ");
            string type;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    type = "габаритный";
                    break;
                }
                else if (input == "2")
                {
                    type = "негабаритный";
                    break;
                }
                else
                {
                    Console.Write("Ошибка! Введите 1 или 2: ");
                }
            }

            array[i] = new Buggage { Id = id, Count = count, Weight = weight, Type = type };
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("Введенные данные:");
        foreach (var luggage in array)
        {
            Console.WriteLine($"Пассажир {luggage.Id}: {luggage.Count} вещей, {luggage.Weight} кг, {luggage.Type}");
        }
        Console.WriteLine(new string('=', 50));

        // а) Найти число пассажиров, количество вещей которых превосходит среднее число вещей всех пассажиров
        double averageCount = array.Average(e => e.Count);
        int countAboveAverage = array.Count(e => e.Count > averageCount);
        Console.WriteLine($"\nа) Среднее количество вещей: {averageCount:F1}");
        Console.WriteLine($"Пассажиров с количеством вещей больше среднего: {countAboveAverage}");

        // б) Найти номер багажа, где средний вес вещи отличается от общего среднего не более чем на 0,5 кг
        double totalWeightAll = array.Sum(e => e.Weight);
        int totalItemsAll = array.Sum(e => e.Count);
        double averageWeightAll = totalWeightAll / totalItemsAll;

        Console.WriteLine($"\nб) Общий средний вес одной вещи: {averageWeightAll:F2} кг");
        Console.WriteLine("Номера багажа с близким весом вещи (разница ≤ 0,5 кг):");

        bool found = false;
        foreach (var luggage in array)
        {
            double difference = Math.Abs(luggage.AverageWeight - averageWeightAll);
            if (difference <= 0.5)
            {
                Console.WriteLine($"  Пассажир {luggage.Id}: {luggage.AverageWeight:F2} кг (разница: {difference:F2} кг)");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("  Не найдено багажа с близким весом вещи");
        }

        // в) Выполнить задание с фильтром по типу багажа
        Console.WriteLine("\nв) Введите тип багажа для фильтра (1-габаритный, 2-негабаритный):");
        string filterTypeInput = Console.ReadLine();
        string filterType = "";

        if (filterTypeInput == "1")
            filterType = "габаритный";
        else if (filterTypeInput == "2")
            filterType = "негабаритный";
        else
        {
            Console.WriteLine("Неверный ввод, используется тип 'габаритный'");
            filterType = "габаритный";
        }

        var filteredArray = array.Where(e => e.Type == filterType).ToArray();

        Console.WriteLine($"\nРезультаты для типа '{filterType}':");
        Console.WriteLine($"Общий средний вес одной вещи: {averageWeightAll:F2} кг");
        Console.WriteLine("Номера багажа с близким весом вещи:");

        found = false;
        foreach (var luggage in filteredArray)
        {
            double difference = Math.Abs(luggage.AverageWeight - averageWeightAll);
            if (difference <= 0.5)
            {
                Console.WriteLine($"  Пассажир {luggage.Id}: {luggage.AverageWeight:F2} кг (разница: {difference:F2} кг)");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("  Не найдено багажа с близким весом вещи");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}