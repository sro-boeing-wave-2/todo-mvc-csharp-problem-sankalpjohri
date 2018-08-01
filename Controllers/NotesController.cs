using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo_mvc_csharp_problem_sankalpjohri.Controllers
{
  [Route("api/notes")]
  [ApiController]
  public class NotesController : Controller
  {
    
    private INoteService _noteService;

    public NotesController(INoteService _noteService)
    {
      this._noteService = _noteService;
    }
    
    /**
     * Get all notes
     */
    [HttpGet]
    public IActionResult GetAllNotes()
    {
      List<Note> result = _noteService.GetAllNotes();
      return Ok(result);
    }
    
    /**
     * Get note by id
     */
    [HttpGet]
    public IActionResult GetNoteById(long id)
    {
      Note result = _noteService.GetNote(id);
      return Ok(result);
    }
    
    /**
     * Create a new note
     */
    [HttpPost]
    public IActionResult CreateNote([FromBody] Note note)
    {
      Note result = _noteService.CreateNote(note);
      return Ok(result);
    }
    
    /**
     * Delete a/set of note/s.
     */
    [HttpDelete]
    public IActionResult DeleteNote([FromQuery] List<long> ids)
    {
      bool result = _noteService.DeleteNotes(ids);
      return Ok(result);
    }
    
    /**
     * Edit a note
     */
    [HttpPut]
    public IActionResult EditNote(long id, [FromBody] Note note)
    {
      Note result = _noteService.EditNote(id, note);
      return Ok(result);
    }
    
    /**
     * Get all the pinned notes
     */
    [HttpGet]
    public IActionResult GetPinnedNotes()
    {
      List<Note> result = _noteService.GetPinnedNotes();
      return Ok(result);
    }
    
    /**
     * Get notes by labels
     */
    [HttpGet]
    public IActionResult GetNotesByLabels([FromQuery] List<string> query)
    {
      List<Note> result = _noteService.GetNotesByLabel(query);
      return Ok(result);
    }
    
    /**
     * Search the notes with title.
     */
    [HttpGet]
    public IActionResult SearchNotes([FromQuery] string query)
    {
      List<Note> result = _noteService.SearchNotesByTitle(query);
      return Ok(result);
    }
  }
}