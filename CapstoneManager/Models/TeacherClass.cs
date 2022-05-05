using System.ComponentModel.DataAnnotations;

namespace CapstoneManager.Models
{
    public class TeacherClass
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        [Required]
        public int ClassId { get; set; }

    }
}
