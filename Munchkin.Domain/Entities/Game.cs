namespace Munchkin.Domain.Entities
{
    public class Game
    {
        private static Game _instance;

        private Game() { }

        public static Game Instance
        {
            get
            {
                if (_instance == null)                
                    _instance = new Game();
                
                return _instance;
            }
        }

        public void StartGame()
        {
            // Implementation to start the game
        }

        public void EndGame()
        {
            // Implementation to end the game
        }

        public void AdvanceTurn()
        {
            // Implementation to advance the turn
        }
    }
}
