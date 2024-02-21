using Stream_backend.DTOs;
using Stream_backend.Entities;

namespace Stream_backend
{
    public static class Extensions
    {
        public static StreamerDto AsDto(this Streamer streamer)
        {
            return new StreamerDto {
                Id = streamer.Id,
                Username = streamer.Username,
                Name = streamer.Name
            };
        }
    }
}