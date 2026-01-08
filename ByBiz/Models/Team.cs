using ByBiz.Models.Base;

namespace ByBiz.Models
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
