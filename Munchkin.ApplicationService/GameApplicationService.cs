using Munchkin.Domain.Entities;

namespace Munchkin.ApplicationService
{
    public class GameApplicationService
    {
        public Match InitializeGame()
        {            
            var match = new Match();
            match.Initialize(Player.CreatePlayers(), new Deck());

            return match;
        }        
    }
}
