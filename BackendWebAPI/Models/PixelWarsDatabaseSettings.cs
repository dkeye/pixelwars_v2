namespace BackendWebAPI.Models
{
    public class PixelWarsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PixelWarsCollectionName { get; set; } = null!;
    }
}
