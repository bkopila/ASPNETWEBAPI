using Microsoft.AspNetCore.Mvc;

namespace StudentAPI;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    // Data
    private static readonly List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "Ram", Price = 1200, Course = "BCA", age = 20 },
        new Student { Id = 2, Name = "Sita", Price = 1500, Course = "BIM", age = 21 },
        new Student { Id = 3, Name = "Hari", Price = 1300, Course = "BSc CSIT", age = 22 },
        new Student { Id = 4, Name = "Gita", Price = 1400, Course = "BIT", age = 20 },
        new Student { Id = 5, Name = "Shyam", Price = 1600, Course = "BCA", age = 23 }
    };

    // GET ALL
    [HttpGet]
    [Route("getall")]
    public ActionResult<List<Student>> Get()
    {
        return Ok(students);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound("Student not found with ID: " + id);
        }

        return Ok(student);
    }

    // ADD STUDENT
    [HttpPost]
    public ActionResult<Student> Post(Student student)
    {
        student.Id = students.Max(s => s.Id) + 1;
        students.Add(student);

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    // UPDATE STUDENT
    [HttpPut("{id}")]
    public ActionResult Put(int id, Student student)
    {
        var existingStudent = students.FirstOrDefault(s => s.Id == id);

        if (existingStudent == null)
        {
            return NotFound();
        }

        students.Remove(existingStudent);
        student.Id = id;
        students.Add(student);

        return Ok(student);
    }

    // DELETE STUDENT
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        students.Remove(student);

        return NoContent();
    }
}