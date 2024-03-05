using Microsoft.AspNetCore.Mvc;
using Stream_backend.Entities;
using Stream_backend.Model;
using Stream_backend.DTOs;

namespace Stream_backend.Controllers
{
    [ApiController]
    [Route("streamer")]
    public class StreamerController:ControllerBase
    {
        public readonly IStreamerModel streamer;

        public StreamerController(IStreamerModel streamer)
        {
            this.streamer = streamer;
        }

        [HttpGet]
        public IEnumerable<StreamerDto> GetStreamers()
        {
            return streamer.GetStreamers().Select(item => item.AsDto());
        }

        [HttpGet]
        [Route("{email}")]
        public ActionResult<StreamerDto> GetStreamerByEmail(string email)
        {

            var result =  streamer.GetStreamerByEmail(email);

            if(result==null){
                return NotFound();
            }

            return result.AsDto();
        }

        [HttpPost]
        public StreamerDto CreateStreamer(CreateStreamerDto newStreamer)
        {

            Streamer tempstreamer = new Streamer {
                Id = Guid.NewGuid(),
                Live = Guid.Empty,
                Name = newStreamer.Name,
                Email = newStreamer.Email,
                ProfileImg = newStreamer.ProfileImg,
                Followers = 0,
                Following = 0,
                Videos = []
            };

            tempstreamer = streamer.CreateStreamer(tempstreamer);

            return new StreamerDto{
                Id = tempstreamer.Id,
                Live = tempstreamer.Live,
                Name = tempstreamer.Name,
                Email = tempstreamer.Email,
                ProfileImg = tempstreamer.ProfileImg,
                Followers = tempstreamer.Followers,
                Following = tempstreamer.Following,
                Videos = tempstreamer.Videos
            };
        }
    }
}