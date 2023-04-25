﻿using Microsoft.AspNetCore.Mvc;
using tinker.Infrastructure;

namespace tinker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost("Upload")]
        public async Task<string> UploadFile([FromForm] FileUpload objfile)
        {
            Console.WriteLine(objfile);
            string filename = "";
            string extension = "";
            if(objfile.Files.Length> 0)
            {
                var file = objfile.Files;
                try
                {
                    extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
                    filename = file.FileName.Split('.')[file.FileName.Split('.').Length - 2];

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles");

                    if (!Directory.Exists(filePath))
                    {
                        Console.Write("File upload directory couldn't be find, creating a new one...");
                        Directory.CreateDirectory(filePath);
                    }

                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles", filename);

                    using (var stream = new FileStream(exactPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Error is occured while trying to upload a file.");
                    return ex.Message;
                }
            }
            
            return filename + extension;
        }
    }
}
