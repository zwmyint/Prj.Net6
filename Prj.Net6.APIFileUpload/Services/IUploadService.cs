using Prj.Net6.APIFileUpload.Entities;
using System.IO;

namespace Prj.Net6.APIFileUpload.Services
{
    public interface IUploadService
    {
        Task<int> UploadFile(IFormFile imageFile, FileModel image);
    }
}
