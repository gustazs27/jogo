using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace jogo
{
    public class Player : PictureBox
    {
        public int Velocidade { get; set; } = 10;
        public List<Bullet> Balas { get; } = new List<Bullet>();

        public Player(string imagem)
        {
            Size = new Size(100, 120);
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;

            if (File.Exists(imagem))
                Image = Image.FromFile(imagem);
        }

        public void Mover(int x, int y)
        {
            Left += x * Velocidade;
            Top += y * Velocidade;
        }

        public Bullet Atirar()
        {
            int x = Left + Width - 5;
            int y = Top + (Height / 2) - 10;
            var bala = new Bullet(x, y);
            Balas.Add(bala);
            return bala;
        }
    }
}
