using Stream_backend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stream_backend.Model
{
    public class LiveModel:ILiveModel
    {
        private readonly IMongoCollection<Live> liveCollection;
        private readonly string CollectionName = "live";

        public LiveModel(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            liveCollection = database.GetCollection<Live>(CollectionName);
        }

        public void CreateLive(Live live)
        {
            liveCollection.InsertOne(live);
        }
        
        public IEnumerable<Live> GetLive()
        {
            return liveCollection.Find(new BsonDocument()).ToList();
        }
    }
}