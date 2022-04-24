using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace UnknownElementsEditor
{
    public static class Serializer
    {
        public static void WriteToXml<T>(T objToSerialize, string filePath)
        {
            try
            {
                DataContractSerializer serializerForXml = new DataContractSerializer(objToSerialize.GetType());

                using (FileStream writer = new FileStream(filePath, FileMode.Create))
                {
                    serializerForXml.WriteObject(writer, objToSerialize);
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        public static T ReadFromXml<T>(string filePath)
        {
            try
            {
                DataContractSerializer serializerForXml = new DataContractSerializer(typeof(T));

                using (FileStream reader = new FileStream(filePath, FileMode.Open))
                {
                    T deserializedObject = (T)serializerForXml.ReadObject(reader);
                    return deserializedObject;
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
