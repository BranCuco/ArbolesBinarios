using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaUno.Clases
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }

        public Libro(string ISBN, string Titulo)
        {
            this.ISBN = ISBN.ToUpper();
            this.Titulo = Titulo;
        }
        public override string ToString()
        {
            return $"Titulo: {Titulo}   ISBN:{ISBN.ToUpper()}";
        }
    }

}
