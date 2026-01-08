using ByBiz.Models.Base;

namespace ByBiz.Models
{
    public class Portfolio:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }
        public int CategoryId { get; set; }
       public  string ImageUrl { get; set; }

    }
}
