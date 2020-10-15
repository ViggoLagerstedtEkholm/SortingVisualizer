using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Algorithms;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : Handler
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>

        public BubbleSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        {}

        public override void Sort()
        {
            for (int i = 0; i < window.getLength(); i++)
            {
                for (int j = 0; j < window.getLength() - 1; j++)
                {
                    if (window.getIndex(j) > window.getIndex(j + 1))
                    {
                        window.swap(j, j+ 1, sleepTime);
                    }
                }
            }

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
