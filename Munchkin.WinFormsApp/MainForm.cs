using System.Media;

namespace Munchkin.WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PlaySound();
        }

        private void PlaySound()
        {
            // TOOD: Colocar o caminho dentro da aplicação
            SoundPlayer player = new SoundPlayer("C:/Users/imaud/Music/start_sound.wav");
            player.PlayLooping();
        }

        private void btn_bot_Click(object sender, EventArgs e)
        {
            this.Hide();

            // TOOD: Colocar o caminho dentro da aplicação
            SoundPlayer clickSound = new SoundPlayer("C:/Users/imaud/Music/click_sound.wav");
            clickSound.Play();

            MatchForm matchForm = new MatchForm();
            matchForm.ShowDialog();
        }
    }
}
