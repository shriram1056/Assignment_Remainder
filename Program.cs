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

app.MapGet("api/v1/assignments", async (IAssignmentRepo repo, IMapper mapper) =>
{
  var assignments = await repo.GetAllAssignments();
  return Results.Ok((mapper.Map<IEnumerable<AssignmentReadDto>>(assignments)));
});

app.MapGet("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id) =>
{
  var course = await repo.GetCourseById(id);
  if (course != null)
  {
    return Results.Ok(mapper.Map<CourseReadDto>(course));
  }
  return Results.NotFound();
});

app.MapGet("api/v1/assignments/{id}", async (IAssignmentRepo repo, IMapper mapper, int id) =>
{
  var assignment = await repo.GetAssignmentById(id);
  if (assignment != null)
  {
    return Results.Ok(mapper.Map<AssignmentReadDto>(assignment));
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

app.MapPost("api/v1/assignments", async (IAssignmentRepo repo, IMapper mapper, AssignmentCreateDto assignmentCreateDto) =>
{
  var assignmentModel = mapper.Map<Assignment>(assignmentCreateDto);
  assignmentModel.DueDate = DateTime.Now;
  await repo.CreateAssignment(assignmentModel);
  await repo.SaveChanges();

  var assignmentReadDto = mapper.Map<AssignmentReadDto>(assignmentModel);

  return Results.Created($"api/v1/commands/{assignmentReadDto.Id}", assignmentReadDto);

});

app.MapPut("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id, CourseUpdateDto courseUpdateDto) =>
{
  var course = await repo.GetCourseById(id);
  if (course == null)
  {
    return Results.NotFound();
  }

  mapper.Map(courseUpdateDto, course);

  await repo.SaveChanges();

  return Results.NoContent();
});

app.MapPut("api/v1/assignments/{id}", async (IAssignmentRepo repo, IMapper mapper, int id, AssignmentUpdateDto assignmentUpdateDto) =>
{
  var assignment = await repo.GetAssignmentById(id);
  if (assignment == null)
  {
    return Results.NotFound();
  }

  mapper.Map(assignmentUpdateDto, assignment);

  await repo.SaveChanges();

  return Results.NoContent();
});

app.MapDelete("api/v1/courses/{id}", async (ICourseRepo repo, IMapper mapper, int id) =>
{
  var course = await repo.GetCourseById(id);
  if (course == null)
  {
    return Results.NotFound();
  }

  repo.DeleteCourse(course);

  await repo.SaveChanges();

  return Results.NoContent();

});

app.MapDelete("api/v1/assignments/{id}", async (IAssignmentRepo repo, IMapper mapper, int id) =>
{
  var assignment = await repo.GetAssignmentById(id);
  if (assignment == null)
  {
    return Results.NotFound();
  }

  repo.DeleteAssignment(assignment);

  await repo.SaveChanges();

  return Results.NoContent();

});

app.Run();
