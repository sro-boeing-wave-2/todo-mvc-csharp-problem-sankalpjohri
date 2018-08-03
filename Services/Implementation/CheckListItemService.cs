using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Update.Internal;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo
{
  public class CheckListItemService : ICheckListItemService
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

    public bool DeleteCheckListItemsForNote(long noteId, List<ChecklistItemDTO> checkListItems)
    {
      List<long> checkListItemIds =
        checkListItems.Select(ChecklistEntity => ChecklistEntity.id).ToList();
      _checkListItemAccess.DeleteChecklistItem(checkListItemIds);
      return true;
    }

    public List<ChecklistItemDTO> UpdateCheckListItemsForNote(long noteId, List<ChecklistItemDTO> checkListItems)
    {
      List<ChecklistItem> itemsFromDb = _checkListItemAccess.GetByNoteId(noteId);
      List<ChecklistItemDTO> toBeAdded = checkListItems.Where(checkListItem => checkListItem.id == 0)
        .Select(item => item)
        .ToList();
      AddCheckListItemsForNote(noteId, toBeAdded);
      List<ChecklistItemDTO> toBeDeleted = itemsFromDb
        .Where(item => !checkListItems.Contains(new ChecklistItemDTO(item))).Select(item => new ChecklistItemDTO(item))
         .ToList();
      DeleteCheckListItemsForNote(noteId, toBeDeleted);
      List<ChecklistItem> toBeUpdated =
        checkListItems.Where(item => itemsFromDb.Contains(item.toEntity(noteId))).Select(item => item.toEntity(noteId))
          .ToList();
      if (toBeUpdated != null && toBeUpdated.Count > 0)
      {
        foreach (ChecklistItem UpdateEntry in toBeUpdated)
        {
          _checkListItemAccess.UpdateCheckListItem(noteId, UpdateEntry);
        }
      }

      return FindByNoteId(noteId);
    }
  }
}