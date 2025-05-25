using AutoMapper;
using GoogleTranslate.Application.DTOs;
using GoogleTranslate.Application.Features.GoogleTranslate.Queries.GetLanguagesList;
using GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText;

namespace GoogleTranslate.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TranslateRequest, TranslateTextQuery>().ReverseMap();
            CreateMap<LanguageResponse, LanguageListVm>().ReverseMap();
        }
    }
}
