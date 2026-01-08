using ByBiz.Models.Base;

namespace ByBiz.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
