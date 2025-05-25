namespace GoogleTranslate.Application.DTOs
{
    public class TranslateRequest
    {
        public string sourceLanguage { get; set; } = string.Empty;
        public string targetLanguage { get; set; } = string.Empty;
        public string TextToTranslate { get; set; } = string.Empty;
    }
}
