using GoogleTranslate.Application.DTOs;

namespace GoogleTranslate.Application.Contracts.Infrastructure
{
    public interface IGoogleTranslateService
    {
        Task<string> TranslateText(TranslateRequest translateRequest);
        Task<List<ListLanguagesResponse>> GetLanguagesList();
    }
}
