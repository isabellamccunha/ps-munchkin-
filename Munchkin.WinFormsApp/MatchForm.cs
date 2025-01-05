using System;
using System.Media;
using Munchkin.ApplicationService;
using Munchkin.Domain.Entities;
using Munchkin.Domain.Shared.Abstractions;
using Munchkin.WinFormsApp.Utils;

namespace Munchkin.WinFormsApp
{
    public partial class MatchForm : Form
    {
        private GameApplicationService _gameApplicationService;
        private Match _match;

        private Card _chosenCard;
        private Backpack _backpack;

        private Button _choosenButton;

        public MatchForm()
        {
            InitializeComponent();

            HideCards();

            _gameApplicationService = new GameApplicationService();
            _backpack = new Backpack();
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
            btn_backpack.Hide();
            btn_dice.Hide();
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
                var button = ButtonCreator.CreateCardButton
                (
                    "btn_myself_cards",
                    card,
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
            _chosenCard = _match.Deck.ChooseCard();

            _choosenButton = ButtonCreator.CreateCardButton
            (
                "btn_choosen_card",
                _chosenCard,
                596,
                160
            );

            this.Controls.Add(_choosenButton);

            btn_open_door.Hide();
            if (_chosenCard.Type == "Monstro")
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            _backpack.AddNewCard(_chosenCard);

            var totalCards = int.Parse(lbl_card_number_myself.Text) + 1;
            lbl_card_number_myself.Text = totalCards.ToString();

            btn_add.Hide();
            btn_delete.Hide();

            _choosenButton.Hide();

            btn_open_door.Show();
            btn_backpack.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            _choosenButton.Hide();
            btn_add.Hide();
            btn_delete.Hide();
            btn_open_door.Show();
        }

        private void btn_backpack_Click(object sender, EventArgs e)
        {
            var backpack = new BackpackForm(_backpack);
            backpack.ShowDialog();
        }

        private void btn_escape_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rolando dado...");
            btn_dice.Show();

            Random random = new Random();

            var number = random.Next(1, 7);

            
            if (number == 6 || number == 5) 
            {
                MessageBox.Show($"Número sorteado: {number} :: Você venceu o combate!!");
            }
            else
            {
                MessageBox.Show($"Número sorteado: {number} :: Você perdeu o combate!!");
            }

            lbl_dice.Hide();
            btn_dice.Hide();
            HideMonsterButtons();

            btn_open_door.Show();
            _choosenButton.Hide();
        }

        private void btn_help_Click(object sender, EventArgs e)
        {

        }

        private void btn_attack_Click(object sender, EventArgs e)
        {

        }

        private void HideMonsterButtons()
        {
            btn_escape.Hide();
            btn_help.Hide();
            btn_attack.Hide();
        }
    }
}
