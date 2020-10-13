using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : ISortAlgorithms, IPlaySound
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>
        private string name = "BubbleSort";
        private int sleepTime;
        private Window sortingStarter;
        public BubbleSort(int sleepTime, Window sortingStarter)
        {
            Console.WriteLine("Created bubble sort!");
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            for (int i = 0; i < sortingStarter.getLength(); i++)
            {
                for (int j = 0; j < sortingStarter.getLength() - 1; j++)
                {
                    if (sortingStarter.getIndex(j) > sortingStarter.getIndex(j + 1))
                    {
                        sortingStarter.swap(j, j+ 1, sleepTime);
                    }
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

        public void PlaySound()
        {
            
        }
    }
}
