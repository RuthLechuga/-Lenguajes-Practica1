using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1.Clases
{
    public class Valla
    {
        String empresa; 
        int tamaño_horizontal;
        int tamaño_vertical;
        Color color_fondo;
        List<pixeles> pixeles;


        public Valla()
        {
            empresa = "";
            tamaño_horizontal = 10;
            tamaño_vertical = 10;
            color_fondo = Color.Black;
            pixeles = new List<pixeles>();
        }

        public string Empresa { get => empresa; set => empresa = value; }
        public int Tamaño_horizontal { get => tamaño_horizontal; set => tamaño_horizontal = value; }
        public int Tamaño_vertical { get => tamaño_vertical; set => tamaño_vertical = value; }
        public Color Color_fondo { get => color_fondo; set => color_fondo = value; }
        internal List<pixeles> Pixeles { get => pixeles; set => pixeles = value; }
    }
}
