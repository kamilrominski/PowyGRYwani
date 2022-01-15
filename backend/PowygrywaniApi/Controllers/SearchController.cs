using Microsoft.AspNetCore.Mvc;
using PowygrywaniApi.Model;

namespace PowygrywaniApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ModelContext _context;

        public SearchController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("{searchString}")]
        public List<Object> Search(string searchString)
        {
            List<Game> games = GetGames(searchString);
            List<Studio> studios = GetStudios(searchString);

            List<object> _result = games.Cast<object>().Concat(studios).ToList();

            return _result;
        }
        [HttpGet("game/{searchString}")]
        public List<Game> GetGames(string searchString)
        {
            var gamesList = _context.games.Where(o => o.Name.Contains(searchString)).ToList();
            if (gamesList.Count == 0)
                return new List<Game>();

            foreach (var game in gamesList)
                game.Type = "game";

            return gamesList;
        }
        [HttpGet("studio/{searchString}")]
        public List<Studio> GetStudios(string searchString)
        {
            var studioList = _context.studios.Where(o => o.Name.Contains(searchString)).ToList();

            if (studioList.Count == 0)
                return new List<Studio>();

            foreach (var studio in studioList)
                studio.Type = "studio";

            return studioList;
        }

    }
}
