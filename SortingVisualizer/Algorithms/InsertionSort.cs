using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Algorithms
{
    public class InsertionSort : Handler
    {
        /// <summary>
        /// INSERTION-SORT
        /// https://en.wikipedia.org/wiki/Insertion_sort
        /// </summary>
        public InsertionSort(int sleepTime, SortingWindow window) : base(sleepTime, window)
        { }

        public override void Sort()
        {
            for (int i = 1; i < Window.ArrayLength; i++)
            {
                int key = Window.GetIndex(i);
                int j = i - 1;

                while(j >= 0 && Window.GetIndex(j) > key)
                {
                    Window.Swap(j, j + 1, SleepTime);
                    j -= 1;
                }
                Window.SwapSingleElement(j + 1, key, SleepTime);
            }
        }
    }
}
