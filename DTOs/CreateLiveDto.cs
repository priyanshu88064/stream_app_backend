namespace Stream_backend.DTOs
{
    public record CreateLiveDto
    {
        public Guid Publisher {get;set;}
        public string Title {get;set;}
        public string Image {get;set;}
    }
}