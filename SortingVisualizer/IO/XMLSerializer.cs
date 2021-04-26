using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WindowsFormsApp2.Draw;

namespace WindowsFormsApp2.IO
{
    public class XMLSerializer : Serialize
    {
        public XMLSerializer(string Directory) : base(Directory) { }
        public override void SerializeObjects(Session serializeObject, string name, string path)
        {
            Type type = serializeObject.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            using (FileStream outFile = new FileStream(DirectoryPath + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outFile, serializeObject);
            }
        }
        public override List<Session> DeSerializeObjects(List<string> names)
        {
            List<Session> objects = new List<Session>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Session));
            for (int i = 0; i < names.Count; i++)
            {
                using (FileStream inFile = new FileStream(names[i], FileMode.Open, FileAccess.Read))
                {
                    objects.Add((Session)xmlSerializer.Deserialize(inFile));
                }
            }

            return objects;
        }
    }
}
