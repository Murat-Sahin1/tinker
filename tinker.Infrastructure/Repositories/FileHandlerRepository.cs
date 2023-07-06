using Newtonsoft.Json;
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

            if (form.inputFiles.Length > 0) // Input file loading part 
            {

                var inputFileName = fileName.ToString();
                var file = form.inputFiles;
                var type = form.inputType.ToString();
                Console.WriteLine("In input", file);
                try
                {
                    Console.WriteLine("try");
                    extension = "." + file[0].FileName.Split(".")[file[0].FileName.Split(".").Length - 1];

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/InputFiles/" + type);
                    var directoryPath = Path.GetFullPath(filePath);

                    Console.WriteLine(directoryPath);

                    if (!Directory.Exists(directoryPath))
                    {
                        Console.WriteLine("file creatign");
                        Console.Write("File upload directory couldn't be find, creating a new one...");
                        Directory.CreateDirectory(directoryPath);
                    }

                    int i = 0;
                    foreach (var inputFile in file)
                    {
                        var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/InputFiles/" + type, i + extension);
                        i++;

                        Console.WriteLine(exactPath);

                        using (var stream = new FileStream(exactPath, FileMode.Create))
                        {
                            Console.WriteLine("stream");
                            await inputFile.CopyToAsync(stream);
                        }
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

            if (form.csvFile.Length > 0)
            {
                Console.WriteLine("inside the function");
                var file = form.csvFile;
                try
                {
                    extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/yValues/");
                    var directoryPath = Path.GetFullPath(filePath);

                    Console.WriteLine(file.Name);
                    if (!Directory.Exists(directoryPath))
                    {
                        Console.WriteLine("File upload directory couldn't be found, creating a new one...");
                        Directory.CreateDirectory(directoryPath);
                    }

                    var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + fileName.ToString() + "/yValues/" + file.FileName);

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
                throw new Exception("csv file could not be found.");
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

        public EvaluationDto GetEvaluation(string modelName)
        {
            EvaluationDto evaluation = null;
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../tinker.Infrastructure/AiModelFiles/" + modelName + "/Evaluation/InitialEvaluation/InitialEvaluation.json");

            if (!Directory.Exists(jsonFilePath))
            {
                using (StreamReader file = File.OpenText(jsonFilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    evaluation = (EvaluationDto)serializer.Deserialize(file, typeof(EvaluationDto));
                }
                return evaluation;
            }
            else
            {
                Console.WriteLine("Initial evaluation does not exist.");
                return evaluation;
            }
        }
    }
}
