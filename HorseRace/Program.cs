using System;
using System.Threading;

namespace HorseRace
{
    partial class Program
    {
        static AutoResetEvent finishLine = new AutoResetEvent(false);
        static int count = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Horse1), finishLine);
                ThreadPool.QueueUserWorkItem(new WaitCallback(Horse2), finishLine);
                ThreadPool.QueueUserWorkItem(new WaitCallback(Horse3), finishLine);

                finishLine.WaitOne();

                Console.WriteLine(count.ToString());

                Console.ReadKey();
            }
        }

        static void Horse1(object stateInfo)
        {
            Console.WriteLine("Start galloping.");

            // Simulate time spent working.
            Thread.Sleep(new Random().Next(100, 2000));

            // Signal that work is finished.
            count = 1;
            ((AutoResetEvent)stateInfo).Set();
        }

        static void Horse2(object stateInfo)
        {
            Console.WriteLine("Start galloping.");

            // Simulate time spent working.
            Thread.Sleep(new Random().Next(100, 2000));

            // Signal that work is finished.
            count = 2;
            ((AutoResetEvent)stateInfo).Set();
        }

        static void Horse3(object stateInfo)
        {
            Console.WriteLine("Start galloping.");

            // Simulate time spent working.
            Thread.Sleep(new Random().Next(100, 2000));

            // Signal that work is finished.
            count = 3;
            ((AutoResetEvent)stateInfo).Set();
        }
    }
}
