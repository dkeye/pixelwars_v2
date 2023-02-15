using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System.Text.Json.Serialization;

#nullable disable
namespace BackendWebAPI.Models
{
    public class PixelWarsCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Square[] Squares { get; set; }       

        [BsonElement("Size")]
        [BsonRepresentation(BsonType.String)]
        public string Size { get; set; }

    }
}
