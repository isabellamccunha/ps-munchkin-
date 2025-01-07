using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities.Decks
{
    public class Treasure : Deck
    {
        public Treasure(List<Card> cards) 
            : base(cards)
        {
        }
    }
}
