using System;
using System.Runtime.CompilerServices;
using System.Threading;
namespace Assigment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread Eena = new Thread(ThreadStartFunction);
            Eena.Name = "Eena";
            Thread Meena = new Thread(ThreadStartFunction);
            Meena.Name = "Meena";
            Thread Dika = new Thread(ThreadStartFunction);
            Dika.Name = "Dika";
            Eena.Start();
            Meena.Start();
            Dika.Start();
            Console.WriteLine("Done!");
        }

        static void ThreadStartFunction() {

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"For Thread :{Thread.CurrentThread.Name} and i={i}");
                Thread.Sleep(1000);
            }
        } 
    }
}
