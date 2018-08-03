using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Models;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public interface ICheckListItemService
  {
    /**
     * Service method to get labels by note id.
     */
    List<ChecklistItemDTO> FindByNoteId(long noteId);

    /**
     * Service method to add labels for a note.
     */
    List<ChecklistItemDTO> AddCheckListItemsForNote(long noteId, 
      List<ChecklistItemDTO> checkListItems);

    /**
     * Service method to update labels for a note.
     */
    List<ChecklistItemDTO> UpdateCheckListItemsForNote(long noteId, 
      List<ChecklistItemDTO> checkListItems);
  }
}