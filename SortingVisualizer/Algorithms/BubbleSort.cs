using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : ISortAlgorithms
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations { get; set; }
        public BubbleSort(int[] array)
        {
            this.array = array;
        }

        public void StartThread()
        {
            SleepThread = new Thread(Sort);
            SleepThread.Start();
        }

        public void Sort()
        {
            for (int i = 0; i < array.Length; i++)
            {

                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        iterations++;
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
