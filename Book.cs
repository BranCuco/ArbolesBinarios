using System;

namespace CatalogoLibros
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        // Otros atributos del libro

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
        }

        // Puedes añadir métodos adicionales para el libro según tus necesidades
        
    }
}
