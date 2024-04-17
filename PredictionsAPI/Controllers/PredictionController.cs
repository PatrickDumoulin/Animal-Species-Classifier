using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using System.Net;
using System.Reflection.Metadata;

namespace PredictionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> _predictionEnginePool;
        private readonly ILogger<PredictionController> _logger;
        public PredictionController(PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool, ILogger<PredictionController> logger)
        {
            _predictionEnginePool = predictionEnginePool;
            _logger = logger;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(IFormFile fileContent)
        {
            byte[] fileData;
            using (var ms = new MemoryStream())
            {
                fileContent.CopyTo(ms);
                var fileBytes = ms.ToArray();
                fileData = fileBytes;
            }

            var input = new MLModel.ModelInput()
            {
                ImageSource = fileData,
            };

            var prediction = _predictionEnginePool.Predict(input);

            _logger.LogInformation($"Prediction : {prediction.PredictedLabel}");

            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
