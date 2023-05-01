using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinker.Infrastructure.ScriptHandlers
{
    public class PythonScriptHandler
    {
        public static string Exec_Process()
        {
            convertNotebookIntoPy();

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                { 
                    FileName = "CMD.exe",
                    Arguments = "/C ipython C:/Users/Voul/tinker/tinker/tinker.Infrastructure/AiModelFiles/TF2_Linear_Regression.py",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false
                }
            };

            while (!System.IO.File.Exists("C:/Users/Voul/tinker/tinker/tinker.Infrastructure/AiModelFiles/TF2_Linear_Regression.py"))
            {
                Console.WriteLine("Converting the notebook into a py file...");
                System.Threading.Thread.Sleep(1000);
            }
            string line = "";
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                line = proc.StandardOutput.ReadToEnd();

                Console.WriteLine($"{line}");
            }

            return line;
        }

        private async static void convertNotebookIntoPy()
        {
            //Converting ipynb into py
            string convertingCommand = "/C jupyter nbconvert C:/Users/Voul/tinker/tinker/tinker.Infrastructure/AiModelFiles/TF2_Linear_Regression --to python";
            System.Diagnostics.Process.Start("CMD.exe", convertingCommand);
        }
    }
}
