using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Application.DTOs.FileDtos
{
    public class FileExecute
    {
        public string FileName { get; set; }
        public List<string> InputName { get; set; }
        public string InputType { get; set; }
    }
}
