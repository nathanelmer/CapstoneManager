namespace CapstoneManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string ProposalTitle { get; set; }  
        public int ProgressId { get; set; }
        public string Note { get; set; }
        public Class Class { get; set; }
        public Progress Progress { get; set; }
    }
}
