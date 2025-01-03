using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Backpack
    {
        public int Capacity { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public void Store(Card card)
        {
            if (Cards.Count < Capacity)
            {
                Cards.Add(card);
            }
        }

        public void Take(Card card)
        {
            Cards.Remove(card);
        }
    }
}
