using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

[Generator]
public class MyGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // Opcional: pode ser usado para registrar callbacks adicionais
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Código para gerar fonte
        string source = @"
        namespace GeneratedCode
        {
            public static class HelloWorld
            {
                public static void SayHello()
                {
                    System.Console.WriteLine(""Hello from generated code!"");
                }
            }
        }";

        context.AddSource("helloWorldGenerator", SourceText.From(source, Encoding.UTF8));
    }
}