using System;
using System.Threading;

namespace OOADandPatterns.Threads
{
    internal class ThreadSemaphore
    {
        private readonly SemaphoreSlim printa = new(1), printb = new(0);
        private static void Print_char(char c, SemaphoreSlim a, SemaphoreSlim b)
        {
            while (true)
            {
                a.Wait();
                Console.Write(c);
                b.Release();
            }
        }
        private void Print_char_b() => Print_char('b', printb, printa);
        public void Thread_start() //Main
        {
            new Thread(Print_char_b).Start();
            Print_char('a', printa, printb);
        }
    }
}
