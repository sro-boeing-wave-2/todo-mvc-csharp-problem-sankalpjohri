namespace todo_mvc_csharp_problem_sankalpjohri.Entities
{
  public class Label
  {
    public long id { get; set; }
    public string text { get; set; }
    public long noteId { get; set; }

    public Label()
    {
    }

    public Label(long id, string text, long noteId)
    {
      this.id = id;
      this.text = text;
      this.noteId = noteId;
    }
  }
}