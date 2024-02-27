using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stream_backend.Entities
{
    public record Streamer
    {   
        [BsonId]
        public Guid Id {get;set;}
        public Guid Live {get;set;}
        public string Username {get;set;}
        public string Name {get;set;}
        public int Followers {get;set;}
        public int Following {get;set;}
        public string ProfileImg {get;set;}
        public List<Guid> Videos {get;set;}
    }
}