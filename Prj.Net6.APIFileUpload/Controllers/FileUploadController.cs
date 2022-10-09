using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prj.Net6.APIFileUpload.Entities;
using Prj.Net6.APIFileUpload.Services;

namespace Prj.Net6.APIFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        IUploadService _fileUploadService;

        public FileUploadController(IUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost, Route("UploadFile")]
        public async Task<ErrorModel> UploadFileTo(
            IFormFile imageFile, [FromForm] FileModel image)
        {
            try
            {
                var imageupload = await _fileUploadService.UploadFile(imageFile, image);
                if (imageupload < 1)
                {
                    return new ErrorModel { ErrMessage = "Unable to upload your Image", Status = imageupload };
                }
                return new ErrorModel { ErrMessage = "Image Uploaded Successfully", Status = imageupload };
            }
            catch (Exception ex)
            {
                return new ErrorModel { ErrMessage = ex.Message, Status = 0 };
            }
        }

        //To see if your image is correctly saved,
        //1. copy the base64string value in your table column SavedFile
        //2. Go to https://codebeautify.org/base64-to-image-converter and paste the string and your image should display

    }
}
