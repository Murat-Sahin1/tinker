using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Infrastructure
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
