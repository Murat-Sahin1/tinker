using Microsoft.AspNetCore.Http;

namespace tinker.Application.DTOs.FileDtos
{
    public class FileUpload
    {
        public IFormFile modelFile { get; set; }
        public string inputType { get; set; }
        public IFormFile inputFile { get; set; }
        public bool willNormalize { get; set; }
    }
}
