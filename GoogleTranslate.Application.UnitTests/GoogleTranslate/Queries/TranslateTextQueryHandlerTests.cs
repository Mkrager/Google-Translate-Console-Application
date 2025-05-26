using AutoMapper;
using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Application.Exceptions;
using GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText;
using GoogleTranslate.Application.Profiles;
using GoogleTranslate.Application.UnitTests.Mocks;
using Moq;

namespace GoogleTranslate.Application.UnitTests.GoogleTranslate.Queries
{
    public class TranslateTextQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGoogleTranslateService> _googleTranslateService;

        public TranslateTextQueryHandlerTests()
        {
            _googleTranslateService = ServiceMocks.GetGoogleTranslateService();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handler_WhenCalled_MustTranslateText()
        {
            var handler = new TranslateTextQueryHandler(_googleTranslateService.Object, _mapper);

            var query = new TranslateTextQuery
            {
                SourceLanguage = "en",
                TargetLanguage = "uk",
                TextToTranslate = "Hello"
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Привіт", result);
        }

        [Fact]
        public async Task Handler_WhenValidationFails_ThrowsValidationException()
        {
            var handler = new TranslateTextQueryHandler(_googleTranslateService.Object, _mapper);

            var invalidQuery = new TranslateTextQuery
            {
                SourceLanguage = "",
                TargetLanguage = "uk",
                TextToTranslate = "Hello"
            };

            await Assert.ThrowsAsync<ValidationException>(() =>
                handler.Handle(invalidQuery, CancellationToken.None));
        }
    }
}
