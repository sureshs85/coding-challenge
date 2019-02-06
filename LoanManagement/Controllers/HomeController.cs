using System.Web.Mvc;

namespace LoanManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Loan Management";
            return View();
        }
    }
}
