using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Draw.Windows
{
    class SortingHandler 
    {
        private List<ISortAlgorithms> algorithms;
        private Window window;
        private bool isPaused;
        private bool isResumed;
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(true);
        private Thread workerThread;
        private int sortingIndex;
        public SortingHandler(List<ISortAlgorithms> algorithms, Window window)
        {
            this.algorithms = algorithms;
            this.window = window;
     
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



        //I might rework this part and make a Queue, in that way you can pause, resume, add new algorithms, remove algorihms runtime.

        /// <summary>
        /// This method goes through the whole array of algorithms and displays the sorting using the window class.
        /// </summary>
        /// 
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
                    window.setCurrentAlgorithm(algorithm);
                    window.setAlgorithmName(algorithm.getName());
                    window.ShuffleWhenStarted();
                    
                    algorithm.Sort();
                    Sleep(300);
                    window.runWhenFinallySorted();
                    Sleep(300);
                    window.ResetColor();
                    window.ShuffleAfterSorted();
                    Sleep(300);

                    window.setIterations();
                    sortingIndex++;
                }


                //Write to files
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
