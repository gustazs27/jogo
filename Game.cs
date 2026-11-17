using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace jogo
{
    public class Game : Form
    {
        private readonly Player jogador;
        private readonly Timer timer;

        public Game(string personagem)
        {
            Text = "Jogo - Meninas Super Poderosas";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = new Size(900, 600);
            MaximizeBox = false;
            DoubleBuffered = true;
            KeyPreview = true;
            BackColor = Color.FromArgb(245, 235, 242);

            string caminhoPersonagem = Path.Combine(AppContext.BaseDirectory, personagem);
            if (!File.Exists(caminhoPersonagem))
                caminhoPersonagem = Path.Combine(AppContext.BaseDirectory,
                    personagem.Contains("blossom", StringComparison.OrdinalIgnoreCase) ? "blossom.png" : "bubbles.png");

            jogador = new Player(caminhoPersonagem)
            {
                Location = new Point(100, 220)
            };

            Controls.Add(jogador);

            timer = new Timer
            {
                Enabled = true,
                Interval = 100
            };
            timer.Tick += Timer_Tick;

            KeyDown += Game_KeyDown;
        }

        private void Game_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Bullet bala = jogador.Atirar();
                Controls.Add(bala);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left)
                MoverJogador(-1, 0);
            else if (e.KeyCode == Keys.Right)
                MoverJogador(1, 0);
            else if (e.KeyCode == Keys.Up)
                MoverJogador(0, -1);
            else if (e.KeyCode == Keys.Down)
                MoverJogador(0, 1);
        }

        private void MoverJogador(int x, int y)
        {
            jogador.Mover(x, y);

            if (jogador.Left < 0)
                jogador.Left = 0;
            if (jogador.Right > ClientSize.Width)
                jogador.Left = ClientSize.Width - jogador.Width;
            if (jogador.Top < 0)
                jogador.Top = 0;
            if (jogador.Bottom > ClientSize.Height)
                jogador.Top = ClientSize.Height - jogador.Height;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (int i = jogador.Balas.Count - 1; i >= 0; i--)
            {
                Bullet bala = jogador.Balas[i];
                bala.Mover();

                if (bala.SaiuDaTela(this))
                {
                    Controls.Remove(bala);
                    jogador.Balas.RemoveAt(i);
                    bala.Dispose();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            base.OnFormClosed(e);
        }
    }
}
