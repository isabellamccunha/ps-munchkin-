
namespace Munchkin.Domain.Shared.Abstractions
{
    public abstract class Card
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }  

        protected Card(string type, string name, string description) 
        {
            Type = type;
            Name = name;
            Description = description;
        }
        public abstract void Activate();
    }
}
