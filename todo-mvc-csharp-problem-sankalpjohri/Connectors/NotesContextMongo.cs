using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Connectors
{
  public class NotesContextMongo
  {
    private IMongoDatabase db;

    public NotesContextMongo()
    {
      MongoClient _client = new MongoClient("mongodb://sankalp:test@123@db:27017/NotesDB");
      this.db = _client.GetDatabase("NoteDB");
    }
     
    public IMongoCollection<Note> Notes
    {
      get
      {
        return db.GetCollection<Note>("Note"); 
      }
    }

    public IMongoCollection<ChecklistItem> ChecklistItems
    {
      get
      {
        return db.GetCollection<ChecklistItem>("CheckListItem"); 
      }
    }

    public IMongoCollection<Label> labels
    {
      get { return db.GetCollection<Label>("Label"); }
    }
  }
}