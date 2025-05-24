using Google.Cloud.Translation.V2;

namespace GoogleTranslate.App.Contracts
{
    public interface IGoogleTranslatorService
    {
        Task<string> TranslateText(string sourceLanguage, string targetLanguage, string textToTranslate);
        Task<List<Language>> GetLanguagesList();
    }
}
