using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace jogo
{
    public class Form2 : Form
    {
        private readonly Button btnBlossom;
        private readonly Button btnBubbles;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Escolha seu personagem";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = new Size(900, 600);
            MaximizeBox = false;
            BackColor = Color.FromArgb(255, 220, 234);

            var titulo = new Label
            {
                Text = "ESCOLHA SEU PERSONAGEM",
                Font = new Font("Impact", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 20, 45),
                AutoSize = true,
                Location = new Point(180, 25)
            };

            string pasta = AppContext.BaseDirectory;
            string caminhoBlossom = Path.Combine(pasta, "blossom.png");
            string caminhoBubbles = Path.Combine(pasta, "bubbles.png");

            if (!File.Exists(caminhoBlossom))
                CharacterFactory.CriarBlossom(caminhoBlossom);
            if (!File.Exists(caminhoBubbles))
                CharacterFactory.CriarBubbles(caminhoBubbles);

            var imgBlossom = new PictureBox
            {
                Size = new Size(220, 260), SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle, Location = new Point(120, 130),
                Image = Image.FromFile(caminhoBlossom)
            };
            var imgBubbles = new PictureBox
            {
                Size = new Size(220, 260), SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle, Location = new Point(520, 130),
                Image = Image.FromFile(caminhoBubbles)
            };

            btnBlossom = new Button
            {
                Text = "JOGAR COM BLOSSOM", Size = new Size(220, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(120, 420)
            };
            btnBubbles = new Button
            {
                Text = "JOGAR COM BUBBLES", Size = new Size(220, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(520, 420)
            };

            btnBlossom.Click += (s, e) => AbrirJogo("blossom.png");
            btnBubbles.Click += (s, e) => AbrirJogo("bubbles.png");

            var btnVoltar = new Button
            {
                Text = "VOLTAR", Size = new Size(150, 50),
                Font = new Font("Arial", 12, FontStyle.Bold), Location = new Point(360, 500)
            };
            btnVoltar.Click += (s, e) =>
            {
                var telaInicio = new Form1();
                telaInicio.Show();
                Close();
            };

            Controls.Add(titulo);
            Controls.Add(imgBlossom);
            Controls.Add(imgBubbles);
            Controls.Add(btnBlossom);
            Controls.Add(btnBubbles);
            Controls.Add(btnVoltar);
        }

        private void AbrirJogo(string personagem)
        {
            var jogo = new Game(personagem);
            jogo.FormClosed += (s, e) => Application.Exit();
            jogo.Show();
            Hide();
        }
    }

    public static class CharacterFactory
    {
        public static void CriarBlossom(string caminho)
        {
            using var bmp = new Bitmap(300, 350);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Purple, 70, 40, 170, 120);
            g.FillEllipse(Brushes.Pink, 80, 120, 140, 150);
            g.FillEllipse(new SolidBrush(Color.FromArgb(245, 220, 170)), 95, 70, 110, 100);
            g.FillEllipse(Brushes.White, 120, 95, 15, 15);
            g.FillEllipse(Brushes.White, 170, 95, 15, 15);
            g.FillEllipse(Brushes.Black, 124, 99, 7, 7);
            g.FillEllipse(Brushes.Black, 174, 99, 7, 7);
            g.DrawArc(new Pen(Color.Black, 2), new Rectangle(120, 120, 60, 25), 180, 180);
            bmp.Save(caminho, ImageFormat.Png);
        }

        public static void CriarBubbles(string caminho)
        {
            using var bmp = new Bitmap(300, 350);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Blue, 70, 40, 170, 120);
            g.FillEllipse(Brushes.Yellow, 80, 120, 140, 150);
            g.FillEllipse(new SolidBrush(Color.FromArgb(245, 220, 170)), 95, 70, 110, 100);
            g.FillEllipse(Brushes.White, 120, 95, 15, 15);
            g.FillEllipse(Brushes.White, 170, 95, 15, 15);
            g.FillEllipse(Brushes.Black, 124, 99, 7, 7);
            g.FillEllipse(Brushes.Black, 174, 99, 7, 7);
            g.DrawArc(new Pen(Color.Black, 2), new Rectangle(120, 120, 60, 25), 180, 180);
            bmp.Save(caminho, ImageFormat.Png);
        }
    }
}
