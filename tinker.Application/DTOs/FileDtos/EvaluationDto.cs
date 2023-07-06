using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Application.DTOs.FileDtos
{
    public class EvaluationDto
    {
        public string Accuracy { get; set; }
        public string Rmse { get; set; }
        public string Mae { get; set; }
        public string[] Precision { get; set; }
        public string[] Recall { get; set; }
        public string[] F1Score { get; set; }
    }
}
