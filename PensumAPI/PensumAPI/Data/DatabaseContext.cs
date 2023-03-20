using Microsoft.EntityFrameworkCore;
using PensumAPI.Models;

namespace PensumAPI.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
    
    public DbSet<Lektion> Lektions { get; set; }
}