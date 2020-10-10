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
        private Input input;
        public Sorter() : base(
            "Sort algorithms!"
            )
        {}

        public override void OnExit(Thread thread)
        {
            thread.Abort();
  
        }
        public override void OnLoad(ISortAlgorithms sortAlgorithm, Window Window)
        {
            input = new Input(Window, this);
            ISortAlgorithms aItem = sortAlgorithm;
            //Start the thread for selected algorithm.
            aItem.StartThread();
        }
    }
}
