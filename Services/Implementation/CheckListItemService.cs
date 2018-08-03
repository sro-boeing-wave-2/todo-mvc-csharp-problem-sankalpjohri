using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo
{
  public class CheckListItemService: ICheckListItemService
  {
    private ICheckListAccess<ChecklistItem, long> _checkListItemAccess;

    public CheckListItemService(ICheckListAccess<ChecklistItem, long> _checkListItemAccess)
    {
      this._checkListItemAccess = _checkListItemAccess;
    }

    public List<ChecklistItemDTO> FindByNoteId(long noteId)
    {
      List<ChecklistItemDTO> resultList = new List<ChecklistItemDTO>();
      List<ChecklistItem> checklistItems = _checkListItemAccess.GetByNoteId(noteId);
      if (checklistItems != null && checklistItems.Count > 0)
      {
        foreach (ChecklistItem checklistItem in checklistItems)
        {
          resultList.Add(new ChecklistItemDTO(checklistItem));
        }
      }

      return resultList;
    }

    public List<ChecklistItemDTO> AddCheckListItemsForNote(long noteId, List<ChecklistItemDTO> checkListItems)
    {
      if (checkListItems != null && checkListItems.Count > 0)
      {
        foreach (ChecklistItemDTO checklistItemDto in checkListItems)
        {
          ChecklistItem checklistItem = _checkListItemAccess.AddChecklistItem(checklistItemDto.toEntity(noteId));
          checklistItemDto.id = checklistItem.id;
        }
      }
      return checkListItems;
    }

    public List<ChecklistItemDTO> UpdateCheckListItemsForNote(long noteId, List<ChecklistItemDTO> checkListItems)
    {
      throw new System.NotImplementedException();
    }
  }
}