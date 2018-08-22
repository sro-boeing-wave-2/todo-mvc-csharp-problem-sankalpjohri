using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Note
  {
    [BsonId]
    public ObjectId id { get; set; }

    [Required]
    public string title { get; set; }

    public string text { get; set; }
    public bool isPinned { get; set; }

    public List<Label> labels { get; set; }
    public List<ChecklistItem> checklist { get; set; }

    public Note()
    {
      title = "";
      text = "";
      isPinned = false;
      labels = new List<Label>();
      checklist = new List<ChecklistItem>();
    }

    public Note(ObjectId id, string title, string text, bool isPinned, List<Label> labels,
      List<ChecklistItem> checkList)
    {
      this.id = id;
      this.title = title ?? throw new ArgumentNullException(nameof(title));
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.isPinned = isPinned;
      this.labels = labels;
      this.checklist = checkList;
    }
  }
}