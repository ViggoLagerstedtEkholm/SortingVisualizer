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
        {}

        public override void OnLoad(List<ISortAlgorithms> sortAlgorithms)
        {
            foreach(ISortAlgorithms item in sortAlgorithms)
            {
                item.StartThread();
            }
            
        }

        int frame = 0;
        public override void OnUpdate()
        {
            frame++;
            Console.Write(frame + ", ");
        }
    }
}
