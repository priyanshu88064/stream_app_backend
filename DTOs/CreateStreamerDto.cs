using System.ComponentModel.DataAnnotations;

namespace Stream_backend.DTOs
{
    public record CreateStreamerDto
    {   

        [Required(ErrorMessage = "Name is required")]
        public string Name {get;set;}

        [Required(ErrorMessage = "Email is required")]
        public string Email {get;set;}
        
        public string ProfileImg {get;set;}
    }
}