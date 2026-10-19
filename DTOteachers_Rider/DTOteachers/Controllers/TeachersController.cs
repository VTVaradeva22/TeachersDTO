using DTOteachers.DTOs;
using DTOteachers.Services;
using Microsoft.AspNetCore.Mvc;

namespace DTOteachers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController(ITeacherService teacherService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TeacherDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
        => Ok(await teacherService.GetAllAsync());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(TeacherDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherDto>> GetById(int id)
    {
        var teacher = await teacherService.GetByIdAsync(id);
        return teacher is null
            ? NotFound(new { message = "Учителят не е намерен." })
            : Ok(teacher);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TeacherDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherDto>> Create([FromBody] CreateTeacherDto dto)
    {
        var created = await teacherService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDto dto)
    {
        var success = await teacherService.UpdateAsync(id, dto);
        return success
            ? NoContent()
            : NotFound(new { message = "Учителят не е намерен за редакция." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await teacherService.DeleteAsync(id);
        return success
            ? NoContent()
            : NotFound(new { message = "Учителят не е намерен за изтриване." });
    }
}
