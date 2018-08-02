using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class LabelDTO
  {
    public int id { get; set; }
    public string text { get; set; }

    public LabelDTO()
    {
    }

    public LabelDTO(int id, string text)
    {
      this.id = id;
      this.text = text;
    }

    public LabelDTO(Label label)
    {
      id = label.id;
      text = label.text;
    }

    public Label toEntity(int noteId)
    {
      return new Label(id, text, noteId);
    }
  }
}