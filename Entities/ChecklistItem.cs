using System;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class ChecklistItem
  {
    private long id { get; }
    private string text { get; set; }
    private bool isChecked { get; set; }

    public ChecklistItem()
    {
      text = "";
      isChecked = false;
    }

    public ChecklistItem(string text, bool isChecked)
    {
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.isChecked = isChecked;
    }
  }
}