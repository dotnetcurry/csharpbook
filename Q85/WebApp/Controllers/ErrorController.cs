using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
    }
}