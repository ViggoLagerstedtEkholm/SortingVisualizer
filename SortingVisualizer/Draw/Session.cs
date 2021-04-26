using System;
using System.Collections.Generic;

namespace WindowsFormsApp2.Draw
{
    [Serializable]
    public class Session
    {
        public string Name { get; set; }
        public List<SortSummary> SortSummaries { get; set; }
        public DateTime Date { get; set; }
        public Session() { }
        public Session(List<SortSummary> sortSummaries, string name)
        {
            SortSummaries = sortSummaries;
            Name = name;
            Date = DateTime.Now;
        }
    }
}
