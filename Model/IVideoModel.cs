namespace Stream_backend.Model
{
    public interface IVideoModel
    {
        public void CreateVideo(Video video);
        public IEnumerable<Video> GetVideoByStreamer(Guid id);
        public Video GetVideoById(Guid id);
    }
}