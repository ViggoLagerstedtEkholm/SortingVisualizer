
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Draw;

namespace WindowsFormsApp2.IO
{
    class JSONSerializer : Serialize
    {
        private readonly JsonSerializer jsonSerializer;
        private readonly JsonSerializerSettings settings;
        public JSONSerializer()
        {
            jsonSerializer = new JsonSerializer();
            settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
        }

        public override void SerializeObjects(SortSummary serializeObject, string name, string path)
        {
            string jsonData = JsonConvert.SerializeObject(serializeObject, settings);

            using (StreamWriter writer = new StreamWriter(path + name + ".json"))
            {
                writer.Write(jsonData);
            }
        }
        public override List<SortSummary> DeSerializeObjects(List<string> names)
        {
            List<SortSummary> objectReturned = new List<SortSummary>();

            using(StreamReader reader = File.OpenText("SortedData.json"))
            {
                objectReturned.Add((SortSummary)jsonSerializer.Deserialize(reader, typeof(SortSummary)));
            }

            return objectReturned;
        }
    }
}
