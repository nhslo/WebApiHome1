using Microsoft.AspNetCore.Mvc;
using WebApiHome1.Models;

namespace WebApiHome1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> Students = new()
    {
        new Student { Id = 1, Name = "Ayan", Age = 20 },
        new Student { Id = 2, Name = "Dana", Age = 21 }
    };

    [HttpGet]
    public ActionResult<List<Student>> GetStudents() => Ok(Students);

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetStudent(int id)
    {
        var student = Students.FirstOrDefault(item => item.Id == id);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> AddStudent(Student student)
    {
        student.Id = Students.Count == 0 ? 1 : Students.Max(item => item.Id) + 1;
        Students.Add(student);
        return Ok(student);
    }
}
