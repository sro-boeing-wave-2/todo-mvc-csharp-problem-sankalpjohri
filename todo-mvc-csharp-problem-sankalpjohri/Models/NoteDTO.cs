using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class NoteDTO
  {
    public string id { get; set; }
    public string title { get; set; }
    public string text { get; set; }
    public bool isPinned { get; set; }
    public List<LabelDTO> labels { get; set; }
    public List<ChecklistItemDTO> checklist { get; set; }

    public NoteDTO()
    {
      labels = new List<LabelDTO>();
      checklist = new List<ChecklistItemDTO>();
    }

    public NoteDTO(long id, string title, string text, bool isPinned, List<LabelDTO> labels,
      List<ChecklistItemDTO> checklist)
    {
      this.id = id.ToString();
      this.title = title;
      this.text = text;
      this.isPinned = isPinned;
      this.labels = labels;
      this.checklist = checklist;
    }

    public NoteDTO(Note note)
    {
      id = note.id.ToString();
      title = note.title;
      text = note.text;
      if (note.labels != null && note.labels.Count > 0)
      {
        foreach (Label label in note.labels)
        {
          this.labels = new List<LabelDTO>();
          this.labels.Add(new LabelDTO(label));
        }
      }
      
      if (note.checklist != null && note.checklist.Count > 0)
      {
        this.checklist = new List<ChecklistItemDTO>();
        foreach (ChecklistItem checklistItem in note.checklist)
        {
          this.checklist.Add(new ChecklistItemDTO(checklistItem));
        }  
      }
    }

    public Note toEntity()
    {
      Note note = new Note();
      note.text = text;
      note.title = title;
      note.isPinned = isPinned;
      if (labels != null && labels.Count > 0)
      {
        foreach (LabelDTO labelDto in labels)
        {
          note.labels.Add(labelDto.toEntity());
        }  
      }
      
      if (checklist != null && checklist.Count > 0)
      {
        foreach (ChecklistItemDTO checklistItemDto in checklist)
        {
          note.checklist.Add(checklistItemDto.toEntity());
        }
      }
      return note;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((NoteDTO) obj).id == null || !((NoteDTO) obj).id.Equals(id))
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