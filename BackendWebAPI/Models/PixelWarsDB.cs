using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

#nullable disable
namespace BackendWebAPI.Models
{
    public class PixelWarsCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]

        public Square square { get; set; }
        public string Size { get; set; }
    }
}
