using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;
using WindowsFormsApp1.Formas;

namespace WindowsFormsApp1
{
    public partial class Principal : Form
    {
        //Componentes
        //TabPage[] Pestañas;
        List<TabPage> Pestañas;
        List<RichTextBox> cuadrosTexto;
        //RichTextBox[] cuadrosTexto;
        List<Token> tokens;
        List<Errores> errores;
        List<String> erroresAnalisis;
        Valla valla;
        analisisLexico analizadorLexico;

        //Variables
        int seleccion;
        String texto;
        Boolean banderaAnalisis;

        public Principal()
        {
            InitializeComponent();

            //Inicialización componentes
            Pestañas = new List<TabPage>();
            cuadrosTexto = new List<RichTextBox>();
            valla = new Valla();
            analizadorLexico = new analisisLexico();

            //Inicialización de variables
            seleccion = 0;
            banderaAnalisis = false;

            crearPestaña();
            numeroLabel.Font = cuadrosTexto[seleccion].Font;
        }

        private void analizarLéxicamente_Click(object sender, EventArgs e)
        {
            String temporal = "";
            texto = cuadrosTexto.ElementAt(seleccion).Text; 

            analisisLexico analizadorLexico = new analisisLexico();

            tokens = analizadorLexico.realizarAnalisis(texto);
            errores = analizadorLexico.obtenerErrores();
            richTextBox1.Text = "Análisis Realizado de forma éxitosa" + "\n";

            if (errores.Count == 0)
            {
                erroresAnalisis = analizadorLexico.verificarEstructura(tokens);
                
                if(erroresAnalisis.Count > 0)
                {
                    foreach (String elemento in erroresAnalisis)
                        temporal += elemento + "\n";
                } else
                {
                    temporal = "No se encontraron errores, ¡puede construir su valla!";
                }

            } else
            {
                richTextBox1.Text = richTextBox1.Text + "Hay errores léxicos, ingresar a:" +
                    "'Compilar>Archivos de Salida>Archivo de Errores' para verlos. ";
            }
            richTextBox1.Text = richTextBox1.Text + temporal;
            banderaAnalisis = true;
        }

        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog cuadroDialogo = new SaveFileDialog();
            cuadroDialogo.Title = "Seleccionar ubicación para guardar archivo";
            cuadroDialogo.Filter = "Documentos de texto(*.vp502) | *.vp502";

            texto = cuadrosTexto.ElementAt(seleccion).Text;

            if(cuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter escritor = new StreamWriter(cuadroDialogo.FileName);
                    escritor.Write(texto);
                    Pestañas.ElementAt(seleccion).Text = Path.GetFileName(cuadroDialogo.FileName);
                    escritor.Close();

                    MessageBox.Show("Archivo guardado Satisfactoriamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar guardar el archivo" + ex.Message);
                }
            } else
            {
                MessageBox.Show("Error al intentar encontrar la dirección");
            }
        }

        private void nuevaPestaña_Click(object sender, EventArgs e)
        {
            crearPestaña();
            numeroLinea();
        }

        private void cargarArchivo_Click(object sender, EventArgs e)
        {
              OpenFileDialog cuadroDialogo = new OpenFileDialog();
              cuadroDialogo.Title = "Seleccionar archivo";
              cuadroDialogo.Filter = "Documentos de texto (*.vp502)|*.vp502";

              if ((cuadroDialogo.ShowDialog()) == DialogResult.OK)
              {
                  try
                  {
                    StreamReader lector = new StreamReader(cuadroDialogo.FileName);
                    texto = lector.ReadToEnd();
                    cuadrosTexto.ElementAt(seleccion).Text = texto;
                    Pestañas.ElementAt(seleccion).Text = Path.GetFileName(cuadroDialogo.FileName);
                    lector.Close();

                    MessageBox.Show("Archivo abierto Satisfactoriamente");
                    numeroLinea();

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("¡Error! Ha habido un problema al intentar abrir el archivo" + ex.Message);
                  }
              }
                else
              {
                MessageBox.Show("Error al intentar encontrar la dirección");
              }
        }

        public void crearPestaña()
        {
            //Creación de nuevas pestañas
            Pestañas.Add(new TabPage());
            cuadrosTexto.Add(new RichTextBox());

            //Crear pestaña del tabControl
            Pestañas.Last().Controls.Add(cuadrosTexto.Last());
            Pestañas.Last().Location = new Point(4, 22);
            Pestañas.Last().Name = Pestañas.Count.ToString();
            Pestañas.Last().Size = new Size(537, 463);
            Pestañas.Last().TabIndex = Pestañas.Count - 1;
            Pestañas.Last().Text = "Pestaña#" + Pestañas.Count.ToString();

            //Evento de cambio de pestaña
            tabControl1.SelectedIndexChanged += new EventHandler(cambio_pestaña);

            //Añadir pestaña al TabControl
            tabControl1.Controls.Add(Pestañas.Last());

            //Crear cuadros de texto
            cuadrosTexto.Last().Location = new Point(0, 0);
            cuadrosTexto.Last().Name = cuadrosTexto.ToString();
            cuadrosTexto.Last().Size = new Size(516,467);
            cuadrosTexto.Last().TabIndex = cuadrosTexto.Count - 1;
            cuadrosTexto.Last().Text = "";
            cuadrosTexto.Last().VScroll += Scroll;
            cuadrosTexto.Last().PreviewKeyDown += Principal_PreviewKeyDown;
            cuadrosTexto.Last().TextChanged += Principal_TextChanged;
        }

        private void Principal_TextChanged(object sender, EventArgs e)
        {
            banderaAnalisis = false; 
        }

        private void Principal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                numeroLinea();
        }

        private void cambio_pestaña(object sender, EventArgs e)
        {
            TabControl menu = (TabControl)sender;
            seleccion = menu.SelectedIndex;
            texto = cuadrosTexto.ElementAt(seleccion).Text;
            numeroLinea();
            banderaAnalisis = false; 
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void archivoDeTokens_Click(object sender, EventArgs e)
        {
            if (banderaAnalisis)
            {
                TablaSimbolos salida = new TablaSimbolos(tokens);
                salida.Show();
            }
            else MessageBox.Show("No se ha realizado el análisis léxico");
        }

        private void archivoDeErrores_Click(object sender, EventArgs e)
        {
            if (banderaAnalisis)
            {
                TablaErrores salida = new TablaErrores(errores);
                salida.Show();
            }
            else MessageBox.Show("No se ha realizado el análisis léxico");
        }
        
        /*Ya realizado el análisis léxico y verificada la estructura, en base a como están distribuidos los tokens
          se establecen las propiedades para construir la valla*/
        private void generarValla_Click(object sender, EventArgs e)
        {
            if (!banderaAnalisis || errores.Count != 0 || erroresAnalisis.Count != 0)
            {
                MessageBox.Show("Se deben solucionar primero los errores del código fuente para generar su valla \n" +
                                "Verifique en 'Compilar>Archivos de Salida>Archivo de Errores' y la terminal, o bien" +
                                "no se ha realizado el análisis");
            }
            else
            {
                valla = new Valla();
                valla.Pixeles.Clear();
                Boolean fondo = false;
                Boolean pixel = false;
                String elemento = "";
                int posicionx=1; int posiciony=1; String color=""; 


                for (int i = 0; i < tokens.Count - 1; i++)
                {
                    elemento = tokens.ElementAt(i).Lexema;
                    if (elemento == "fondo")
                        fondo = !fondo;
                    if (elemento == "pixel")
                    {
                        if (!pixel)
                        {
                            pixel = !pixel;
                        }
                        else
                        {
                            valla.Pixeles.Add(crearPixel(posicionx,posiciony,color));
                            posicionx = 1; posiciony = 1; color = "";
                            pixel = !pixel;
                        }
                    }

                    if (elemento == "empresa")
                    {
                        valla.Empresa = tokens.ElementAt(i + 2).Lexema;
                        i += 7;
                    }
                    else if (elemento == "horizontal")
                    {
                        valla.Tamaño_horizontal = Int32.Parse(tokens.ElementAt(i + 2).Lexema);
                        i += 7;
                    }
                    else if (elemento == "vertical")
                    {
                        valla.Tamaño_vertical = Int32.Parse(tokens.ElementAt(i + 2).Lexema);
                        i += 7;
                    }
                    else if (elemento == "color" && fondo)
                    {
                        valla.Color_fondo = establecerColor(tokens.ElementAt(i + 2).Lexema);
                        i += 7;
                    }
                    else if (elemento == "posicionx")
                    {
                        posicionx = Int32.Parse(tokens.ElementAt(i + 2).Lexema);
                        i += 7;
                    }
                    else if (elemento == "posiciony")
                    {
                        posiciony = Int32.Parse(tokens.ElementAt(i + 2).Lexema);
                        i += 7;
                    }
                    else if(elemento == "color" && pixel)
                    {
                        color = tokens.ElementAt(i + 2).Lexema;
                        i += 7;
                    }

                }
                visualizarValla estiloValla = new visualizarValla(valla);
                estiloValla.Show();
            }
        }

        private pixeles crearPixel(int posicionx, int posiciony, String color)
        {
            return new pixeles(posicionx, posiciony, establecerColor(color));
        }

        private Color establecerColor(String color)
        {
            if (color == "azul")
                return Color.Blue;
            else if (color == "rojo")
                return Color.Red;
            else if (color == "amarillo")
                return Color.Yellow;
            else if (color == "verde")
                return Color.Green;
            else 
                return Color.Black;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Curso: Lenguajes Formales y de Programación\n"+
                            "Sección: A-\n"+
                            "Elaborado: Ruth Nohemy Ardón Lechuga\n"+
                            "Carnet: 201602975");
        }

        private void numeroLinea()
        {
            Point pos = new Point(0, 0);
            int firstIndex = cuadrosTexto[seleccion].GetCharIndexFromPosition(pos);
            int firstLine = cuadrosTexto[seleccion].GetLineFromCharIndex(firstIndex);

            pos.X = cuadrosTexto[seleccion].Width-20;
            pos.Y = cuadrosTexto[seleccion].Height-20;
            int lastIndex = cuadrosTexto[seleccion].GetCharIndexFromPosition(pos);
            int lastLine = cuadrosTexto[seleccion].GetLineFromCharIndex(lastIndex);

           pos = cuadrosTexto[seleccion].GetPositionFromCharIndex(lastIndex);

            numeroLabel.Text = "";
            for (int i = firstLine; i <= lastLine+1; i++)
            {
                numeroLabel.Text += i + 1 + "\n";
            }

        }

        private void Scroll(object sender, EventArgs e)
        {
            numeroLinea();
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Manual de Usuario.pdf");

            Process.Start(pdfPath);
        }

        private void manualTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Manual técnico.pdf");

            Process.Start(pdfPath);
        }
    }
}