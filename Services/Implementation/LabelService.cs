using System.Collections.Generic;
using System.Linq;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo
{
  public class LabelService : ILabelService
  {
    private ILabelAccess<Label, long> _lableAccess;

    public LabelService(ILabelAccess<Label, long> _lableAccess)
    {
      this._lableAccess = _lableAccess;
    }

    public List<LabelDTO> FindByNoteId(long noteId)
    {
      List<LabelDTO> resultList = new List<LabelDTO>();
      List<Label> labels = _lableAccess.GetByNoteId(noteId);
      if (labels != null && labels.Count > 0)
      {
        foreach (Label label in labels)
        {
          resultList.Add(new LabelDTO(label));
        }
      }

      return resultList;
    }

    public List<LabelDTO> AddLabelsForNote(long noteId, List<LabelDTO> labels)
    {
      if (labels != null && labels.Count > 0)
      {
        foreach (LabelDTO labelDto in labels)
        {
          Label label = _lableAccess.AddLabel(labelDto.toEntity(noteId));
          labelDto.id = label.id;
        }
      }
      return labels;
    }

    public List<LabelDTO> UpdateLabelsForNote(long noteId, List<LabelDTO> labels)
    {
      List<Label> labelsFromDb = _lableAccess.GetByNoteId(noteId);
      List<LabelDTO> resultList = new List<LabelDTO>();
      if (labels != null && labels.Count > 0)
      {
        foreach (LabelDTO labelDto in labels)
        {
          Label label;
          label = labelsFromDb.FirstOrDefault(l => l.id == labelDto.id && l.noteId == noteId);
          if (label == null && labelDto.id == null)
          {
            label = _lableAccess.AddLabel(labelDto.toEntity(noteId));
            resultList.Add(new LabelDTO(label));
          }
          else if (label == null)
          {
            _lableAccess.DeleteLabel(labelDto.id);
          }
        }
      }
      return resultList;
    }

    public List<Label> SearchLabelByText(List<string> labels)
    {
      return _lableAccess.searchNotesByLabels(labels);
    }
  }
}