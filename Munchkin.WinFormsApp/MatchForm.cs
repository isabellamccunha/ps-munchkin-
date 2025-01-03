using System.Media;

namespace Munchkin.WinFormsApp
{
    public partial class MatchForm : Form
    {
        public MatchForm()
        {
            InitializeComponent();
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {
            btn_attack.Hide();
            btn_help.Hide();
            btn_escape.Hide();
            img_monster_card.Hide();
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
    }
}
