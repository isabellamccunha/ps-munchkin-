using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Match
    {
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }
        private static Match instance;
        private Turn turn { get; set; }

        private Match()
        {
            Players = new List<Player>();
            Deck = new Deck();
        }
               
        public void Initialize(List<Player> players, Deck deck)
        {
            Players = players;
            Deck = deck;
            var random = new Random();

            foreach (var player in Players)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (deck.Cards.Count == 0) break;

                    int cardIndex = random.Next(deck.Cards.Count);
                    var card = deck.Cards[cardIndex];

                    player.Cards.Add(card);
                    deck.Cards.RemoveAt(cardIndex);
                }
            }
        }

        public static Match getInstance()
        {
            if(instance == null)
            {
                instance = new Match();
            }
            return instance;
        }
    }
}
