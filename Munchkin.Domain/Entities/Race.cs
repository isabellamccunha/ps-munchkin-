using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Race : Card
    {
        public override void Activate()
        {
            throw new NotImplementedException();
        }

        public void Equip(Player player)
        {
            // Lógica para equipar raça ao jogador
        }
    }
}
