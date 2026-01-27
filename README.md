•	
o	Assignment: (If working with a UI project like WPF or WinForms, or in a console app simulating a long process) Create a long-running operation (e.g., a heavy calculation or file processing). Run this operation using Task.Run() or the ThreadPool so that it doesn't block the main thread (or UI thread), allowing the application to remain responsive.
o	Learning Objective: Understand the difference between foreground/background execution, the ThreadPool, and the importance of keeping the UI/main thread free.
•	Assignment: Simulate fetching data from several slow network sources (using Task.Delay to mimic latency). Use Task.WhenAll to execute these "fetches" concurrently and process the results once all are complete.
•	Learning Objective: Utilize modern C# asynchronous programming features (async/await, Task.WhenAll) for efficient parallel I/O-bound operations. 
•	Assignment 8: Task Cancellation
o	Goal: Gracefully stop long-running operations.
o	Task: Create a CancellationTokenSource. Start a Task that performs a loop and periodically checks token.IsCancellationRequested. Trigger the cancellation from the main thread after 2 seconds. 


//#region MyRegion
////class akshay
////{
////    public static void WriteError()
////    {
////        Console.WriteLine("Error number = " + Thread.GetData(Thread.GetNamedDataSlot("ErrNo")));
////        Console.WriteLine("Error source = " + Thread.GetData(Thread.GetNamedDataSlot("ErrSource")));
////    }
////    public static void SetError()
////    {
////        Random r = new Random();
////        Thread.SetData(Thread.GetNamedDataSlot("ErrNo"), r.Next(100));
////        Thread.SetData(Thread.GetNamedDataSlot("ErrSource"), Thread.CurrentThread.Name);
////        WriteError();
////    }
////    public static void Main()
////    {
////        Thread.AllocateNamedDataSlot("ErrNo");
////        Thread.AllocateNamedDataSlot("ErrSource");
////        Thread th2 = new Thread(new ThreadStart(SetError));
////        th2.Name = "t2";
////        th2.Start();
////        Thread th3 = new Thread(new ThreadStart(SetError));
////        th3.Name = "t3";
////        th3.Start();
////        Thread.FreeNamedDataSlot("ErrNo");
////        Thread.FreeNamedDataSlot("ErrSource");
////        Console.Read();
////    }
////}
//#endregion
//using System;
//using System.Threading;
//namespace ThreadLocalStorage
//{
//    class akshay
//    {
//        public static void WriteError()
//        {
//            Console.WriteLine("Error number = " + Thread.GetData(Thread.GetNamedDataSlot("ErrNo")));
//            Console.WriteLine("Error source = " + Thread.GetData(Thread.GetNamedDataSlot("ErrSource"))
//        }
//        public static void SetError()
//        {
//            Random r = new Random();
//            Thread.SetData(Thread.GetNamedDataSlot("ErrNo"), r.Next(100));
//            Thread.SetData(Thread.GetNamedDataSlot("ErrSource"), Thread.CurrentThread.Name);
//            WriteError();
//        }
//        public static void Main()
//        {
//            Thread.AllocateNamedDataSlot("ErrNo");
//            Thread.AllocateNamedDataSlot("ErrSource");
//            Thread th2 = new Thread(new ThreadStart(SetError));
//            th2.Name = "t2";
//            th2.Start();
//            Thread th3 = new Thread(new ThreadStart(SetError));
//            th3.Name = "t3";
//            th3.Start();
//            Thread.FreeNamedDataSlot("ErrNo");
//            Thread.FreeNamedDataSlot("ErrSource");
//            Console.Read();
//        }
//    }
//using Aerospike.Client;
//using System;

//class Program
//{
//    static void Main()
//    {
//        // Aerospike client initialization
//        AerospikeClient client = new AerospikeClient("127.0.0.1", 3000);
//        string namespaceName = "test";  // Replace with your namespace
//        string setName = "demo";        // Replace with your set name
//        string keyValue = "key1";       // Replace with your key value
//        Key key1 = new Key(namespaceName, setName, keyValue);

//        Key key2 = new Key(namespaceName, "demo1", "key2");




//        // Prepare a list of keys to read
//        List<Key> keyValuesToRead = new List<Key>
//        {
//            key1,key2
//        };

//        // Batch read the records
//        Record[] records = client.Get(null, keyValuesToRead.ToArray());

//        // Process the retrieved records
//        for (int i = 0; i < records.Length; i++)
//        {
//            if (records[i] != null)
//            {
//                Console.WriteLine(records[i].bins.Keys.Take(1).F);
//            }
//            else
//            {
//                Console.WriteLine($"Record {keyValuesToRead[i]} not found.");
//            }
//        }

//        // Close the Aerospike client
//        client.Close();


//    }
//}
//using Aerospike.Client;
//using System;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Threading.Tasks;

//partial class Program
//{
//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Main Thread Start.");
//        Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");
//        Console.WriteLine("Initiating long-running operation asynchronously...");

//        // Start the operation without blocking the Main thread
//        Task<long> longRunningTask = StartLongOperationAsync();

//        // The Main thread is free to do other work while the task runs:
//        Console.WriteLine("Main thread is not blocked. Enter commands here (e.g., 'status'):");

//        // Simulate application responsiveness by handling user input
//        bool isRunning = true;
//        while (isRunning)
//        {
//            string input = Console.ReadLine();
//            if (input?.ToLower() == "status")
//            {
//                Console.WriteLine($"Status Check: Task completion status is {longRunningTask.IsCompleted}.");
//            }
//            else if (input?.ToLower() == "exit")
//            {
//                isRunning = false;
//                break;
//            }
//            else if (string.IsNullOrEmpty(input))
//            {
//                continue;
//            }
//            else
//            {
//                Console.WriteLine($"Unknown command: '{input}'. Try 'status' or 'exit'.");
//            }
//        }

//        // Await the result of the task when needed (or before the app closes)
//        Console.WriteLine("\nAwaiting the final result of the long operation...");
//        long result = await longRunningTask;
//        Console.WriteLine($"\nOperation completed. Total duration: {result} milliseconds.");

//        Console.WriteLine("Main Thread End.");
//    }

//    /// <summary>
//    /// Starts a long-running simulation using Task.Run() to offload the work.
//    /// </summary>
//    static Task<long> StartLongOperationAsync()
//    {
//        // Task.Run offloads the synchronous work to the ThreadPool.
//        // The calling method (Main) immediately gets control back.
//        return Task.Run(async () =>
//        {
//            // The code within this lambda runs on a ThreadPool thread,
//            // not the main application thread.
//            Console.WriteLine($"\n--- Operation started on Thread ID: {Thread.CurrentThread.ManagedThreadId} (ThreadPool) ---");
//            Stopwatch stopwatch = Stopwatch.StartNew();

//            const int iterations = 20;
//            for (int i = 0; i < iterations; i++)
//            {
//                // In a real app, replace this with CPU-intensive work (e.g., heavy calculation, file I/O)
//                await Task.Delay(1000); // Simulate 1 second of work
//                Console.WriteLine($"--- Operation step {i + 1}/{iterations} completed... ---");
//            }

//            stopwatch.Stop();
//            Console.WriteLine("--- Operation finished in background ---");
//            return stopwatch.ElapsedMilliseconds;
//        });
//    }
//}
////</ code >

////### How It Works

////1.  * *`Task.Run()`:**This is the key component.It schedules the provided code block (`async () => { ... }`) to run on a separate thread managed by the .NET `ThreadPool`.
////2.  **Responsiveness:**The `Main` method continues execution immediately after calling `StartLongOperationAsync()`. The console application remains responsive, allowing you to type commands like `status` while the operation runs in the background.
////3.  **`await Task.Delay(1000)`:**Inside the long-running task simulation, `await` ensures that the *specific thread* running the loop is not blocked during the simulated delay, making it highly efficient.
////4.  **`await longRunningTask`:**The `Main` method uses `await` to pause its *own* execution only when it genuinely needs the final result from the background task, ensuring the application doesn't close before the work is done.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting data fetches concurrently...");
        Stopwatch stopwatch = Stopwatch.StartNew();

        // 1. Define the concurrent tasks using Task.WhenAll
        Task<string> fetchTaskA = FetchDataAsync("Source A", 3000); // 3-second delay
        Task<string> fetchTaskB = FetchDataAsync("Source B", 2000); // 2-second delay
        Task<string> fetchTaskC = FetchDataAsync("Source C", 4000); // 4-second delay

        // 2. Await all tasks to complete simultaneously
        // The program will pause here until the *longest* running task is finished.
        string[] results = await Task.WhenAll(fetchTaskA, fetchTaskB, fetchTaskC);

        stopwatch.Stop();

        // 3. Process the results once all are complete
        Console.WriteLine("\nAll data sources have returned their data.");
        Console.WriteLine($"Total execution time: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("\n--- Results ---");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    /// <summary>
    /// Simulates a slow network fetch with latency using Task.Delay.
    /// </summary>
    /// <param name="sourceName">The name of the data source.</param>
    /// <param name="delayInMilliseconds">The time to delay to mimic latency.</param>
    /// <returns>A task that returns a string result after the delay.</returns>
    static async Task<string> FetchDataAsync(string sourceName, int delayInMilliseconds)
    {
        Console.WriteLine($"Task for {sourceName} started. (Delay: {delayInMilliseconds}ms)");

        // Mimic network latency
        await Task.Delay(delayInMilliseconds);

        Console.WriteLine($"Task for {sourceName} completed.");

        return $"Data from {sourceName}: Successfully fetched after {delayInMilliseconds}ms.";
    }
}

