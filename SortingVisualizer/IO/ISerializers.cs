using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.IO
{
    interface ISerializers<T>
    {
        void Serialize<T>(T serializeObject, string filePath, bool append);
        T Deserialize(string path);
        T[] DeserializeList();
        T[] SerializeList(List<T> list);

    }
}
