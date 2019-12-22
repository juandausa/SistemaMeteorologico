using AutoMapper;
using API.Data.Entity;
using API.DTO;
using API.DTO.Response;
using API.DTO.Request;

namespace API.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
        }
    }
}
