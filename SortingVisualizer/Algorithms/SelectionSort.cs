using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class SelectionSort : Handler
    {
        /// <summary>
        /// SELECTION-SORT
        /// https://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        public SelectionSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            sw.Start();

            int smallest;
            for (int i = 0; i < Window.GetLength() - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < Window.GetLength(); index++)
                {
                    if (Window.GetArray()[index] < Window.GetArray()[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
                Swaps++;
            }

            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
        public void Swap(int first, int second)
        {
            Window.Swap(first, second, SleepTime);
        }
    }
}
