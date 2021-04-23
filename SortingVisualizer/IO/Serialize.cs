using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Draw;

namespace WindowsFormsApp2.IO
{
    public abstract class Serialize
    {
        public string DirectoryPath { get; set; }
        public Serialize()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            DirectoryPath = projectDirectory + @"\SavedFiles";
        }
        public abstract void SerializeObjects(SortSummary serializeObject, string name, string path);
        public abstract List<SortSummary> DeSerializeObjects(List<string> names);
    }
}
