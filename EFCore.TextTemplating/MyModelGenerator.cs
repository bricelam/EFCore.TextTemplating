using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System.Collections.Generic;
using System.IO;

namespace EFCore.TextTemplating
{
    /// <summary>
    /// Implements the EF Core service used to generate code for a model. This class essentially just calls the T4
    /// templates.
    /// </summary>
    class MyModelGenerator : ModelCodeGenerator
    {
        readonly IProviderConfigurationCodeGenerator _providerConfigurationCodeGenerator;
        readonly IAnnotationCodeGenerator _annotationCodeGenerator;
        readonly ICSharpHelper _csharpHelper;

        public MyModelGenerator(
            ModelCodeGeneratorDependencies dependencies,
            IProviderConfigurationCodeGenerator providerConfigurationCodeGenerator,
            IAnnotationCodeGenerator annotationCodeGenerator,
            ICSharpHelper csharpHelper)
            : base(dependencies)
        {
            _providerConfigurationCodeGenerator = providerConfigurationCodeGenerator;
            _annotationCodeGenerator = annotationCodeGenerator;
            _csharpHelper = csharpHelper;
        }

        public override string Language => "C#";

        public override ScaffoldedModel GenerateModel(IModel model, ModelCodeGenerationOptions options)
        {
            var resultingFiles = new ScaffoldedModel();

            var connectionString = options.ConnectionString;

            // HACK: Work around dotnet/efcore#19799
            if (File.Exists(connectionString))
            {
                connectionString = "Data Source=(local);Initial Catalog=" + (string)model["Scaffolding:DatabaseName"];
            }

            var contextGenerator = new MyDbContextGenerator
            {
                Session = new Dictionary<string, object>
                {
                    ["Model"] = model,
                    ["ModelNamespace"] = options.ModelNamespace,
                    ["Namespace"] = options.ContextNamespace,
                    ["ContextName"] = options.ContextName,
                    ["ConnectionString"] = connectionString,
                    ["SuppressConnectionStringWarning"] = options.SuppressConnectionStringWarning,
                    ["UseDataAnnotations"] = options.UseDataAnnotations,

                    ["Code"] = _csharpHelper,
                    ["ProviderCode"] = _providerConfigurationCodeGenerator,
                    ["AnnotationCode"] = _annotationCodeGenerator
                }
            };
            contextGenerator.Initialize();
            var generatedCode = contextGenerator.TransformText();

            var dbContextFileName = options.ContextName + ".cs";
            resultingFiles.ContextFile = new ScaffoldedFile
            {
                Path = Path.Combine(options.ContextDir, dbContextFileName),
                Code = generatedCode
            };

            foreach (var entityType in model.GetEntityTypes())
            {
                var entityGenerator = new MyEntityTypeGenerator
                {
                    Session = new Dictionary<string, object>
                    {
                        ["EntityType"] = entityType,
                        ["Namespace"] = options.ModelNamespace,
                        ["UseDataAnnotations"] = options.UseDataAnnotations,

                        ["Code"] = _csharpHelper
                    }
                };
                entityGenerator.Initialize();
                generatedCode = entityGenerator.TransformText();

                resultingFiles.AdditionalFiles.Add(
                    new ScaffoldedFile
                    {
                        Path = entityType.Name + ".cs",
                        Code = generatedCode
                    });

                var configurationGenerator = new MyEntityTypeConfigurationGenerator
                {
                    Session = new Dictionary<string, object>
                    {
                        ["EntityType"] = entityType,
                        ["ModelNamespace"] = options.ModelNamespace,
                        ["Namespace"] = options.ContextNamespace,
                        ["UseDataAnnotations"] = options.UseDataAnnotations,

                        ["Code"] = _csharpHelper,
                        ["AnnotationCode"] = _annotationCodeGenerator
                    }
                };
                configurationGenerator.Initialize();
                generatedCode = configurationGenerator.TransformText();

                resultingFiles.AdditionalFiles.Add(
                    new ScaffoldedFile
                    {
                        Path = Path.Combine(options.ContextDir, entityType.Name + "Configuration.cs"),
                        Code = generatedCode
                    });
            }

            return resultingFiles;
        }
    }
}
