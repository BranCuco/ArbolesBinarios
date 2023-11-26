using PracticaUno.Clases;
using System.Windows.Forms;

namespace PracticaUno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArbolBinario miArbol = new ArbolBinario(null);

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
               
                Libro miLibro = new Libro (textBox1.Text.Trim().ToLower(), textBox4.Text.Trim() );

                miArbol.Insertar(miLibro);
                listBox1.Items.Clear();
                miArbol.MostrarEnListBox(miArbol.nodoRaiz, listBox1);
                textBox1.Text="";
                textBox4.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                
                Libro libroEliminar = miArbol.Buscar(textBox2.Text.Trim().ToUpper());
                miArbol.Eliminar(libroEliminar);
                listBox1.Items.Clear();
                miArbol.MostrarEnListBox(miArbol.nodoRaiz, listBox1);
                textBox2.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
              
                Libro libroBuscar = miArbol.Buscar(textBox3.Text.Trim().ToUpper());
                
                if( libroBuscar != null )
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(libroBuscar);
                }  
                else
                    MessageBox.Show("El Libro no existe");

                textBox3.Text = "";
            }

        }
    }
}