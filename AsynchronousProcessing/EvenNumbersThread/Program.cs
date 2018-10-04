using System;
using System.Linq;
using System.Threading;

namespace EvenNumbersThread
{
    class Program
    {
        static void Main(string[] args)
        {
	        var input = Console.ReadLine()
		        .Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries)
		        .Select(int.Parse)
		        .ToArray();
	        Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} finished.");

			Thread evens = new Thread(() => PrintEventNumbers(input[0],input[1]));
			evens.Start();
	        evens.Join();
			Console.WriteLine("Thread finished work!");
        }

	    private static void PrintEventNumbers(int start, int end)
	    {
		    for (int i = start; i <= end; i++)
		    {
			    if (i % 2 != 0)
			    {
				    continue;
				}
			    Console.WriteLine(i);
			    Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} finished.");
		    }
	    }
    }
}
