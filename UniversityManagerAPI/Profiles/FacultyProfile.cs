using AutoMapper;
using UniversityManagerAPI.DTO;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Profiles
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile() 
        {
            CreateMap<FacultyRequestPostDTO, Faculty>();
            CreateMap<FacultyRequestPutDTO, Faculty>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
