using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Persistence
{
    public class ApplicationSettings
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, string> Token { get; set; }
    }
}
