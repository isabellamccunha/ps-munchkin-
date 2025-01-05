using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities.Cards
{
    public class Class : Card
    {
        public Class(string name, string description) 
            :base("Classe", name, description) 
        {
        }

        public static (string, string) CreateClassInfo()
        {
            var random = new Random();

            var classInfos = new List<(string, string)>
            {
                ("Guerreiro", "Um combatente feroz especializado no uso de armas pesadas e na resistência em combate."),
                ("Mago", "Um mestre das artes arcanas, capaz de lançar feitiços poderosos e manipular os elementos."),
                ("Ladrão", "Um especialista em furtividade, roubo e habilidades de evasão, mestre do disfarce."),
                ("Arqueiro", "Um habilidoso com o arco e flecha, capaz de atacar à distância com precisão mortal."),
                ("Clérigo", "Um devoto curandeiro que usa magia divina para restaurar a saúde e proteger os aliados."),
                ("Bárbaro", "Um guerreiro bruto e selvagem, que entra em fúria para aumentar sua força e resistência."),
                ("Assassino", "Um mestre do silêncio, especializado em eliminar alvos rapidamente com precisão mortal."),
                ("Necromante", "Um conjurador de mortos que usa magia sombria para controlar os mortos e amaldiçoar os inimigos.")
            };

            return classInfos[random.Next(classInfos.Count)];
        }

        public override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
