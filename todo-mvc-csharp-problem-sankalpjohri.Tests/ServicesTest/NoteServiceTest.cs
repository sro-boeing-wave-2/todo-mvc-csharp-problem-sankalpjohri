using System.Collections.Generic;
using Moq;
using todo;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;
using Xunit;

namespace todo_mvc_csharp_problem_sankalpjohri.Tests.ServicesTest
{
  public class NoteServiceTest
  {
    private INoteService _noteService;

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
      noteDto.id = 1L;
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
      note.id = 1L;
      note.title = "Title";
      note.text = "Test Text";
      note.isPinned = true;
      return note;
    }

    [Fact]
    public void Test_CreateNote_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.AddNote(It.IsAny<Note>())).Returns(1L);
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.AddLabelsForNote(1, It.IsAny<List<LabelDTO>>())).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.AddCheckListItemsForNote(1L, It.IsAny<List<ChecklistItemDTO>>()))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      actual = _noteService.CreateNote(expected);
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test_GetNote_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.FindByNoteId(1)).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.FindByNoteId(1L))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      actual = _noteService.GetNote(1l);
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test_GetAllNotes_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.GetAllNotes()).Returns(new List<Note>() {note});
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.FindByNoteId(1)).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.FindByNoteId(1L))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      List<NoteDTO> allNotes = new List<NoteDTO>();
      allNotes = _noteService.GetAllNotes();
      actual = allNotes[0];
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test_DeleteNote_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.AddLabelsForNote(1, It.IsAny<List<LabelDTO>>())).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.AddCheckListItemsForNote(1L, It.IsAny<List<ChecklistItemDTO>>()))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      Assert.True(_noteService.DeleteNotes(new List<long>(){1l}));
    }

    [Fact]
    public void Test_EditNote_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.AddLabelsForNote(1, It.IsAny<List<LabelDTO>>())).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.AddCheckListItemsForNote(1L, It.IsAny<List<ChecklistItemDTO>>()))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      actual = _noteService.EditNote(1l ,expected);
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test_GetPinnnedNotes_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      noteAccess.Setup(_ => _.GetPinnedNotes()).Returns(new List<Note>() {note});
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.FindByNoteId(1)).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.FindByNoteId(1L))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      List<NoteDTO> allNotes = new List<NoteDTO>();
      allNotes = _noteService.GetPinnedNotes();
      actual = allNotes[0];
      Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test_GetNotesByTitle_Success()
    {
      Setup();
      var noteAccess = new Mock<INoteAccess<Note,long>>();
      var labelService = new Mock<ILabelService>();
      var checkListItemService = new Mock<ICheckListItemService>();
      
      noteAccess.Setup(_ => _.searchNotesByTitle(It.IsAny<string>())).
        Returns(new List<Note>() {note});
      noteAccess.Setup(_ => _.GetNoteById(It.IsAny<long>())).Returns(note);
      labelService.Setup(l => l.FindByNoteId(1)).Returns(new List<LabelDTO>());
      checkListItemService.Setup(c => c.FindByNoteId(1L))
        .Returns(new List<ChecklistItemDTO>());
      _noteService = new NoteService(noteAccess.Object, labelService.Object, checkListItemService.Object);
      List<NoteDTO> allNotes = new List<NoteDTO>();
      allNotes = _noteService.SearchNotesByTitle("Test Note");
      actual = allNotes[0];
      Assert.Equal(actual, expected);
    }
  }
}