using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stream_backend.Entities
{
    public record Game
    {
        [BsonId]
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Image {get;set;}
    }
}