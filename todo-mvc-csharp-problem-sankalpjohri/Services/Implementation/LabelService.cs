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
      List<LabelDTO> tobeAdded = labels.Where(label => label.id == 0).Select(label => label).ToList();
      AddLabelsForNote(noteId, tobeAdded);
      List<LabelDTO> toBeDeleted = labelsFromDb.Where(label => !labels.Contains(new LabelDTO(label)))
        .Select(label => new LabelDTO(label)).ToList();
      DeleteLabelsForNote(noteId, toBeDeleted);
      return _lableAccess.GetByNoteId(noteId).Select(label => new LabelDTO(label)).ToList();
    }

    public List<Label> SearchLabelByText(List<string> labels)
    {
      return _lableAccess.searchNotesByLabels(labels);
    }

    public void DeleteLabelsForNote(long noteId, List<LabelDTO> labels)
    {
      if (labels != null && labels.Count > 0)
      {
        List<long> labelIds = labels.Select(label => label.id).ToList();
        _lableAccess.DeleteLabel(labelIds);
      }
    }
  }
}