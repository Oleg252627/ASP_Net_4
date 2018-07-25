using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz4zad1.Models
{
    public class Singelton
    {
        public static Singelton _instens;
        public static Singelton Instens => _instens ?? (_instens = new Singelton());

        public Singelton() { }
        private List<Book> Books = new List<Book>();
        private List<Publisher> Publishers = new List<Publisher>();
        private IEnumerable<Author> Authors = new List<Author>();


        public List<Book> GetBooks => Books;
        public List<Publisher> GetPublishers => Publishers;
        public IEnumerable<Author> GetAuthors
        {
            get => Authors;
            set => Authors = value;
        }

        public void Add_Book(Book book)
        {
            book.Id = (Books.LastOrDefault()?.Id ?? 0) + 1;
            Books.Add(book);
        }

        public void Add_Publishers(Publisher publisher)
        {
            publisher.Id = (Publishers.LastOrDefault()?.Id ?? 0) + 1;
            Publishers.Add(publisher);
        }

        public void Add_Author(Author author)
        {
            author.Id = (Authors.LastOrDefault()?.Id ?? 0) + 1;
            Authors = Authors.Add(author);
        } 
    }
}