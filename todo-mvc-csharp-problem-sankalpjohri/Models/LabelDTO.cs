using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class LabelDTO
  {
    public string text { get; set; }

    public LabelDTO()
    {
    }

    public LabelDTO(string text)
    {
      this.text = text;
    }

    public LabelDTO(Label label)
    {
      text = label.text;
    }

    public Label toEntity()
    {
      return new Label(text);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((LabelDTO) obj).text == null || !((LabelDTO) obj).text.Equals(text))
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