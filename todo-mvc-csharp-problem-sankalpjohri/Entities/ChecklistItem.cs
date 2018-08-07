
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class ChecklistItem
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id { get; set; }
    public string text { get; set; }
    public bool isChecked { get; set; }
    public long noteId { get; set; }

    public ChecklistItem()
    {
      text = "";
      isChecked = false;
    }

    public ChecklistItem(long id, string text, bool isChecked, long noteId)
    {
      this.id = id;
      this.text = text;
      this.isChecked = isChecked;
      this.noteId = noteId;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((ChecklistItem) obj).id == null || ((ChecklistItem) obj).id != id)
      {
        return false;
      }
      
      return true;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}