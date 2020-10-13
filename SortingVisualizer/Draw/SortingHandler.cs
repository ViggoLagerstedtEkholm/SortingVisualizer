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
        public SortingHandler(List<ISortAlgorithms> algorithms, Window window)
        {
            this.algorithms = algorithms;
            this.window = window;
            initiateSorting();
        }

        /// <summary>
        /// This method goes through the whole array of algorithms and displays the sorting using the window class.
        /// </summary>
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
                    window.ShuffleWhenStarted();

                    algorithm.Sort();
                    window.ResetColor();
                    window.ShuffleAfterSorted();

                    Thread.Sleep(300);
                }

            }).Start();
        }
    }
}
