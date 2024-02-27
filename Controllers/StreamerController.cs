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
        [Route("{username}")]
        public ActionResult<StreamerDto> GetStreamerByUsername(string username)
        {

            var result =  streamer.GetStreamerByUsername(username);

            if(result==null){
                return NotFound();
            }

            return result.AsDto();
        }

        [HttpPost]
        public void CreateStreamer(CreateStreamerDto newStreamer)
        {
            streamer.CreateStreamer(new Streamer {
                Id = Guid.NewGuid(),
                Live = Guid.Empty,
                Name = newStreamer.Name,
                Username = newStreamer.Username,
                Videos = []
            });
        }
    }
}