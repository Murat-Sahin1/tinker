using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.DTOs.FileDtos;

namespace tinker.Application.Interfaces.Repositories
{
    public interface IFileHandlerRepository
    {
        Task<string> UploadFormWithFile(FileUpload form);
        string ExecuteModel(string modelName, List<string> inputNames, string InputType);
    }
}
