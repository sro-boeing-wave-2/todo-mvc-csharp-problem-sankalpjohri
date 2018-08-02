using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Label
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string text { get; set; }
    public int noteId { get; set; }

    public Label()
    {
    }

    public Label(int id, string text, int noteId)
    {
      this.id = id;
      this.text = text;
      this.noteId = noteId;
    }
  }
}