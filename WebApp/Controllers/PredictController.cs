using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class PredictController : ApiController
    {
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostFormData(PredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput> predictionEnginePool)
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //string root = HttpContext.Current.Server.MapPath("~/App_Data");
            //var provider = new MultipartFormDataStreamProvider(root);

            var input = new MLModel1.ModelInput()
            {
                ImageSource = File.ReadAllBytes(@"C:Users\Goglu\source\repos\VeilleTechnoTP2V2\Animals\Fox\01c58020-9388-11ee-8319-bdafcbf63490.jpg"),
            };

            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
