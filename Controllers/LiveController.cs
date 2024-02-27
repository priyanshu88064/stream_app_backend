using Microsoft.AspNetCore.Mvc;
using Stream_backend.Entities;
using Stream_backend.Model;
using Stream_backend.DTOs;

namespace Stream_Backend.Controllers
{
    [ApiController]
    [Route("live")]
    public class LiveController:ControllerBase
    {
        private readonly ILiveModel live;
        private readonly IStreamerModel streamer;

        public LiveController(ILiveModel live,IStreamerModel streamer)
        {
            this.live = live;
            this.streamer = streamer;
        }

        [HttpGet]
        public IEnumerable<LiveDto> GetLive()
        {
            return live.GetLive().Select(data => new LiveDto{
                Id = data.Id,
                Publisher = data.Publisher,
                viewers = data.viewers,
                Title = data.Title,
                Image = data.Image
            });
        }

        [HttpPost]
        public void CreateLive(CreateLiveDto newLive)
        {
            Guid liveId = Guid.NewGuid();

            streamer.AddLive(liveId,newLive.Publisher);

            Random rnd = new Random();

            live.CreateLive(new Live{
                Id = liveId,
                Publisher = newLive.Publisher,
                viewers = rnd.Next(2300,9999),
                Title = newLive.Title,
                Image = newLive.Image
            });
        }
    }
}