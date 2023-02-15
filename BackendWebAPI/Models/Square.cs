using MongoDB.Bson.Serialization.Attributes;

namespace BackendWebAPI.Models
{
    public class Square
    {
        public int x { get; set; }
        public int y { get; set; }

        [BsonElement("color")]
        public string Сolor { get; set; } = null!;
    }    
}
