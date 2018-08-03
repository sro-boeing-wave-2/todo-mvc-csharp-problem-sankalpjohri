using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Label
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id { get; set; }
    public string text { get; set; }
    public long noteId { get; set; }

    public Label()
    {
    }

    public Label(long id, string text, long noteId)
    {
      this.id = id;
      this.text = text;
      this.noteId = noteId;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((Label) obj).id == null || ((Label) obj).id != id)
      {
        return false;
      }
      return true;
    }
  }
}