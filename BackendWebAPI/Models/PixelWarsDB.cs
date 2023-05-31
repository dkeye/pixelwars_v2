using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace BackendWebAPI.Models
{
    public class PixelWarsGrid
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Square[] Squares { get; set; }

        [BsonIgnore]
        public uint x { get; set; }
        [BsonIgnore]
        public uint y { get; set; }

        [BsonElement("Size")]
        [BsonRepresentation(BsonType.String)]
        public string Size { get; set; }

    }
}
