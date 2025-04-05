using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Storage;

namespace EmpDeptCalApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department? Department { get; set; }
    }
}
