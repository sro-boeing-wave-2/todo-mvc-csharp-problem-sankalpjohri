using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using todo_mvc_csharp_problem_sankalpjohri.Connectors;
using todo_mvc_csharp_problem_sankalpjohri.Entities;
using todo_mvc_csharp_problem_sankalpjohri.Repositories;
using todo_mvc_csharp_problem_sankalpjohri.Services;
using MySql.Data.EntityFrameworkCore;
using todo;

namespace todo_mvc_csharp_problem_sankalpjohri
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddScoped<INoteService, NoteService>();
      services.AddScoped<INoteAccess<Note, long>, NoteAccess>();
      services.AddScoped<ILabelService, LabelService>();
      services.AddScoped<ILabelAccess<Label, long>, LabelAccess>();
      services.AddScoped<ICheckListItemService, CheckListItemService>();
      services.AddScoped<ICheckListAccess<ChecklistItem, long>, CheckListItemAccess>();
      services.AddDbContext<NotesContext>(opts =>
        opts.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
     }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
      app.UseMvc();
    }
  }
}