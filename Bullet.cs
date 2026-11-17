using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace jogo
{
    public class Bullet : PictureBox
    {
        public int Velocidade { get; set; } = 10;

        public Bullet(int x, int y)
        {
            Size = new Size(25, 20);
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;
            Location = new Point(x, y);

            string caminho = Path.Combine(AppContext.BaseDirectory, "assets", "bullet.png");

            if (File.Exists(caminho))
                Image = Image.FromFile(caminho);
            else
                BackColor = Color.DeepSkyBlue;
        }

        public void Mover()
        {
            Left += Velocidade;
        }

        public bool SaiuDaTela(Form formulario)
        {
            return Left > formulario.ClientSize.Width;
        }
    }
}
