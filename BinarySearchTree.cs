using System;

namespace CatalogoLibros
{
    public class BinarySearchTree
    {
        private class Node
        {
            public Book Book { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(Book book)
            {
                Book = book;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(Book book)
        {
            root = InsertRecursive(root, book);
        }

        private Node InsertRecursive(Node root, Book book)
        {
            if (root == null)
            {
                root = new Node(book);
                return root;
            }

            if (String.Compare(book.ISBN, root.Book.ISBN) < 0)
            {
                root.Left = InsertRecursive(root.Left, book);
            }
            else if (String.Compare(book.ISBN, root.Book.ISBN) > 0)
            {
                root.Right = InsertRecursive(root.Right, book);
            }

            return root;
        }

        // Aquí puedes implementar métodos para búsqueda, eliminación, y recorrido del árbol según tus necesidades
    }
}
