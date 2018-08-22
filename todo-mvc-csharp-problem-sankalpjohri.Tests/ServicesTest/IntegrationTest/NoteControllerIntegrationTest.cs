using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Bson;
using Newtonsoft.Json;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Models;
using Xunit;

namespace todo_mvc_csharp_problem_sankalpjohri.Tests.ServicesTest.IntegrationTest
{
  public class NoteControllerIntegrationTest
  {
    // Variable for server
    private TestServer _testServer;
    private HttpClient _client;

    // Data variables
    private NoteDTO actual, expected;
    private Note note;
    private long noteId;
    private List<ChecklistItemDTO> checklistItemDtos;
    private List<LabelDTO> labelDtos;

    /**
     * Setting up the data for the tests
     */
    public NoteControllerIntegrationTest()
    {
      _testServer = new TestServer(
        new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>()
      );
      _client = _testServer.CreateClient();
      note = SetupNote();
      actual = SetupNoteDTO();
      expected = SetupNoteDTO();
    }

    private NoteDTO SetupNoteDTO()
    {
      NoteDTO noteDto = new NoteDTO();
      noteDto.id = ObjectId.GenerateNewId().ToString();
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
      note.id = ObjectId.GenerateNewId();
      note.title = "Title";
      note.text = "Test Text";
      note.isPinned = true;
      return note;
    }

    [Fact]
    public async void Integeration_Test_CreateNote_Success()
    {
      var response = await _client.PostAsync("/api/note",
        new StringContent(JsonConvert.SerializeObject(expected),
          Encoding.UTF8, "application/json"));
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      NoteDTO actualResponse = JsonConvert.DeserializeObject<NoteDTO>(actualResponseString);
      Assert.Equal(actualResponse, expected);
    }

    [Fact]
    public async void Integeration_Test_GetNote_Success()
    {
      var response = await _client.GetAsync("/api/note");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      List<NoteDTO> actualResponse = JsonConvert.DeserializeObject<List<NoteDTO>>(actualResponseString);
      Assert.Empty(actualResponse);
    }

    [Fact]
    public async void Integration_Test_EditNote_Success()
    {
      var response = await _client.PutAsync("/api/note/1",
        new StringContent(JsonConvert.SerializeObject(expected),
          Encoding.UTF8, "application/json"));
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      NoteDTO actualResponse = JsonConvert.DeserializeObject<NoteDTO>(actualResponseString);
      Assert.Null(actualResponse);
    }

    [Fact]
    public async void Integeration_Test_SearchTitle_Success()
    {
      var response = await _client.GetAsync("/api/note/search/title?query=title");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      List<NoteDTO> actualResponse = JsonConvert.DeserializeObject<List<NoteDTO>>(actualResponseString);
      Assert.Empty(actualResponse);
    }

    [Fact]
    public async void Integeration_Test_SearchLabel_Success()
    {
      var response = await _client.GetAsync("/api/note/search/label?query=test");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      List<NoteDTO> actualResponse = JsonConvert.DeserializeObject<List<NoteDTO>>(actualResponseString);
      Assert.Empty(actualResponse);
    }

    [Fact]
    public async void Integeration_Test_GetNoteById_Success()
    {
      var response = await _client.GetAsync("/api/note/1");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      NoteDTO actualResponse = JsonConvert.DeserializeObject<NoteDTO>(actualResponseString);
      Assert.Null(actualResponse);
    }

    [Fact]
    public async void Integeration_Test_DeleteNote_Success()
    {
      var response = await _client.DeleteAsync("/api/note?ids=1");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      bool actualResponse = JsonConvert.DeserializeObject<bool>(actualResponseString);
      Assert.False(actualResponse);
    }

    [Fact]
    public async void Integeration_Test_PinnedNotes_Success()
    {
      var response = await _client.GetAsync("/api/note/search/pinned");
      response.EnsureSuccessStatusCode();
      string actualResponseString = await response.Content.ReadAsStringAsync();
      List<NoteDTO> actualResponse = JsonConvert.DeserializeObject<List<NoteDTO>>(actualResponseString);
      Assert.Empty(actualResponse);
    }
  }
}