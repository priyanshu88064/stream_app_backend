using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface IStreamerModel
    {
        public IEnumerable<Streamer> GetStreamers();
        public Streamer GetStreamerByUsername(string username);
        public void CreateStreamer(Streamer newStreamer);
    }
}