using GoogleTranslate.App.Models;

namespace GoogleTranslate.App.Contracts
{
    public interface IGoogleTranslatorService
    {
        Task<string> TranslateText(string sourceLanguage, string targetLanguage, string textToTranslate);
        Task<List<LanguageViewModel>> GetLanguagesList();
    }
}
