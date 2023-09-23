using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.RepositoryLayer;
using MiskProgramTask.RepositoryLayer.Application;
using MiskProgramTask.RepositoryLayer.WorkFlow;
using MiskProgramTask.ServiceLayer;
using MiskProgramTask.ServiceLayer.Application;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.WorkFlow;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IWorkFlowRepository, WorkFlowRepository>();
builder.Services.AddScoped<IWorkFlowService, WorkFlowService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    //Local development
    options.UseCosmos(
        "https://localhost:8081",
        "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        "MiskDB"
    );
});
var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();