using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.Draw;
using WindowsFormsApp2.IO;

namespace SortingVisualizer.Draw.Windows
{
    public class SortingHandler
    {
        public delegate void CurrentAlgortihm(Algorithm handler);
        public event EventHandler RestartWindowState;

        private readonly Queue<Algorithm> Algorithms;
        private readonly SortingWindow Window;
        private readonly BackgroundWorker BackgroundWorker = new BackgroundWorker();
        private readonly Serialize Serializer;
        private readonly List<SortSummary> SortSummaries;
        private readonly string Name;
        public bool ShouldSave { get; set; }
        public int Remaining => Algorithms.Count;
        public SortingHandler(Queue<Algorithm> algorithms, Serialize serialiser, SortingWindow Window, string name, bool save)
        {
            Algorithms = algorithms;
            this.Window = Window;
            Serializer = serialiser;
            SortSummaries = new List<SortSummary>();
            Name = name;
            ShouldSave = save;
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
            BackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
            BackgroundWorker.RunWorkerAsync(argument: currentAlgortihm);
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

            foreach (Algorithm algorithm in Algorithms.ToArray())
            {
                currentAlgortihm(algorithm);
                Window.ShuffleWhenStarted();
                int[] unsortedArray = new int[Window.ArrayLength];
                Array.Copy(Window.Array, unsortedArray, Window.ArrayLength);
                algorithm.Start();
                algorithm.Sort();
                algorithm.Stop();
                Sleep(100);
                Window.RunWhenFinallySorted();
                Sleep(100);
                Window.ResetColor();
                Sleep(100);

                if (ShouldSave)
                {
                    SortSummary summary = new SortSummary
                    {
                        Iterations = algorithm.Swaps,
                        Name = algorithm.Name,
                        SortedArray = Window.Array,
                        UnsortedArray = unsortedArray
                    };
                    SortSummaries.Add(summary);
                }

                if (Algorithms.Any())
                {
                    Algorithms.Dequeue();
                    if (Algorithms.Any())
                    {
                        Window.ShuffleAfterSorted();
                        Window.Invalidate();
                    }
                }
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Thread completed.");
            if (ShouldSave)
            {
                Serialize(new Session(SortSummaries, Name));
            }
            RestartWindowState?.Invoke(this, null);
        }

        private void Serialize(Session session)
        {
            Serializer.SerializeObjects(session, Name, "path");
        }

        public Algorithm GetCurrentSortingItem()
        {
            if (Algorithms.Any())
            {
                return Algorithms.Peek();
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