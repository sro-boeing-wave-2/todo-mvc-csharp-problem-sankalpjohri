using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo
{
  public class NoteService : INoteService
  {
    private INoteAccess<Note, ObjectId> _noteAccess;

    public NoteService(INoteAccess<Note, ObjectId> _noteAccess)
    {
      this._noteAccess = _noteAccess;
    }

    public NoteDTO CreateNote(NoteDTO note)
    {
      Note noteEntity = note.toEntity();
      ObjectId noteId = _noteAccess.AddNote(noteEntity);
      noteEntity = _noteAccess.GetNoteById(noteId);
      NoteDTO result = new NoteDTO(noteEntity);
      return result;
    }

    public NoteDTO GetNote(ObjectId id)
    {
      Note note = _noteAccess.GetNoteById(id);
      if (note == null)
      {
        return null;
      }

      NoteDTO result = new NoteDTO(note);
      return result;
    }

    public List<NoteDTO> GetAllNotes()
    {
      List<NoteDTO> resultList = new List<NoteDTO>();
      List<Note> noteList = _noteAccess.GetAllNotes().ToList();
      if (noteList != null && noteList.Count > 0)
      {
        foreach (Note note in noteList)
        {
          resultList.Add(new NoteDTO(note));
        }
      }

      return resultList;
    }

    public bool DeleteNotes(List<ObjectId> noteIds)
    {
      _noteAccess.DeleteNotes(noteIds);
      return true;
    }

    public NoteDTO EditNote(ObjectId id, NoteDTO note)
    {
      _noteAccess.UpdateNote(note.toEntity());
      return GetNote(id);
    }

    public List<NoteDTO> GetNotesByLabel(List<string> labels)
    {
      List<NoteDTO> resultLists = new List<NoteDTO>();
      return resultLists;
    }

    public List<NoteDTO> GetPinnedNotes()
    {
      List<NoteDTO> resultLists = new List<NoteDTO>();
      List<Note> notes = _noteAccess.GetPinnedNotes();
      if (notes != null && notes.Count > 0)
      {
        foreach (Note note in notes)
        {
          resultLists.Add(new NoteDTO(note));
        }
      }

      return resultLists;
    }

    public List<NoteDTO> SearchNotesByTitle(string title)
    {
      List<NoteDTO> resultLists = new List<NoteDTO>();
      List<Note> notes = _noteAccess.searchNotesByTitle(title);
      if (notes != null && notes.Count > 0)
      {
        foreach (Note note in notes)
        {
          resultLists.Add(new NoteDTO(note));
        }
      }

      return resultLists;
    }
  }
}