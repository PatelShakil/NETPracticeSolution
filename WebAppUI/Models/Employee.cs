using System.ComponentModel.DataAnnotations;

namespace WebAppUI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int? DeptId { get; set; }
        public Gender Gender { get; set; }
        public Department? Department { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female,

        [Display(Name = "Other")]
        Others
    }
}
