using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SFyCSm013p6e1;

class Program
{
    /// <summary>
    /// Процедура реализующая основной алгоритм работы приложения.
    /// Замер времени выполнения операций вставки
    /// </summary>
    static void PerformTiming()
    {
        // Путь к файлу в который будет выполнятся вставка
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt"); 

        var list = new List<String>();
        var linkedList = new LinkedList<String>();

        using (StreamReader stream = File.OpenText(filePath))
        {
            string? line = "";

            while ((line = stream.ReadLine()) != null)
            {
                list.Add(line);
                linkedList.AddLast(line);
            }
        }

        var watch = new Stopwatch();

        watch.Start();
        list.Insert(0, "");
        watch.Stop();

        Console.WriteLine("Замер операции \"list.Insert\": {0} мс.", watch.Elapsed.TotalMilliseconds);

        watch.Start();
        linkedList.AddFirst("");
        watch.Stop();

        Console.WriteLine("Замер операции \"linkedList.AddFirst\": {0} мс.", watch.Elapsed.TotalMilliseconds);
    }

    /// <summary>
    /// Главная точка входа приложения
    /// </summary>
    /// <param name="args">Аргументы командной строки при запуске приложения.</param>
    static void Main(string[] args)
    {
        PerformTiming();
    }
}