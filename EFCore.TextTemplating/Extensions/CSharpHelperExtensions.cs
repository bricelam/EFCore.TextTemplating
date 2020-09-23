// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore.Design
{
    using Metadata;
    using System.Collections.Generic;
    using System.Linq;

    internal static class CSharpHelperExtensions
    {
        /// <summary>
        /// Generates a property accessor lambda.
        /// </summary>
        /// <param name="code">The helper used to generate the lambda.</param>
        /// <param name="properties">The properties.</param>
        /// <returns>The lambda.</returns>
        public static string Lambda(this ICSharpHelper code, IReadOnlyList<IProperty> properties)
            => code.Lambda(properties.Select(p => p.Name).ToList());
    }
}