using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        // Endpoint utilisé par le UI React.
        public ActionResult Post(IFormFile fileContent)
        {
            if (fileContent == null)
            {
                return NotFound();
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

            // Logs
            _logger.LogInformation($"Prediction : {prediction.PredictedLabel}");
            foreach (var score in prediction.Score)
            {
                _logger.LogInformation($"Score : {score}");
            }

            // Retourne un JsonResult qui envoie la prédiction au client
            return Ok(prediction.PredictedLabel);
        }
    }
}
