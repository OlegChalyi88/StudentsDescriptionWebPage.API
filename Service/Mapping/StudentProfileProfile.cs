using AutoMapper;
using Repository.Models.DataTransferObject;
using Repository.Models.Domain;

namespace Service.Mapping;

public class StudentProfileProfile : Profile
{
    public StudentProfileProfile()
    {
        CreateMap<StudentProfileEditRequestDto, StudentProfile>();
    }
}
