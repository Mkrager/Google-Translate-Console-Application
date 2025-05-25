using FluentValidation;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText
{
    public class TranslateTextQueryValidator : AbstractValidator<TranslateTextQuery>
    {
        public TranslateTextQueryValidator()
        {
            RuleFor(t => t.TextToTranslate)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(t => t.targetLanguage)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(t => t.sourceLanguage)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
