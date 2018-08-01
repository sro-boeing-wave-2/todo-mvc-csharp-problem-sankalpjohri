using Microsoft.EntityFrameworkCore;

namespace todo_mvc_csharp_problem_sankalpjohri.Connectors
{
  public class NotesContext: DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mysqllocaldb;Database=NOTES;Trusted_Conneciton=yes");
    }
  }
}