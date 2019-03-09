using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EFCore.TextTemplating.Design
{
    /// <summary>
    /// Specifies our design-time services. EF Core scans for implementations of IDesignTimeServices.
    /// </summary>
    class DesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
            => services.Replace(ServiceDescriptor.Singleton<IModelCodeGenerator, MyModelGenerator>());
    }
}
