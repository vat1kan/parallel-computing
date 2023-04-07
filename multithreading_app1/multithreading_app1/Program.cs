using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SimpleMultithreadingApplication
{
    class Program
    {
        static void FirstThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(20);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This string is written by the first thread");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The first thread ended");
        }
        static void SecondThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The string that the second thread wrote");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The second thread is all");
        }
        static void ThirdThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(90);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You can read this string because the thirst thread is working");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Unfortunately, the third thread is over");
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(FirstThread));
            Thread thread2 = new Thread(new ThreadStart(SecondThread));
            Thread thread3 = new Thread(new ThreadStart(ThirdThread));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.WriteLine("Главный поток молчит");
            Console.WriteLine("Завершение главного потока");
            Console.ReadLine();

        }
    }
}
