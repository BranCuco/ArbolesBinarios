using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaUno.Clases
{
    public class ArbolBinario
    {
        public Nodo nodoRaiz;
        public Nodo nodoAux;

        public ArbolBinario()
        {
            nodoAux = new Nodo();
        }

        public ArbolBinario(Nodo nodoRaiz)
        {
            this.nodoRaiz = nodoRaiz;
        }
        public void Insertar(Libro libro)
        {
            if (nodoRaiz == null)
            {
                nodoRaiz = new Nodo(libro, null, null, null);
            }
            else
            {
                nodoRaiz.Agregar(libro, nodoRaiz, 0);
            }
        }

        public void Eliminar(Libro libro)
        {
            if (nodoRaiz != null)
            {
                nodoRaiz.Eliminar(libro, ref nodoRaiz);
            }
        }

        public Libro Buscar(string isbn)
        {
            if (nodoRaiz != null)
            {
                return nodoRaiz.Buscar(isbn);
            }
            return null;
        }

        public void MostrarEnListBox(Nodo nodo, ListBox listBox)
        {
            if (nodo != null)
            {
              
                
                MostrarEnListBox(nodo.Izquierdo, listBox);

               
                listBox.Items.Add(nodo.info);

        
                MostrarEnListBox(nodo.Derecho, listBox);
            }
        }

    }
}

