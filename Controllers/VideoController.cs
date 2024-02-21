using Microsoft.AspNetCore.Mvc;
using Stream_backend.DTOs;
using Stream_backend.Entities;
using Stream_backend.Model;

namespace Stream_backend.Controllers
{
    [ApiController]
    [Route("video")]
    public class VideoController
    {
        private readonly IVideoModel video;
        private readonly IStreamerModel streamer;

        public VideoController(IStreamerModel streamer,IVideoModel video)
        {
            this.streamer = streamer;
            this.video = video;
        }

        [HttpGet]
        [Route("{publisher}")]
        public IEnumerable<Video> GetVideosByPublisher(Guid publisher)
        {
            return video.GetVideosByPublisher(publisher);
        }

        [HttpPost]
        public void CreateVideo(CreateVideoDto newVideo)
        {
            Guid videoId = Guid.NewGuid();

            streamer.AddVideo(newVideo.Publisher,videoId);

            video.CreateVideo(new Video{
                Id = videoId,
                Publisher = newVideo.Publisher,
                Title = newVideo.Title,
                Duration = newVideo.Duration,
                Thumbnail = newVideo.Thumbnail
            });
        }
    }
}