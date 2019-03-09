using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace EFCore.TextTemplating.Design
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

        public override ScaffoldedModel GenerateModel(
            IModel model,
            string @namespace,
            string contextDir,
            string contextName,
            string connectionString,
            ModelCodeGenerationOptions options)
        {
            var resultingFiles = new ScaffoldedModel();

            var contextGenerator = new MyDbContextGenerator
            {
                Session = new Dictionary<string, object>
                {
                    ["Model"] = model,
                    ["Namespace"] = @namespace,
                    ["ContextName"] = contextName,
                    ["ConnectionString"] = connectionString,

                    ["Code"] = _csharpHelper,
                    ["ProviderCode"] = _providerConfigurationCodeGenerator,
                    ["Annotation"] = _annotationCodeGenerator
                }
            };
            contextGenerator.Initialize();
            var generatedCode = contextGenerator.TransformText();

            var dbContextFileName = contextName + ".cs";
            resultingFiles.ContextFile = new ScaffoldedFile
            {
                Path = Path.Combine(contextDir, dbContextFileName),
                Code = generatedCode
            };

            foreach (var entityType in model.GetEntityTypes())
            {
                var entityGenerator = new MyEntityTypeGenerator
                {
                    Session = new Dictionary<string, object>
                    {
                        ["EntityType"] = entityType,
                        ["Namespace"] = @namespace,

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
                        ["Namespace"] = @namespace,

                        ["Code"] = _csharpHelper
                    }
                };
                configurationGenerator.Initialize();
                generatedCode = configurationGenerator.TransformText();

                resultingFiles.AdditionalFiles.Add(
                    new ScaffoldedFile
                    {
                        Path = Path.Combine("Configuration", entityType.Name + "Configuration.cs"),
                        Code = generatedCode
                    });
            }

            return resultingFiles;
        }
    }
}
