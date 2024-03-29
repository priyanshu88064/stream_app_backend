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
                Live = streamer.Live,
                Name = streamer.Name,
                Email = streamer.Email,
                ProfileImg = streamer.ProfileImg,
                Videos = streamer.Videos,
                Followers = streamer.Followers,
                Following = streamer.Following
            };
        }

        public static VideoDto AsDto(this Video video)
        {
            return new VideoDto {
                Id = video.Id,
                Title = video.Title,
                Publisher = video.Publisher,
                Duration = video.Duration,
                Thumbnail = video.Thumbnail
            };
        }
    }
}