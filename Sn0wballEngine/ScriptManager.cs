using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Audio;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis;

namespace Sn0wballEngine
{
    public class ScriptManager
    {
        static List<string> errors = new List<string>();
        static string[] scriptdefs;


        private static void LoadScriptDefs()
        {
            Debug.PrintInfo("Loading script definitions...");
            scriptdefs = File.ReadAllLines("scripts/scripts.txt");
            if(scriptdefs == null)
            {
                var error = "Failed to find scripts/scripts.txt!";
                Debug.PrintError(error);
                errors.Add(error);
                return;
            }
            foreach(var scriptdef in scriptdefs)
            {
                if (!File.Exists("scripts/" + scriptdef))
                {
                    Debug.PrintError("Failed to find script " + scriptdef + "!");
                }
                else
                {
                    Debug.PrintInfo("Found script " + scriptdef);
                }
            }
            

            
        }

        private static async Task RunScriptInternal()
        {

            LoadScriptDefs();

            string input = "";
            bool compiled = true;


            Debug.PrintInfo("Compiling game scripts...");
            foreach(var source in scriptdefs)
            {
                var file = File.ReadAllText("scripts/" + source);
                input += file;
            }

            

            try
            {
                var script = await CSharpScript.RunAsync(input, Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.AddReferences(typeof(Sn0wballEngine.Entity).Assembly));
            }
            catch(CompilationErrorException e)
            {
                
                foreach(var diag in e.Diagnostics)
                {
                    switch (diag.Severity)
                    {
                        case DiagnosticSeverity.Hidden:
                            Debug.PrintInfo(diag.ToString());
                            break;
                        case DiagnosticSeverity.Info:
                            Debug.PrintInfo(diag.ToString());
                            break;
                        case DiagnosticSeverity.Warning:
                            Debug.PrintWarning(diag.ToString());
                            break;
                        case DiagnosticSeverity.Error:
                            Debug.PrintError(diag.ToString());
                            compiled = false;
                            break;
                        default:
                            break;
                    }
                    errors.Add(diag.ToString());
                }
                
            }
            if (compiled)
            {
                Debug.PrintSuccess("Compiled game scripts");
            }
            else
            {
            }
            
            DumpLogs("log.log");
        }
        
        public static void DumpLogs(string filename)
        {
            using (FileStream fs = File.Create(filename))
            {  
                foreach (string str in errors)
                {
                    Byte[] line = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(line, 0, line.Length);
                }
                fs.Close();
            }

            
        }

        public static void RunGameScripts()
        {
            
            Thread t = new Thread(async () => await RunScriptInternal());

            t.Start();
        }
    }
}
