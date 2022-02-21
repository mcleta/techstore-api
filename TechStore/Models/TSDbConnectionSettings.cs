using System;

namespace TechStore.Models
{
    public class TSDbConnectionSettings : ITSDbConnectionSettings
    {
        public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("DbConnection:ConnectionString");
        public string DbName { get; set; } = Environment.GetEnvironmentVariable("DbConnection:DbName");
        public string UserCollection { get; set; } = Environment.GetEnvironmentVariable("DbConnection:UserCollection");
        public string OrderCollection { get; set; } = Environment.GetEnvironmentVariable("DbConnection:OrderCollection");
    }

    public interface ITSDbConnectionSettings
    {
        string ConnectionString { get; set; }
        string DbName { get; set; }
        string UserCollection { get; set; }
        string OrderCollection { get; set; }
    }
}
