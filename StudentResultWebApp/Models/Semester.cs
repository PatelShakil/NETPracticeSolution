namespace StudentResultWebApp.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Course { get; set; }
        public virtual List<Student>? Students { get; set; }
        public virtual List<Subject>? Subjects { get; set; }
    }
}
