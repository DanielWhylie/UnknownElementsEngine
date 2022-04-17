using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnknownElementsEditor
{
    public static class Serializer
    {
        //TODO: may need to refactor for Deep Serialization.
        public static void WriteToXml<T>(T objToSerialize, string filePath)
        {
            

            try
            {
                XmlSerializer serializerForXml = new XmlSerializer(objToSerialize.GetType());

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializerForXml.Serialize(writer, objToSerialize);
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        public static T ReadFromXml<T>(string path)
        {
            try
            {
                XmlSerializer serializerForXml = new XmlSerializer(typeof(T));

                using (Stream reader = new FileStream(path, FileMode.Open))
                {
                    T deserializedObj = (T)serializerForXml.Deserialize(reader);
                    return deserializedObj;
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return default(T);
            }
            
        }
    }
}
