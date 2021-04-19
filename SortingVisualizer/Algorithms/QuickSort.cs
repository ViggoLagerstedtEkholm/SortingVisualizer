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
    public class QuickSort : Handler
    {
        /// <summary>
        /// QUICK-SORT
        /// Help with implementation - http://csharpexamples.com/c-quick-sort-algorithm-implementation/
        /// </summary>
        public QuickSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }
        public override void Sort()
        {
            sw.Start();

            Sort(0, Window.GetLength() - 1);

            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
        public void Sort(int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(start, end);

                Sort(start, i - 1);
                Sort(i + 1, end);
            }
        }
        private int Partition(int start, int end)
        {
            int p = Window.GetArray()[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (Window.GetArray()[j] <= p)
                {
                    i++;
                    Window.Swap(i, j, SleepTime);
                    Swaps++;
                }
            }
            Window.Swap(i + 1, end, SleepTime);
            Swaps++;

            return i + 1;
        }
    }
}
