using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public class NoteService: INoteService
  {
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
      throw new System.NotImplementedException();
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