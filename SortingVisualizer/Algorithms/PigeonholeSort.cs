using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class PigeonholeSort : ISortAlgorithms
    {
        /// <summary>
        /// PIGEONHOLE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/pigeonhole-sort/
        /// </summary>
        private string name = "PigeonSort";
        private int sleepTime;
        private Window sortingStarter;
        public PigeonholeSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int min = sortingStarter.getIndex(0);
            int max = sortingStarter.getIndex(0);
            int range, i, j, index;
            int n = sortingStarter.getLength();


            for (int a = 0; a < n; a++)
            {
                if (sortingStarter.getIndex(a) > max)
                {
                    max = sortingStarter.getIndex(a);
                }
                    
                if (sortingStarter.getIndex(a) < min)
                {
                    min = sortingStarter.getIndex(a);
                }
            }

            range = max - min + 1;
            int[] phole = new int[range];

            for (i = 0; i < n; i++)
            {
                phole[i] = 0;
            }
                

            for (i = 0; i < n; i++)
            {
                phole[sortingStarter.getIndex(i) - min]++;
            }

            index = 0;

            for (j = 0; j < range; j++)
            {
                while (phole[j]-- > 0)
                    sortingStarter.getArray()[index++] = j + min;
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
    }
}
