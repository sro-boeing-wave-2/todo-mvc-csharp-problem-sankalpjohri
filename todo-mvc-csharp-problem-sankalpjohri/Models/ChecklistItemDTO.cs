using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class ChecklistItemDTO
  {
    public string text { get; set; }
    public bool isChecked { get; set; }


    public ChecklistItemDTO()
    {
    }

    public ChecklistItemDTO(string text, bool isChecked)
    {
      this.text = text;
      this.isChecked = isChecked;
    }

    public ChecklistItemDTO(ChecklistItem checklistItem)
    {
      text = checklistItem.text;
      isChecked = checklistItem.isChecked;
    }

    public ChecklistItem toEntity()
    {
      return new ChecklistItem(text, isChecked);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((ChecklistItemDTO) obj).text == null || !((ChecklistItemDTO) obj).text.Equals(text))
      {
        return false;
      }
      
      if (((ChecklistItemDTO) obj).isChecked == null || !((ChecklistItemDTO) obj).isChecked.Equals(isChecked))
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