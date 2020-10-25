using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void methodA()
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("Chicken running........");
                Thread.Sleep(1000);
            }
            Console.WriteLine("         Chicken completed");
            DateTime end = DateTime.Now;
            TimeSpan ts = (end - start);
            Thread.Sleep(18000);
            Console.WriteLine("3.Chicken:"+ts.TotalMilliseconds);
        }

        static void methodB()
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Cat running........");
                Thread.Sleep(1000);
            }
            Console.WriteLine("         Cat completed");
            DateTime end = DateTime.Now;
            TimeSpan ts = (end - start);
            Thread.Sleep(18000);
            Console.WriteLine("2.Cat:"+ts.TotalMilliseconds);
        }

        static void methodC()
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                
                Console.WriteLine("Dog running........");
                Thread.Sleep(1000);
            }
            Console.WriteLine("         Dog completed");
            DateTime end = DateTime.Now;
            TimeSpan ts = (end - start);
            Thread.Sleep(18000);
            Console.WriteLine("Summary:");
            Console.WriteLine("1.Dog:"+ts.TotalMilliseconds);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Dog waiting.......");
            Console.WriteLine("Cat waiting.......");
            Console.WriteLine("Chicken waiting.......");
            Console.WriteLine("Start running.......");
            Thread t1 = new Thread(new ThreadStart(methodA));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(methodB));
            t2.Start();
            Thread t3 = new Thread(new ThreadStart(methodC));
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("All completed!");






        }
    }
}
