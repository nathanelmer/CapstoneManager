using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CapstoneManager.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }

    }
}
