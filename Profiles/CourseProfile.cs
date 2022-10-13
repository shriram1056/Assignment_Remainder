using AutoMapper;
using AsnRemainderAPI.DTO;
using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Profiles
{
  public class CourseProfile : Profile
  {
    public CourseProfile()
    {
      CreateMap<Course, CourseReadDto>();
      CreateMap<CourseCreateDto, Course>();
      CreateMap<CourseUpdateDto, Course>();
    }
  }
}