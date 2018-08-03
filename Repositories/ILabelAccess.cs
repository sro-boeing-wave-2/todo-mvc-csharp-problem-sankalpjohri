using System.Collections.Generic;
using todo_mvc_csharp_problem_sankalpjohri.Entities;

namespace todo_mvc_csharp_problem_sankalpjohri.Repositories
{
  public interface ILabelAccess<TEntity, TU>
  {
    /**
     * Repository method to get labels by note id.
     */
    List<Label> GetByNoteId(long noteId);

    /**
     * Repository method to add a label
     */
    Label AddLabel(Label label);

    /**
     * Repository method to delete a label
     */
    int DeleteLabel(long id);
  }
}