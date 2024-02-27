using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface IStreamerModel
    {
        public IEnumerable<Streamer> GetStreamers();
        public Streamer GetStreamerByUsername(string username);
        public void CreateStreamer(Streamer newStreamer);
        public void AddVideo(Guid publisher,Guid video);
        public void AddLive(Guid live,Guid publisher);
    }
}