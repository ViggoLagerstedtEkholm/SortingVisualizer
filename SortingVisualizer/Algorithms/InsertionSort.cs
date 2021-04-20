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
        public InsertionSort(int sleepTime, Window window) : base(sleepTime, window)
        { }

        public override void Sort()
        {
            sw.Start();

            for (int i = 1; i < Window.GetLength(); i++)
            {
                int key = Window.GetIndex(i);
                int j = i - 1;

                while(j >= 0 && Window.GetIndex(j) > key)
                {
                    Window.GetArray()[j + 1] = Window.GetArray()[j];
                    j -= 1;
                }
                Window.GetArray()[j + 1] = key;
            }

            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
    }
}
