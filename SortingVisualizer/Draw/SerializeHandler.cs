using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.IO;

namespace WindowsFormsApp2.Draw
{
    public class SerializeHandler
    {
        private readonly Serialize Serializer;
        public SerializeHandler(FILE_TYPE FILE)
        {
            switch (FILE)
            {
                case FILE_TYPE.XML:
                    Serializer = new XMLSerializer();
                    break;
                case FILE_TYPE.BINARY:
                    Serializer = new BINARYSerializer();
                    break;
                case FILE_TYPE.JSON:
                    Serializer = new JSONSerializer();
                    break;
            }
        }
        public void Serialize(SortSummary SortSummary, string name, string path, bool append)
        {
            Serializer.SerializeObjects(SortSummary, name, path);
        }
        public List<SortSummary> Deserialize(List<string> paths)
        {
            return Serializer.DeSerializeObjects(paths);
        }
    }
}
