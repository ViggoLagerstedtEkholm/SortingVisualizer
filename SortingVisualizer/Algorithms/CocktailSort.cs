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
    class CocktailSort : Handler
    {
        /// <summary>
        /// COCKTAIL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/cocktail-sort/
        /// </summary>
        public CocktailSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        {}

        public override void Sort()
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
