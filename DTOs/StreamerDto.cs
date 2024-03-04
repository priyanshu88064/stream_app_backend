using MongoDB.Bson;

namespace Stream_backend.DTOs
{
    public record StreamerDto
    {
        public Guid Id {get;set;}
        public Guid Live {get;set;}
        public string Email {get;set;}
        public string ProfileImg {get;set;}
        public string Name {get;set;}
        public int Followers {get;set;}
        public int Following {get;set;}
        public List<Guid> Videos {get;set;}
    }
}