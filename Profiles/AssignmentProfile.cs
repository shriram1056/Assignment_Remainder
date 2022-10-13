using AutoMapper;
using AsnRemainderAPI.DTO;
using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Profiles
{
  public class AssignmentProfile : Profile
  {
    public AssignmentProfile(){
CreateMap<Assignment, AssignmentReadDto>();
CreateMap<AssignmentCreateDto, Assignment>();
CreateMap<AssignmentUpdateDto, Assignment>();
    }
    }
}