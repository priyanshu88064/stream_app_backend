namespace Stream_backend.Controllers
{
    public class VideoController
    {
        private readonly IVideoModel video;

        public VideoController(IVideoModel video)
        {
            this.video = video;
        }
    }
}