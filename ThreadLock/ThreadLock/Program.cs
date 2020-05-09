using System;
using System.Threading;

namespace ThreadLock
{
    class Program
    {
        //Single object MyLock Used with lock.
        //This .net object is used for Achieving the encapsulation of a critical section.
        //lock is nothing but Monitor object with Enter and Exit function.
        static object myObject = new object();
        static void Main(string[] args)
        {
            Thread ping = new Thread(MyThread);
            Thread pong = new Thread(MyThread);
            ping.Name = "ping";
            pong.Name = "pong";
            ping.Start();
            pong.Start();
        }

        static void MyThread() {
            //Critical Section has been defended via lock using myObject.
            //myObject plays an critical part in encapsulation.i.e. at a given time only one thread can access 
            //the code within lock(){}
            //If we use new object() instead of myObject,then all the threads will access the code within lock(){}
            //simultaneously
            try
            {
                lock (myObject)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} started");
                    Thread.Sleep(500);
                    //throw new Exception("Test"); //Check how lock is handled when error occurs
                    Console.WriteLine($"{Thread.CurrentThread.Name} stopped");
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
