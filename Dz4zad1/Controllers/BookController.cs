using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Dz4zad1.Models;

namespace Dz4zad1.Controllers
{
    public class BookController : Controller
    {
        Singelton singelton=Singelton.Instens;
        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            Show_RadioAndCeck();
            return View();
        }

        private void Show_RadioAndCeck()
        {
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> ceckBox = new List<SelectListItem>();
            if (singelton.GetPublishers.Count != 0)
            {
                foreach (var VARIABLE in singelton.GetPublishers)
                {
                    radio.Add(new SelectListItem{Text = $"{VARIABLE.Name}",Value = $"{VARIABLE.Id}"});
                }
            }

            if (singelton.GetAuthors.ToList().Count != 0)
            {
                foreach (var VARIABLE in singelton.GetAuthors)
                {
                    ceckBox.Add(new SelectListItem {Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}"});
                }
            }

            ViewBag.Radio = radio;
            ViewBag.Check = ceckBox;
        }

        [HttpPost]
        public ActionResult Index(ModelBook model)
        {
            if (ModelState.IsValid)
            {
                Book book=new Book(model.Name,model.PublishDate,model.PageCount,model.ISBN);
                    foreach (string VARIABLE in model.SelectedCeck)
                    {
                        Author Find_Author = singelton.GetAuthors.Back_Author(Convert.ToInt32(VARIABLE));
                        book.Add_BookAutor(Find_Author);
                    }
                
                Publisher pub = singelton.GetPublishers.Find(Publisher => Publisher.Id == Convert.ToInt32(model.RadioCeck));
                book.Add_BookPublicher(pub);
                singelton.Add_Book(book);
                ViewBag.Book = singelton.GetBooks;
                return RedirectToAction("Show_Table");
            }
            else
            {
                Show_RadioAndCeck();
                return View();
            }
            
        }

        public ActionResult Show_Table()
        {
            ViewBag.Book = singelton.GetBooks;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book Find_Book = singelton.GetBooks.Find(Book => Book.Id == id);
            EditShow_Radio_Check(Find_Book);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ModelBook model, int id)
        {
            if (ModelState.IsValid)
            {
                Book Find_book = singelton.GetBooks.Find(Book => Book.Id == id);
                Find_book.Raname_Book(model.Name,model.PublishDate,model.PageCount,model.ISBN);
                Publisher Find_publich =
                    singelton.GetPublishers.Find(Publisher => Publisher.Id == Convert.ToInt32(model.RadioCeck));
                Find_book.publisher = Find_publich;
                Find_book.Clear_Author();
                foreach (string VARIABLE in model.SelectedCeck)
                {
                    Author Find_Author = singelton.GetAuthors.Back_Author(Convert.ToInt32(VARIABLE));
                    Find_book.Add_BookAutor(Find_Author);
                }

                return RedirectToAction("Show_Table");
            }
            else
            {
                Book Find_Book = singelton.GetBooks.Find(Book => Book.Id == id);
                EditShow_Radio_Check(Find_Book);
                return View();
            }
        }

        private void EditShow_Radio_Check(Book findBook)
        {
            ViewBag.Book = findBook;
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> check = new List<SelectListItem>();
            if (findBook!=null)
            { 
                foreach (Publisher VARIABLE in singelton.GetPublishers)
                {
                    if (findBook.publisher!=null)
                    {
                        if (findBook.publisher.Id == VARIABLE.Id)
                        {
                            radio.Add(new SelectListItem{Text = $"{VARIABLE.Name}",Value = $"{VARIABLE.Id}",Selected = true});
                        }
                        else
                        {
                            radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                        }
                    }
                    else
                    {
                        radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                    }
                }

                int i = 0;
                foreach (Author VARIABLE in singelton.GetAuthors)
                {
                    i = 0;
                    foreach (Author VAR in findBook.Get_BookAuthor)
                    {
                        if (VARIABLE.Id == VAR.Id)
                        {
                            check.Add(new SelectListItem
                            {
                                Text = $"{VARIABLE.Name}",
                                Value = $"{VARIABLE.Id}",
                                Selected = true
                            });
                            i++;
                        }
                    }

                    if (i == 0)
                    {
                        check.Add(
                            new SelectListItem {Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false});

                    }
                }
            }

            ViewBag.Radio = radio;
            ViewBag.Check = check;
        }

        public ActionResult Delete(int id)
        {
            var Find_Book = singelton.GetBooks.Find(Book => Book.Id == id);
            singelton.GetBooks.Remove(Find_Book);
            ViewBag.Book = singelton.GetBooks;
            return View("Show_Table");
        }
    }
     
}