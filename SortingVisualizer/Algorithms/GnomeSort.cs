using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class GnomeSort : ISortAlgorithms
    {
        /// <summary>
        /// GNOME-SORT
        /// https://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>
        private string name = "Gnome Sort";
        private int sleepTime;
        private Window sortingStarter;
        
        public GnomeSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int index = 0;
            int n = sortingStarter.getLength();
            while (index < n)
            {
                if (index == 0)
                    index++;
                if (sortingStarter.getIndex(index) >= sortingStarter.getIndex(index - 1))
                    index++;
                else
                {
                    sortingStarter.swap(index, index - 1, sleepTime);
                    index--;
                }
            }
        }
        public string getName()
        {
            return name;
        }

        public int GetSleepTime()
        {
            return sleepTime;
        }

        public void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
