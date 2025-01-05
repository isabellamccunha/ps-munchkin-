using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities.Cards
{
    public class Curse : Card
    {
        public Curse(string name, string description) 
            :base("Maldição", name, description) 
        {
        }

        public static (string, string) CreateCurseInfo()
        {
            var random = new Random();

            var curseInfos = new List<(string, string)>
            {
                ("Vento Sombrio", "Uma maldição que faz com que o portador ouça sussurros aterrorizantes durante a noite."),
                ("Imortalidade", "Concede imortalidade, mas o portador nunca pode encontrar paz, vivendo eternamente em agonia."),
                ("Sombra", "A sombra do portador se torna independente e persegue sua vítima, causando pânico e medo."),
                ("Lua Sangrenta", "Faz com que o portador se transforme em uma criatura selvagem durante as noites de lua cheia."),
                ("Lamento Eterno", "A voz do portador nunca mais será ouvida, mas será substituída por gritos de dor incessantes."),
                ("Olho Furtivo", "O portador perde o controle de sua visão, sendo forçado a ver o pior de cada situação que acontece ao seu redor.")
            };

            return curseInfos[random.Next(curseInfos.Count)];
        }

        public override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
