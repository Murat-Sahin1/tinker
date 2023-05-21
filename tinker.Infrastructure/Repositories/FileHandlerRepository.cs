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
            if (form.modelFile.Length > 0)
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
            } else{
                throw new Exception("Model file could not be found.");
            }

            if (form.inputFile.Length > 0) 
            {
                var inputFileName = fileName.ToString() + "_INPUT";
                var file = form.inputFile;
                var type = form.inputType.ToString();
                if (type == "Image")
                {
                    try
                    {
                        extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/ModelInputs/ImageInput/", fileName.ToString());

                        if (!Directory.Exists(filePath))
                        {
                            Console.Write("File upload directory couldn't be find, creating a new one...");
                            Directory.CreateDirectory(filePath);
                        }

                        var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/ModelInputs/ImageInput/", fileName.ToString(), inputFileName + extension);

                        using (var stream = new FileStream(exactPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Error is occured while trying to upload input file.");
                        return ex.Message;
                    }
                } else if (type == "Text")
                {
                    try
                    {
                        extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/ModelInputs/TextInput/");

                        if (!Directory.Exists(filePath))
                        {
                            Console.Write("File upload directory couldn't be find, creating a new one...");
                            Directory.CreateDirectory(filePath);
                        }

                        var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/ModelInputs/TextInput/", inputFileName + extension);

                        using (var stream = new FileStream(exactPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Error is occured while trying to upload input file.");
                        return ex.Message;
                    }
                } else
                {
                    throw new Exception("Unsupported input type.");
                }
                
            } else
            {
                throw new Exception("Input file could not be found.");
            }

            if (form.willNormalize == true) 
            {

            } else
            {

            }

            return fileName.ToString();
        }

        public string ExecuteModel(string modelName, List<string> inputNames)
        {
            return PythonScriptHandler.Exec_Process(modelName, inputNames);
        }
    }
}
