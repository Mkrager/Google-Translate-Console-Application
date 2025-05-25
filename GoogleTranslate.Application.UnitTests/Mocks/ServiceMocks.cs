using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Application.DTOs;
using Moq;

namespace GoogleTranslate.Application.UnitTests.Mocks
{
    public class ServiceMocks
    {
        public static Mock<IGoogleTranslateService> GetGoogleTranslateService()
        {
            var languages = new List<LanguageResponse>
            {
                new LanguageResponse { Name = "Ukrainian", Code = "uk" },
                new LanguageResponse { Name = "French", Code = "fr" },
                new LanguageResponse { Name = "English", Code = "en" },
            };

            var mockService = new Mock<IGoogleTranslateService>();

            mockService.Setup(s => s.GetLanguagesList())
                .ReturnsAsync(languages);

            mockService.Setup(s => s.TranslateText(It.IsAny<TranslateRequest>()))
                       .ReturnsAsync("Привіт");

            return mockService;
        }
    }
}
