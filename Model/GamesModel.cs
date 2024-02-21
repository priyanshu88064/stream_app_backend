using Stream_backend.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stream_backend.Model
{
    public class GamesModel:IGamesModel
    {
        private readonly IMongoCollection<Game> gameCollection;
        private readonly string CollectionName = "games";

        public GamesModel(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            gameCollection = database.GetCollection<Game>(CollectionName);
        }

        public void AddGame(Game game){
            gameCollection.InsertOne(game);
        }

        public IEnumerable<Game> GetGames()
        {
            return gameCollection.Find(new BsonDocument()).ToList();
        }
    }
}