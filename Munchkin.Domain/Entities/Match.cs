using Munchkin.Domain.Entities.Decks;
using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Match
    {
        public List<Player> Players { get; private set; }
        public Deck Deck { get; private set; }
        
        public Match(List<Player> players)
        {
            Players = players;          
        }
               
        public void Initialize(Deck deck)
        {
            Deck = deck;
            
            var random = new Random();

            foreach (var player in Players)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (deck.Cards.Count == 0) break;

                    int cardIndex = random.Next(deck.Cards.Count);
                    var card = deck.Cards[cardIndex];

                    player.AddCard(card);
                    deck.Cards.RemoveAt(cardIndex);
                }

                player.SetPower();
            }
        }
    }
}
