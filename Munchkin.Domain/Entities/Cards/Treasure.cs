using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.Domain.Entities.Cards
{
    public class Treasure : Card
    {
        public Treasure(string name, string description)
            : base("Tesouro", name, description)
        {
        }

        public static (string, string) CreateTreasureInfo()
        {
            var random = new Random();

            var treasureList = new List<(string, string)>
            {
                ("Coroa de Rubis", "Uma coroa adornada com rubis que dizem ter poderes mágicos."),
                ("Espada Dourada", "Uma espada antiga feita de um metal dourado impenetrável."),
                ("Gema Mística", "Uma gema misteriosa que brilha com uma luz sobrenatural."),
                ("Elixir de Vida", "Um elixir que promete curar qualquer ferimento e restaurar a juventude."),
                ("Cofre Antigo", "Um cofre antigo, cheio de riquezas esquecidas e mistérios."),
                ("Poderoso Grimório", "Um grimório contendo feitiços poderosos e segredos antigos.")
            };

            return treasureList[random.Next(treasureList.Count)];
        }


        public override void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
