using Microsoft.AspNetCore.Mvc;

namespace ByBiz.Area.Admin.Controllers.Home
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
