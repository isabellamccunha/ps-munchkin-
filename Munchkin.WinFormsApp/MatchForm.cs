using System.Media;
using Munchkin.ApplicationService;
using Munchkin.Domain.Entities;
using Munchkin.Domain.Shared.Abstractions;

namespace Munchkin.WinFormsApp
{
    public partial class MatchForm : Form
    {
        private GameApplicationService _gameApplicationService;
        private Match _match;

        public MatchForm()
        {
            InitializeComponent();

            HideCards();

            _gameApplicationService = new GameApplicationService();
        }

        private void btn_initialize_match_Click(object sender, EventArgs e)
        {
            _match = _gameApplicationService.InitializeGame();

            MessageBox.Show("Embaralhando cartas....");

            LoadMyselfCardForm();
            btn_initialize_match.Hide();

            ChangeCardNumbers();

            btn_open_door.Show();
        }

        private void HideCards()
        {
            btn_attack.Hide();
            btn_help.Hide();
            btn_escape.Hide();            
            btn_open_door.Hide();
            btn_add.Hide();
            btn_delete.Hide();
        }

        private void ChangeCardNumbers()
        {
            var cardNumbersFirstPlayer = _match.Players.FirstOrDefault(x => x.Username == "Player1").Cards.Count();
            lbl_card_number_first_player.Text = cardNumbersFirstPlayer.ToString();

            var cardNumbersSecondPlayer = _match.Players.FirstOrDefault(x => x.Username == "Player2").Cards.Count();
            lbl_card_number_second_player.Text = cardNumbersFirstPlayer.ToString();

            var cardNumbersThirdPlayer = _match.Players.FirstOrDefault(x => x.Username == "Player3").Cards.Count();
            lbl_card_number_third_player.Text = cardNumbersThirdPlayer.ToString();

            var cardNumbersMyselfPlayer = _match.Players.FirstOrDefault(x => x.Username == "Myself").Cards.Count();
            lbl_card_number_myself.Text = cardNumbersMyselfPlayer.ToString();
        }

        private void LoadMyselfCardForm()
        {
            var myself = _match.Players.FirstOrDefault(p => p.Username == "Myself");

            LoadCards(myself.Cards);
        }

        private void LoadCards(List<Card> cards)
        {
            int startLocationX = 226, startLocationY = 204;

            foreach (var card in cards)
            {
                var button = CreateCardButton
                (
                    card.Name,
                    card.Description,
                    card.Type,
                    startLocationX,
                    startLocationY
                );

                button.Click += (sender, e) => Button_Click(sender, e, card);

                this.Controls.Add(button);

                startLocationX += 81;

                if ((startLocationX - 226) / 77 >= 4)
                {
                    startLocationX = 226;
                    startLocationY += 130;
                }
            }
        }

        private Button CreateCardButton(string cardName, string cardDescription, string cardType, int locationX, int locationY)
        {
            var button = new Button
            {
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

        private Label CreateTitleCard(string cardType)
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

        private Label CreateDescriptionCard(string cardDescription)
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

        private void Button_Click(object sender, EventArgs e, Card card)
        {
            DialogResult result = MessageBox.Show
            (
                $"Você deseja escolher a carta: {card.Name} ?",
                "Sim",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                if (card.Type == "Classe")
                {
                    lbl_class_myself.Text = card.Name.ToUpper();
                }
            }
        }

        private void btn_open_door_Click(object sender, EventArgs e)
        {
            var chosenCard = _match.Deck.ChooseCard();

            var button = CreateCardButton(chosenCard.Name, chosenCard.Description, chosenCard.Type, 596, 160);
            this.Controls.Add(button);

            btn_open_door.Hide();
            if (chosenCard.Type == "Monstro")
            {
                btn_attack.Show();
                btn_help.Show();
                btn_escape.Show();
            }
            else
            {
                btn_add.Show();
                btn_delete.Show();
            }
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_monster_Click(object sender, EventArgs e)
        {

        }

        private void btn_curse_MouseEnter(object sender, EventArgs e)
        {
            PlayMouseEnter();
        }

        private void btn_monster_MouseEnter(object sender, EventArgs e)
        {
            PlayMouseEnter();
        }

        private void btn_treasure_MouseEnter(object sender, EventArgs e)
        {
            PlayMouseEnter();
        }

        private void btn_class_MouseEnter(object sender, EventArgs e)
        {
            PlayMouseEnter();
        }

        private void PlayMouseEnter()
        {
            // TOOD: Colocar o caminho dentro da aplicação
            SoundPlayer clickSound = new SoundPlayer("C:/Users/imaud/Music/click_sound.wav");
            clickSound.Play();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }
    }
}
