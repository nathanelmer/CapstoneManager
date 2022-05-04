using System.ComponentModel.DataAnnotations;

namespace CapstoneManager.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
