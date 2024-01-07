using AutoMapper;
using project.business.DTOs.CategoryDto;
using project.business.DTOs.MemberDto;
using project.business.DTOs.PortifolioDto;
using project.business.DTOs.ProfesiionDto;
using project.core.Entities;

namespace project.business.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MemberCreateDto, Member>().ReverseMap();
            CreateMap<MemberGetDto, Member>().ReverseMap();
            CreateMap<MemberUpdateDto, Member>().ReverseMap();


            CreateMap<ProfessionCreateDto, Profession>().ReverseMap();
            CreateMap<ProfessionGetDto, Profession>().ReverseMap();
            CreateMap<ProfessionUpdateDto, Profession>().ReverseMap();

            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategorygetDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<PortifolioCreateDto, Portifolio>().ReverseMap();
            CreateMap<PortifolioGetDto, Portifolio>().ReverseMap();
            CreateMap<PortifolioUpdateDto, Portifolio>().ReverseMap();
        }
    }
}
