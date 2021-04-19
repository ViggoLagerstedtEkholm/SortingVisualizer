using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp2.IO
{
    public class XMLSerializer<T>
    {
        public XMLSerializer()
        {}

        /// <summary>
        /// Serializes a given object into a XML file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializeObject">Object to serialize</param>
        /// <param name="fileName">Name of the file we want to save.</param>
        public void Serialize(T serializeObject, string filePath, bool append, string fileName)
        {
            if (serializeObject == null) { return; }
            string submittedFilePath = filePath + fileName + ".txt";
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(submittedFilePath, append);
                serializer.Serialize(writer, serializeObject);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Deserializes a XML file into a object list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public T Deserialize(string path)
        {
            if (string.IsNullOrEmpty(path)) { return default(T); }

            string submittedFilePath =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Path\\myFile.txt.";

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(submittedFilePath);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception)
            {
                //Exception handling here.
            }

            return objectOut;
        }

        public T[] DeserializeList()
        {
            throw new NotImplementedException();
        }

        public T[] SerializeList(List<T> list)
        {
            throw new NotImplementedException();
        }
    }
}
