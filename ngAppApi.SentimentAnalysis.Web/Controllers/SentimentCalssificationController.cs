using Microsoft.AspNetCore.Mvc;
using ngAppApi.Core.Cqs;
using ngAppApi.SentimentAnalysis.Models;
using ngAppApi.SentimentAnalysis.Queries;

namespace ngAppApi.SentimentAnalysis.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SentimentCalssificationController : ControllerBase
    {
        private readonly ICqsDispatcher _cqsDispatcher;
        public SentimentCalssificationController(ICqsDispatcher cqsDispatcher)
        {
            _cqsDispatcher = cqsDispatcher;
        }

        [HttpGet("get-sentiment-result")]
        public async Task<ActionResult<ClassificationResultModel>> Get(string sentence)
        {
            var query = new ClassifySentimentQuery(sentence: sentence);

            var result = await _cqsDispatcher.HandleQueryAsync<ClassifySentimentQuery, ClassificationResultModel>(query);

            return Ok(result);
        }
    }
}
