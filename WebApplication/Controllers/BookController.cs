using BookBLL;
using Entities;
using PublishingHouseBLL;
using System;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookLogic _bookLogic = new BookLogic();
        private readonly PublishingHouseLogic _publishingHouseLogic = new PublishingHouseLogic();

        public ActionResult AllBooks()
        {
            System.Collections.Generic.List<Book> books = _bookLogic.GetAll();
            ViewData["ph"] = _publishingHouseLogic.GetAll();
            return View(books);
        }

        public ActionResult AddBook()
        {
            string title = Request.Form["title"];
            int year = Convert.ToInt32(Request.Form["year"]);
            int ph = Convert.ToInt32(Request.Form["ph"]);
            string language = Request.Form["language"];
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