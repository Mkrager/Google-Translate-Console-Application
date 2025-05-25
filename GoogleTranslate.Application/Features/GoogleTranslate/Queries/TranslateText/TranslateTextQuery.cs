using MediatR;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText
{
    public class TranslateTextQuery : IRequest<string>
    {
        public string sourceLanguage { get; set; } = string.Empty;
        public string targetLanguage { get; set; } = string.Empty;
        public string TextToTranslate { get; set; } = string.Empty;
    }
}
