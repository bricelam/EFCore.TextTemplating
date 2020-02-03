# EFCore.TextTemplating

This sample shows how to use T4 templates to scaffold code when reverse engineering a model from a database using EF Core.

This repo contains three projects:

Project | Description
--- | ---
ChinookApp | An example app containing the scaffolded DbContext type, configuration, and entity types
ChinookDatabase | The database project for our example app
EFCore.TextTemplating | Contains the T4 templates and required plumbing to hook them into EF Core.<br />**Copy into your solution to get started**

ChinookApp references EFCore.TextTemplating and contains an assembly-level attribute that EF Core uses to discover its design-time services. **Your app needs to do this too:**

```cs
[assembly: DesignTimeServicesReference(
    "EFCore.TextTemplating.DesignTimeServices, EFCore.TextTemplating")]
```

ChinookApp also references the EF Core tools and [my pluralizer extension](https://github.com/bricelam/EFCore.Pluralizer) to enhance the scaffolded code.

EFCore.TextTemplating contains three templates: one for scaffolding the DbContext, one for the IEntityTypeConfiguration implementations, and one for the entity types.

The templates in this repo are merely a starting point. Feel free to tweak them to your heart's content. The resulting code is a little ugly, but I refrained from adding formatting code to keep the templates as simple as possible. I scaffold the code I would want to use, so only the parts of the model that actually affect EF Core behavior are scaffolded. Things like sequences, constraint names, and non-unique indexes are ignored.

⚠ **Warning!** Staring directly at a T4 template without syntax highlighting may hurt your eyes. I recommend using the [Devart T4 Editor](https://marketplace.visualstudio.com/items?itemName=DevartSoftware.DevartT4EditorforVisualStudio) for Visual Studio or [T4 Support by Zachary Becknell](https://marketplace.visualstudio.com/items?itemName=zbecknell.t4-support) for VS Code.

If you're using Visual Studio, merely saving the template files is enough.

If you're using VS Code, you'll need to use [dotnet-t4](https://github.com/mono/t4) after editing the files:

```sh
dotnet tool install -g dotnet-t4
t4 MyDbContextGenerator.tt -c MyDbContextGenerator -o MyDbContextGenerator.cs
```

Reverse engineering the model can be done in [the normal way](https://docs.microsoft.com/ef/core/managing-schemas/scaffolding):

```sh
dotnet ef dbcontext scaffold \
    "Data Source=(localdb)\ProjectsV13;Initial Catalog=ChinookDatabase" \
    Microsoft.EntityFrameworkCore.SqlServer \
    --output-dir Models \
    --context-dir Data \
    --force
```
or
```ps1
Scaffold-DbContext `
    "Data Source=(localdb)\ProjectsV13;Initial Catalog=ChinookDatabase" `
    Microsoft.EntityFrameworkCore.SqlServer `
    -OutputDir Models `
    -ContextDir Data `
    -Force
```

## API Reference

In addition to [all the usual T4 goodness](https://docs.microsoft.com/visualstudio/modeling/code-generation-and-t4-text-templates), the following helpers are also available.

Method | Description
--- | ---
AnnotationCode.IsHandledByConvention | Gets a value indicating whether the annotation would be handled by convention. If so, generating code is unnecessary
AnnotationCode.GenerateFluentApi | Generates provider-specific fluent API for the given annotation (like `.IsClustered()`)
Code.Fragment | Generates code from fragments returned by the `ProviderCode` and `AnnotationCode` helpers
Code.Identifier | Generates a valid identifier unique within the given scope
Code.Lambda | Generates a property access lambda
Code.Literal | Generates a literal for given value
Code.Namespace | Generates a valid namespace from its given parts
Code.Reference | Generates a C# reference to the given type
Code.UnknownLiteral | Generates a literal for a value whose type isn't known at compile time
ProviderCode.GenerateUseProvide | Generates the DbContextOptions code to configure the provider (like `.UseSqlServer("Data Source=...")`)

For example:

**Input**
```tt
builder.HasKey(<#= Code.Lambda(primaryKey.Properties) #>);
```

**Output**
```cs
builder.HasKey(x => x.Id);
```
