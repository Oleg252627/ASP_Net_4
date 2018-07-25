using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz4zad1.Models;

namespace Dz4zad1.Controllers
{
    public class HomeController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: Publisher
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelPublisher model)
        {
            if (ModelState.IsValid)
            {
                Publisher publisher=new Publisher(model.Name);
                singelton.Add_Publishers(publisher);
                ViewBag.Publis_Table = singelton.GetPublishers;
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Publis_Table = singelton.GetPublishers;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           ViewBag.Publisher= singelton.GetPublishers.Find(Publisher => Publisher.Id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ModelPublisher model,int id)
        {
            if (ModelState.IsValid)
            {
                var Find_Publisher = singelton.GetPublishers.Find(Publisher => Publisher.Id == id);
                Find_Publisher.Rename_publisher(model.Name);
                Checking_P(Find_Publisher);
                return RedirectToAction("Show_Table");
            }
            else
            {
                ViewBag.Publisher = singelton.GetPublishers.Find(Publisher => Publisher.Id == id);
                return View();
            }
        }

        private void Checking_P(Publisher item)
        {
            foreach (Book VARIABLE in singelton.GetBooks)
            {
                if (VARIABLE.publisher.Id == item.Id)
                {
                    VARIABLE.publisher.Name = item.Name;
                }
            }
        }

        public ActionResult Delete(int id)
        {
            var Fin_publisher = singelton.GetPublishers.Find(Publisher => Publisher.Id == id);
            singelton.GetPublishers.Remove(Fin_publisher);
            Delete_P(Fin_publisher);
            ViewBag.Publis_Table = singelton.GetPublishers;
            return View("Show_Table");
        }

        private void Delete_P(Publisher finPublisher)
        {
            foreach (Book VARIABLE in singelton.GetBooks)
            {
                if (VARIABLE.publisher.Id == finPublisher.Id)
                {
                    VARIABLE.publisher = null;
                }
            }
        }
    }
}