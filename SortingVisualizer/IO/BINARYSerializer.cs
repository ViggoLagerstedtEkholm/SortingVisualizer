using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Draw;

namespace WindowsFormsApp2.IO
{
    class BINARYSerializer : Serialize
    {
        private readonly BinaryFormatter formatter;
        public BINARYSerializer()
        {
            formatter = new BinaryFormatter();
        }
        public override void SerializeObjects(SortSummary serializeObject, string name, string path)
        {
            using(FileStream outFile = new FileStream(path + name + ".bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(outFile, serializeObject);
            }
        }

        public override List<SortSummary> DeSerializeObjects(List<string> names)
        {
            List<SortSummary> objectReturned = new List<SortSummary>();

            using (FileStream outFile = new FileStream("SortedData.bin", FileMode.Open, FileAccess.Read))
            {
                objectReturned.Add((SortSummary)formatter.Deserialize(outFile));
            }

            return objectReturned;
        }
    }
}
