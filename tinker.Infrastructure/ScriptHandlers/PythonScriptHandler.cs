using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Domain.Entities;

namespace tinker.Infrastructure.ScriptHandlers
{
    public class PythonScriptHandler
    {
        public static string Exec_Process(string modelName, List<string> inputNames)
        {
            var argument = $"/C python ../tinker.Infrastructure/ScriptHandlers/predict.py --model_path=../tinker.Infrastructure/AiModelfiles/{modelName}/{modelName + ".h5"} --input=../tinker.Infrastructure/ModelInputs/ImageInput/{modelName}/";
            foreach (string inputName in inputNames)
            {
                argument += inputName + "_INPUT" + ".jpeg" + " ";
            }
            Console.WriteLine(argument);

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                { 
                    FileName = "CMD.exe",
                    Arguments = argument,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false
                }
            };

            string output = "";
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                output = proc.StandardOutput.ReadToEnd();

                Console.WriteLine($"{output}");
            }

            return output;
        }
    }
}
