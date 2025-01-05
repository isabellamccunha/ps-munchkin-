

using Munchkin.Domain.Utils;

namespace Munchkin.Domain.Shared.Abstractions
{
    public abstract class Card
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }  
        public int Power { get; private set; }
        public int Damage { get; private set; }
        public int Reward { get; private set; }

        protected Card(string type, string name, string description) 
        {
            Type = type;
            Name = name;
            Description = description;
            Power = RandomNumberGenerator.GenerateNumberFrom1To100();
            Damage = RandomNumberGenerator.GenerateNumberFrom1To10();
            Reward = RandomNumberGenerator.GenerateNumberFrom1To10();
        }

        public abstract void Activate();
    }
}
