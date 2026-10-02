using System;
using System.Drawing;
using System.Windows.Forms;

namespace jogo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Jogo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(900, 600);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 228, 235);

            var titulo = new Label
            {
                Text = "JOGO DE (A DEFINIR)",
                Font = new Font("Impact", 36, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(150, 60)
            };

            var botaoJogar = new Button
            {
                Text = "JOGAR",
                Size = new Size(260, 80),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.FromArgb(250, 245, 248),
                ForeColor = Color.FromArgb(30, 30, 50),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(320, 250)
            };

            botaoJogar.FlatAppearance.BorderColor = Color.Gray;
            botaoJogar.FlatAppearance.BorderSize = 2;

            botaoJogar.Click += (s, e) =>
            {
                var telaPersonagens = new Form2();
                telaPersonagens.Show();
                this.Hide();
            };

            this.Controls.Add(titulo);
            this.Controls.Add(botaoJogar);
        }
    }
}