using DTOteachers.Data;
using DTOteachers.DTOs;
using DTOteachers.Models;
using Microsoft.EntityFrameworkCore;

namespace DTOteachers.Services;

public class TeacherService(AppDbContext context) : ITeacherService
{
    public async Task<IEnumerable<TeacherDto>> GetAllAsync()
    {
        return await context.Teachers
            .OrderBy(t => t.Id)
            .Select(t => new TeacherDto
            {
                Id = t.Id,
                FullName = t.FirstName + " " + t.LastName,
                Email = t.Email,
                Subject = t.Subject
            })
            .ToListAsync();
    }

    public async Task<TeacherDto?> GetByIdAsync(int id)
    {
        var teacher = await context.Teachers.FindAsync(id);
        return teacher is null ? null : ToDto(teacher);
    }

    public async Task<TeacherDto> CreateAsync(CreateTeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Email = dto.Email.Trim(),
            Subject = dto.Subject.Trim()
        };

        context.Teachers.Add(teacher);
        await context.SaveChangesAsync();
        return ToDto(teacher);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTeacherDto dto)
    {
        var teacher = await context.Teachers.FindAsync(id);
        if (teacher is null) return false;

        teacher.FirstName = dto.FirstName.Trim();
        teacher.LastName = dto.LastName.Trim();
        teacher.Email = dto.Email.Trim();
        teacher.Subject = dto.Subject.Trim();

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await context.Teachers.FindAsync(id);
        if (teacher is null) return false;

        context.Teachers.Remove(teacher);
        await context.SaveChangesAsync();
        return true;
    }

    private static TeacherDto ToDto(Teacher teacher) => new()
    {
        Id = teacher.Id,
        FullName = $"{teacher.FirstName} {teacher.LastName}",
        Email = teacher.Email,
        Subject = teacher.Subject
    };
}
