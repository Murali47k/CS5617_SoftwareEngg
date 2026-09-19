using System;
using System.Threading;

class Program
{
    static int counter = 0;

    static readonly object counterLock = new object();

    // WITHOUT LOCK
    static void IncrementWithoutLock()
    {
        for (int i = 0; i < 100000; i++)
        {
            counter++;
        }
    }

    // WITH LOCK
    static void IncrementWithLock()
    {
        for (int i = 0; i < 100000; i++)
        {
            lock (counterLock)
            {
                counter++;
            }
        }
    }

    static void Main()
    {
        
        // WITHOUT LOCK

        counter = 0;

        Thread t1 = new Thread(IncrementWithoutLock);
        Thread t2 = new Thread(IncrementWithoutLock);
        Thread t3 = new Thread(IncrementWithoutLock);
        Thread t4 = new Thread(IncrementWithoutLock);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("WITHOUT LOCK");
        Console.WriteLine($"Counter: {counter}");
        Console.WriteLine($"Expected: {4 * 100000}");

        // WITH LOCK
        counter = 0;

        Thread t5 = new Thread(IncrementWithLock);
        Thread t6 = new Thread(IncrementWithLock);
        Thread t7 = new Thread(IncrementWithLock);
        Thread t8 = new Thread(IncrementWithLock);

        t5.Start();
        t6.Start();
        t7.Start();
        t8.Start();

        t5.Join();
        t6.Join();
        t7.Join();
        t8.Join();

        Console.WriteLine();
        Console.WriteLine("WITH LOCK");
        Console.WriteLine($"Counter: {counter}");
        Console.WriteLine($"Expected: {4 * 100000}");
    }
}