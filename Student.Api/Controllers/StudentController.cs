using Microsoft.AspNetCore.Mvc;
using Student.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student.Api.Models.Student>>> GetStudents()
    {
        var students = await _studentRepository.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student.Api.Models.Student>> GetStudent(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent(Student.Api.Models.Student student)
    {
        await _studentRepository.AddAsync(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student.Api.Models.Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }
        await _studentRepository.UpdateAsync(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _studentRepository.DeleteAsync(id);
        return NoContent();
    }
}
