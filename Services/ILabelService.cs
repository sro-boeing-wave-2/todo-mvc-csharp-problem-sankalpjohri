using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;

namespace todo_mvc_csharp_problem_sankalpjohri.Services
{
  public interface ILabelService
  {
    /**
     * Service method to get labels by note id.
     */
    List<LabelDTO> FindByNoteId(long noteId);

    /**
     * Service method to add labels for a note.
     */
    List<LabelDTO> AddLabelsForNote(long noteId, List<LabelDTO> labels);
    
    /**
     * Service method to update labels for a note.
     */
    List<LabelDTO> UpdateLabelsForNote(long noteId, List<LabelDTO> labels);

    /**
     * Method to get list of labels by text
     */
    List<Label> SearchLabelByText(List<string> labels);
  }
}