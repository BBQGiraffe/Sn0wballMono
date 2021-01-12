using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sn0wballEngine
{
    public class ScriptManager
    {
        public static void TestCompile(params string[] paths)
        {


            List<string> sources = new List<string>();

            var metadataReferences = new List<MetadataReference>();


            metadataReferences.Add(MetadataReference.CreateFromFile("System.Console.dll"));


            foreach (var item in paths)
            {
                if (!File.Exists(item))
                    continue;

                string code = File.ReadAllText(item);
                sources.Add(code);
            }



            var trees = new List<SyntaxTree>();
            var parseOptions = new CSharpParseOptions(LanguageVersion.Latest);


            foreach (var item in sources) //sources is just a list of strings where each entry is the contents of a script
            {
                var tree = CSharpSyntaxTree.ParseText(item, parseOptions);
                trees.Add(tree);
            }




            var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            var compilation = CSharpCompilation.Create(Guid.NewGuid().ToString().Normalize(), trees, metadataReferences, compilationOptions);
            var diagnostics = compilation.GetDiagnostics();
            foreach(var diag in diagnostics)
            {
                Console.Write(diag.ToString());
            }

            compilation.Emit("output.dll");

        }
    }
}
