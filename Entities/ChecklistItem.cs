
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class ChecklistItem
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string text { get; set; }
    public bool isChecked { get; set; }
    public int noteId { get; set; }

    public ChecklistItem()
    {
      text = "";
      isChecked = false;
    }

    public ChecklistItem(int id, string text, bool isChecked, int noteId)
    {
      this.id = id;
      this.text = text;
      this.isChecked = isChecked;
      this.noteId = noteId;
    }
  }
}