using ByBiz.Models;
using Microsoft.EntityFrameworkCore;

namespace ByBiz.ViewModels.Home
{
    public class HomeVM
    {

        public List<Portfolio> Portfolios { get; set; }

        public List<Service> Services { get; set; }
        public List<Team> Teams { get; set; }
        public List<Slider> Sliders { get; set; }


    }

}
