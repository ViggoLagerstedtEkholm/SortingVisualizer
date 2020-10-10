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
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "PigeonSort";
        private int currentlyMoving;
        private int sleepTime;
        private Window sortingStarter;
        public PigeonholeSort(int[] array, int sleepTime, Window sortingStarter)
        {
            this.array = array;
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }
        public void StartThread()
        {
            SleepThread = new Thread(Sort);
            SleepThread.Start();
        }
        public void Sort()
        {
            int min = array[0];
            int max = array[0];
            int range, i, j, index;
            int n = array.Length ;


            for (int a = 0; a < n; a++)
            {
                if (array[a] > max)
                {
                    max = array[a];
                }
                    
                if (array[a] < min)
                {
                    min = array[a];
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
                phole[array[i] - min]++;
            }

            index = 0;

            for (j = 0; j < range; j++)
            {
                while (phole[j]-- > 0)
                    array[index++] = j + min;
                    Thread.Sleep(sleepTime);
                    currentlyMoving = j + min;
                    iterations++;
            }
            Done();
        }
        public string getName()
        {
            return name;
        }

        public int getIterations()
        {
            return iterations;
        }

        public int getCurrentMoving()
        {
            return currentlyMoving;
        }
        public int getValue(int index)
        {
            return array[index];
        }

        public void Done()
        {
            sortingStarter.DequeueItem();
            sortingStarter.StartQueue();
            SleepThread.Abort();
        }
    }
}
