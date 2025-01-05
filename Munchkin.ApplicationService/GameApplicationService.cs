using Munchkin.Domain.Entities;

namespace Munchkin.ApplicationService
{
    public class GameApplicationService
    {
        public Match InitializeGame()
        {            
            var match = Match.getInstance();
            match.Initialize(Player.CreatePlayers(), new Deck());

            return match;
        }        
    }
}
