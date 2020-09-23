namespace EFCore.TextTemplating
{
    using System;
    using Addition;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Scaffolding;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Implements the EF Core service used to generate code for a model. This class essentially just calls the T4
    /// templates.
    /// </summary>
    internal class ModelGenerator : ModelCodeGenerator
    {
        private readonly IProviderConfigurationCodeGenerator _providerConfigurationCodeGenerator;
        private readonly IAnnotationCodeGenerator _annotationCodeGenerator;
        private readonly ICSharpHelper _csharpHelper;

        public ModelGenerator(
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

            var configurationContextFolder = options.ContextName.Replace("Context", string.Empty);

            var contextGenerator = new DbContextGenerator
            {
                Session = new Dictionary<string, object>
                {
                    ["Model"] = model,
                    ["ContextNamespace"] = options.ContextNamespace,
                    ["ModelNamespace"] = options.ModelNamespace,
                    ["ContextName"] = options.ContextName,
                    ["ConnectionString"] = connectionString,
                    ["SuppressConnectionStringWarning"] = options.SuppressConnectionStringWarning,
                    ["UseDataAnnotations"] = options.UseDataAnnotations,

                    ["Code"] = _csharpHelper,
                    ["ProviderCode"] = _providerConfigurationCodeGenerator,
                    ["AnnotationCode"] = _annotationCodeGenerator,
                    ["ConfigurationContextFolder"] = configurationContextFolder,
                    ["GetEntityName"] = (Func<IEntityType, string>)GetEntityName,
                    ["GetEntityClassName"] = (Func<IEntityType, string>)GetEntityClassName,
                    ["GetEntityConfigurationName"] = (Func<IEntityType, string>)GetEntityConfigurationName,
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

            var entityPropertyInfos = new Dictionary<EntityPropertyInfo, IProperty>();

            foreach (var entityType in model.GetEntityTypes())
            {
                var entityName = GetEntityName(entityType);
                var entityClassName = GetEntityClassName(entityType);

                var entityGenerator = new EntityTypeGenerator
                {
                    Session = new Dictionary<string, object>
                    {
                        ["EntityType"] = entityType,
                        ["ModelNamespace"] = options.ModelNamespace,
                        ["UseDataAnnotations"] = options.UseDataAnnotations,

                        ["Code"] = _csharpHelper,
                        ["EntityName"] = entityName,
                        ["EntityClassName"] = entityClassName,
                        ["GetEntityName"] = (Func<IEntityType, string>)GetEntityName,
                        ["GetEntityClassName"] = (Func<IEntityType, string>)GetEntityClassName,
                    }
                };
                entityGenerator.Initialize();
                generatedCode = entityGenerator.TransformText();

                resultingFiles.AdditionalFiles.Add(
                    new ScaffoldedFile
                    {
                        Path = entityClassName + ".cs",
                        Code = generatedCode
                    });

                var entityConfigurationName = GetEntityConfigurationName(entityType);
                var configurationGenerator = new EntityTypeConfigurationGenerator
                {
                    Session = new Dictionary<string, object>
                    {
                        ["EntityType"] = entityType,
                        ["ContextNamespace"] = options.ContextNamespace,
                        ["ModelNamespace"] = options.ModelNamespace,
                        ["UseDataAnnotations"] = options.UseDataAnnotations,

                        ["Code"] = _csharpHelper,
                        ["AnnotationCode"] = _annotationCodeGenerator,
                        ["ConfigurationNamespace"] = string.Join(".", options.ModelNamespace, configurationContextFolder),
                        ["EntityName"] = entityName,
                        ["EntityClassName"] = entityClassName,
                        ["EntityConfigurationName"] = entityConfigurationName,
                    }
                };
                configurationGenerator.Initialize();
                generatedCode = configurationGenerator.TransformText();

                var configurationContextDir = Path.Combine(options.ContextDir, configurationContextFolder);
                var configurationContextDirectory = new DirectoryInfo(configurationContextDir);
                if (!configurationContextDirectory.Exists)
                {
                    configurationContextDirectory.Create();
                }

                resultingFiles.AdditionalFiles.Add(
                    new ScaffoldedFile
                    {
                        Path = Path.Combine(configurationContextDir, entityConfigurationName + ".cs"),
                        Code = generatedCode
                    });

                foreach (var property in entityType.GetProperties())
                {
                    var propertyComment = property.GetComment();
                    if (string.IsNullOrEmpty(propertyComment))
                    {
                        continue;
                    }

                    if (!EntityPropertyInfo.TryGetInfo(ref propertyComment, out var entityPropertyInfo))
                    {
                        continue;
                    }

                    entityPropertyInfos[entityPropertyInfo] = property;
                }
            }

            if (entityPropertyInfos.Any())
            {
                foreach (var entityEnumInfo in entityPropertyInfos.Select(item => (item.Key.Enum, item.Value))
                    .Where(item => item.Enum != null && !string.IsNullOrEmpty(item.Enum.Name) && item.Enum.Values?.Any() == true).Distinct())
                {
                    var enumTypeGenerator = new EntityEnumTypeGenerator
                    {
                        Session = new Dictionary<string, object>
                        {
                            ["EntityEnumInfo"] = entityEnumInfo,
                            ["ModelNamespace"] = options.ModelNamespace,

                            ["Code"] = _csharpHelper,
                        }
                    };
                    enumTypeGenerator.Initialize();
                    generatedCode = enumTypeGenerator.TransformText();

                    resultingFiles.AdditionalFiles.Add(
                        new ScaffoldedFile
                        {
                            Path = entityEnumInfo.Enum.Name + ".cs",
                            Code = generatedCode
                        });
                }
            }

            return resultingFiles;
        }

        private string GetEntityClassName(IEntityType entityType)
        {
            var entityPrefix = "Table";
            var entityName = GetEntityName(entityType, out var entityClassInfo);
            if (!string.IsNullOrEmpty(entityClassInfo?.ClassName))
            {
                return entityClassInfo.ClassName;
            }
            return entityName.StartsWith(entityPrefix) ? entityName : string.Concat(entityPrefix, entityName);
        }

        private string GetEntityName(IEntityType entityType)
        {
            return GetEntityName(entityType, out _);
        }

        private string GetEntityConfigurationName(IEntityType entityType)
        {
            return GetEntityName(entityType) + "Configuration";
        }

        private string GetEntityName(IEntityType entityType, out EntityClassInfo entityClassInfo)
        {
            var entityName = GetEntityClassInfo(entityType, out entityClassInfo) && !string.IsNullOrEmpty(entityClassInfo.Name)
                ? entityClassInfo.Name
                : entityType.Name;
            return entityName;
        }

        private bool GetEntityClassInfo(IEntityType entityType, out EntityClassInfo entityClassInfo)
        {
            var entityTypeComment = entityType.GetComment();
            if (!string.IsNullOrEmpty(entityTypeComment) && EntityClassInfo.TryGetInfo(ref entityTypeComment, out entityClassInfo))
            {
                return true;
            }

            entityClassInfo = default;
            return false;
        }
    }
}
