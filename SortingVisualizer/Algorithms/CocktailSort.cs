using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    class CocktailSort : ISortAlgorithms
    {
        /// <summary>
        /// COCKTAIL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/cocktail-sort/
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "CocktailSort";
        private int currentlyMoving;
        private int sleepTime;
        private Window sortingStarter;
        public CocktailSort(int[] array, int sleepTime, Window sortingStarter)
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
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                        currentlyMoving = array[i + 1];
                        iterations++;
                        Thread.Sleep(sleepTime);
                    }
                }

                if (swapped == false)
                {
                    break;
                }
                swapped = false;

                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                        currentlyMoving = array[i + 1];
                        iterations++;
                        Thread.Sleep(sleepTime);
                    }
                }
                start = start + 1;
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
