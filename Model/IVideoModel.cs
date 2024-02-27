using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface IVideoModel
    {   
        public IEnumerable<Video> GetVideos();
        public void CreateVideo(Video video);
        public IEnumerable<Video> GetVideosByPublisher(Guid publisher);
    }
}