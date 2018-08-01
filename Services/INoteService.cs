using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public interface INoteService
  {
    /**
     * Create a new note.
     */
    Note CreateNote(Note note);

    /**
     * Get note by id/
     */
    Note GetNote(long id);

    /**
     * Get all notes
     */
    List<Note> GetAllNotes();

    /**
     * Delete notes by ids.
     */
    bool DeleteNotes(List<long> noteIds);

   /**
    * Edit note
    */
    Note EditNote(long id, Note note);

   /**
    * Search notes by labels.
    */
    List<Note> GetNotesByLabel(List<string> labels);

   /**
    * Get all pinned notes
    */
    List<Note> GetPinnedNotes();

   /**
    * Search notes by title.
    */
    List<Note> SearchNotesByTitle(string title);
  }
}