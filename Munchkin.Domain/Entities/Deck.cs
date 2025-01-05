using Munchkin.Domain.Entities.Cards;
using Munchkin.Domain.Shared.Abstractions;
using System;

namespace Munchkin.Domain.Entities
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            CreateDeck();
        }

        public void CreateDeck()
        {
            Cards = new List<Card>();

            for (int i = 0; i < 30; i++)
            {
                var monsterInfos = Monster.CreateMonsterInfo();
                 Add(new Monster(monsterInfos.Item1, monsterInfos.Item2));
            }

            for (int i = 0; i < 30; i++)
            {
                var classInfos = Class.CreateClassInfo();
                Add(new Class(classInfos.Item1, classInfos.Item2));
            }

            for (int i = 0; i < 30; i++)
            {
                var treasureInfos = Treasure.CreateTreasureInfo();
                Add(new Treasure(treasureInfos.Item1, treasureInfos.Item2));
            }

            for (int i = 0; i < 30; i++)
            {
                var curseInfos = Curse.CreateCurseInfo();
                Add(new Curse(curseInfos.Item1, curseInfos.Item2));
            }
        }

        public Card ChooseCard()
        {
            Random random = new Random();

            int randomIndex = random.Next(Cards.Count);

            return Cards[randomIndex];
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }
    }
}
