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
    [BsonIgnore]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id { get; set; }
    
    [BsonId]
    [NotMapped]
    public ObjectId mongoId { get; set; }
    
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

    public Note(long id, string title, string text, bool isPinned)
    {
      this.id = id;
      this.title = title ?? throw new ArgumentNullException(nameof(title));
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.isPinned = isPinned;
    }
   
  }
}