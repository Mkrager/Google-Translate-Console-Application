using GoogleTranslate.Application.Features.GoogleTranslate.Queries.GetLanguagesList;
using GoogleTranslate.Application.Features.GoogleTranslate.Queries.TranslateText;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoogleTranslate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleTranslateController(IMediator mediator) : Controller
    {
        [HttpGet("languages", Name = "GetAllLanguages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<LanguageListVm>>> GetAllLanguages()
        {
            var dtos = await mediator.Send(new GetLanguageListQuery());
            return Ok(dtos);
        }

        [HttpGet("translate", Name = "TranslateText")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<string>> TranslateText(
            string sourceLanguage, 
            string targetLanguage, 
            string textToTranslate)
        {
            var dtos = await mediator.Send(new TranslateTextQuery()
            {
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage,
                TextToTranslate = textToTranslate
            });

            return Ok(dtos);
        }

    }
}