using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NunoSolutions.ImageUpload.YT.Models;

namespace NunoSolutions.ImageUpload.YT.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        // api/upload/image
        [HttpPost, Route("image")]
        public FileBundle UploadImage()
        {
            var fileBundle = new FileBundle(Request);
            try
            {
                fileBundle.SaveAs($"D:\\Temp\\{fileBundle.FileName}");
                fileBundle.ReturnMessage = $"{fileBundle.FileName} uploaded successfully.";
            }
            catch (Exception ex)
            {
                fileBundle.ReturnCode = -1;
                fileBundle.ReturnMessage = ex.Message;
            }
            return fileBundle;
        }
    }
}
