using tinker.Application.DTOs.FileDtos;
using tinker.Application.Interfaces.Repositories;
using tinker.Infrastructure.ScriptHandlers;

namespace tinker.Infrastructure.Repositories
{
    public class FileHandlerRepository : IFileHandlerRepository
    {
        

        public async Task<string> UploadFormWithFile(FileUpload form)
        {
            Console.WriteLine(form);
            string filename = "";
            string extension = "";
            if (form.Files.Length > 0)
            {
                var file = form.Files;
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

                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles", filename + extension);

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

        public string ReadFileUpload()
        {
            return PythonScriptHandler.Exec_Process();
        }
    }
}
