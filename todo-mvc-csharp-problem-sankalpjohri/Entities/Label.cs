using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Label
  {
    public string text { get; set; }

    public Label()
    {
    }

    public Label(string text)
    {
      this.text = text;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      if (((Label) obj).text == null || !((Label) obj).text.Equals(text))
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