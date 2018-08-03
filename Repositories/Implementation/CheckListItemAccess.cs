using System.Collections.Generic;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;

namespace todo
{
  public class CheckListItemAccess : ICheckListAccess<ChecklistItem, long>
  {
    private NotesContext _notesContext;

    public CheckListItemAccess(NotesContext _notesContext)
    {
      this._notesContext = _notesContext;
    }

    public List<ChecklistItem> GetByNoteId(long noteId)
    {
      return _notesContext.ChecklistItems.Where(checkListItem => checkListItem.noteId == noteId).ToList();
    }

    public ChecklistItem AddChecklistItem(ChecklistItem checklistItem)
    {
      _notesContext.ChecklistItems.Add(checklistItem);
      _notesContext.SaveChanges();
      return checklistItem;
    }

    public int DeleteChecklistItem(long id)
    {
      ChecklistItem checklistItem = _notesContext.ChecklistItems.Find(id);
      if (checklistItem != null)
      {
        _notesContext.ChecklistItems.Remove(checklistItem);
        return _notesContext.SaveChanges();
      }
      return -1;
    }

    public int UpdateCheckListItem(long id, ChecklistItem checklistItem)
    {
      ChecklistItem checkListItemFromDb = _notesContext.ChecklistItems.Find(id);
      if (checkListItemFromDb != null)
      {
        checkListItemFromDb.text = checklistItem.text;
        checkListItemFromDb.isChecked = checklistItem.isChecked;
        return _notesContext.SaveChanges();
      }
      return -1;
    }
  }
}