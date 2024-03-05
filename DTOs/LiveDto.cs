namespace Stream_backend.DTOs
{
    public record LiveDto
    {
        public Guid Id {get;set;}
        public Guid Publisher {get;set;}
        public int viewers {get;set;}
        public string Title {get;set;}
        public string Image {get;set;}
        public string meetingid {get;set;}
    }
}