using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class PlayerClass : Card
    {
        public override void Activate()
        {
        }

        public void Equip(Player player)
        {
            // Logic to equip class to the player
        }
    }
}
