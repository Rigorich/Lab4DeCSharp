using System;
using System.IO;
using System.Threading;

namespace Lab4DeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager.DataManager manager = new DataManager.DataManager();
            new Thread(new ThreadStart(manager.Start)).Start();
            Console.WriteLine("DataManager successfully started work");
        }

        /*
        static void CreateConfigsFromDefault()
        {
            const string XmlConfigName = @"config.xml";
            const string JsonConfigName = @"appsettings.json";
            string CurPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string JsonConfigPath = Path.Combine(CurPath, JsonConfigName);
            string XmlConfigPath = Path.Combine(CurPath, XmlConfigName);

            DataManager.Options.AllOptions options = new DataManager.Options.AllOptions();
            System.Xml.Serialization.XmlSerializer formatter = new System.Xml.Serialization.XmlSerializer(typeof(DataManager.Options.AllOptions));
            using (FileStream fs = new FileStream(XmlConfigPath, FileMode.Create))
            {
                formatter.Serialize(fs, options);
            }
            using (StreamWriter sw = new StreamWriter(JsonConfigPath))
            {
                sw.Write(System.Text.Json.JsonSerializer.Serialize(options, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
            }
        }
        */
    }
}
