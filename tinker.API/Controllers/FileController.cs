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

        [DisableRequestSizeLimit]
        [HttpPost("Upload")]
        public async Task<string> UploadFile([FromForm] FileUpload objfile)
        {
            return await _fileHandlerRepository.UploadFormWithFile(objfile);
        }

        [HttpPost("Execute")]
        public string ReadFileOutput([FromForm] FileExecute executingDetails)
        {
            return _fileHandlerRepository.ExecuteModel(executingDetails.FileName, executingDetails.InputName);
        }
    }
} 
