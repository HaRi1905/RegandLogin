using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegandLogin.Models;

namespace RegandLogin.Controllers
{
    public class ViewBookController : Controller
    {
        private practice_purposeEntities db = new practice_purposeEntities();

        // GET: ViewBook
        public ActionResult Index()
        {
            var books = db.Books;
            return View(books.ToList());
        }

        [HttpPost]
        public ActionResult Index(string BName,Book b)
        {
            
            var books = db.Books.ToList().Where(p => p.Book_Name.StartsWith(BName));
            return View(books);

        }


    }
}