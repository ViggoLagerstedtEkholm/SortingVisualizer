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
    public delegate void Finish();
    public class SortingHandler 
    {
        private readonly Finish _finishCallback = new Finish(FinishScreen);

        private readonly Queue<Handler> algorithms;
        private readonly Window window;
        private Thread thread;
        private readonly FileType fileType;
        private readonly string path;
        private readonly bool shouldSave;

        public SortingHandler(Queue<Handler> algorithms, Window window, FileType fileType, string path)
        {
            this.algorithms = algorithms;
            this.window = window;
            this.fileType = fileType;
            this.path = path;
            shouldSave = true;
        }

        public static void FinishScreen()
        {
            Application.Exit();
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
        public void InitiateSorting()
        {
            ThreadStart starter = Sort;
            thread = new Thread(starter) {IsBackground = true };
            thread.Start();
        }

        private void Sort()
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
                window.ShuffleWhenStarted();
                algorithm.Sort();
                Sleep(300);
                window.RunWhenFinallySorted();
                Sleep(300);
                window.ResetColor();
                window.ShuffleAfterSorted();
                Sleep(300);

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
                }
                else
                {
                    _finishCallback.Invoke();
                }
            }
        }

        private void Serialize(SortSummary summary)
        {
            new XMLSerializer().Serialize(summary, path);
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