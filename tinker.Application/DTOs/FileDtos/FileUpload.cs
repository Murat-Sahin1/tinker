using Microsoft.AspNetCore.Http;

namespace tinker.Application.DTOs.FileDtos
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
