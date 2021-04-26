using System;

namespace WindowsFormsApp2.Draw
{
    [Serializable]
    public class SortSummary
    {
        public string Name { get; set; }
        public int Iterations { get; set; }
        public int[] SortedArray { get; set; }
        public int[] UnsortedArray { get; set; }
        public SortSummary()
        { }
    }
}
