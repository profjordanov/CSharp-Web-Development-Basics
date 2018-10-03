using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RaceConditionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
			object lockObj = new object(); //Solution
			var threads = new List<Thread>();
	        int num = 0;
			try
			{
		        for(int i = 0; i < 8; i++)
		        {
			        var thread = new Thread(() =>
			        {
				        for (int j = 0; j < 10000; j++)
				        {
					        if (j == 100)
					        {
						        throw new Exception();
					        }
					        //Interlocked.Increment(ref num);
							lock(lockObj)
							{
								num++;
							}
						}

						Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} finished.");
			        });
					threads.Add(thread);
					thread.Start();
		        }
			}
	        catch (Exception e)
	        {
		        Console.WriteLine("!!!!!!!" + e);
	        }

	        foreach (var thread in threads)
	        {
		        thread.Join();
	        }
	        Console.WriteLine(num);
		}

	    private void ExampleTwo() //PROBLEM
	    {
		    var threads = new List<Thread>();
		    int num = 0;
		    try
		    {
			    for(int i = 0; i < 2; i++)
			    {
				    var thread = new Thread(() =>
				    {
					    for(int j = 0; j < 10000; j++)
					    {
						    num++;
						    /*
						     * get num value to tmp
						     * add 1 to tmp
						     * set tmp to num
						     */
					    }

					    Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} finished.");
				    });
				    threads.Add(thread);
				    thread.Start();
			    }
		    }
		    catch(Exception e)
		    {
			    Console.WriteLine(e);
		    }

		    foreach(var thread in threads)
		    {
			    thread.Join();
		    }
		    Console.WriteLine(num);
		}

		private void ExampleOne()
	    {
		    List<int> numbers = Enumerable.Range(0 , 10000).ToList();
		    for(int i = 0; i < 4; i++)
		    {
			    new Thread(() =>
			    {
				    while(numbers.Count > 0)
				    {
					    numbers.RemoveAt(numbers.Count - 1);
				    }
			    }).Start();
		    }
		}
    }
}
