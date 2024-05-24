using AutoMapper;
using SE130ApiTestProject.Data.Dto.Lector;
using SE130ApiTestProject.Data.Dto.Student;
using SE130ApiTestProject.Data.Models;

namespace SE130ApiTestProject
{
    public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Lector,LectorCreateDTO>().ReverseMap();
            CreateMap<Lector,LectorUpdateDTO>().ReverseMap();
            CreateMap<Student,StudentCreateDTO>().ReverseMap();
            CreateMap<Student,StudentUpdateDTO>().ReverseMap();
        }
    }
}
