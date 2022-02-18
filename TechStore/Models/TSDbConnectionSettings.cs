namespace TechStore.Models
{
    public class TSDbConnectionSettings : ITSDbConnectionSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string UserCollection { get; set; }
        public string OrderCollection { get; set; }
    }

    public interface ITSDbConnectionSettings
    {
        string ConnectionString { get; set; }
        string DbName { get; set; }
        string UserCollection { get; set; }
        string OrderCollection { get; set; }
    }
}
