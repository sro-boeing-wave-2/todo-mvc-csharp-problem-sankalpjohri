using System.Collections.Generic;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public class NoteService: INoteService
  {
    private INoteAccess<Note, long> _noteAccess;

    public NoteService(INoteAccess<Note, long> _noteAccess)
    {
      this._noteAccess = _noteAccess;
    }

    public Note CreateNote(Note note)
    {
      throw new System.NotImplementedException();
    }

    public Note GetNote(long id)
    {
      throw new System.NotImplementedException();
    }

    public List<Note> GetAllNotes()
    {
      return _noteAccess.GetAllNotes().ToList();
    }

    public bool DeleteNotes(List<long> noteIds)
    {
      throw new System.NotImplementedException();
    }

    public Note EditNote(long id, Note note)
    {
      throw new System.NotImplementedException();
    }

    public List<Note> GetNotesByLabel(List<string> labels)
    {
      throw new System.NotImplementedException();
    }

    public List<Note> GetPinnedNotes()
    {
      throw new System.NotImplementedException();
    }

    public List<Note> SearchNotesByTitle(string title)
    {
      throw new System.NotImplementedException();
    }
  }
}