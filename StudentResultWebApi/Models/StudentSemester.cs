using System.ComponentModel.DataAnnotations.Schema;

namespace StudentResultWebApi.Models
{
    public class StudentSemester
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
