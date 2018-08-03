using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo_mvc_csharp_problem_sankalpjohri.Controllers
{
  [Route("api/note")]
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
      List<NoteDTO> result = _noteService.GetAllNotes();
      return Ok(result);
    }
    
    /**
     * Get note by id
     */
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetNoteById(long id)
    {
      NoteDTO result = _noteService.GetNote(id);
      return Ok(result);
    }
    
    /**
     * Create a new note
     */
    [HttpPost]
    public IActionResult CreateNote([FromBody] NoteDTO note)
    {
      NoteDTO result = _noteService.CreateNote(note);
      return Ok(result);
    }
    
    /**
     * Delete a/set of note/s.
     */
    [Route("{id}")]
    [HttpDelete]
    public IActionResult DeleteNote([FromQuery] List<long> ids)
    {
      bool result = _noteService.DeleteNotes(ids);
      return Ok(result);
    }
    
    /**
     * Edit a note
     */
    [Route("{id}")]
    [HttpPut]
    public IActionResult EditNote(long id, [FromBody] NoteDTO note)
    {
      NoteDTO result = _noteService.EditNote(id, note);
      return Ok(result);
    }
    
    /**
     * Get all the pinned notes
     */
    [Route("pinned")]
    [HttpGet]
    public IActionResult GetPinnedNotes()
    {
      List<NoteDTO> result = _noteService.GetPinnedNotes();
      return Ok(result);
    }
    
    /**
     * Get notes by labels
     */
    [Route("label")]
    [HttpGet]
    public IActionResult GetNotesByLabels([FromQuery] List<string> query)
    {
      List<NoteDTO> result = _noteService.GetNotesByLabel(query);
      return Ok(result);
    }
    
    /**
     * Search the notes with title.
     */
    [Route("search")]
    [HttpGet]
    public IActionResult SearchNotes([FromQuery] string query)
    {
      List<NoteDTO> result = _noteService.SearchNotesByTitle(query);
      return Ok(result);
    }
  }
}