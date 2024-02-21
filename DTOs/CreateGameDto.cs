namespace Stream_backend.DTOs
{
    public record CreateGameDto
    {
        public string Name {get;set;}
        public string Image {get;set;}
    }
}