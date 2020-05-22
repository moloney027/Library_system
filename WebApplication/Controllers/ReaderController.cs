using System.Web.Mvc;
using Entities;
using ReadersBLL;

namespace WebApplication.Controllers
{
    public class ReaderController : Controller
    {
        private readonly ReadersLogic _readersLogic = new ReadersLogic();

        public ActionResult AllReaders()
        {
            var readers = _readersLogic.GetAll();
            return View(readers);
        }

        public ActionResult GetReader(int libraryCard)
        {
            var reader = _readersLogic.GetById(libraryCard);
            return View(reader);
        }

        public ActionResult DeleteReader(int libraryCard)
        {
            _readersLogic.Delete(libraryCard);
            return RedirectToAction("AllReaders");
        }

        public ActionResult AddReader(int libraryCard, string fullName, int age, string address)
        {
            _readersLogic.Create(new Readers(libraryCard, fullName, age, address));
            return RedirectToAction("AllReaders");
        }
    }
}