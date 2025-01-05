using Munchkin.Domain.Shared.Abstractions;
using System;

namespace Munchkin.Domain.Entities.Cards
{
    public class Monster : Card
    {
        public Monster(string name, string description)
            : base("Monstro", name, description)
        {
        }


        public static (string, string) CreateMonsterInfo()
        {
            var random = new Random();

            var monsterInfos = new List<(string, string)>
            {
                ("Drakon", "A mighty and ancient dragon, feared by many."),
                ("Gorgon", "A terrifying gorgon that turns all to stone."),
                ("Cyclops", "A one-eyed giant, known for its incredible strength."),
                ("Behemoth", "A legendary beast with unmatched power."),
                ("Hydra", "A multi-headed hydra, each head more dangerous than the last."),
                ("Griffin", "A fierce griffin, part eagle and part lion."),
                ("Chimera", "A chimera, a terrifying creature with the body of a lion, the head of a goat, and the tail of a snake."),
                ("Manticore", "A manticore with a poisonous tail, ready to strike.")
            };

            return monsterInfos[random.Next(monsterInfos.Count)];
        }

        private static (string, string) GetRandomItem(List<(string, string)> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }

        public override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
