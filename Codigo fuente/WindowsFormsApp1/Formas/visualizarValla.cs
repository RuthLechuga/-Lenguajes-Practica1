using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;

namespace WindowsFormsApp1.Formas
{
    public partial class visualizarValla : Form
    {
        Valla valla;

        public visualizarValla(Valla valla)
        {
            InitializeComponent();
            this.valla = valla;
        }

        private void visualizarValla_Paint(object sender, PaintEventArgs e)
        {
            this.Size = new Size(20*(valla.Tamaño_horizontal+1),20*(valla.Tamaño_vertical+2));

            Graphics dibujar;
            SolidBrush colorfondo = new SolidBrush(valla.Color_fondo);
            SolidBrush colorLetras; 

            dibujar = this.CreateGraphics();
            for (int i = 0; i < valla.Tamaño_horizontal; i++)
                for (int j = 0; j < valla.Tamaño_vertical; j++)
                {
                    dibujar.FillEllipse(colorfondo, i * 20, j * 20,20,20);
                }

            foreach(pixeles Pixel in valla.Pixeles)
            {
                colorLetras = new SolidBrush(Pixel.Color);
                dibujar.FillEllipse(colorLetras, (Pixel.Posicionx-1) * 20, (Pixel.Posiciony-1) * 20,
                   20, 20);

            }

            dibujar.Dispose();
        }
    }
}
