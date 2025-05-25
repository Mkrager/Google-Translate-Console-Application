using AutoMapper;
using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Application.DTOs;
using GoogleTranslate.Application.Exceptions;
using MediatR;

namespace GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText
{
    public class TranslateTextQueryHandler : IRequestHandler<TranslateTextQuery, string>
    {
        private readonly IGoogleTranslateService _googleTranslateService;
        private readonly IMapper _mapper;

        public TranslateTextQueryHandler(IGoogleTranslateService googleTranslateService, IMapper mapper)
        {
            _googleTranslateService = googleTranslateService;
            _mapper = mapper;
        }

        public async Task<string> Handle(TranslateTextQuery request, CancellationToken cancellationToken)
        {
            var validator = new TranslateTextQueryValidator();

            var validationResult =  await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            return await _googleTranslateService.TranslateText(_mapper.Map<TranslateRequest>(request));
        }
    }
}
