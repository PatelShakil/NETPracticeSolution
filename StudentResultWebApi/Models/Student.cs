namespace StudentResultWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public List<Semester>? semesters { get; set; }
        public List<Marks>? Marks { get; set; }
    }
}
