﻿using SortingVisualizer.Draw;
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
    public class HeapSort : Handler
    {
        /// <summary>	
        /// HEAP-SORT	
        /// Help with implementation - https://www.geeksforgeeks.org/heap-sort/	
        /// </summary>	
        public HeapSort(int sleepTime, SortingWindow window) : base(sleepTime, window)
        { }
        public override void Sort()
        {
            int n = Window.ArrayLength;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heap(Window.Array, n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Window.Swap(0, i, SleepTime);
                Heap(Window.Array, i, 0);
            }
        }

        private void Heap(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Window.Swap(i, largest, SleepTime);
                Swaps++;
                Heap(array, n, largest);
            }
        }
    }
}
