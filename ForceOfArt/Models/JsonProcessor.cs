using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ForceOfArt.Models
{
    public class JsonProcessor:DataProcessor
    {
        List<FileInfo> inputs;
        public JsonProcessor(List <FileInfo> files)
        {
            inputs = files;
        }
        public override void Process()
        {
            Result = new List<ArtObject>();
            JsonSerializer serializer = new JsonSerializer();
            foreach(var file in inputs)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                        string content = reader.ReadToEnd();
                        content = content.Replace("\r\n", "");
                        ArtObject obj = JsonConvert.DeserializeObject<ArtObject>(content);
                        Result.Add(obj);

                }
            }
        }
        
    }
}
