using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static Random random = new Random();
    static void Main()
    {

        // Продемонструвати роботу з класом Thread
        ThreadDemo();

        // Продемонструвати роботу з класом Thread(декілька потоків)
        RunThreads();


        // Продемонструвати роботу з Async-Await
        TaskDemo();

        Console.ReadLine();
    }



    // Продемонструвати роботу з класом Thread
    static void ThreadDemo()
    {
        Console.WriteLine("Thread Demo:");

        // Створюємо новий об'єкт Thread та передаємо метод, який ми хочемо виконати
        Thread thread = new Thread(DoWork);
        // Запускаємо потік
        thread.Start();

        Console.WriteLine("Main thread is working...");
    }

    static void DoWork()
    {
        // Логіка, яка виконується в іншому потоці
        Console.WriteLine("Worker thread is working...");
        Thread.Sleep(2000); // Пауза на 2 секунди
        Console.WriteLine("Worker thread finished.");
    }

    static void ThreadsWork(object threadName)
    {
        string name = (string)threadName;
        Console.WriteLine($"{name} is working...");
        for(int i = 0; i <= 3; i++)
        {
            int randomNumber = random.Next(0, 101);
            Console.WriteLine($"{name}. Try {i+1}. Resut: {randomNumber}");
            Thread.Sleep(300);
        }
        Console.WriteLine($"{name} finished.");
    }



    static void RunThreads()
    {
        Thread thread1 = new Thread(ThreadsWork);
        Thread thread2 = new Thread(ThreadsWork);
        Thread thread3 = new Thread(ThreadsWork);

        thread1.Start("Thread 1");
        thread2.Start("Thread 2");
        thread3.Start("Thread 3");
    }




    // Продемонструвати роботу з Async-Await
    static async void TaskDemo()
    {
        Console.WriteLine("\nAsync-Await Demo:");

        // Асинхронно викликаємо метод, який повертає Task
        Task<int> task = TaskMethod();
        Console.WriteLine("Main thread is working...");

        // Очікуємо завершення асинхронного методу та виводимо результат
        int result = await task;
        Console.WriteLine($"Result from async method: {result}");
    }

    static async Task<int> TaskMethod()
    {
        Console.WriteLine("Async method is working...");

        await Task.Delay(2000); // Асинхронна пауза на 2 секунди
        Console.WriteLine("Async method finished.");

        // Повертаємо результат
        return 42;
    }

   


}