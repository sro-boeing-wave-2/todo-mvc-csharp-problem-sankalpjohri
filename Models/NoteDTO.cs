using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class NoteDTO
  {
    public long id { get; set; }
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
      this.id = id;
      this.title = title;
      this.text = text;
      this.isPinned = isPinned;
      this.labels = labels;
      this.checklist = checklist;
    }

    public NoteDTO(Note note)
    {
      id = note.id;
      title = note.title;
      text = note.text;
    }

    public Note toEntity()
    {
      Note note = new Note();
      note.text = text;
      note.title = title;
      note.isPinned = isPinned;
      return note;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((NoteDTO) obj).id == null || ((NoteDTO) obj).id != id)
      {
        return false;
      }
      return true;
    }
  }
}