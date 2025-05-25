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

            RuleFor(t => t.TargetLanguage)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(t => t.SourceLanguage)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
