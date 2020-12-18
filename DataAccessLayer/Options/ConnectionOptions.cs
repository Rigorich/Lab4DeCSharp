using System;

namespace DataAccessLayer.Options
{
    public class ConnectionOptions
    {
        public string Server { get; set; } = @"DESKTOP-5BPITN8\SQLEXPRESS";
        public string Database { get; set; } = "AdventureWorks2017";
        public bool IntegratedSecurity { get; set; } = true;
    }
}
