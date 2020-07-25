﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class SelectionSort : ISortAlgorithms
    {
        /// <summary>
        /// SELECTION-SORT
        /// https://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations { get; set; }
        public SelectionSort(int[] array)
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
            int smallest;
            for (int i = 0; i < array.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < array.Length; index++)
                {
                    if (array[index] < array[smallest])
                    {
                        smallest = index;
                    }
                }
                iterations++;
                Swap(i, smallest);
                Thread.Sleep(100);
            }
        }

        public void Swap(int first, int second)
        {
            int temporary = array[first];
            array[first] = array[second];
            array[second] = temporary;
        }
    }
}
