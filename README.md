•	
o	Assignment: (If working with a UI project like WPF or WinForms, or in a console app simulating a long process) Create a long-running operation (e.g., a heavy calculation or file processing). Run this operation using Task.Run() or the ThreadPool so that it doesn't block the main thread (or UI thread), allowing the application to remain responsive.
o	Learning Objective: Understand the difference between foreground/background execution, the ThreadPool, and the importance of keeping the UI/main thread free.
•	Assignment: Simulate fetching data from several slow network sources (using Task.Delay to mimic latency). Use Task.WhenAll to execute these "fetches" concurrently and process the results once all are complete.
•	Learning Objective: Utilize modern C# asynchronous programming features (async/await, Task.WhenAll) for efficient parallel I/O-bound operations. 
•	Assignment 8: Task Cancellation
o	Goal: Gracefully stop long-running operations.
o	Task: Create a CancellationTokenSource. Start a Task that performs a loop and periodically checks token.IsCancellationRequested. Trigger the cancellation from the main thread after 2 seconds. 

