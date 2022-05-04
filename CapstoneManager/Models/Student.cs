using System.ComponentModel.DataAnnotations;

namespace CapstoneManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string ProposalTitle { get; set; }
        [Required]
        public int ProgressId { get; set; }
        public string Note { get; set; }
        public Class Class { get; set; }
        public Progress Progress { get; set; }
    }
}
