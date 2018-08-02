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
    public long id { get; }
    [Required]
    public string title { get; set; }
    public string text { get; set; }
    public bool isPinned { get; set; }
    
    public Note()
    {
      title = "";
      text = "";
      isPinned = false;
    }

    public Note(string title, string text, List<ChecklistItem> checklist, List<string> labels, bool isPinned)
    {
      this.title = title ?? throw new ArgumentNullException(nameof(title));
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.isPinned = isPinned;
    }
  }
}