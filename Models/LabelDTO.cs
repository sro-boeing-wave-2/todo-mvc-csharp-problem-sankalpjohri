using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class LabelDTO
  {
    public long id { get; set; }
    public string text { get; set; }

    public LabelDTO()
    {
    }

    public LabelDTO(long id, string text)
    {
      this.id = id;
      this.text = text;
    }

    public LabelDTO(Label label)
    {
      id = label.id;
      text = label.text;
    }

    public Label toEntity(long noteId)
    {
      return new Label(id, text, noteId);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((Label) obj).id != id)
      {
        return false;
      }
      return true;
    }
  }
}