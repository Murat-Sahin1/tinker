using System.Reflection.Metadata.Ecma335;
using tinker.Application.DTOs.FileDtos;
using tinker.Application.Interfaces.Repositories;
using tinker.Infrastructure.ScriptHandlers;

namespace tinker.Infrastructure.Repositories
{
    public class FileHandlerRepository : IFileHandlerRepository
    {
        public async Task<string> UploadFormWithFile(FileUpload form)
        {
            Guid fileName = Guid.NewGuid();
            Console.WriteLine(form);
            string extension = "";
            if (form.modelFile.Length > 0) // Model loading part
            {
                var file = form.modelFile;
                try
                {
                    extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/", fileName.ToString());

                    if (!Directory.Exists(filePath))
                    {
                        Console.Write("File upload directory couldn't be find, creating a new one...");
                        Directory.CreateDirectory(filePath);
                    }

                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/", fileName.ToString(), fileName + extension);

                    using (var stream = new FileStream(exactPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Error is occured while trying to upload model file.");
                    return ex.Message;
                }
            }
            else
            {
                throw new Exception("Model file could not be found.");
            }

            if (form.inputFile.Length > 0) // Input file loading part 
            {
                var inputFileName = fileName.ToString();
                var file = form.inputFile;
                var type = form.inputType.ToString();
                Console.WriteLine("In input");
                try
                {
                    Console.WriteLine("try");
                    extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/InputFiles/" + type);
                    var directoryPath = Path.GetFullPath(filePath);
                    
                    Console.WriteLine(directoryPath);

                    if (!Directory.Exists(directoryPath))
                    {
                        Console.WriteLine("file creatign");
                        Console.Write("File upload directory couldn't be find, creating a new one...");
                        Directory.CreateDirectory(directoryPath);
                    }

                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/InputFiles/" + type , inputFileName + extension);
                    Console.WriteLine(exactPath);

                    using (var stream = new FileStream(exactPath, FileMode.Create))
                    {
                        Console.WriteLine("stream");
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Error is occured while trying to upload input file.");
                    return ex.Message;
                }
            }
            else
            {
                throw new Exception("Input file could not be found.");
            }

            if (form.willNormalize == true)
            {

            }
            else
            {

            }

            return fileName.ToString();
        }

        public string ExecuteModel(string modelName, List<string> inputNames, string inputType)
        {
            return PythonScriptHandler.Exec_Process(modelName, inputNames, inputType);
        }
    }
}
