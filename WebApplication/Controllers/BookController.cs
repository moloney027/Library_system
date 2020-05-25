using AuthorBLL;
using AuthorsAndBooksBLL;
using BookBLL;
using Entities;
using GenreBLL;
using ListGenreBLL;
using PublishingHouseBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookLogic _bookLogic = new BookLogic();
        private readonly PublishingHouseLogic _publishingHouseLogic = new PublishingHouseLogic();
        private readonly AuthorLogic _authorLogic = new AuthorLogic();
        private readonly AuthorsAndBooksLogic _authorsAndBooksLogic = new AuthorsAndBooksLogic();
        private readonly ListGenreLogic _listGenreLogic = new ListGenreLogic();
        private readonly GenreLogic _genreLogic = new GenreLogic();

        public ActionResult AllBooks()
        {
            List<Book> books = _bookLogic.GetAll();
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
            Book book = _bookLogic.GetById(bookId);
            List<AuthorsAndBooks> authorId = _authorsAndBooksLogic.GetAll().FindAll(ab => ab.BookID == bookId);
            List<Author> authors = _authorLogic.GetAll().FindAll(a => authorId.Exists(ab => ab.AuthorID == a.AuthorID));
            List<ListGenre> listGenres = _listGenreLogic.GetAll().FindAll(lg => lg.BookID == bookId);
            List<Genre> genres = _genreLogic.GetAll().FindAll(g => listGenres.Exists(lg => lg.GenreID == g.GenreID));
            ViewData["ph"] = _publishingHouseLogic.GetAll().Find(p => p.PublishingHouseID == book.PublishingHouseID).PublishingHouseTitle;
            ViewData["author"] = string.Join(", ", authors.Select(a => a.AuthorFullName).ToArray());
            ViewData["genre"] = string.Join(", ", genres.Select(g => g.GenreTitle).ToArray()); ;
            return View(book);
        }
    }
}