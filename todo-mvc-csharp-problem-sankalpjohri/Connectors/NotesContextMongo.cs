using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Connectors
{
  public class NotesContextMongo
  {
    public NotesContextMongo()
    {
      //Server settings
      MongoClient _client = new MongoClient("mongodb://sankalp:test123@mongo/");
      this.db = _client.GetDatabase("NoteDB");
    }

    private IMongoDatabase db;

    public IMongoCollection<Note> Notes
    {
      get
      {
        return db.GetCollection<Note>("Note"); 
      }
    }
  }
}