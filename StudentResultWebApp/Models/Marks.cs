namespace StudentResultWebApp.Models
{
    public class Marks
    {
        public double MarksObtained { get; set; }
        public double TotalMarks { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
