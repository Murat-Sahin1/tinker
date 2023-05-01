using Microsoft.AspNetCore.Mvc;
using tinker.Application.DTOs.FileDtos;
using tinker.Application.Interfaces.Repositories;
using tinker.Infrastructure;
using tinker.Infrastructure.ScriptHandlers;

namespace tinker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileHandlerRepository _fileHandlerRepository;
        public FileController(IFileHandlerRepository fileHandlerRepository)
        {
            _fileHandlerRepository = fileHandlerRepository;
        }

        [HttpPost("Upload")]
        public async Task<string> UploadFile([FromForm] FileUpload objfile)
        {
            return await _fileHandlerRepository.UploadFormWithFile(objfile);
        }

        [HttpGet]

        public string ReadFileOutput()
        {
            return _fileHandlerRepository.ReadFileUpload();
        }
    }
} 
