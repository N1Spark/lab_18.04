using System;
using System.Collections.Generic;
using System.Threading;


namespace lab1_18._04
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> numbers = new List<string>() { "Bi", " Ba", " i ", "Bo", "Ba " };
            Thread thread = new Thread(() =>
            {
                foreach (string number in numbers)
                    Console.Write($" {number}");
            });
            thread.Start();
            thread.Join();
            Console.ReadLine();
        }
    }
}
