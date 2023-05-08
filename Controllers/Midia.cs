using System.IO;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotosController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FotosController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "fc-services-ba67f-firebase-adminsdk-nytje-1959376e26.json");

                var storage = StorageClient.Create();
                var filename = $"{DateTime.Now:yyyyMMddHHmmss}-{file.FileName}";
                var bucketName = "fc-services-ba67f.appspot.com";
                var objectName = filename;

                using (var stream = file.OpenReadStream())
                {
                    var contentType = file.ContentType;
                    var result = await storage.UploadObjectAsync(bucketName, objectName, contentType, stream);
                }

                var url = $"https://firebasestorage.googleapis.com/v0/b/{bucketName}/o/{Uri.EscapeDataString(filename)}?alt=media";

                return Ok(new { url });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer upload do arquivo: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

    }
}
