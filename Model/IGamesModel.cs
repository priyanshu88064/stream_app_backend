using Stream_backend.Entities;

namespace Stream_backend.Model
{
    public interface IGamesModel
    {
        public void AddGame(Game game);
        public IEnumerable<Game> GetGames();
    }
}