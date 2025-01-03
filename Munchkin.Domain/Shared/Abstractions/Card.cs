
namespace Munchkin.Domain.Shared.Abstractions
{
    public abstract class Card
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public abstract void Activate();
    }
}
