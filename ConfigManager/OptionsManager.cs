using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConfigManager
{
    public class OptionsManager
    {
        const string XmlConfigName = @"config.xml";
        const string JsonConfigName = @"appsettings.json";
        private readonly string CurPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public T GetOptions<T>() where T: new()
        {
            string JsonConfigPath = Path.Combine(CurPath, JsonConfigName);
            string XmlConfigPath = Path.Combine(CurPath, XmlConfigName);

            string jsonDocContent;
            try
            {
                jsonDocContent = File.ReadAllText(JsonConfigPath);
            }
            catch
            {
                jsonDocContent = null;
            }
            string xmlDocContent;
            try
            {
                xmlDocContent = File.ReadAllText(XmlConfigPath);
            }
            catch
            {
                xmlDocContent = null;
            }

            T options = new T();
            bool OptionsIsFilled = false;
            if (!OptionsIsFilled && !(jsonDocContent is null))
            {
                try
                {
                    options = JsonSerializer.Deserialize<T>(jsonDocContent);
                    OptionsIsFilled = true;
                }
                catch
                {
                    options = new T();
                }
            }
            if (!OptionsIsFilled && !(xmlDocContent is null))
            {
                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    using (FileStream fs = new FileStream(XmlConfigPath, FileMode.Open))
                    {
                        options = (T)formatter.Deserialize(fs);
                    }
                    OptionsIsFilled = true;
                }
                catch
                {
                    options = new T();
                }
            }
            if (!OptionsIsFilled)
            {
                OptionsIsFilled = true;
            }
            return options;
        }
    }
}
