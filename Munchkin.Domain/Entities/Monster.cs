namespace Munchkin.Domain.Entities
{
    public class Monster
    {
        public int Level { get; set; }
        public int NumberOfTreasures { get; set; }

        public void ApplyMisfortune(Player player)
        {
        }
    }
}
