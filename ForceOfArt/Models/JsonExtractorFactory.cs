using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ForceOfArt.Models
{
    public class JsonExtractorFactory : DataExtractorFactory
    {
        JsonProcessor processor;
        DirectoryInfo RootDir;
        List<FileInfo> files;
        public JsonExtractorFactory(string directory)
        {
            RootDir = new DirectoryInfo(directory);
        }
        public DataProcessor GetProcessor()
        {

            files = new List<FileInfo>();
            if (RootDir.Exists)
            {
                foreach(var dir in RootDir.GetDirectories())
                {
                    files.AddRange(dir.EnumerateFiles());
                }
                processor = new JsonProcessor(files);
                return processor;
            }
            else
            {
                throw new Exception("Directory does not exists");
            }
        }
    }
}
