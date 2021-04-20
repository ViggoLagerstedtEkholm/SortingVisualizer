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
    public class XMLSerializer
    {
        private readonly string designatedFileFolder;
        public XMLSerializer()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }

        public void Serialize(SortSummary serializeObject, string name, string path)
        {
            Type type = serializeObject.GetType();
            XmlSerializer serializer = new XmlSerializer(type);

            using (FileStream outFile = new FileStream(path + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outFile, serializeObject);
            }
        }

        public void Serialize(SortSummary serializeObject, string name)
        {
            Type type = serializeObject.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            if (!Directory.Exists(designatedFileFolder))
                Directory.CreateDirectory(designatedFileFolder);
            Console.WriteLine(designatedFileFolder);
            using (FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outFile, serializeObject);
            }
        }
        public List<SortSummary> DeserializeList(string[] names)
        {
            List<SortSummary> objects = new List<SortSummary>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SortSummary>));
            for(int i = 0; i < names.Length; i++)
            {
                using (FileStream inFile = new FileStream(names[i], FileMode.Open, FileAccess.Read))
                {
                    objects.Add((SortSummary)xmlSerializer.Deserialize(inFile));
                }
            }

            return objects;
        }

        public SortSummary DeserializeSingle(string path)
        {
            SortSummary objects;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SortSummary));
            using (FileStream inFile = new FileStream(path,
                FileMode.Open, FileAccess.Read))
            {
                objects = (SortSummary)xmlSerializer.Deserialize(inFile);
            }

            return objects;
        }
    }
}
