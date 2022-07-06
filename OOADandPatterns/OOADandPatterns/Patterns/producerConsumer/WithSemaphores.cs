using System;
using System.Threading;

namespace OOADandPatterns.Patterns.producerConsumer
{
    /*
        A global array of 100 integers
        Producer Thread: Generates random numbers
            Generate 1 million random numbers and write it to array
        Consumer thread: Counting odds/evens
            Wait for number to be generated
            Read the numbers
    */

    internal class WithSemaphores
    {
        private const int SIZE = 100;
        private volatile int[] buffer = new int[SIZE];
        private readonly SemaphoreSlim free_slots = new(SIZE), used_slots = new(0);
        private void Producer()
        {
            int position = 0;
            Random random = new();
            for (int i = 0; i < 1000000; i++)
            {
                int n = random.Next();
                free_slots.Wait();
                buffer[position] = n;
                used_slots.Release();
                position = (position + 1) % SIZE;
            }
        }
        private void Consumer()
        {
            int position = 0, odds = 0, evens = 0;
            for (int i = 0; i < 1000000; i++)
            {
                used_slots.Wait();
                int n = buffer[position];
                free_slots.Release();
                _ = (n % 2 == 0) ? evens++ : odds++;
                position = (position + 1) % SIZE;
            }
            Console.WriteLine($"Evens: {evens}  Odds: {odds}");
        }

        public void ProducerConsumer() //Main
        {
            new Thread(Producer).Start();
            Consumer();
        }
    }
}
