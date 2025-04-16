using System;

namespace Task6
{
    public delegate void ThresholdReachedEventHandler(int value);
    public class Counter
    {
        private int _count; 
        public int Threshold { get; set; } 

        public event ThresholdReachedEventHandler ThresholdReached;

        public void Increment()
        {
            _count++;
            Console.WriteLine($"Counter: {_count}");

            if (_count >= Threshold)
            {
                ThresholdReached?.Invoke(_count);
            }
        }
    }

 
    public class EventHandlers
    {
        public void Alert(int value)
        {
            Console.WriteLine($"Alert! Threshold of {value} reached.");
        }

        public void Log(int value)
        {
            Console.WriteLine($"Logging: Threshold {value} reached.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter { Threshold = 5 };

            EventHandlers handlers = new EventHandlers();

            counter.ThresholdReached += handlers.Alert;
            counter.ThresholdReached += handlers.Log;

            int c=0;
            while(true)
            {
                Console.Write("press Enter:");
                Console.ReadLine();
                counter.Increment();
                c+=1;
                if(c==5){
                    Console.WriteLine("\nUnsubscribing the Log handler...\n");
                    counter.ThresholdReached -= handlers.Log;
                }
                
            }
        }
    }
}