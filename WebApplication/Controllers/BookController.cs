using System;
using System.Web.Mvc;
using BookBLL;
using Entities;
using PublishingHouseBLL;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookLogic _bookLogic = new BookLogic();
        private readonly PublishingHouseLogic _publishingHouseLogic = new PublishingHouseLogic();

        public ActionResult AllBooks()
        {
            var books = _bookLogic.GetAll();
            ViewData["ph"] = _publishingHouseLogic.GetAll();
            return View(books);
        }

        public ActionResult AddBook()
        {
            var title = Request.Form["title"];
            var year = Convert.ToInt32(Request.Form["year"]);
            var ph = Convert.ToInt32(Request.Form["ph"]);
            var language = Request.Form["language"];
            _bookLogic.Create(new Book(title, year, ph, language));
            return RedirectToAction("AllBooks");
        }

        public ActionResult DeleteBook(int bookId)
        {
            _bookLogic.Delete(bookId);
            return RedirectToAction("AllBooks");
        }

        public ActionResult GetBook(int bookId)
        {
            return View(_bookLogic.GetById(bookId));
        }
    }
}