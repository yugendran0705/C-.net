using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting asynchronous operations...\n");

            try
            {
                
                List<Task<string>> tasks = new List<Task<string>>
                {
                    FetchDataFromTask("Task 1", 2000),
                    FetchDataFromTask("Task 2", 1000),
                    FetchDataFromTask("Task 3", 3000),
                    FetchDataFromTaskWithError("Task 4", 1500)
                };

                
                var results = await Task.WhenAll(tasks);

                
                Console.WriteLine("\nAll tasks completed. Results:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nException occurred: {ex.Message}");
            }
        }

        static async Task<string> FetchDataFromTask(string taskName, int delay)
        {
            Console.WriteLine($"{taskName}: Fetching data...");
            await Task.Delay(delay); 
            return $"{taskName}: Data fetched after {delay}ms";
        }

        static async Task<string> FetchDataFromTaskWithError(string taskName, int delay)
        {
            Console.WriteLine($"{taskName}: Fetching data...");
            await Task.Delay(delay); 
            throw new InvalidOperationException($"{taskName}: Failed to fetch data");
        }
    }
}