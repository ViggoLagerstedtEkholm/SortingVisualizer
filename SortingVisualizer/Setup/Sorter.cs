using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Setup
{
    public class Sorter : SortingStarter
    {
        private string Title;
        public Sorter() : base(
            "Sort algorithms!"
            )
        {

        }

        public override void OnLoad(SelectionSort selectionSort)
        {
            selectionSort.StartThread();
        }

        int frame = 0;
        public override void OnUpdate()
        {
            frame++;
            Console.Write(frame + ", ");
        }
    }
}
