using System.Collections.Generic;
using MongoDB.Bson;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public interface INoteService
  {
    /**
     * Create a new note.
     */
    NoteDTO CreateNote(NoteDTO note);

    /**
     * Get note by id/
     */
    NoteDTO GetNote(ObjectId id);

    /**
     * Get all notes
     */
    List<NoteDTO> GetAllNotes();

    /**
     * Delete notes by ids.
     */
    bool DeleteNotes(List<ObjectId> noteIds);

   /**
    * Edit note
    */
    NoteDTO EditNote(ObjectId id, NoteDTO note);

   /**
    * Search notes by labels.
    */
    List<NoteDTO> GetNotesByLabel(List<string> labels);

   /**
    * Get all pinned notes
    */
    List<NoteDTO> GetPinnedNotes();

   /**
    * Search notes by title.
    */
    List<NoteDTO> SearchNotesByTitle(string title);
  }
}