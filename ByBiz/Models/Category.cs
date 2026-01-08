using ByBiz.Models.Base;

namespace ByBiz.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
