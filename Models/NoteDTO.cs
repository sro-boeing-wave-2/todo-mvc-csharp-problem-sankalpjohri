using System.Collections.Generic;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class NoteDTO
  {
    private long id { get; set; }
    private string title { get; set; }
    private string text { get; set; }
    private List<LabelDTO> labels { get; set; }
    private List<ChecklistItemDTO> checklist { get; set; }

    public NoteDTO()
    {
      labels = new List<LabelDTO>();
      checklist = new List<ChecklistItemDTO>();
    }

    public NoteDTO(long id, string title, string text, List<LabelDTO> labels, List<ChecklistItemDTO> checklist)
    {
      this.id = id;
      this.title = title;
      this.text = text;
      this.labels = labels;
      this.checklist = checklist;
    }
  }
}