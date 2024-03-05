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

        public Streamer GetStreamerByEmail(string email)
        {
            return streamerCollection.Find(res => res.Email==email).FirstOrDefault();
        }

        public Streamer CreateStreamer(Streamer newStreamer)
        {

            Streamer findstreamer = GetStreamerByEmail(newStreamer.Email);

            if(findstreamer==null)
            {
                streamerCollection.InsertOne(newStreamer);
                return newStreamer;
            }
            else
            {
                return findstreamer;
            }
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