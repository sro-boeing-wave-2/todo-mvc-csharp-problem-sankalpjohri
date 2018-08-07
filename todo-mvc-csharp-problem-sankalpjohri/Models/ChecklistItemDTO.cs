using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class ChecklistItemDTO
  {
    public long id { get; set; }
    public string text { get; set; }
    public bool isChecked { get; set; }


    public ChecklistItemDTO()
    {
    }

    public ChecklistItemDTO(long id, string text, bool isChecked)
    {
      this.id = id;
      this.text = text;
      this.isChecked = isChecked;
    }

    public ChecklistItemDTO(ChecklistItem checklistItem)
    {
      id = checklistItem.id;
      text = checklistItem.text;
      isChecked = checklistItem.isChecked;
    }

    public ChecklistItem toEntity(long noteId)
    {
      return new ChecklistItem(id, text, isChecked, noteId);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((ChecklistItemDTO) obj).id == null || ((ChecklistItemDTO) obj).id != id)
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