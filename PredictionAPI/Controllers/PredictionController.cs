using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using System.Net;

namespace PredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post(MultipartFormDataContent content)
        {

            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
