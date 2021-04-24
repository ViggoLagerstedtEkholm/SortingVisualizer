using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp2.Draw;

namespace WindowsFormsApp2.IO
{
    public class XMLSerializer : Serialize
    {
        public override void SerializeObjects(SortSummary serializeObject, string name, string path)
        {
            Type type = serializeObject.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            using (FileStream outFile = new FileStream(DirectoryPath + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outFile, serializeObject);
            }
        }
        public override List<SortSummary> DeSerializeObjects(List<string> names)
        {
            List<SortSummary> objects = new List<SortSummary>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SortSummary>));
            for(int i = 0; i < names.Count; i++)
            {
                using (FileStream inFile = new FileStream(names[i], FileMode.Open, FileAccess.Read))
                {
                    objects.Add((SortSummary)xmlSerializer.Deserialize(inFile));
                }
            }

            return objects;
        }
    }
}
