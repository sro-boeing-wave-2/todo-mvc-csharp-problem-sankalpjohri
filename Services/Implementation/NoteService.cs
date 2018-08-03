using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo
{
  public class NoteService : INoteService
  {
    private INoteAccess<Note, long> _noteAccess;
    private ILabelService _labelService;
    private ICheckListItemService _checkListItemService;

    public NoteService(INoteAccess<Note, long> _noteAccess, ILabelService _labelService,
      ICheckListItemService _checkListItemService)
    {
      this._noteAccess = _noteAccess;
      this._labelService = _labelService;
      this._checkListItemService = _checkListItemService;
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

    public bool DeleteNotes(List<long> noteIds)
    {
      int res = _noteAccess.DeleteNotes(noteIds);
      if (res <= 0)
      {
        return false;
      }
      return true;
    }

    public NoteDTO EditNote(long id, NoteDTO note)
    {
      NoteDTO result = null;
      return result;
    }

    public List<NoteDTO> GetNotesByLabel(List<string> labels)
    {
      List<NoteDTO> resultLists = new List<NoteDTO>();
      List<Label> searchResults = _labelService.SearchLabelByText(labels);
      List<long> noteIds = searchResults.Select(label => label.noteId).Distinct().ToList();
      List<Note> notes = _noteAccess.GetNoteById(noteIds);
      if (noteIds != null && noteIds.Count > 0)
      {
        foreach (Note note in notes)
        {
          resultLists.Add(new NoteDTO(note));
        }
      }
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