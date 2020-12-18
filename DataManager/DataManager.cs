using System;
using Models;
using ServiceLayer;
using DataManager.Options;

namespace DataManager
{
    public class DataManager
    {
        private readonly AllOptions Options;
        private readonly ServiceDAL Service;
        private readonly XmlGeneratorService Generator;
        public FullPersonInfo[] Persons { get; private set; }
        public DataManager()
        {
            ConfigManager.OptionsManager manager = new ConfigManager.OptionsManager();
            Options = manager.GetOptions<AllOptions>();
            Service = new ServiceDAL(Options.ConnectionOptions);
            Generator = new XmlGeneratorService(Options.SendingOptions);
        }
        public void Load()
        {
            try
            {
                Persons = Service.GetFullPersonInfo();
            }
            catch
            {
                Persons = null;
            }
        }
        public void GenerateXml(string filename = null)
        {
            try
            {
                Generator.GenerateXml(Persons, filename);
            }
            catch
            {
            }
        }

        bool Enabled = false;
        public void Start()
        {
            Enabled = true;
            while (Enabled)
            {
                Load();
                GenerateXml(DateTime.Now.ToString());
                System.Threading.Thread.Sleep(Options.MonitorOptions.CopyInterval * 1000);
            }
        }
        public void Stop()
        {
            Enabled = false;
        }
    }
}
