using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
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
            Sort(0, window.getLength() - 1);
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
            int temp;
            int p = window.getArray()[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (window.getArray()[j] <= p)
                {
                    i++;
                    window.swap(i, j, sleepTime);
                }
            }
            window.swap(i + 1, end, sleepTime);

            return i + 1;
        }
        public override string getName()
        {
            return name;
        }

        public override int GetSleepTime()
        {
            return sleepTime;
        }

        public override void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
