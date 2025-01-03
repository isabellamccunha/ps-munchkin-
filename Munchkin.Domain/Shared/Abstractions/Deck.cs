namespace Munchkin.Domain.Shared.Abstractions
{
    public abstract class Deck
    {
        protected List<Card> Cards { get; set; } = new List<Card>();

        public virtual void PlayCard()
        {
            // Implementation to play a card
        }
    }
}
