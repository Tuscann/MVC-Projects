using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Again
{
    class Program
    {
        public static void Main()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = Path.Combine(dirPath, "zhivko.txt");

            Queue<string> writeQueue = new Queue<string>();
            Queue<string> readQueue = new Queue<string>();

            Thread writeThread = new Thread(() => { WriteToFile(fileName, writeQueue, readQueue); });
            Thread goalThread = new Thread(() => { new CustomMessage("Goooooooal!", 1000).CreateMessage(writeQueue); });
            Thread penaltyThread = new Thread(() => { new CustomMessage("Penalty", 2000).CreateMessage(writeQueue); });
            Thread readThread = new Thread(() => { ReadFile(readQueue); });

            writeThread.Start();
            readThread.Start();
            goalThread.Start();
            penaltyThread.Start();
        }

        private static void ReadFile(Queue<string> readQueue)
        {
            DateTime stopAt = DateTime.Now.AddMinutes(1);

            while (DateTime.Now < stopAt)
            {
                readQueue.TryDequeue(out var nextMessage);

                if (nextMessage != null)
                {
                    Console.WriteLine(nextMessage);
                }
                else
                {
                    Thread.Sleep(250);
                }
            }
        }

        private static void WriteToFile(string fileName, Queue<string> writeQueue, Queue<string> readQueue)
        {
            var stopAt = DateTime.Now.AddMinutes(1);

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                while (DateTime.Now < stopAt)
                {
                    writeQueue.TryDequeue(out var nextMessage);

                    if (nextMessage != null)
                    {
                        try
                        {
                            streamWriter.WriteLine(nextMessage);
                            streamWriter.Flush();
                            readQueue.Enqueue(nextMessage);
                        }
                        catch
                        {
                            writeQueue.Enqueue(nextMessage);
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }

    public class CustomMessage
    {
        public string Message { get; }
        public int TimeOut { get; }

        public CustomMessage(string message, int timeOut)
        {
            Message = message;
            TimeOut = timeOut;
        }

        public void CreateMessage(Queue<string> writeQueue)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");

            int count = 1;

            while (count < 9)
            {
                writeQueue.Enqueue($"Message : {Message} - Time : {date} - ThreadId : {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(TimeOut);

                count += 1;
            }
        }
    }
}