using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stream_backend.Entities
{
    public record Video
    {
        [BsonId]
        public Guid Id {get;set;}
        public Guid Streamer {get;set;}
        public string Title {get;set;}
        public string Duration {get;set;}
        public string Thumbnail {get;set;}

    }
}