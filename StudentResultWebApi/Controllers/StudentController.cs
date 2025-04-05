using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StudentResultWebApi.Data;
using StudentResultWebApi.Models;

namespace StudentResultWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(AppDbContext context) : ControllerBase
    {
        [HttpGet("find/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            return Ok(std);
            /*
            var std = await context.Students
                .Include(ls=>ls.semesters)
                .FirstOrDefaultAsync(s => s.Id == id);
            var temp = std.semesters;
            std.semesters = null;
            return Ok(new { Sem=temp?.Select(s => new { s.Id, s.Name }),std });*/
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([Bind("RollNo", "Name")] Student std)
        {
            var student = new Student()
            {
                RollNo = std.RollNo,
                Name = std.Name
            };

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpGet("std-sem/{StdId}/{SemId}")]
        public async Task<IActionResult> AddStudentToSemester(int StdId, int SemId)
        {
            var std = await context.Students.FindAsync(StdId);
            var sub = await context.Semesters.FindAsync(SemId);

            if (std == null || sub == null)
            {
                return NotFound();
            }

            var stdSem = new StudentSemester
            {
                StudentId = std.Id,
                SemesterId = sub.Id
            };

            await context.StudentSemesters.AddAsync(stdSem);
            await context.SaveChangesAsync();
            return Ok("Enrolled");
        }

        [HttpGet("get-semesters/{course}")]
        public async Task<IActionResult> GetSemesters(string course)
        {
            var semesters = await context.Semesters.Where(s => s.Course == course).ToListAsync();
            return Ok(semesters);
        }

        [HttpGet("get-subjects/{SemId}")]
        public async Task<IActionResult> GetSubjects(int SemId)
        {
            var subs = await context.Subjects.Where(s => s.SemesterId == SemId).ToListAsync();
            return Ok(subs);
        }

        [HttpGet("add-marks/{StdId}/{SubId}/{marks}/{totalMarks}")]
        public async Task<IActionResult> AddMarks(int StdId, int SubId, double marks, double totalMarks)
        {
            var std = await context.Students.FindAsync(StdId);
            var sub = await context.Subjects.FindAsync(SubId);
            if (std == null || sub == null)
            {
                return NotFound();
            }

            var marksObj = new Marks
            {
                StudentId = std.Id,
                SubjectId = sub.Id,
                MarksObtained = marks,
                TotalMarks = totalMarks
            };

            await context.Marks.AddAsync(marksObj);
            await context.SaveChangesAsync();
            return Ok("Marks Added");
        }

            [HttpGet("get-result/{StdId}/{SemId}")]
        public async Task<IActionResult> GetResult(int StdId,int SemId)
        {
            var stdSem = await context.Students
                .Where(s => s.Id == StdId)
                .Include(s=>s.Marks)
                .ThenInclude(m => m.Subject)
                .FirstAsync();

            var sem = await context.Semesters.FindAsync(SemId);

            stdSem.Marks?.RemoveAll(m => m.Subject.SemesterId != SemId);


            if (stdSem == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Name = stdSem.Name,
                RollNo = stdSem.RollNo,
                Sem = sem?.Name,
                Marks = stdSem.Marks.Select(m =>new
                {
                    m.Subject.Name,
                    m.MarksObtained,
                    m.TotalMarks
                })
            });
        }
    }
}
