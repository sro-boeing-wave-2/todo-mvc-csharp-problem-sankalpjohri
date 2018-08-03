using System.Collections.Generic;
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
    NoteDTO GetNote(long id);

    /**
     * Get all notes
     */
    List<NoteDTO> GetAllNotes();

    /**
     * Delete notes by ids.
     */
    bool DeleteNotes(List<long> noteIds);

   /**
    * Edit note
    */
    NoteDTO EditNote(long id, NoteDTO note);

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