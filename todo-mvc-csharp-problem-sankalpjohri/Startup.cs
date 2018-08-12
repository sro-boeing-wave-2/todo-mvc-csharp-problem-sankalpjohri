using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Swagger;


using todo;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Repositories.MongoRepositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;

namespace todo_mvc_csharp_problem_sankalpjohri
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IHostingEnvironment _currentEnvironment)
    {
      Configuration = configuration;
      this._currentEnvironment = _currentEnvironment;
    }
    
    public IConfiguration Configuration { get; }
    public IHostingEnvironment _currentEnvironment { get; }
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddScoped<INoteService, NoteService>();
      services.AddScoped<INoteAccess<Note, ObjectId>, NoteAccessMongo>();      
      services.AddScoped<INoteAccess<Note, long>, NoteAccess>();
      services.AddScoped<ILabelService, LabelService>();
      services.AddScoped<ILabelAccess<Label, long>, LabelAccess>();
      services.AddScoped<ICheckListItemService, CheckListItemService>();
      services.AddScoped<ICheckListAccess<ChecklistItem, long>, CheckListItemAccess>();
      if (_currentEnvironment.EnvironmentName.Equals("Testing"))
      {
        services.AddDbContext<NotesContext>(opts =>
          opts.UseInMemoryDatabase("TestDB"));
      }
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Todo API\'s", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request ipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseSwagger();
      
      app.UseSwaggerUI(c =>
      { 
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API\'s v1");
      });
      
      app.UseMvc();
    }
  }
}