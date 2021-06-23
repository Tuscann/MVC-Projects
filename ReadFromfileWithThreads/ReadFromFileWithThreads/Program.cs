using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace ReadFromFileWithThreads
{
    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }

    class Program
    {
        static void Main()
        {
            //  string text = System.IO.File.ReadAllText(@"C:\Users\Az\Documents\MVC-Projects\ReadFromFileWithThreads\ReadFromFileWithThreads\WriteText.txt");
            //
            // Console.WriteLine("Contents of WriteText.txt = {0}", text);
            //
            // string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
            //
            //  Console.WriteLine("Contents of WriteLines2.txt = ");
            //  foreach (string line in lines)
            //  {
            //     
            //      Console.WriteLine("\t" + line);
            //  }
            //
            //  Console.WriteLine("Press any key to exit.");
            //  Console.ReadKey();

            //  SimpleParallelWriteAsync();

            Task[] taskArray = new Task[3];
            
            string folder = Directory.CreateDirectory("ReadFromfileWithThreads").Name;
            string fileName = $"WriteText.txt";
            string filePath = $"{folder}/{fileName}";

            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                    {
                        CustomData data = obj as CustomData;
                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    },

                   new CustomData {Name = i, CreationTime = DateTime.Now.Ticks});
            }

            Task.WaitAll(taskArray);
            foreach (Task currentTask in taskArray)
            {
                CustomData data = currentTask.AsyncState as CustomData;

                Console.WriteLine("Task number #{0} created at {1}, ran on thread #{2}.",
                    data.Name, data.CreationTime, data.ThreadNum);
            }
        }

        public static async Task SimpleParallelWriteAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            string folder = Directory.CreateDirectory("ReadFromfileWithThreads").Name;
            string fileName = $"WriteText.txt";
            string filePath = $"{folder}/{fileName}";
            IList<Task> writeTaskList = new List<Task>();

            for (int index = 1; index <= 6; ++index)
            {
                string text = $"In file {index}{Environment.NewLine}";

                writeTaskList.Add(File.WriteAllTextAsync(filePath, text));

                writeTaskList.Add(File.ReadAllTextAsync(filePath));
                stopwatch.Stop();

                Console.WriteLine(writeTaskList[index].GetHashCode() + "" + " Thread Id : " + writeTaskList[index].Id +
                                  " Elapsed Time : " +
                                  stopwatch.Elapsed);
                stopwatch = Stopwatch.StartNew();
            }

            stopwatch.Stop();

            for (int i = 0; i < writeTaskList.Count; i++)
            {
                Console.WriteLine(writeTaskList + "" + "Thread Id :" + writeTaskList[i].Id);
            }


            await Task.WhenAll(writeTaskList);
        }
    }
}