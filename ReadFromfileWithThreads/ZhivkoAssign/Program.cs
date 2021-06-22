using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Again
{
    class Program
    {
        static void Main()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "ZhivkoDesktopFile.txt";

            Random random = new Random();

            string longString = "dam" + random.Next(3, 56);

            List<Task> tasksList = new List<Task>
            {
                Task.Factory.StartNew(async () => { await WriteFileAsync(dirPath, fileName, longString); }),
                Task.Factory.StartNew(async () => { await ReadFileAsync(dirPath, fileName); }),
                Task.Factory.StartNew(async () => { await ReadFileAsync(dirPath, fileName); }),
                Task.Factory.StartNew(async () => { await WriteFileAsync(dirPath, fileName, longString); }),
            };
            ExecuteSynchronousCode();
            Task.WaitAll(tasksList.ToArray());
        }

        private static async Task ReadFileAsync(string dirPath, string fileName)
        {
            Console.WriteLine("ASYNC READ has started.");

            using (StreamReader outputFile = new StreamReader(Path.Combine(dirPath, fileName)))
            {
                string line = outputFile.ReadLine();

                if (line != null)
                {
                    Console.WriteLine(line);
                }

                await outputFile.ReadLineAsync();
            }

            Console.WriteLine("ASYNC READ has completed.");
        }

        private static async Task WriteFileAsync(string dirPath, string fileName, string content)
        {
            Console.WriteLine("ASYNC WRITE has started.");

            StreamWriter stream = new StreamWriter(fileName, true);
      
            await stream.WriteLineAsync("Fourth line");

            Console.WriteLine("ASYNC WRITE has completed.");
        }

        static void ExecuteSynchronousCode()
        {
            Console.WriteLine();
            Console.WriteLine("Executing Code while Async task runs...");
            Console.WriteLine();
        }
    }
}