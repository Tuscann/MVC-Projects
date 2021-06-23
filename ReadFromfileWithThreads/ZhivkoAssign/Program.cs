using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Again
{
    class Program
    {
        static async Task Main()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = Path.Combine(dirPath, "ZhivkoDesktopFile.txt");

            // Queue writeQueue = new Queue();
            // Queue readQueue = new Queue();

            Random random = new Random();

            string longString = "dam" + random.Next(3, 56);

            UnicodeEncoding uniencoding = new UnicodeEncoding();

            byte[] result = uniencoding.GetBytes("12");

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fileStream))
            {
                
                var test = new Thread(() => { Thread1(fileName);}) ;
                test.Start();
            }


            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
              
            
                // List<Task> tasksList = new List<Task>
                // {
                //     Task.Factory.StartNew(() => { ReadFileAsync(dirPath, fileName); }),
                //     Task.Factory.StartNew(() => { WriteFileAsync(fileName, longString); }),
                // };
            }
            
            using (StreamReader streamReader = new StreamReader(fileName, true))
            {
                while (true)
                {
                    string? line = streamReader.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine(line);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }

            ExecuteSynchronousCode();
        }

        public static void Thread1(string fileName)
        {
            string name = "thread1111";
            int id = 12;
            int count = 1;

            while (count < 10)
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    sw.WriteLine(name);
                    count++;
                    Thread.Sleep(1000);
                }
            }
        }

        public static void Thread2(StreamWriter streamReader)
        {
            string name = "thread2";
            int id = 12;
            int count = 1;

            while (count < 10)
            {
                streamReader.WriteLine(name);
                count++;
                Thread.Sleep(1000);
            }
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

        private static async Task WriteFileAsync(string fileName, string content)
        {
            Console.WriteLine("ASYNC WRITE has started.");

            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                await stream.WriteLineAsync(content);
            }

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