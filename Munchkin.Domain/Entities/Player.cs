
using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities
{
    public class Player
    {
        public Player(string level, string username)
        {
            Level = level;
            Username = username;
            Hand = new Hand();
            Backpack = new Backpack();
        }

        public string Level { get; private set; }
        public string Username { get; private set; }
        public Hand Hand { get; private set; } 
        public Backpack Backpack { get; private set; }

        public void GiveCard(Player player, Card card)
        {
            // Implementation to give a card to another player
        }

        public void EscapeCombat()
        {
            // Implementation to escape combat
        }

        public void EquipItem(Item item)
        {
            // Logic to equip an item
        }

        public void ActivateItem(Item item)
        {
            // Logic to activate an item
        }

        public void EquipMonster(Item item)
        {
            // Logic to equip a monster
        }
    }
}
