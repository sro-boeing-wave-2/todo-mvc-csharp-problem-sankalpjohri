using System;
using System.Collections.Generic;

namespace todo_mvc_csharp_problem_sankalpjohri.Classes
{
  public class Notes
  {
    private string title { get; set; }
    private string text { get; set; }
    private List<string> checklist { get; set; }
    private List<string> labels { get; set; }
    private bool isPinned { get; set; }

    public Notes()
    {
    }

    public Notes(string title, string text, List<string> checklist, List<string> labels, bool isPinned)
    {
      this.title = title ?? throw new ArgumentNullException(nameof(title));
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.checklist = checklist ?? throw new ArgumentNullException(nameof(checklist));
      this.labels = labels ?? throw new ArgumentNullException(nameof(labels));
      this.isPinned = isPinned;
    }
    
    
  }
}