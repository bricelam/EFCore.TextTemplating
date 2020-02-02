# EFCore.TextTemplating

This sample shows how to use T4 templates to generate code when reverse engineering a model from a database using EF Core.

The templates in this repo are merely a starting point. Feel free to tweak them to your heart's content. I know the resulting code is a little ubly, but I refrained from adding formatting code to keep the templates as simple as possible. I tried to generate the code I would want to use. I'm a minimalist, so only the parts of the model that actually affect EF Core behavior are scaffolded. Much of the database schema is ignored including sequences, constraint names, non-uniqe indexes, etc.

(TODO: Explain key parts and how to reuse it in another project)

## API Reference

In addition to all the usual [T4 goodness](https://docs.microsoft.com/visualstudio/modeling/code-generation-and-t4-text-templates), the following helpers are also available.

### Code

Helps generate C# code.

Method | Description
--- | ---
Fragment | Generates code from fragments returned by the `ProviderCode` or `AnnotationCode` helpers
Identifier | Generates a valid identifier unique within the given scope
Lambda | Generates a property access lambda (like `x => x.Property` or `x => new { x.Property1, x.Property2 }`)
Literal | Generates a literal for given value
Namespace | Generates a valid namespace from its given parts
Reference | Generates a C# reference to the given type
UnknownLiteral | Generates a literal for a value whose type isn't known at compile time

### ProviderCode

Helps generate provider-specific code.

Method | Description
--- | ---
GenerateUseProvide | Generates the DbContextOptions code to configure the provider (like `.UseSqlServer("Data Source=...")`)

### AnnotationCode

Helps generate provider-specific fluent API for model annotations.

Method | Description
--- | ---
IsHandledByConvention | Gets a value indicating whether the annotation would be handled by convention. If so, generating code for it is unnessary.
GenerateFluentApi | Generates provider-specific fluent API for the given annotation (like `.IsClustered()`)
