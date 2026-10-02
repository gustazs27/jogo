using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace jogo
{
    public class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Escolha seu personagem";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(900, 600);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(255, 220, 234);

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
                Size = new Size(220, 260),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(120, 130),
                Image = Image.FromFile(caminhoBlossom)
            };

            var imgBubbles = new PictureBox
            {
                Size = new Size(220, 260),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(520, 130),
                Image = Image.FromFile(caminhoBubbles)
            };

            imgBlossom.Click += (s, e) => MessageBox.Show("Você escolheu: Blossom", "Personagem");
            imgBubbles.Click += (s, e) => MessageBox.Show("Você escolheu: Bubbles", "Personagem");

            var lblBlossom = new Label
            {
                Text = "Blossom",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 20, 45),
                AutoSize = true,
                Location = new Point(190, 420)
            };

            var lblBubbles = new Label
            {
                Text = "Bubbles",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 20, 45),
                AutoSize = true,
                Location = new Point(590, 420)
            };

            var btnVoltar = new Button
            {
                Text = "VOLTAR",
                Size = new Size(150, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(360, 500)
            };

            btnVoltar.Click += (s, e) =>
            {
                var telaInicio = new Form1();
                telaInicio.Show();
                this.Close();
            };

            this.Controls.Add(titulo);
            this.Controls.Add(imgBlossom);
            this.Controls.Add(imgBubbles);
            this.Controls.Add(lblBlossom);
            this.Controls.Add(lblBubbles);
            this.Controls.Add(btnVoltar);
        }
    }

    public static class CharacterFactory
    {
        public static void CriarBlossom(string caminho)
        {
            using var bmp = new Bitmap(300, 350);
            using var g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            // cabelo roxo
            g.FillEllipse(new SolidBrush(Color.Purple), 70, 40, 170, 120);

            // corpo rosa
            g.FillEllipse(new SolidBrush(Color.Pink), 80, 120, 140, 150);

            // rosto
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 95, 70, 110, 100);

            // olhos
            g.FillEllipse(new SolidBrush(Color.White), 120, 95, 15, 15);
            g.FillEllipse(new SolidBrush(Color.White), 170, 95, 15, 15);
            g.FillEllipse(new SolidBrush(Color.Black), 124, 99, 7, 7);
            g.FillEllipse(new SolidBrush(Color.Black), 174, 99, 7, 7);

            // boca
            g.DrawArc(new Pen(Color.Black, 2), new Rectangle(120, 120, 60, 25), 180, 180);

            // braços
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 110, 160, 25, 70);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 165, 160, 25, 70);

            // pernas
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 115, 250, 35, 60);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 150, 250, 35, 60);

            bmp.Save(caminho, ImageFormat.Png);
        }

        public static void CriarBubbles(string caminho)
        {
            using var bmp = new Bitmap(300, 350);
            using var g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            // cabelo azul
            g.FillEllipse(new SolidBrush(Color.Blue), 70, 40, 170, 120);

            // corpo amarelo
            g.FillEllipse(new SolidBrush(Color.Yellow), 80, 120, 140, 150);

            // rosto
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 95, 70, 110, 100);

            // olhos
            g.FillEllipse(new SolidBrush(Color.White), 120, 95, 15, 15);
            g.FillEllipse(new SolidBrush(Color.White), 170, 95, 15, 15);
            g.FillEllipse(new SolidBrush(Color.Black), 124, 99, 7, 7);
            g.FillEllipse(new SolidBrush(Color.Black), 174, 99, 7, 7);

            // boca
            g.DrawArc(new Pen(Color.Black, 2), new Rectangle(120, 120, 60, 25), 180, 180);

            // braços
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 110, 160, 25, 70);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 165, 160, 25, 70);

            // pernas
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 115, 250, 35, 60);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 245, 220, 170)), 150, 250, 35, 60);

            bmp.Save(caminho, ImageFormat.Png);
        }
    }
}