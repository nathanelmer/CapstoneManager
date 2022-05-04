using System.ComponentModel.DataAnnotations;

namespace CapstoneManager.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirebaseUserId { get; set; }
    }
}
