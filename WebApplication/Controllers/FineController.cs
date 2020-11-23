using Entities;
using FineBLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class FineController : Controller
    {
        private readonly FineLogic _fineLogic = new FineLogic();
        public ActionResult GetFine(int bookIssuanceId)
        {
            TempData["BookIssuanceId"] = bookIssuanceId;
            List<Fine> fineList = _fineLogic.GetAll().FindAll(f => f.BookIssuanceID == bookIssuanceId);
            return View(fineList);
        }

        public ActionResult AddFine(int id, int amount, string article)
        {
            _ = _fineLogic.Create(new Fine(id, (int)TempData.Peek("BookIssuanceID"), Convert.ToByte(amount)));
            return RedirectToAction("GetFine", new { bookIssuanceId = TempData.Peek("BookIssuanceID") });
        }

        public ActionResult DeleteFine(int id)
        {
            _fineLogic.Delete(id);
            return RedirectToAction("GetFine", new { bookIssuanceId = TempData["BookIssuanceID"] });
        }
    }
}