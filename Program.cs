using AsnRemainderAPI.Data;
using AsnRemainderAPI.DTO;
using AsnRemainderAPI.Models;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();

sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConBuilder.UserID = builder.Configuration["UserId"];
sqlConBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/courses", async (ICourseRepo repo, IMapper mapper) =>
{
  var courses = await repo.GetAllCourses();
  return Results.Ok((mapper.Map<IEnumerable<CourseReadDto>>(courses)));
});

app.MapGet("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id) =>
{
  var course = await repo.GetCourseById(id);
  if (course?.CourseName != null)
  {
    return Results.Ok(mapper.Map<CourseReadDto>(course));
  }
  return Results.NotFound();
});

app.MapPost("api/v1/courses", async (ICourseRepo repo, IMapper mapper, CourseCreateDto courseCreateDto) =>
{
  var courseModel = mapper.Map<Course>(courseCreateDto);

  await repo.CreateCourse(courseModel);
  await repo.SaveChanges();

  var courseReadDto = mapper.Map<CourseReadDto>(courseModel);

  return Results.Created($"api/v1/commands/{courseReadDto.Id}", courseReadDto);

});

app.MapPut("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id, CourseUpdateDto courseUpdateDto) =>
{
  var command = await repo.GetCourseById(id);
  if (command == null)
  {
    return Results.NotFound();
  }

  mapper.Map(courseUpdateDto, command);

  await repo.SaveChanges();

  return Results.NoContent();
});

app.MapDelete("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id) =>
{
  var command = await repo.GetCourseById(id);
  if (command == null)
  {
    return Results.NotFound();
  }

  repo.DeleteCourse(command);

  await repo.SaveChanges();

  return Results.NoContent();

});
app.Run();
