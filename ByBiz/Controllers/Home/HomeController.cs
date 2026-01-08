using ByBiz.DAL;
using ByBiz.Models;
using ByBiz.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByBiz.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            List<Service> services = _context.Services.ToList();
            List<Team> teams = _context.Teams.Include(p => p.Position).ToList();
            List<Portfolio> portfolios= _context.Portfolios.Include(p => p.category).ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Portfolios = portfolios,
                Services = services,
                Teams = teams
            };
            return View(homeVM);
        }
    }
}
