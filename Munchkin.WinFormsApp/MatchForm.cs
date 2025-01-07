using Munchkin.ApplicationService;
using Munchkin.Domain.Entities;
using Munchkin.Domain.Shared.Abstractions;
using Munchkin.Domain.Utils;
using Munchkin.WinFormsApp.Utils;

namespace Munchkin.WinFormsApp
{
    public partial class MatchForm : Form
    {
        private readonly GameApplicationService _gameApplicationService;
        private Match _match;

        private Card _chosenCard;
        private Backpack _backpack;
        private Button _chosenButton;

        public MatchForm()
        {
            InitializeComponent();
            _gameApplicationService = new GameApplicationService();
            _backpack = new Backpack();

            HideButtons();
        }

        private void btn_initialize_match_Click(object sender, EventArgs e)
        {
            _match = _gameApplicationService.InitializeGame();

            MessageBox.Show("Cartas embaralhadas e jogadores prontos!");

            LoadMyselfCards();
            UpdateCardNumbers();
            ConfigureGameStart();
        }

        private void ConfigureGameStart()
        {
            btn_initialize_match.Hide();
            btn_open_door.Show();
            DisableBackButton();
        }

        private void DisableBackButton()
        {
            btn_back.Enabled = false;
            btn_back.BackColor = Color.Gray;
        }

        private void EnableBackButton()
        {
            btn_back.Enabled = true;
            btn_back.BackColor = Color.AliceBlue;
        }

        private void HideButtons()
        {
            foreach (var button in new[] { btn_attack, btn_help, btn_escape, btn_open_door, btn_add, btn_delete, btn_backpack, btn_dice })
            {
                button.Hide();
            }
        }

        private void UpdateCardNumbers()
        {
            foreach (var player in _match.Players)
            {
                UpdatePlayerCardCount(player);
            }
        }

        private void UpdatePlayerCardCount(Player player)
        {
            var cardCount = player.Cards.Count;

            switch (player.Username)
            {
                case "Player1":
                    lbl_card_number_first_player.Text = cardCount.ToString();
                    break;
                case "Player2":
                    lbl_card_number_second_player.Text = cardCount.ToString();
                    break;
                case "Player3":
                    lbl_card_number_third_player.Text = cardCount.ToString();
                    break;
                case "Myself":
                    lbl_card_number_myself.Text = cardCount.ToString();
                    break;
            }
        }

        private void LoadMyselfCards()
        {
            var myself = _match.Players.FirstOrDefault(p => p.Username == "Myself");
            if (myself == null) return;

            LoadCardsToUI(myself.Cards);
        }

        private void LoadCardsToUI(IEnumerable<Card> cards)
        {
            int startLocationX = 226, startLocationY = 204;

            foreach (var card in cards)
            {
                var button = ButtonCreator.CreateCardButton("btn_myself_card", card, startLocationX, startLocationY);
                button.Click += (_, _) => HandleCardSelection(card);
                Controls.Add(button);

                startLocationX += 81;
                if ((startLocationX - 226) / 77 >= 4)
                {
                    startLocationX = 226;
                    startLocationY += 130;
                }
            }
        }

        private void HandleCardSelection(Card card)
        {
            if (MessageBox.Show($"Você deseja escolher a carta: {card.Name}?", "Confirmação", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            if (card.Type == "Classe")
                lbl_class_myself.Text = card.Name.ToUpper();

            _chosenCard = card;
        }

        private void btn_open_door_Click(object sender, EventArgs e)
        {
            _chosenCard = _match.Deck.ChooseCard();
            DisplayChosenCard(_chosenCard);
            btn_open_door.Hide();
            HandleChosenCard(_chosenCard);
        }

        private void DisplayChosenCard(Card card)
        {
            _chosenButton = ButtonCreator.CreateCardButton("btn_chosen_card", card, 596, 160);
            Controls.Add(_chosenButton);
        }

        private void HandleChosenCard(Card card)
        {
            switch (card.Type)
            {
                case "Monstro":
                    ShowMonsterButtons();
                    break;
                case "Tesouro":
                    AddTreasureToPlayerInventory(card);
                    break;
                case "Maldição":
                    ApplyCurseToPlayer(card);
                    break;
                default:
                    ShowGenericCardButtons();
                    break;
            }
        }

        private void AddTreasureToPlayerInventory(Card card)
        {
            MessageBox.Show($"Você encontrou um tesouro: {card.Name}!");
            _backpack.AddNewCard(card);
            UpdateCardNumbers();
            ResetAfterCardAction();
        }

        private void ApplyCurseToPlayer(Card card)
        {
            MessageBox.Show($"Você foi amaldiçoado: {card.Name} - {card.Description}");
            // Aplicar efeitos específicos da maldição aqui
            ResetAfterCardAction();
        }

        private void ShowMonsterButtons()
        {
            btn_attack.Show();
            btn_help.Show();
            btn_escape.Show();
        }

        private void ShowGenericCardButtons()
        {
            btn_add.Show();
            btn_delete.Show();
        }

        private void ResetAfterCardAction()
        {
            _chosenButton?.Hide();
            btn_open_door.Show();
        }

        private void btn_escape_Click(object sender, EventArgs e)
        {
            var diceRoll = RandomNumberGenerator.GenerateNumberFrom1To10();
            HandleEscape(diceRoll);
        }

        private void HandleEscape(int diceRoll)
        {
            MessageBox.Show($"Você rolou o número {diceRoll}!");
            if (diceRoll >= 5)
            {
                MessageBox.Show("Você escapou com sucesso!");
            }
            else
            {
                MessageBox.Show("Você falhou em escapar!");
                // Aplicar penalidades
            }
            ResetAfterCardAction();
        }

        private void btn_attack_Click(object sender, EventArgs e)
        {
            if (_chosenCard == null || _chosenCard.Type != "Monstro")
            {
                MessageBox.Show("Selecione um monstro para atacar!");
                return;
            }

            HandleAttackOutcome();
        }

        private void HandleAttackOutcome()
        {
            var diceRoll = RandomNumberGenerator.GenerateNumberFrom1To100();
            if (_chosenCard.Power < diceRoll)
            {
                MessageBox.Show("Você derrotou o monstro!");
                // Atualizar nível e recompensas
            }
            else
            {
                MessageBox.Show("O monstro venceu!");
                // Aplicar penalidades
            }
            ResetAfterCardAction();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (_chosenCard == null)
            {
                MessageBox.Show("Nenhuma carta selecionada para guardar.");
                return;
            }

            _backpack.AddNewCard(_chosenCard);

            var totalCards = int.Parse(lbl_card_number_myself.Text) + 1;
            lbl_card_number_myself.Text = totalCards.ToString();

            MessageBox.Show($"Carta '{_chosenCard.Name}' adicionada à mochila!");

            btn_add.Hide();
            btn_delete.Hide();
            _chosenButton?.Hide();
            btn_open_door.Show();
            btn_backpack.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (_chosenCard == null)
            {
                MessageBox.Show("Nenhuma carta selecionada para descartar.");
                return;
            }

            MessageBox.Show($"Carta '{_chosenCard.Name}' descartada.");

            _chosenButton?.Hide();
            btn_add.Hide();
            btn_delete.Hide();
            btn_open_door.Show();
        }

        private void btn_backpack_Click(object sender, EventArgs e)
        {
            var backpackForm = new BackpackForm(_backpack);
            backpackForm.ShowDialog();
        }
    }
}
