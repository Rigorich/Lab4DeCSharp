using System;
using System.IO;
using System.Xml.Serialization;

namespace DataManager
{
    public class XmlGeneratorService
    {
        private readonly Options.SendingOptions Options;
        public XmlGeneratorService(Options.SendingOptions options)
        {
            Options = options;
            if (!Directory.Exists(options.Directory))
            {
                Directory.CreateDirectory(options.Directory);
            }
        }
        public void GenerateXml<T>(T obj, string filename = null)
        {
            string fullname = Path.Combine(Options.Directory, (filename == null ? typeof(T).Name : filename.Replace(':', '-')) + ".xml");
            using (FileStream fs = new FileStream(fullname, FileMode.Create))
            {
                new XmlSerializer(typeof(T)).Serialize(fs, obj);
            }
        }
    }
}
