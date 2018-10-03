using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemos
{
    class Program
    {
        static void Main(string[] args)
        {
	        NumberOfPrimesInIntervalAsync(2, 10000)
		        .ContinueWith((resultTask) => Console.WriteLine(resultTask.Result));
        }

	    public static Task<int> NumberOfPrimesInIntervalAsync(int min, int max)
			=> Task.Run(() => NumberOfPrimesInInterval(min , max));


		public static int NumberOfPrimesInInterval(int min, int max)
	    {
		    var count = 0;
		    for (var i = min; i < max; i++)
		    {
			    var isPrime = true;
			    for (var j = 2; j < i; j++)
			    {
				    if (i % j != 0)
				    {
					    continue;
					}

				    isPrime = false;
				    break;
			    }

			    if (isPrime)
			    {
				    count++;
			    }
		    }

		    return count;
	    }

    }
}
