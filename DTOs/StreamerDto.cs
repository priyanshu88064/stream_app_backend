using MongoDB.Bson;

namespace Stream_backend.DTOs
{
    public record StreamerDto
    {
        public Guid Id {get;set;}
        public string Username {get;set;}
        public string Name {get;set;}
        public List<Guid> Videos {get;set;}
    }
}