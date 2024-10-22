using System.ComponentModel.DataAnnotations;

namespace Blogfelhasznalok.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string ? Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
