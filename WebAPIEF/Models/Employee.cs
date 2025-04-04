using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEF.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department? Department { get; set; }
    }
}
