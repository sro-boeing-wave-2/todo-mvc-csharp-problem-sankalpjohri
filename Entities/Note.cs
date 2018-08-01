using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Note
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private long id { get; }
    [Required]
    private string title { get; set; }
    private string text { get; set; }
    private List<ChecklistItem> checklist { get; set; }
    private List<string> labels { get; set; }
    private bool isPinned { get; set; }


    public Note()
    {
      title = "";
      text = "";
      checklist = new List<ChecklistItem>();
      labels = new List<string>();
      isPinned = false;
    }

    public Note(string title, string text, List<ChecklistItem> checklist, List<string> labels, bool isPinned)
    {
      this.title = title ?? throw new ArgumentNullException(nameof(title));
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.checklist = checklist ?? throw new ArgumentNullException(nameof(checklist));
      this.labels = labels ?? throw new ArgumentNullException(nameof(labels));
      this.isPinned = isPinned;
    }
  }
}