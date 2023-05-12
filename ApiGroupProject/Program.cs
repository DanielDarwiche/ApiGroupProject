using ApiGroupProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//implementing repository pattern below:
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepo>();
builder.Services.AddScoped<IProjectRepository, ProjectRepo>();
builder.Services.AddScoped<ITimeReportRepository, TimeReportRepo>();


builder.Services.AddDbContext<WarriorContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
