using System.Collections.Generic;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Repositories.MongoRepositories
{
  public class NoteAccessMongo: INoteAccess<Note, ObjectId>
  {
    private NotesContextMongo _context;

    public NoteAccessMongo()
    {
      _context = new NotesContextMongo();
    }
    
    public IEnumerable<Note> GetAllNotes()
    {
      return _context.Notes.AsQueryable().Select(n => n).ToList();
    }

    public Note GetNoteById(ObjectId id)
    {
      return _context.Notes.AsQueryable().Where(n => n.mongoId.Equals(id)).FirstOrDefault();
    }

    public List<Note> GetNoteById(List<ObjectId> ids)
    {
      return _context.Notes.AsQueryable().Where(n => ids.Contains(n.mongoId)).ToList();
    }

    public ObjectId AddNote(Note note)
    {
      _context.Notes.InsertOne(note);
      return note.mongoId;
    }

    public int UpdateNote(Note note)
    {
      var filter = Builders<Note>.Filter.Eq("mongoId", note.mongoId);
      var update = Builders<Note>.Update.Set("title", note.title).Set("text", note.text)
        .Set("isPinned", note.isPinned);
      var updateResult = _context.Notes.UpdateOne(filter, update);
      return int.Parse(updateResult.ModifiedCount.ToString());
    }

    public int DeleteNotes(List<ObjectId> id)
    {
      var filter = Builders<Note>.Filter.AnyEq("mongoId", id);
      var deleteResult = _context.Notes.DeleteMany(filter);
      return int.Parse(deleteResult.DeletedCount.ToString());
    }

    public List<Note> searchNotesByTitle(string title)
    {
      return _context.Notes.AsQueryable().Where(note => note.title.Contains(title)).ToList();
    }

    public List<Note> GetPinnedNotes()
    {
      return _context.Notes.AsQueryable().Where(note => note.isPinned).ToList();
    }
  }
}