using AutoMapper;
using AsnRemainderAPI.DTO;
using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Profiles
{
  public class AutomapperProfile : Profile
  {
    public AutomapperProfile()
    {

      CreateMap<Assignment, AssignmentReadDto>();
      CreateMap<AssignmentCreateDto, Assignment>();
      CreateMap<AssignmentUpdateDto, Assignment>();
      CreateMap<Course, CourseReadDto>();
      CreateMap<CourseCreateDto, Course>();
      CreateMap<CourseUpdateDto, Course>();
    }
  }
}