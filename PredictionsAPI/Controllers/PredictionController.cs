using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

        // Endpoint utilisé par le UI React
        [HttpPost]
        public async Task<HttpResponseMessage> Post(IFormFile fileContent)
        {
            if(fileContent == null)
            {
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            // Transforme le fichier en byte
            byte[] fileData;            
            using (var ms = new MemoryStream())
            {
                fileContent.CopyTo(ms);
                var fileBytes = ms.ToArray();
                fileData = fileBytes;
            }

            // Créé instance du modèle
            var input = new MLModel.ModelInput()
            {
                ImageSource = fileData,
            };

            // Fait la prédiction de l'image
            var prediction = _predictionEnginePool.Predict(input);

            _logger.LogInformation($"Prediction : {prediction.PredictedLabel}");

            // Message qui retourne vers l'UI React
            return await Task.FromResult(new HttpResponseMessage
            {
                Content = new StringContent(prediction.PredictedLabel, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK,
            });
        }
    }
}
