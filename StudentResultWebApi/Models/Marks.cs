using System.ComponentModel.DataAnnotations.Schema;

namespace StudentResultWebApi.Models
{
    public class Marks
    {
        public double MarksObtained { get; set; }
        public double TotalMarks { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
    }
}
