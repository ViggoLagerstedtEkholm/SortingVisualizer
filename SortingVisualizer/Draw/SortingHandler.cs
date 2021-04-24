using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public event EventHandler RestartWindowState;

        private readonly Queue<Handler> algorithms;
        private readonly Window window;
        private BackgroundWorker backgroundWorker;
        private readonly SerializeHandler serializeHandler;
        private readonly string Name;
        private readonly bool shouldSave;
        public int Remaining => algorithms.Count;
        public SortingHandler(Queue<Handler> algorithms, Window window, FILE_TYPE fileType, string name)
        {
            this.algorithms = algorithms;
            this.window = window;
            serializeHandler = new SerializeHandler(fileType);
            Name = name;
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
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync(argument: currentAlgortihm);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CurrentAlgortihm currentAlgortihm = (CurrentAlgortihm)e.Argument;
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
                    Console.WriteLine(algorithm.ExecutionTime);
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
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Thread completed.");
            RestartWindowState?.Invoke(this, null);
        }

        private void Serialize(SortSummary Summary)
        {
            serializeHandler.Serialize(Summary, Name, "path", true);
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
            Application.Exit();
        }
    }
}