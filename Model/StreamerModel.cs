using Stream_backend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stream_backend.Model
{
    public class StreamerModel:IStreamerModel
    {
        private readonly IMongoCollection<Streamer> streamerCollection;
        private readonly string CollectionName = "streamers";

        public StreamerModel(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            streamerCollection = database.GetCollection<Streamer>(CollectionName);
        }

        public IEnumerable<Streamer> GetStreamers()
        {
            return streamerCollection.Find(new BsonDocument()).ToList();
        }

        public Streamer GetStreamerByUsername(string username)
        {
            return streamerCollection.Find(res => res.Username==username).FirstOrDefault();
        }

        public void CreateStreamer(Streamer newStreamer)
        {
            streamerCollection.InsertOne(newStreamer);
        }

        public void AddVideo(Guid publisher,Guid video)
        {
            streamerCollection.UpdateOne(
                Builders<Streamer>.Filter.Eq("Id",publisher),
                Builders<Streamer>.Update.Push("Videos",video)
            );
        }

        public void AddLive(Guid live,Guid publisher)
        {
            streamerCollection.UpdateOne(
                Builders<Streamer>.Filter.Eq("Id",publisher),
                Builders<Streamer>.Update.Set("Live",live)
            );
        }
    }
}