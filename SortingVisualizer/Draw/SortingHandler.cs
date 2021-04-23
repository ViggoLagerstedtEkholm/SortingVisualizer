using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.Draw;
using WindowsFormsApp2.IO;

namespace SortingVisualizer.Draw.Windows
{
    public class SortingHandler 
    {
        public delegate void CurrentAlgortihm(Handler handler);
        private readonly Queue<Handler> algorithms;
        private readonly Window window;
        private Thread thread;
        private readonly SerializeHandler serializeHandler;
        private readonly string path;
        private readonly bool shouldSave;

        public SortingHandler(Queue<Handler> algorithms, Window window, FILE_TYPE fileType, string path)
        {
            this.algorithms = algorithms;
            this.window = window;
            serializeHandler = new SerializeHandler(fileType);
            this.path = path;
            shouldSave = true;
        }
        private void Sleep(int sleepTime)
        {
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (ThreadInterruptedException)
            {
                Thread.CurrentThread.Interrupt();
            }

        }
        public void InitiateSorting(CurrentAlgortihm currentAlgortihm)
        {
            thread = new Thread(() => Sort(currentAlgortihm));
            thread.Start();
        }

        private void Sort(CurrentAlgortihm currentAlgortihm)
        {
            try
            {
                Thread.Sleep(300);
            }
            catch (ThreadInterruptedException exception)
            {
                Console.WriteLine("Thread Interrupted" + exception);
            }

            foreach (Handler algorithm in algorithms.ToArray())
            {
                currentAlgortihm(algorithm);
                window.ShuffleWhenStarted();
                algorithm.Sort();
                Sleep(100);
                window.RunWhenFinallySorted();
                Sleep(100);
                window.ResetColor();
                Sleep(100);

                if (shouldSave)
                {
                    SortSummary summary = new SortSummary
                    {
                        Iterations = algorithm.Swaps,
                        Name = algorithm.Name,
                        ExecutionTime = algorithm.ExecutionTime
                    };

                    Serialize(summary);
                }

                if (algorithms.Any())
                {
                    algorithms.Dequeue();
                    if (algorithms.Any())
                    {
                        window.ShuffleAfterSorted();
                    }
                }
                else
                {
                    thread.Abort();
                }
            }
        }

        private void Serialize(SortSummary Summary)
        {
            serializeHandler.Serialize(Summary, "Test", "path", true);
        }

        public int Remaining()
        {
            return algorithms.Count;
        }

        public Handler GetCurrentSortingItem()
        {
            if (algorithms.Any())
            {
                return algorithms.Peek();
            }
            return null; //should not happen.
        }

        public void Stop()
        {
            Console.WriteLine("stop");
            thread.Abort();
            Application.Exit();
        }
    }
}