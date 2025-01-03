using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class CombatPhase : Phase
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public void AttackMonster(Monster monster)
        {
            // Logic to attack a monster
        }

        public void AskForHelp(Player player)
        {
            // Implementation to ask another player for help
        }
    }
}
