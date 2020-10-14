using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Draw.Windows
{
    class SortingHandler 
    {
        private List<ISortAlgorithms> algorithms;
        private Window window;
        private Queue<ISortAlgorithms> algotihmsQueue; //Use this in the rework.
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
            new Thread(() =>
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
                }

            }).Start();
        }
    }
}
