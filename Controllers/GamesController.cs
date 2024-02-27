using Microsoft.AspNetCore.Mvc;
using Stream_backend.Entities;
using Stream_backend.Model;
using Stream_backend.DTOs;

namespace Stream_backend.Controllers
{
    [ApiController]
    [Route("games")]
    public class GamesController:ControllerBase
    {
        private readonly IGamesModel games;

        public GamesController(IGamesModel games)
        {
            this.games = games;
        }

        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            return games.GetGames().Select(data => new GameDto{
                Id = data.Id,
                Name = data.Name,
                Image = data.Image
            });
        }

        [HttpPost]
        public void AddGame(CreateGameDto game)
        {
            games.AddGame(new Game{
                Id = Guid.NewGuid(),
                Name = game.Name,
                Image = game.Image
            });
        }
    }
}