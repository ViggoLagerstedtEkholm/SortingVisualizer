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
        public event Action SomeEvent;//TODO give better name

        private readonly List<Handler> algorithms;
        private readonly Window window;
        private Thread thread;
        private int sortingIndex;
        private readonly FileType fileType;
        private readonly string path;
        private readonly bool shouldSave;
        public SortingHandler(List<Handler> algorithms, Window window)
        {
            this.algorithms = algorithms;
            this.window = window;
            InitiateSorting();
        }

        public SortingHandler(List<Handler> algorithms, Window window, FileType fileType, string path)
        {
            this.algorithms = algorithms;
            this.window = window;
            this.fileType = fileType;
            this.path = path;
            shouldSave = true;

            InitiateSorting();
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
        private void InitiateSorting()
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

            foreach (Handler algorithm in algorithms)
            {
                SortSummary summary = new SortSummary();
                window.ShuffleWhenStarted();
                summary.UnsortedArray = window.GetArray();

                algorithm.Sort();
                Sleep(300);
                window.RunWhenFinallySorted();
                Sleep(300);
                window.ResetColor();
                window.ShuffleAfterSorted();
                Sleep(300);

                summary.Iterations = algorithm.Swaps;
                summary.Name = algorithm.Name;
                summary.SortedArray = window.GetArray();

                sortingIndex++;

                if (shouldSave)
                    Serialize(summary);
            }
            var handler = SomeEvent;
            if (handler != null)
                SomeEvent();
        }

        private void Serialize(SortSummary summary)
        {
            switch (fileType)
            {
                case FileType.BINARY:
                    new BINARYSerializer<SortSummary>().Serialize(summary, path, true, "minData");
                    break;
                case FileType.JSON:
                    new JSONSerializer<SortSummary>().Serialize(summary, path, true, "minData");
                    break;
                case FileType.XML:
                    new XMLSerializer<SortSummary>().Serialize(summary, path, true, "minData");
                    break;
            }
        }

        public int GetCount()
        {
            return algorithms.Count;
        }

        public int GetSortingIndex()
        {
            return sortingIndex + 1;
        }

        public Handler GetCurrentSortingItem()
        {
            return algorithms[sortingIndex];
        }

        public void Stop()
        {
            Console.WriteLine("stop");
            thread.Abort();
            Application.Exit();
        }
    }
}