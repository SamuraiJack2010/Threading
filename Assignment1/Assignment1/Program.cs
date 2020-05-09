using System;
using System.Threading;
namespace BasicThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Thread T1 = new Thread(ThreadStartFunction);
            T1.Start();
            Thread.Sleep(2000);
            Console.WriteLine("I have Started the Thread");
        }

        static void ThreadStartFunction()
        {

            for (var local = 0; local < 10; local++)
            {
                Console.WriteLine($"Local={local}");
                Thread.Sleep(1000);
            }
        }
    }
}
