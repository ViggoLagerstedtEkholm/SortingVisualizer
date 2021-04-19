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

        public GnomeSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            sw.Start();

            int index = 0;
            int n = Window.GetLength();
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
            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
    }
}
