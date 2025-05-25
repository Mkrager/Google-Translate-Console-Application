using AutoMapper;
using GoogleTranslate.Application.Contracts.Infrastructure;
using MediatR;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.GetLanguagesList
{
    public class GetLanguageListQueryHandler : IRequestHandler<GetLanguageListQuery, List<LanguageListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IGoogleTranslateService _googleTranslateService;

        public GetLanguageListQueryHandler(IMapper mapper, IGoogleTranslateService googleTranslateService)
        {
            _googleTranslateService = googleTranslateService;
            _mapper = mapper;
        }
        public async Task<List<LanguageListVm>> Handle(GetLanguageListQuery request, CancellationToken cancellationToken)
        {
            var allLanguages = await _googleTranslateService.GetLanguagesList();
            return _mapper.Map<List<LanguageListVm>>(allLanguages);
        }
    }
}
