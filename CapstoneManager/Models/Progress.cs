using System.ComponentModel.DataAnnotations;

namespace CapstoneManager.Models
{
    public class Progress
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
