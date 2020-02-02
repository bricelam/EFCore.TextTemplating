using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Design
{
    static class CSharpHelperExtensions
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
