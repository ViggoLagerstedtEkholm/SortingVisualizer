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
            int smallest;
            for (int i = 0; i < window.getLength() - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < window.getLength(); index++)
                {
                    if (window.getArray()[index] < window.getArray()[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
            }
        }

        public void Swap(int first, int second)
        {
            window.swap(first, second, sleepTime);
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
