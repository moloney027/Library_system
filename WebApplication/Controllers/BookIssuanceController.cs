using BookBLL;
using BookCopyBLL;
using BookIssuanceBLL;
using Entities;
using ReadersBLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BookIssuanceController : Controller
    {
        private readonly BookIssuanceLogic _issuanceLogic = new BookIssuanceLogic();
        private readonly ReadersLogic _readersLogic = new ReadersLogic();
        private readonly BookCopyLogic _bookCopyLogic = new BookCopyLogic();
        private readonly BookLogic _bookLogic = new BookLogic();

        public ActionResult ReaderBookIssuance(int libraryCard)
        {
            TempData["FullName"] = _readersLogic.GetById(libraryCard).ReaderFullName;
            TempData["LibraryCard"] = libraryCard;
            List<BookCopyModel> bookCopyModels = new List<BookCopyModel>();
            List<BookCopy> bookCopies = _bookCopyLogic.GetAll();
            List<Book> books = _bookLogic.GetAll();
            foreach (BookCopy bc in bookCopies)
            {
                Book book = books.Find(b => b.BookID == bc.BookID);
                bookCopyModels.Add(new BookCopyModel(bc.BookCopyID, book.BookID, book.BookTitle));
            }
            TempData["BookCopy"] = bookCopyModels;

            TempData["BookIssuance"] = _issuanceLogic.GetAll().FindAll(bi => bi.LibraryCard == libraryCard);
            return RedirectToAction("GetBookIssuance");
        }

        public ActionResult AddBookIssuance(int id, DateTime dateOfIssue, DateTime dateOfCompletion, int bookCopyId)
        {
            Console.WriteLine(_issuanceLogic.Create(new BookIssuance(id, dateOfIssue, dateOfCompletion, (int)TempData.Peek("LibraryCard"), bookCopyId)));
            return RedirectToAction("ReaderBookIssuance", new { libraryCard = (int)TempData["LibraryCard"] });
        }

        public ActionResult DeleteBookIssuance(int libraryCard, int id)
        {
            Console.WriteLine(_issuanceLogic.Delete(id));
            return RedirectToAction("ReaderBookIssuance", new { libraryCard });
        }

        public ActionResult GetBookIssuance()
        {
            return View(TempData["BookIssuance"]);
        }
    }
}