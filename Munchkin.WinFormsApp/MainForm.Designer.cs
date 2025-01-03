namespace Munchkin.WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btn_bot = new Button();
            btn_amigos = new Button();
            SuspendLayout();
            // 
            // btn_bot
            // 
            btn_bot.BackColor = Color.SaddleBrown;
            btn_bot.Font = new Font("Berlin Sans FB", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_bot.ForeColor = SystemColors.ControlLightLight;
            btn_bot.Location = new Point(287, 290);
            btn_bot.Name = "btn_bot";
            btn_bot.Size = new Size(122, 40);
            btn_bot.TabIndex = 0;
            btn_bot.Text = "JOGUE vs BOT";
            btn_bot.UseVisualStyleBackColor = false;
            btn_bot.Click += btn_bot_Click;
            // 
            // btn_amigos
            // 
            btn_amigos.BackColor = Color.FromArgb(128, 64, 0);
            btn_amigos.Font = new Font("Berlin Sans FB", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_amigos.ForeColor = SystemColors.ControlLightLight;
            btn_amigos.Location = new Point(287, 336);
            btn_amigos.Name = "btn_amigos";
            btn_amigos.Size = new Size(122, 40);
            btn_amigos.TabIndex = 1;
            btn_amigos.Text = "JOGUE vs AMIGOS";
            btn_amigos.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(682, 388);
            Controls.Add(btn_amigos);
            Controls.Add(btn_bot);
            Cursor = Cursors.Hand;
            Name = "MainForm";
            Text = "start";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_start;
        private Button btn_bot;
        private Button btn_amigos;
    }
}
