using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EFCore.TextTemplating
{
    /// <summary>
    /// Specifies our design-time services. Reference this class from your startup project using
    /// <see cref="DesignTimeServicesReferenceAttribute" />.
    /// </summary>
    class DesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
            => services.Replace(ServiceDescriptor.Singleton<IModelCodeGenerator, MyModelGenerator>());
    }
}
