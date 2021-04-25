﻿using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Algorithms;
using WindowsFormsApp2.Algorithms;
using System.Diagnostics;

namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : Handler
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>

        public BubbleSort(int sleepTime, SortingWindow window) : base(sleepTime, window)
        {}

        public override void Sort()
        {
            for (int i = 0; i < Window.ArrayLength; i++)
            {
                for (int j = 0; j < Window.ArrayLength - 1; j++)
                {
                    if (Window.GetIndex(j) > Window.GetIndex(j + 1))
                    {
                        Window.Swap(j, j + 1, SleepTime);
                        Swaps++;
                    }
                }
            }
        }
    }
}
