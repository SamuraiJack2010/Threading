using System;
using System.Threading;

namespace ThreadMonitor
{
    class Program
    {
        //Single object MyLock Used for Monitor.
        //This .net object is used for Achieving the encapsulation of a critical section.
        //Used in Monitor Enter and Exit function.
        
        static object myLock = new object();
        static void Main(string[] args)
        {
            Thread ping = new Thread(TakeTurns);
            Thread pong = new Thread(TakeTurns);
            ping.Name = "ping";
            pong.Name = "pong";
            ping.Start();
            pong.Start();
        }
        static void TakeTurns() {
            //If we use new object() instead of myLock Below. Then lock will not be achieved 
            //and threads ping and pong will access the function simultaneously.
            Monitor.Enter(myLock);
            try
            {
                Console.WriteLine($"{ Thread.CurrentThread.Name } started");
                Thread.Sleep(2000);
                Console.WriteLine($"{ Thread.CurrentThread.Name } stopped");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(myLock);
                Console.WriteLine("Inside Finally");
            }
            Console.WriteLine("OutSide Finally");

        }
    }
}
