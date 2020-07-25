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
        int getCurrentMoving();
        int getIterations();
        void StartThread();
        void Sort();
        void Done();
    }
}
