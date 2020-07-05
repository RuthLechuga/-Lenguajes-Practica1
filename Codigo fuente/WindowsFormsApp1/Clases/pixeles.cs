using System;
using System.Drawing;

namespace WindowsFormsApp1.Clases
{
    class pixeles
    {
        int posicionx;
        int posiciony;
        Color color;

        public pixeles(int posicionx, int posiciony, Color color)
        {
            this.Posicionx = posicionx;
            this.Posiciony = posiciony;
            this.Color = color;
        }

        public int Posicionx { get => posicionx; set => posicionx = value; }
        public int Posiciony { get => posiciony; set => posiciony = value; }
        public Color Color { get => color; set => color = value; }
    }
}
