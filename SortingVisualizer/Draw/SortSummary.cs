using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Draw
{
    public class SortSummary
    {
        public string name { get; set; }
        public int iterations { get; set; }
        public int sleepTime { get; set; }
        public int[] sortedArray { get; set; }
        public int[] unsortedArray { get; set; }
        public SortSummary()
        {}
    }
}
