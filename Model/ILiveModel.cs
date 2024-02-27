using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface ILiveModel
    {
        public void CreateLive(Live live);
        public IEnumerable<Live> GetLive();
    }
}