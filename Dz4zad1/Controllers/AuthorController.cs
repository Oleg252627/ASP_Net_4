using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz4zad1.Models;

namespace Dz4zad1.Controllers
{
    public class AuthorController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: Author
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelAuthor model)
        {
            if (ModelState.IsValid)
            {
                Author author=new Author(model.Name,model.DateOfBirth,model.DateOfDeath);
                singelton.Add_Author(author);
                ViewBag.Author = singelton.GetAuthors;
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Show_Table()
        {
            ViewBag.Author = singelton.GetAuthors;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author Find_Author = singelton.GetAuthors.Back_Author(id);
            ViewBag.Author = Find_Author;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ModelAuthor model,int id)
        {
            if (ModelState.IsValid)
            {
                Author Find_Author = singelton.GetAuthors.Back_Author(id); ;
                Find_Author.Raname_Author(model.Name,model.DateOfBirth,model.DateOfDeath);
                ViewBag.Author = singelton.GetAuthors;
                Checking_A();
                return RedirectToAction("Show_Table");
            }
            else
            {
                Author Find_Author = singelton.GetAuthors.Back_Author(id);
                ViewBag.Author = Find_Author;
                return View();
            }
            
        }

        private void Checking_A()
        {
            foreach (Book VARIABLE in singelton.GetBooks)
            {
                VARIABLE.Checking_Author();
            }
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Author> Authors = singelton.GetAuthors.Delete(id);
            singelton.GetAuthors = Authors;
            ViewBag.Author = singelton.GetAuthors;
            Checking_A();
            return View("Show_Table");
        }
    }
}