using System.Collections.Generic;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;

namespace todo
{
  public class LabelAccess : ILabelAccess<Label, long>
  {
    private NotesContext _notesContext;

    public LabelAccess(NotesContext _notesContext)
    {
      this._notesContext = _notesContext;
    }

    public List<Label> GetByNoteId(long noteId)
    {
      return _notesContext.labels.Where(label => label.noteId == noteId).ToList();
    }

    public Label AddLabel(Label label)
    {
      _notesContext.labels.Add(label);
      _notesContext.SaveChanges();
      return label;
    }

    public int DeleteLabel(List<long> ids)
    {
      List<Label> labels = _notesContext.labels.Where(label => ids.Contains(label.id)).ToList();
      if (labels != null)
      {
        _notesContext.labels.RemoveRange(labels);
        return _notesContext.SaveChanges();
      }

      return -1;
    }

    public List<Label> searchNotesByLabels(List<string> labels)
    {
      return _notesContext.labels.Where(label => labels.Contains(label.text)).ToList();
    }
  }
}