using System;
using System.Web.Mvc;
using BookIssuanceBLL;
using Entities;

namespace WebApplication.Controllers
{
    public class BookIssuanceController : Controller
    {
        private readonly BookIssuanceLogic _issuanceLogic = new BookIssuanceLogic();

        public ActionResult GetAll()
        {
            var bookIssuanceList = _issuanceLogic.GetAll();
            return View(bookIssuanceList);
        }

        public ActionResult AddBookIssuance(int id, DateTime dateOfIssue, DateTime dateOfCompletion, int libraryCard,
            int bookCopyId)
        {
            _issuanceLogic.Create(new BookIssuance(id, dateOfIssue, dateOfCompletion, libraryCard, bookCopyId));
            return RedirectToAction("GetAll");
        }

        public ActionResult DeleteBookIssuance(int id)
        {
            _issuanceLogic.Delete(id);
            return RedirectToAction("GetAll");
        }

        public ActionResult GetBookIssuance(int id)
        {
            var bookIssuance = _issuanceLogic.GetById(id);
            return View(bookIssuance);
        }
    }
}