using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Prj.Net6.APIFileUpload.Entities;
using System.Data;

namespace Prj.Net6.APIFileUpload.Services
{
    public class FileUploadService : IUploadService
    {
        private readonly IOptions<ReaderModel> _option;
        public FileUploadService(IOptions<ReaderModel> options)
        {
            _option = options;
        }
        public async Task<int> UploadFile(IFormFile imageFile, FileModel image)
        {
            string filePath = Path.GetTempFileName();
            using (var stream = File.Create(filePath))
            {
                await imageFile.CopyToAsync(stream);
            }
            // Converts image file into byte[]
            byte[] imageData = await File.ReadAllBytesAsync(filePath);

            using (var connection = new SqlConnection(_option.Value.DefaultConnection))
            {
                await connection.OpenAsync();

                // created uspUpload SP in DB
                int result = await connection.ExecuteAsync("uspUpload", new
                {
                    filename = image.FileName,
                    filetype = image.FileType,
                    imageData = Convert.ToBase64String(imageData)
                }, commandType: CommandType.StoredProcedure);

                await connection.CloseAsync();
                connection.Dispose();
                return result;
            }
        }
    }
}
