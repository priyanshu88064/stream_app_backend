using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stream_backend.Entities
{
    public record Live
    {
        [BsonId]
        public Guid Id {get;set;}
        public Guid Publisher {get;set;}
        public int viewers {get;set;}
        public string Title {get;set;}
        public string Image {get;set;}
    }
}