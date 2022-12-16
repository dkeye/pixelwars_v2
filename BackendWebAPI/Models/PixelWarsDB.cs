using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System.Text.Json.Serialization;
using System.Web.Helpers;

#nullable disable
namespace BackendWebAPI.Models
{
    public class PixelWarsCollection
    {
        private Square square1;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Squares")]
        [BsonRepresentation(BsonType.String)]
        public string Squares { get; set; }       


        [BsonElement("x")]
        [BsonRepresentation(BsonType.Int32)]
        public int x { get; set; }

        [BsonElement("Size")]
        [BsonRepresentation(BsonType.String)]
        public string Size { get; set; }


    }
}
