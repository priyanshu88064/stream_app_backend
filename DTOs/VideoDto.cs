namespace Stream_backend.DTOs
{
    public record VideoDto
    {
        public Guid Id {get;set;}
        public Guid Publisher {get;set;}
        public string Title {get;set;}
        public string Duration {get;set;}
        public string Thumbnail {get;set;}
    }
}