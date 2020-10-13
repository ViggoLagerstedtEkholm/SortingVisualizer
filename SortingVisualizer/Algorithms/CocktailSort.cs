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
        private string name = "CocktailSort";
        private int sleepTime;
        private Window window;
        public CocktailSort(int sleepTime, Window window)
        {
            this.sleepTime = sleepTime;
            this.window = window;
        }
        public void Sort()
        {
            bool swapped = true;
            int start = 0;
            int end = window.getLength();

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (window.getIndex(i) > window.getIndex(i + 1))
                    {
                        window.swap(i, i + 1, sleepTime);
                        swapped = true;
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
                    if (window.getIndex(i) > window.getIndex(i + 1))
                    {
                        window.swap(i, i + 1, sleepTime);
                        swapped = true;
                    }
                }
                start = start + 1;
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
