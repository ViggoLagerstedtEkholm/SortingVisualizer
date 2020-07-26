using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Setup
{
    public class Sorter : SortingStarter
    {
        private string Title;
        public Sorter() : base(
            "Sort algorithms!"
            )
        {}

        public override void OnExit(Thread thread)
        {
            thread.Abort();
        }
        public override void OnLoad(ISortAlgorithms sortAlgorithm)
        {
            ISortAlgorithms aItem = sortAlgorithm;
            aItem.StartThread();
        }
    }
}
