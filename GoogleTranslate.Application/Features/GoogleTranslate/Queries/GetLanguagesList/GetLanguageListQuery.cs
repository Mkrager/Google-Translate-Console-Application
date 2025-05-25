using MediatR;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.GetLanguagesList
{
    public class GetLanguageListQuery : IRequest<List<LanguageListVm>>
    {
    }
}
