using DTOteachers.Models;
using Microsoft.EntityFrameworkCore;

namespace DTOteachers.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Teacher> Teachers => Set<Teacher>();
}
