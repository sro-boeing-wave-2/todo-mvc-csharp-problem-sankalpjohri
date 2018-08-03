﻿using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Models
{
  public class ChecklistItemDTO
  {
    public int id { get; set; }
    public string text { get; set; }
    public bool isChecked { get; set; }


    public ChecklistItemDTO()
    {
    }

    public ChecklistItemDTO(int id, string text, bool isChecked)
    {
      this.id = id;
      this.text = text;
      this.isChecked = isChecked;
    }

    public ChecklistItemDTO(ChecklistItem checklistItem)
    {
      id = checklistItem.id;
      text = checklistItem.text;
      isChecked = checklistItem.isChecked;
    }

    public ChecklistItem toEntity(int noteId)
    {
      return new ChecklistItem(id, text, isChecked, noteId);
    }
  }
}