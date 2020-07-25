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

        public override void OnExit()
        {
            throw new NotImplementedException();
        }

        public override void OnLoad(List<ISortAlgorithms> sortAlgorithms, int index)
        {
            //foreach(ISortAlgorithms item in sortAlgorithms)
            //{
            //    item.StartThread();
            //}

            for(int i = 0; i < sortAlgorithms.Count; i++)
            {
                ISortAlgorithms aItem = sortAlgorithms[i];
                aItem.StartThread();
            }
        }
    }
}
