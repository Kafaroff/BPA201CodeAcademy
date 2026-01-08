using Microsoft.AspNetCore.Mvc;

namespace ByBiz.Areas.Admin.Controllers.Create
{
    [Area("Admin")]
    public class CreateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
