using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticaUno.Clases
{
    public class Nodo
    {
        public Libro info;
        public Nodo Izquierdo;
        public Nodo Derecho;
        public Nodo NodoPadre;
        public int Altura;
        public int Nivel;


        private Nodo _arbol;

        public Nodo()
        {

        }

        public Nodo Arbol
        {
            get { return _arbol; }
            set { _arbol = value; }
        }

        public Nodo(Libro nuevaInfo, Nodo izquierdo, Nodo derecho,
            Nodo padre)
        {
            info = nuevaInfo;
            Izquierdo = izquierdo;
            Derecho = derecho;
            NodoPadre = padre;
            Altura = 0;
        }

        public Nodo Agregar(Libro libro, Nodo nodo, int nivel)
        {
            if (nodo == null)
            {
                nodo = new Nodo(libro, null, null, null);
                nodo.Nivel = nivel;
            }
            else if (string.Compare(libro.ISBN, nodo.info.ISBN) < 0)
            {
                nivel++;
                nodo.Izquierdo = Agregar(libro, nodo.Izquierdo, nivel);
            }
            else if (string.Compare(libro.ISBN, nodo.info.ISBN) > 0)
            {
                nivel++;
                nodo.Derecho = Agregar(libro, nodo.Derecho, nivel);
            }
            else
            {
                MessageBox.Show("El libro ya existe en el árbol", "Error de ingreso");
            }

            return nodo;
        }

   

        //Función para eliminar un nodo

        public void Eliminar(Libro libro, ref Nodo arbol)
        {
            if (arbol != null)
            {
                if (string.Compare(libro.ISBN, arbol.info.ISBN) < 0)
                {
                    Eliminar(libro, ref arbol.Izquierdo);
                }
                else if (string.Compare(libro.ISBN, arbol.info.ISBN) > 0)
                {
                    Eliminar(libro, ref arbol.Derecho);
                }
                else
                {
                    Nodo NodoEliminar = arbol;
                    if (NodoEliminar.Derecho == null)
                    {
                        arbol = NodoEliminar.Izquierdo;
                    }
                    else if (NodoEliminar.Izquierdo == null)
                    {
                        arbol = NodoEliminar.Derecho;
                    }
                    else
                    {

                        Nodo sucesor = ObtenerSucesor(NodoEliminar.Derecho);


                        NodoEliminar.info = sucesor.info;

                        Eliminar(sucesor.info, ref NodoEliminar.Derecho);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe");
            }
        }

        private Nodo ObtenerSucesor(Nodo nodo)
        {
            Nodo actual = nodo;

            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }

            return actual;
        }


        public Libro Buscar(string isbn)
        {
            if (info != null)
            {
                if (string.Compare(isbn, info.ISBN) < 0)
                {
                    if (Izquierdo != null)
                    {
                        return Izquierdo.Buscar(isbn);
                    }
                }
                else if (string.Compare(isbn, info.ISBN) > 0)
                {
                    if (Derecho != null)
                    {
                        return Derecho.Buscar(isbn);
                    }
                }
                else
                {
                    return info;
                }
            }
            return null;

        }
    }
}



