using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Dz4zad1.Models;

namespace Dz4zad1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public Publisher publisher { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        public Book(string name, string date, string pageCount, string isbn)
        {
            Authors=new List<Author>();
            Name = name;
            PublishDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }

        public void Raname_Book(string name, string date, string pageCount, string isbn)
        {
            Name = name;
            PublishDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }

        public void Add_BookAutor(Author author)
        {
            Authors=Authors.Add(author);
        }

        public void Add_BookPublicher(Publisher publisher)
        {
            this.publisher = publisher;
        }

        public IEnumerable<Author> Get_BookAuthor => Authors;

        public void Clear_Author()
        {
            Authors = Authors.Clear();
        }

        public void Checking_Author()
        {
            Authors = Singelton.Instens.GetAuthors.Checking(Authors);
        }
    }
}