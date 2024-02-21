using Stream_backend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stream_backend.Model
{
    public class VideoModel:IVideoModel
    {
        private readonly IMongoCollection<Video> videoCollection;
        private readonly string CollectionName = "videos";

        public VideoModel(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            videoCollection = database.GetCollection<Video>(CollectionName);
        }

        public void CreateVideo(Video video)
        {
            videoCollection.InsertOne(video);
        }

        public IEnumerable<Video> GetVideosByPublisher(Guid publisher)
        {
            return videoCollection.Find(item => item.Publisher == publisher).ToList();
        }
    }
}