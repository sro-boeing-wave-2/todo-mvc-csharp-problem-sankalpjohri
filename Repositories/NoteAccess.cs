using System;
using System.Collections.Generic;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Repositories
{
  public class NoteAccess: INoteAccess<Note, long>
  {
    private NotesContext _context;

    public NoteAccess(NotesContext _context)
    {
      this._context = _context;
    }
    
    public IEnumerable<Note> GetAllNotes()
    {
      return _context.Notes.AsEnumerable().ToList();
    }

    public Note GetNoteById(long id)
    {
      return _context.Notes.Find(id);
    }

    public long AddNote(Note note)
    {
      _context.Notes.Add(note);
      int res = _context.SaveChanges();
      if (res > 0)
      {
        return note.id;
      }
      return -1;
    }

    public int UpdateNote(Note note)
    {
      Note noteFromDb = _context.Notes.Find(note.id);
      if (noteFromDb != null)
      {
        noteFromDb.title = note.title;
        noteFromDb.text = note.text;
        noteFromDb.isPinned = note.isPinned;
        return _context.SaveChanges();
      }

      return -1;
    }

    public int DeleteNotes(List<long> ids)
    {
      foreach (long id in ids)
      {
        Note note = _context.Notes.Find(id);
        if (note != null)
        {
          _context.Notes.Remove(note);
        }
      }
      return _context.SaveChanges();
    }

    public List<Note> searchNotesByLabels(List<string> label)
    {
      throw new NotImplementedException();
    }

    public List<Note> searchNotesByTitle(string title)
    {
      throw new NotImplementedException();
    }

    public List<Note> searchNotesByLabels()
    {
      throw new NotImplementedException();
    }
  }
}