namespace GoogleTranslate.Application.DTOs
{
    public class TranslateRequest
    {
        public string SourceLanguage { get; set; } = string.Empty;
        public string TargetLanguage { get; set; } = string.Empty;
        public string TextToTranslate { get; set; } = string.Empty;
    }
}
