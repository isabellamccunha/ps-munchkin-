namespace Munchkin.Domain.Shared.Abstractions
{
    public abstract class Phase
    {
        public abstract void Execute();
        public void NextPhase()
        {
        }
    }
}
