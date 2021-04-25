using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Draw
{
    [Serializable]
    public class SortSummary
    {
        public string Name { get; set; }
        public int Iterations { get; set; }
        public double ExecutionTime { get; set; }
        public int[] SortedArray { get; set; }
        public int[] UnsortedArray { get; set; }
        public SortSummary()
        {}
    }
}
