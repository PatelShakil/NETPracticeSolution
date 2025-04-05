
namespace StudentResultWebApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SemesterId { get; set; }
        public virtual Semester? Semester { get; set; }
    }
}
