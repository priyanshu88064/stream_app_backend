namespace Stream_backend.DTOs
{
    public record GameDto
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Image {get;set;}
    }
}