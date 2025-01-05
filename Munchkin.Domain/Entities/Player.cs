using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Player
    {
        public Player(string username, string type)
        {
            Username = username;
            Type = type;
            Level = 1;
            Cards = new List<Card>();
            Hand = new Hand();
            Backpack = new Backpack();
        }

        public static List<Player> CreatePlayers()
        {
            return new List<Player>()
            {
                new Player("Myself",""),
                new Player("Player1",""),
                new Player("Player2",""),
                new Player("Player3","")
            };
        }

        public string Username { get; private set; }
        public string Type { get; private set; }
        public int Level { get; private set; }
        public List<Card> Cards { get; private set; }
        private Hand Hand { get; set; }
        public Backpack Backpack { get; private set; }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
