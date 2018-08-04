using System.Collections.Generic;
using Moq;
using todo;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using Xunit;

namespace todo_mvc_csharp_problem_sankalpjohri.Tests.ServicesTest
{
  public class NoteServiceTest
  {
    private NoteDTO actual, expected;
    private Note note;
    private long noteId;
    private List<ChecklistItemDTO> checklistItemDtos;
    private List<LabelDTO> labelDtos;
    
    /**
     * Setting up the data for the tests
     */
    public void Setup()
    {
      
      note = SetupNote();
      actual = SetupNoteDTO();
      expected = SetupNoteDTO();
    }

     
    
    private NoteDTO SetupNoteDTO()
    {
      NoteDTO noteDto = new NoteDTO();
      noteDto.id = 0;
      noteDto.text = "Test Text";
      noteDto.title = "Test Title";
      noteDto.isPinned = true;
      noteDto.labels = new List<LabelDTO>();
      noteDto.checklist = new List<ChecklistItemDTO>();
      return noteDto;
    }

    private Note SetupNote()
    {
      Note note = new Note();
      note.id = 1;
      note.title = "Title";
      note.text = "Test Text";
      note.isPinned = true;
      return note;
    }
    
    [Fact]
    public void Test_CreateNote_Success()
    {
      var noteService = new Mock<NoteService>();
      var noteAccess = new Mock<NoteAccess>();
      noteAccess.Setup(_ => _.AddNote(It.IsAny<Note>())).Returns(1L);
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(actual.toEntity());
      //actual = noteService.
    }
    
    [Fact]
    public void Test_GetNote_Success()
    {
      
    }
    
    [Fact]
    public void Test_GetAllNotes_Success()
    {
      
    }
    
    [Fact]
    public void Test_DeleteNote_Success()
    {
      
    }
    
    [Fact]
    public void Test_EditNote_Success()
    {
      
    }
    
    [Fact]
    public void Test_GetNotesByLabels_Success()
    {
      
    }
    
    [Fact]
    public void Test_GetPinnnedNotes_Success()
    {
      
    }
    
    [Fact]
    public void Test_GetNotesByTitle_Success()
    {
      
    }
    
  }
}