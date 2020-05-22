using System.Web.Mvc;
using ReadersBLL;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReadersLogic _readersLogic = new ReadersLogic();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(string login)
        {
            TempData["login"] = login;
            var readers = _readersLogic.GetAll();
            if (readers.Exists(r => r.LibraryCardReader.Equals(int.Parse(login))) || login == "admin")
            {
                return RedirectToAction("AllBooks", "Book");
            }

            return RedirectToAction("Index");

        }
        
        [HttpPost]
        public ActionResult AdminAuthorization(string password)
        {
            if (password != "admin") return RedirectToAction("Index");
            TempData["login"] = "admin";
            return RedirectToAction("AllBooks", "Book");

        }
    }
}