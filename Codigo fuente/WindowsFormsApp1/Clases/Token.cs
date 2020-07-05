using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Token
    {
        String lexema;
        int fila;
        int columna;
        int id;
        String tipo_token;
        int id_token;

        public Token(String lexema, int fila, int columna, int id, String tipo_token, int id_token)
        {
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
            this.id = id;
            this.tipo_token = tipo_token;
            this.Id_token = id_token; 
        }

        public string Lexema { get => lexema; set => lexema = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public int Id { get => id; set => id = value; }
        public string Tipo_token { get => tipo_token; set => tipo_token = value; }
        public int Id_token { get => id_token; set => id_token = value; }
    }
}
