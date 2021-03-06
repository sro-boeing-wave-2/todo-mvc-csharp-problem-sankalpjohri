﻿using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Repositories
{
  public interface INoteAccess<TEntity, TU>
  {
    /**
     * Repository method to get all the notes
     */
    IEnumerable<TEntity> GetAllNotes();

    /**
     * Repository method to get a note by id
     */
    TEntity GetNoteById(TU id);

    /**
     * Repository method to get notes by ids
     */
    List<TEntity> GetNoteById(List<TU> ids);

    /**
     * Repository method to add a note to the db
     */
    TU AddNote(TEntity note);

    /**
     * Repository method to update a note.
     */
    int UpdateNote(TEntity note);

    /**
     * Repository method to delete notes by ids
     */
    int DeleteNotes(List<TU> id);

    /**
    * Repository method to search notes by title.
    */
    List<TEntity> searchNotesByTitle(string title);

    /**
     * Repository method to get pinned notes.
     */
    List<TEntity> GetPinnedNotes();
  }
}