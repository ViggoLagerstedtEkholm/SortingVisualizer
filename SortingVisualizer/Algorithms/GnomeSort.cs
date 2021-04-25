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
    public class GnomeSort : Handler
    {
        /// <summary>
        /// GNOME-SORT
        /// https://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>

        public GnomeSort(int sleepTime, SortingWindow window) : base(sleepTime, window)
        { }

        public override void Sort()
        {
            int index = 0;
            int n = Window.ArrayLength;
            while (index < n)
            {
                if (index == 0)
                    index++;
                if (Window.GetIndex(index) >= Window.GetIndex(index - 1))
                    index++;
                else
                {
                    Window.Swap(index, index - 1, SleepTime);
                    Swaps++;
                    index--;
                }
            }
        }
    }
}
