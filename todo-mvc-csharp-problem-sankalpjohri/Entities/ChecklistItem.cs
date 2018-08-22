
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class ChecklistItem
  {
    public string text { get; set; }
    public bool isChecked { get; set; }
   
    public ChecklistItem()
    {
      text = "";
      isChecked = false;
    }

    public ChecklistItem(string text, bool isChecked)
    {
      this.text = text;
      this.isChecked = isChecked;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((ChecklistItem) obj).text == null || !((ChecklistItem) obj).text.Equals(text))
      {
        return false;
      }
      
      if (((ChecklistItem) obj).isChecked == null || ((ChecklistItem) obj).isChecked != isChecked)
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