using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.Clases;

namespace WindowsFormsApp1
{
    class analisisLexico
    {
        String texto;
        List<Token> tokens;
        List<Errores> errores;
        List<String> tablaDeCadenas;
        List<Token> pilaPalabras;
        int fila;
        int columna;
        int estado;
        int contId;
        int contErrores;
        String auxLex;
        char c;
        
        public analisisLexico()
        {
            tablaDeCadenas = new List<String>();

            //Palabras reservadas
            tablaDeCadenas.Add("valla");
            tablaDeCadenas.Add("empresa");
            tablaDeCadenas.Add("fondo");
            tablaDeCadenas.Add("tamanio");
            tablaDeCadenas.Add("horizontal");
            tablaDeCadenas.Add("vertical");
            tablaDeCadenas.Add("color");
            tablaDeCadenas.Add("pixel");
            tablaDeCadenas.Add("posicionx");
            tablaDeCadenas.Add("posiciony");
            tablaDeCadenas.Add("azul");
            tablaDeCadenas.Add("rojo");
            tablaDeCadenas.Add("amarillo");
            tablaDeCadenas.Add("verde");

            //Inicialización variables
            fila = 1;
            columna = 1;
            estado = 0;
            auxLex = "";
            contId = 1;
            contErrores = 1;
            c = (char)00;
            tokens = new List<Token>();
            errores = new List<Errores>();
            pilaPalabras = new List<Token>();
        }

        public List<Token> realizarAnalisis(String text)
        {
            this.texto = text.ToLower();
            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(c))
                        {
                            auxLex += c;
                            estado = 1;
                            columna++;
                        }
                        else if (Char.IsDigit(c))
                        {
                            auxLex += c;
                            estado = 2;
                            columna++;
                        }
                        else if (c == '<')
                            agregarToken(c.ToString(), "Bracket Izquierdo", 1);
                        else if (c == '>')
                            agregarToken(c.ToString(), "Bracket Derecho", 3);
                        else if (c == '/')
                            agregarToken(c.ToString(), "Diagonal", 6);
                        else if (c == ' ' || c == (char)09)
                            columna++;
                        else if (c == (char)10)
                        {
                            fila++;
                            columna = 1;
                        }
                        else
                        {
                            if (esNombreEmpresa())
                            {
                                columna--;
                                auxLex += c;
                                columna++;
                            }
                            else
                            {
                                errores.Add(new Errores(contErrores, fila, columna, c.ToString(), "Desconocido"));
                                contErrores++;
                            }
                        }
                        break;
                    case 1:
                        if (Char.IsLetter(c))
                        {
                            auxLex += c;
                            columna++;
                        }
                        else
                        {
                            if (esNombreEmpresa())
                            {
                                estado = 0;
                                i--;
                            }
                            else
                            {
                                estado = 0;
                                columna--;
                                if (esReservada(auxLex))
                                    agregarToken(auxLex, "Palabra Reservada",2);
                                else
                                {
                                    agregarToken(auxLex, "Palabras desconocida", 7);
                                    contErrores++;  
                                }
                                i--;
                                auxLex = "";
                            }
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            auxLex += c;
                            columna++;
                        }
                        else
                        {
                            if (esNombreEmpresa())
                            {
                                columna--;
                                estado = 0;
                                i--;
                            }
                            else
                            {
                                estado = 0;
                                columna--;
                                agregarToken(auxLex, "Numero",4);
                                i--;
                                auxLex = "";
                            }
                        }
                        break;
                }

            }
            return (tokens);
        }

        public Boolean esReservada(String palabra)
        {
            Boolean bandera = false;
            foreach (String elemento in tablaDeCadenas)
            {
                if (palabra.Equals(elemento))
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        public void agregarToken(String lexema, String tipo, int id_tipo)
        {
            if (esNombreEmpresa())
            {
                tokens.Add(new Token(auxLex, fila-1, columna, contId, "Nombre Empresa",4));
                columna++;
                contId++;
                auxLex = "";
            }

            if (lexema == "azul" || lexema == "rojo" || lexema == "amarillo" || lexema == "verde")
            {
                tokens.Add(new Token(lexema, fila, columna, contId, "Color",5));
            } else
                tokens.Add(new Token(lexema, fila, columna, contId, tipo, id_tipo));

            columna++;
            contId++;
        }

        public Boolean esNombreEmpresa()
        {    
            if(tokens.Count > 2)
            {
                Token temporal;
                Token temporal2;
                Token temporal3;
                temporal = tokens.ElementAt(tokens.Count-1);
                temporal2 = tokens.ElementAt(tokens.Count-2);
                temporal3 = tokens.ElementAt(tokens.Count-3);

                if ((temporal3.Lexema == "<") && (temporal2.Lexema == "empresa") && (temporal.Lexema == ">"))
                    return true;
                else
                    return false;
            } else
                return false;
    
        }

        public List<Errores> obtenerErrores()
        {
            return errores;
        }

        public List<String> verificarEstructura(List<Token> token)
        {
            List<String> erroresEstructura = new List<String>();
            int estadoAuxiliar = 0;
            Boolean banderaAuxiliar = true;
            /*
             * <  = 1
             * palabra_reservada = 2
             * > = 3
             * numero = 4
             * color = 5
             * / = 6
             * nombre_empresa = 4
             * palabra_desconocida = 7
             */

            foreach(Token elemento in token)
            {
                if(banderaAuxiliar && elemento.Id != 1)
                {
                    switch (elemento.Id_token)
                    {
                        case 1: estadoAuxiliar = 0; break;
                        case 2: estadoAuxiliar = 1; break;
                        case 3: estadoAuxiliar = 2; break;
                        case 4: estadoAuxiliar = 3; break;
                        case 5: estadoAuxiliar = 3; break;
                        case 6: estadoAuxiliar = 5; break;
                    }
                }
                banderaAuxiliar = true;

                switch (estadoAuxiliar)
                {
                    case 0:
                        if (elemento.Id_token == 1)
                        {
                            estadoAuxiliar = 1;
                            banderaAuxiliar = false;
                        }
                        else erroresEstructura.Add("¡Error! Se esperaba un '<' en posicion:"
                            +elemento.Fila.ToString()+","+elemento.Columna.ToString());
                        break;
                    case 1:
                        if (elemento.Id_token == 2)
                        {
                            estadoAuxiliar = 2;
                            pilaPalabras.Add(elemento);
                            banderaAuxiliar = false;
                        } else if (elemento.Id_token == 6)
                        {
                            estadoAuxiliar = 6;
                            banderaAuxiliar = false; 
                        } else erroresEstructura.Add("¡Error! Se esperaba una 'palabra reservada' en posicion:"
                         + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                    case 2:
                        if(elemento.Id_token == 3)
                        {
                            estadoAuxiliar = 3;
                            banderaAuxiliar = false;
                        } else erroresEstructura.Add("¡Error! Se esperaba un '>' en posicion:"
                            + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                    case 3:
                        if(elemento.Id_token == 4 || elemento.Id_token == 5)
                        {
                            estadoAuxiliar = 4;
                            banderaAuxiliar = false;
                        } else if(elemento.Id_token == 1)
                        {
                            estadoAuxiliar = 1;
                        } else erroresEstructura.Add("¡Error! Se esperaba una propiedad o un '<' en posicion:"
                            + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                    case 4:
                        if (elemento.Id_token == 1)
                        {
                            estadoAuxiliar = 5;
                            banderaAuxiliar = false;
                        }
                        else erroresEstructura.Add("¡Error! Se esperaba un '<' en posicion:"
                            + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                    case 5:
                        if (elemento.Id_token == 6)
                        {
                            estadoAuxiliar = 6;
                            banderaAuxiliar = false;
                        }
                        else
                        {
                            erroresEstructura.Add("¡Error! Se esperaba un '/' en posicion:"
                           + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                            pilaPalabras.RemoveAt(pilaPalabras.Count - 1);
                        }
                        break;
                    case 6:
                        if (elemento.Id_token == 2)
                        {
                            estadoAuxiliar = 7;
                            if (pilaPalabras.Count > 0 && !(elemento.Lexema == pilaPalabras.Last().Lexema))
                                erroresEstructura.Add("¡Error de estructura! Se esperaba una </"+
                                pilaPalabras.Last().Lexema +" > en posicion:"
                                + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                    
                            pilaPalabras.RemoveAt(pilaPalabras.Count - 1);
                            banderaAuxiliar = false;
                        }
                        else erroresEstructura.Add("¡Error! Se esperaba una 'palabra reservada' en posicion:"
                          + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                    case 7:
                        if (elemento.Id_token == 3)
                        {
                            estadoAuxiliar = 0;
                            banderaAuxiliar = false;
                        }
                        else erroresEstructura.Add("¡Error! Se esperaba un '>' en posicion:"
                          + elemento.Fila.ToString() + "," + elemento.Columna.ToString());
                        break;
                }
            }

            return erroresEstructura;
        }
        
    }
}
