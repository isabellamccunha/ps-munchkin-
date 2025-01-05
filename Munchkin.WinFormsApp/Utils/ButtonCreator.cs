namespace Munchkin.WinFormsApp.Utils
{
    public static class ButtonCreator
    {
        public static Button CreateCardButton(string buttonName, string cardName, string cardDescription, string cardType, int locationX, int locationY)
        {
            var button = new Button
            {
                Name = buttonName,
                Size = new Size(79, 127),
                Location = new Point(locationX, locationY),
                BackColor = Color.Bisque,
                ForeColor = Color.SaddleBrown,
                Text = cardName,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            var titleLabel = CreateTitleCard(cardType);

            var descriptionLabel = CreateDescriptionCard(cardDescription);

            button.Controls.Add(titleLabel);
            button.Controls.Add(descriptionLabel);

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

        private static Label CreateDescriptionCard(string cardDescription)
        {
            return new Label
            {
                Text = cardDescription,
                Font = new Font("Perpetua", 8, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                Location = new Point(5, 150),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

    }
}
