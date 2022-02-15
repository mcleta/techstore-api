namespace TechStore.Models
{
    public class TSDbConnectionSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string ProductCollection { get; set; } = null!;
        public string OrderCollection { get; set; } = null!;
    }
}
