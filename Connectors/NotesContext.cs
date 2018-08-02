using Microsoft.EntityFrameworkCore;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Connectors
{
  public class NotesContext : DbContext
  {
    public DbSet<Note> Notes { get; set; }
    public DbSet<ChecklistItem> ChecklistItems { get; set; }
    public DbSet<Label> labels { get; set; }

    public NotesContext(DbContextOptions opts) : base(opts)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
  }
}