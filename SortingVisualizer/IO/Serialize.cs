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
        public Serialize(string path)
        {
            DirectoryPath = path;
        }
        public abstract void SerializeObjects(Session serializeObject, string name, string path);
        public abstract List<Session> DeSerializeObjects(List<string> names);
    }
}
