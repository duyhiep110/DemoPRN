using AutoMapper;
using DemoPRN.Dtos.Company;
using DemoPRN.Dtos.Employee;

namespace DemoPRN.Dtos.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Company, CompanyDto>().ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Models.Employee, EmployeeDto>();

            CreateMap<CompanyForCreateDto, Models.Company>();

            CreateMap<CompanyForUpdateDto, Models.Company>();
            CreateMap<EmployeeForCreateDto, Models.Employee>();
            CreateMap<EmployeeForUpdateDto, Models.Employee>();
        }
    }
}
