using System;
using System.Windows.Forms;

namespace CatalogoLibros
{
    public partial class Form1 : Form
    {
        private BinarySearchTree catalog = new BinarySearchTree();
        
        private Button btnAddBook;
        private Button btnSearchBook;
        private Button btnRemoveBook;
        private TextBox txtISBN;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtSearchISBN;
        private TextBox txtRemoveISBN;
        private ListBox listBoxCatalog;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.btnRemoveBook = new System.Windows.Forms.Button();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtSearchISBN = new System.Windows.Forms.TextBox();
            this.txtRemoveISBN = new System.Windows.Forms.TextBox();
            this.listBoxCatalog = new System.Windows.Forms.ListBox();
            
            // Configuración de propiedades y eventos para cada control
            this.btnAddBook.Text = "Agregar Libro";
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);

            this.btnSearchBook.Text = "Buscar Libro";
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);

            this.btnRemoveBook.Text = "Eliminar Libro";
            this.btnRemoveBook.Click += new System.EventHandler(this.btnRemoveBook_Click);

            this.txtISBN.Location = new System.Drawing.Point(10, 10);
            this.txtISBN.Size = new System.Drawing.Size(150, 20);
            // ... configuración similar para otros TextBox

            this.listBoxCatalog.Location = new System.Drawing.Point(10, 120);
            this.listBoxCatalog.Size = new System.Drawing.Size(300, 200);
            
            // Agregar los controles al formulario
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnSearchBook);
            this.Controls.Add(this.btnRemoveBook);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtSearchISBN);
            this.Controls.Add(this.txtRemoveISBN);
            this.Controls.Add(this.listBoxCatalog);

            // Otros detalles de diseño o configuración de propiedades visuales
            // ...
        }

        // Implementación de eventos de los botones
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Lógica de agregado de libros
            string isbn = txtISBN.Text;
            string title = txtTitle.Text;
            string author = txtAuthor.Text;

            Book newBook = new Book(isbn, title, author);
            catalog.Insert(newBook);

            UpdateCatalogDisplay();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            // Lógica de búsqueda de libros
            string isbnToSearch = txtSearchISBN.Text;

            Book foundBook = SearchBookByISBN(isbnToSearch);

            if (foundBook != null)
            {
                MessageBox.Show($"Libro encontrado:\nISBN: {foundBook.ISBN}\nTítulo: {foundBook.Title}\nAutor: {foundBook.Author}");
            }
            else
            {
                MessageBox.Show("Libro no encontrado.");
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            // Lógica de eliminación de libros
            string isbnToRemove = txtRemoveISBN.Text;

            RemoveBookByISBN(isbnToRemove);

            UpdateCatalogDisplay();
        }

        // Otros métodos necesarios
        private void UpdateCatalogDisplay()
        {
            listBoxCatalog.Items.Clear();
            InOrderTraversal(catalog.GetRoot());
        }

        private Book SearchBookByISBN(string isbn)
        {
            return SearchBookByISBNRecursive(catalog.GetRoot(), isbn);
        }

        private Book SearchBookByISBNRecursive(BinarySearchTree.Node root, string isbn)
        {
            // Base case: If the root is null, return null
            if (root == null)
            {
                return null;
            }

            // Compare the isbn with the ISBN of the current node
            int comparisonResult = string.Compare(isbn, root.Book.ISBN);

            // If the isbn matches the current node's ISBN, return the book
            if (comparisonResult == 0)
            {
                return root.Book;
            }
            // If the isbn is less than the current node's ISBN, search in the left subtree
            else if (comparisonResult < 0)
            {
                return SearchBookByISBNRecursive(root.Left, isbn);
            }
            // If the isbn is greater than the current node's ISBN, search in the right subtree
            else
            {
                return SearchBookByISBNRecursive(root.Right, isbn);
            }
        }
        private void RemoveBookByISBN(string isbn)
        {
            // Lógica de eliminación por ISBN
            // ...
        }

        // Resto de tu código, como MinValue, InOrderTraversal, etc.
        // ...

    }
}
