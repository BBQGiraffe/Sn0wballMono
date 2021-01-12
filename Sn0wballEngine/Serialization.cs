using System;
using System.IO;
using Newtonsoft.Json;
namespace Sn0wballEngine
{

    public class Serialization
    {
        static JsonSerializer json = JsonSerializer.Create();

      
        public static T DeserializeObject<T> (string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename), new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public static object DeserializeObject(string filename)
        {
            return json.Deserialize(new JsonTextReader(File.OpenText(filename)));
        }

        public static void SerializeObject(object obj, string filename)
        {
            var file = File.CreateText(filename);
            file.Write(JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            }));

            file.Close();
        }


    }
}
