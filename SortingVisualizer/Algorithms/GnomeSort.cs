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
    public class GnomeSort : Handler
    {
        /// <summary>
        /// GNOME-SORT
        /// https://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>

        public GnomeSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int index = 0;
            int n = window.getLength();
            while (index < n)
            {
                if (index == 0)
                    index++;
                if (window.getIndex(index) >= window.getIndex(index - 1))
                    index++;
                else
                {
                    window.swap(index, index - 1, sleepTime);
                    index--;
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
