using ByBiz.Models.Base;

namespace ByBiz.Models
{
    public class Service:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string IconName { get; set; }
    }
}
