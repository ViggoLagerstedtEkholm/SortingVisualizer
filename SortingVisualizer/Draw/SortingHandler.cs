using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Draw;
using WindowsFormsApp2.IO;

namespace SortingVisualizer.Draw.Windows
{
    class SortingHandler 
    {
        private List<ISortAlgorithms> algorithms;
        private Window window;
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(true);
        private Thread workerThread;
        private int sortingIndex;
        private fileType fileType;
        private SortSummary summary;
        private string path;
        private bool shouldSave;
        public SortingHandler(List<ISortAlgorithms> algorithms, Window window)
        {
            this.algorithms = algorithms;
            this.window = window;
            shouldSave = false;

            summary = new SortSummary();
            initiateSorting();
        }

        public SortingHandler(List<ISortAlgorithms> algorithms, Window window, fileType fileType, string path)
        {
            this.algorithms = algorithms;
            this.window = window;
            this.fileType = fileType;
            this.path = path;

            shouldSave = true;

            summary = new SortSummary();
            initiateSorting();
        }
        private void Sleep(int sleepTime)
        {
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (ThreadInterruptedException e)
            {
                Thread.CurrentThread.Interrupt();
            }

        }
        private void initiateSorting()
        {
            workerThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                try
                {
                    Thread.Sleep(300);
                }
                catch (ThreadInterruptedException exception)
                {
                    Console.WriteLine("Thread Interrupted" + exception);
                }

                foreach (ISortAlgorithms algorithm in algorithms)
                {
                    window.setAlgorithmName(algorithm.getName());
                    window.ShuffleWhenStarted();
                    summary.unsortedArray = window.getArray();

                    algorithm.Sort();
                    Sleep(300);
                    window.runWhenFinallySorted();
                    Sleep(300);
                    window.ResetColor();
                    window.ShuffleAfterSorted();
                    Sleep(300);

                    summary.iterations = window.getIterations();
                    window.setIterations();

                    summary.name = algorithm.getName();
                    summary.sleepTime = algorithm.GetSleepTime();
                    summary.sortedArray = window.getArray();

                    sortingIndex++;

                    if (shouldSave)
                    {
                        switch (fileType)
                        {
                            case fileType.BINARY:
                                new BINARYSerializer<SortSummary>().Serialize(summary, path, true,"minData");
                                break;
                            case fileType.JSON:
                                new JSONSerializer<SortSummary>().Serialize(summary, path, true, "minData");
                                break;
                            case fileType.XML:
                                new XMLSerializer<SortSummary>().Serialize(summary, path, true, "minData");
                                break;
                        }
                    }
                }
            });

            workerThread.Start();
        }

        public ISortAlgorithms getCurrentSortingItem()
        {
            return this.algorithms[sortingIndex];
        }

        public void stop()
        {
            Console.WriteLine("stop");
            workerThread.Abort();
            Application.Exit();
        }
    }
}
