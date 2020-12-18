using System;

namespace DataManager.Options
{
    public class AllOptions
    {
        public DataAccessLayer.Options.ConnectionOptions ConnectionOptions { get; set; } = new DataAccessLayer.Options.ConnectionOptions();
        public SendingOptions SendingOptions { get; set; } = new SendingOptions();
        public MonitorOptions MonitorOptions { get; set; } = new MonitorOptions();
    }
}
