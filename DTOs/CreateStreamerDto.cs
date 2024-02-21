namespace Stream_backend.DTOs
{
    public record CreateStreamerDto
    {
        public string Username {get;set;}
        public string Name {get;set;}
    }
}