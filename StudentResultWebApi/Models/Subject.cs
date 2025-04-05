using System.ComponentModel.DataAnnotations.Schema;

namespace StudentResultWebApi.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester? Semester { get; set; }
    }
}
