using Microsoft.EntityFrameworkCore.Design;

namespace Microsoft.EntityFrameworkCore.Scaffolding
{
    static class ProviderConfigurationCodeGeneratorExtensions
    {
        /// <summary>
        /// Generates a code fragment like .UseSqlServer("Database=Foo") which can be used in
        /// <see cref="DbContext.OnConfiguring(DbContextOptionsBuilder)"/> of the generated DbContext.
        /// </summary>
        /// <param name="providerCode">The provider code helper used to generate the fragment.</param>
        /// <param name="connectionString">The connection string to include in the code fragment.</param>
        /// <returns>The code fragment.</returns>
        public static MethodCallCodeFragment GenerateUseProvider(this IProviderConfigurationCodeGenerator providerCode, string connectionString)
        {
            var useProvider = providerCode.GenerateUseProvider(
                connectionString,
                providerCode.GenerateProviderOptions());
            var contextOptions = providerCode.GenerateContextOptions();
            if (contextOptions != null)
            {
                useProvider = useProvider.Chain(contextOptions);
            }

            return useProvider;
        }
    }
}
