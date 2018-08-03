using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
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

    public NoteDTO CreateNote(NoteDTO note)
    {
      Note noteEntity = note.toEntity();
      long noteId = _noteAccess.AddNote(noteEntity);
      if (noteId <= 0)
      {
        throw new DataException();
      }
      noteEntity = _noteAccess.GetNoteById(noteId);
      return new NoteDTO(noteEntity);
    }
    
    public NoteDTO GetNote(long id)
    {
      Note note = _noteAccess.GetNoteById(id);
      if (note == null)
      {
        throw new ObjectNotFoundException();
      }
      return new NoteDTO(note);
    }

    public List<NoteDTO> GetAllNotes()
    {
      throw new System.NotImplementedException();
      //return _noteAccess.GetAllNotes().ToList();
    }

    public bool DeleteNotes(List<long> noteIds)
    {
      throw new System.NotImplementedException();
    }

    public NoteDTO EditNote(long id, NoteDTO note)
    {
      throw new System.NotImplementedException();
    }

    public List<NoteDTO> GetNotesByLabel(List<string> labels)
    {
      throw new System.NotImplementedException();
    }

    public List<NoteDTO> GetPinnedNotes()
    {
      throw new System.NotImplementedException();
    }

    public List<NoteDTO> SearchNotesByTitle(string title)
    {
      throw new System.NotImplementedException();
    }
  }
}