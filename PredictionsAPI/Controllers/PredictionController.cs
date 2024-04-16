using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using System.Net;

namespace PredictionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        public PredictionController()
        {           
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(IFormFile fileContent)
        {
            //predictionEnginePool.Predict();

            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
