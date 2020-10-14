using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public interface ISortAlgorithms
    {
        string getName();
        void Sort();
        int GetSleepTime();

        //Enables runtime speedup.
        void setSleep(int sleepTime);
    }
}
