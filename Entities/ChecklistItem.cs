using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class ChecklistItem
  {
    public long id { get; }
    public string text { get; set; }
    public bool isChecked { get; set; }
    public long noteId { get; set; }

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