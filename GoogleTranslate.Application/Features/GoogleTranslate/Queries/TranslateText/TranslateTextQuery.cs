using MediatR;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText
{
    public class TranslateTextQuery : IRequest<string>
    {
        public string SourceLanguage { get; set; } = string.Empty;
        public string TargetLanguage { get; set; } = string.Empty;
        public string TextToTranslate { get; set; } = string.Empty;
    }
}
