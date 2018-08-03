using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Repositories
{
  public interface ICheckListAccess<TEntity, TU>
  {
    /**
     * Repository method to get labels by note id.
     */
    List<ChecklistItem> GetByNoteId(long noteId);

    /**
     * Repository method to add a label
     */
    ChecklistItem AddChecklistItem(ChecklistItem checklistItem);

    /**
     * Repository method to delete a label
     */
    int DeleteChecklistItem(long id);

    /**
     * Repository method to update a checklist item.
     */
    int UpdateCheckListItem(long id, ChecklistItem checklistItem);
  }
}