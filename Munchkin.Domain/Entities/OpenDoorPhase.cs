using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class OpenDoorPhase : Phase
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public void DrawCard(Player player, Deck deck)
        {
            // Implementation to draw a card from the deck
        }
    }
}
