using AutoMapper;
using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Application.Features.GoogleTranslate.Queries.GetLanguagesList;
using GoogleTranslate.Application.Profiles;
using GoogleTranslate.Application.UnitTests.Mocks;
using Moq;

namespace GoogleTranslate.Application.UnitTests.GoogleTranslate.Queries
{
    public class GetLanguagesListQueryHandlerTests
    {
        private readonly Mock<IGoogleTranslateService> _mockGoogleTranslateService;
        private readonly IMapper _mapper;
        public GetLanguagesListQueryHandlerTests()
        {
            _mockGoogleTranslateService = ServiceMocks.GetGoogleTranslateService();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsListOfLanguages()
        {
            var handler = new GetLanguageListQueryHandler(_mapper, _mockGoogleTranslateService.Object);

            var result = await handler.Handle(new GetLanguageListQuery(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.IsType<List<LanguageListVm>>(result);
        }

        [Fact]
        public async Task Handle_MapsCorrectLanguageName()
        {
            var handler = new GetLanguageListQueryHandler(_mapper, _mockGoogleTranslateService.Object);

            var result = await handler.Handle(new GetLanguageListQuery(), CancellationToken.None);

            var ukrainian = result.FirstOrDefault(x => x.Code == "uk");

            Assert.NotNull(ukrainian);
            Assert.Equal("Ukrainian", ukrainian.Name);
            Assert.Equal("uk", ukrainian.Code);
        }
    }
}
