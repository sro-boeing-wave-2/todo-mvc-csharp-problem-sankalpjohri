using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
     * Get notes by labels
     */
    [Route("search/label")]
    [HttpGet]
    public IActionResult GetNotesByLabels([FromQuery] List<string> query)
    {
      List<NoteDTO> result = _noteService.GetNotesByLabel(query);
      return Ok(result);
    }
    
    /**
     * Search the notes with title.
     */
    [Route("search/title")]
    [HttpGet]
    public IActionResult SearchNotes([FromQuery] string query)
    {
      List<NoteDTO> result = _noteService.SearchNotesByTitle(query);
      return Ok(result);
    }
    
    /**
     * Get note by id
     */
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetNoteById(string id)
    {
      NoteDTO result = _noteService.GetNote(ObjectId.Parse(id));
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
    [HttpDelete]
    public IActionResult DeleteNote([FromQuery(Name = "ids")] List<string> ids)
    {
      List<ObjectId> objectIds = new List<ObjectId>();
      foreach (string id in ids)
      {
        objectIds.Add(ObjectId.Parse(id));
      }
      bool result = _noteService.DeleteNotes(objectIds);
      return Ok(result);
    }
    
    /**
     * Edit a note
     */
    [Route("{id}")]
    [HttpPut]
    public IActionResult EditNote(string id, [FromBody] NoteDTO note)
    {
      NoteDTO result = _noteService.EditNote(ObjectId.Parse(id), note);
      return Ok(result);
    }
    
    /**
     * Get all the pinned notes
     */
    [Route("search/pinned")]
    [HttpGet]
    public IActionResult GetPinnedNotes()
    {
      List<NoteDTO> result = _noteService.GetPinnedNotes();
      return Ok(result);
    }
  }
}