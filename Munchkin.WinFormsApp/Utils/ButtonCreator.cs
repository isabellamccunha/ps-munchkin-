using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.WinFormsApp.Utils
{
    public static class ButtonCreator
    {
        public static Button CreateCardButton(string buttonName, Card card, int locationX, int locationY)
        {
            var button = new Button
            {
                Name = buttonName,
                Size = new Size(79, 127),
                Location = new Point(locationX, locationY),
                BackColor = Color.Bisque,
                ForeColor = Color.SaddleBrown,
                Text = card.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            var titleLabel = CreateTitleCard(card.Type);

            var powerLabel = CreatePowerCard(card.Power);

            var rewardLabel = CreateRewardCard(card.Reward);

            var damageLabel = CreateDemageCard(card.Damage);

            button.Controls.Add(titleLabel);
            button.Controls.Add(powerLabel);
            button.Controls.Add(rewardLabel);
            button.Controls.Add(damageLabel);

            return button;
        }

        private static Label CreateTitleCard(string cardType)
        {
            return new Label
            {
                Text = cardType,
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                ForeColor = Color.DarkGoldenrod,
                Location = new Point(14, 5),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private static Label CreatePowerCard(int power)
        {
            return new Label
            {
                Text = $"PODER: {power}",
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 85),
                AutoSize = true,
                BackColor = Color.Chocolate
            };
        }

        private static Label CreateRewardCard(int reward)
        {
            return new Label
            {
                Text = $"RECOMP: {reward}",               
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 100),
                AutoSize = true,
                BackColor = Color.Chocolate
            };
        }

        private static Label CreateDemageCard(int demage)
        {
            return new Label
            {
                Text = $"DANO: {demage}",
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 115),
                AutoSize = true,
                BackColor = Color.Chocolate
            };
        }

    }
}
