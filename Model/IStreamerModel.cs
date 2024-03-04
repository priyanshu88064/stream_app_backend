using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface IStreamerModel
    {
        public IEnumerable<Streamer> GetStreamers();
        public Streamer GetStreamerByEmail(string email);
        public string CreateStreamer(Streamer newStreamer);
        public void AddVideo(Guid publisher,Guid video);
        public void AddLive(Guid live,Guid publisher);
    }
}